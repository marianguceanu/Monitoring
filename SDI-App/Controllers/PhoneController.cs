using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SDI_App.DTO.PersonDTOs;
using SDI_App.DTO.PhoneDTOs;
using SDI_App.Errors;
using SDI_App.Models;
using SDI_App.Repository.Interfaces;

namespace SDI_App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhoneController : ControllerBase
{
    private readonly IMapper _mapper;
    private IPhoneRepository _repo;
    private IPersonRepository _personRepo;
    private IAccessedWebsiteRepository _awRepo;

    public PhoneController(IPhoneRepository repo, IPersonRepository personRepo, IAccessedWebsiteRepository accessedWebsiteRepo, IMapper mapper)
    {
        _mapper = mapper;
        _repo = repo;
        _personRepo = personRepo;
        _awRepo = accessedWebsiteRepo;
    }

    [HttpGet("get/all")]
    public async Task<IActionResult> GetAllPhones()
    {
        var phones = await _repo.GetAll();
        if (phones == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<IList<PhoneDTO>>(phones));
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetPhoneById(int id)
    {
        var phone = await _repo.GetById(id);
        if (phone == null) throw new PhoneDoesNotExistException(id);

        var PhoneToShow = _mapper.Map<PhoneDTO>(phone);
        PhoneToShow.Person = _mapper.Map<PersonInClass>(await _personRepo.GetById(phone.PersonId));

        return Ok(PhoneToShow);
    }

    [HttpPost("add")]
    public async Task<IActionResult> PostPhone(AddPhoneDTO addPhoneDTO)
    {
        var phoneExists = await _repo.PhoneExists(addPhoneDTO.ModelNumber);
        if (phoneExists) throw new PhoneExistsAlreadyException(addPhoneDTO.ModelNumber);

        var newPhone = _mapper.Map<Phone>(addPhoneDTO);
        await _repo.Add(newPhone);

        return Created(nameof(GetPhoneById), _mapper.Map<PhoneDTO>(newPhone));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhone(int id)
    {
        var PhoneToDelete = await _repo.GetById(id);
        if (PhoneToDelete == null) throw new PhoneDoesNotExistException(id);

        await _repo.Delete(PhoneToDelete);
        await _repo.SaveChanges();

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePhone([FromRoute] int id, [FromBody] EditPhoneDTO editPhoneDto)
    {
        var phone = await _repo.GetById(id);
        if (phone == null) return BadRequest();

        phone = _mapper.Map<EditPhoneDTO, Phone>(editPhoneDto, phone);
        await _repo.Update(phone);
        if (await _repo.SaveChanges()) return Ok(phone);
        throw new PhoneDoesNotExistException(id);
    }

    [HttpGet("screen_bigger_than/{ScreenSize}")]
    public async Task<IActionResult> GetPhonesWithScreenBiggerThan([FromRoute] int ScreenSize)
    {
        if (ScreenSize < 0) throw new InvalidScreenSize(ScreenSize);

        var phones = await _repo.GetAll();
        if (phones == null) throw new InvalidScreenSize(0);

        var NewPhones = phones.Where(p => p.ScreenSize > ScreenSize).ToList();
        return Ok(_mapper.Map<IList<PhoneDTO>>(NewPhones));
    }
}