using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SDI_App.DTO.AwDTOs;
using SDI_App.DTO.PhoneDTOs;
using SDI_App.DTO.TableDTOs;
using SDI_App.Errors;
using SDI_App.Repository.Interfaces;
using SDI_App.Models;

namespace SDI_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessedWebsiteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IPhoneRepository _phoneRepo;
        private ITabletRepository _tabletRepo;
        private IPersonRepository _personRepo;
        private IAccessedWebsiteRepository _repo;
        public AccessedWebsiteController(IAccessedWebsiteRepository repo, IMapper mapper, IPhoneRepository phoneRepo, ITabletRepository tabletRepo, IPersonRepository personRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _phoneRepo = phoneRepo;
            _tabletRepo = tabletRepo;
            _personRepo = personRepo;
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAllAccessedWebsites()
        {
            var AccessedWebsites = await _repo.GetAll();
            if (AccessedWebsites == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IList<AwShortDTO>>(AccessedWebsites));
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAccessedWebsiteById(int id)
        {
            var AccessedWebsite = await _repo.GetById(id);
            if (AccessedWebsite == null) throw new AwDoesNotExistException(id);

            var ShowAW = _mapper.Map<AwDTO>(AccessedWebsite);

            var Phone = await _phoneRepo.GetById(AccessedWebsite.PhoneId);
            var Tablet = await _tabletRepo.GetById(AccessedWebsite.TabletId);

            ShowAW.Phone = _mapper.Map<PhoneInClass>(Phone);
            ShowAW.Tablet = _mapper.Map<TabletInClass>(Tablet);
            return Ok(ShowAW);
        }

        [HttpPost("add")]
        public async Task<IActionResult> PostAccessedWebsite(AddAwDTO addAwDTO)
        {
            var AccessedWebsiteExists = await _repo.AccessedWebsiteExists(addAwDTO.Url);
            if (AccessedWebsiteExists) throw new AwExistsAlreadyException(addAwDTO.Url);

            var ToAddAW = _mapper.Map<AccessedWebsite>(addAwDTO);
            await _repo.Add(ToAddAW);

            return Ok(_mapper.Map<AwShortDTO>(ToAddAW));
        }

        [HttpPut("add/toWebsite{id:int}/tablet{tabletId:int}")]
        public async Task<IActionResult> AddTabletToAccessedWebsite([FromRoute] int id, [FromRoute] int tabletId)
        {
            var AccessedWebsite = await _repo.GetById(id);
            if (AccessedWebsite == null) throw new AwDoesNotExistException(id);

            var Tablet = await _tabletRepo.GetById(tabletId);
            if (Tablet == null) throw new TabletDoesNotExistException(tabletId);

            AccessedWebsite.TabletId = tabletId;
            await _repo.Update(AccessedWebsite);

            return Ok(_mapper.Map<AwShortDTO>(AccessedWebsite));
        }

        [HttpPut("add/toWebsite{id:int}/phone{phoneId:int}")]
        public async Task<IActionResult> AddPhoneToAccessedWebsite([FromRoute] int id, [FromRoute] int phoneId)
        {
            var AccessedWebsite = await _repo.GetById(id);
            if (AccessedWebsite == null) throw new AwDoesNotExistException(id);

            var Phone = await _phoneRepo.GetById(phoneId);
            if (Phone == null) throw new PhoneDoesNotExistException(phoneId);

            AccessedWebsite.PhoneId = phoneId;
            await _repo.Update(AccessedWebsite);

            return Ok(_mapper.Map<AwShortDTO>(AccessedWebsite));
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateAccessedWebsite([FromRoute] int id, [FromBody] AwShortDTO updateAwDTO)
        {
            var AccessedWebsite = await _repo.GetById(id);
            if (AccessedWebsite == null) throw new AwDoesNotExistException(id);

            _mapper.Map(updateAwDTO, AccessedWebsite);
            await _repo.Update(AccessedWebsite);

            return Ok(_mapper.Map<AwShortDTO>(AccessedWebsite));
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteAccessedWebsite([FromRoute] int id)
        {
            var AccessedWebsite = await _repo.GetById(id);
            if (AccessedWebsite == null) throw new AwDoesNotExistException(id);

            await _repo.Delete(AccessedWebsite);

            return Ok();
        }
    }
}