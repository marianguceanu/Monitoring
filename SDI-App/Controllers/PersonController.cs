using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SDI_App.DTO.PersonDTOs;
using SDI_App.DTO.PhoneDTOs;
using SDI_App.DTO.TableDTOs;
using SDI_App.Errors;
using SDI_App.Models;
using SDI_App.Repository.Interfaces;


// TODO - Make DTOs for posting, adding so on

namespace SDI_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repo;
        private readonly ITabletRepository _tabletRepo;
        private readonly IPhoneRepository _phoneRepo;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository repo, IMapper mapper, ITabletRepository tabletRepo, IPhoneRepository phoneRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _tabletRepo = tabletRepo;
            _phoneRepo = phoneRepo;
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAllPersons()
        {
            var persons = await _repo.GetAll();
            if (persons == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IList<PersonInClass>>(persons));
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await _repo.GetById(id);
            if (person == null) throw new PersonDoesNotExistException(id);

            var p = _mapper.Map<PersonDTO>(person);
            var t = await _tabletRepo.GetById(person.TabletId);
            p.Tablet = _mapper.Map<TabletInClass>(t);

            return Ok(p);
        }


        [HttpPost("add")]
        public async Task<IActionResult> PostPerson([FromBody] AddPersonDTO addPersonDTO)
        {
            var PersonExists = await _repo.GetPersonByCNP(addPersonDTO.CNP) != null;
            if (PersonExists) throw new PersonExistsAlreadyException(addPersonDTO.CNP);

            var newPerson = _mapper.Map<Person>(addPersonDTO);
            await _repo.Add(newPerson);

            return Created(nameof(GetPersonById), _mapper.Map<PersonInClass>(newPerson));

        }

        [HttpPut("add/toPerson{pid:int}/Tablet{tid:int}")]
        public async Task<IActionResult> AddTabletToPerson([FromRoute] int pid, [FromRoute] int tid)
        {
            var Person = await _repo.GetById(pid);
            if (Person == null) throw new PersonDoesNotExistException(pid);

            var Tablet = await _tabletRepo.GetById(tid);
            if (Tablet == null) throw new TabletDoesNotExistException(tid);

            Person.TabletId = Tablet.Id;
            await _repo.Update(Person);

            Tablet.PersonId = pid;
            await _tabletRepo.Update(Tablet);

            PersonDTO ShowPerson = _mapper.Map<PersonDTO>(await _repo.GetById(pid));
            ShowPerson.Tablet = _mapper.Map<TabletInClass>(Tablet);

            return Ok(ShowPerson);
        }

        [HttpPut("add/toPerson{pid:int}/Phone{id:int}")]
        public async Task<IActionResult> AddPhoneToPerson([FromRoute] int pid, [FromRoute] int id)
        {
            var Person = await _repo.GetById(pid);
            if (Person == null) throw new PersonDoesNotExistException(pid);

            var Phone = await _phoneRepo.GetById(id);
            if (Phone == null) throw new PhoneDoesNotExistException(id);

            Phone.PersonId = pid;
            await _phoneRepo.Update(Phone);

            var PhoneToShow = _mapper.Map<PhoneDTO>(await _phoneRepo.GetById(id));
            PhoneToShow.Person = _mapper.Map<PersonInClass>(await _repo.GetById(pid));

            return Ok(PhoneToShow);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var personToDelete = await _repo.GetById(id);
            if (personToDelete == null) throw new PersonDoesNotExistException(id);

            await _repo.Delete(personToDelete);
            await _repo.SaveChanges();

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePerson(int id, EditPersonDTO updatePersonDTO)
        {
            var personToUpdate = await _repo.GetById(id);
            if (personToUpdate == null) throw new PersonDoesNotExistException(id);

            personToUpdate = _mapper.Map(updatePersonDTO, personToUpdate);

            await _repo.Update(personToUpdate);
            await _repo.SaveChanges();
            return Ok(_mapper.Map<PersonDTO>(personToUpdate));
        }

        [HttpGet("get/PersonsWithMostSoldTablets")]
        public async Task<IActionResult> GetPersonsWithMostSoldTablets()
        {
            IList<PersonDTO> Persons = new List<PersonDTO>();
            var persons = await _repo.GetAll();
            if (persons == null)
            {
                return NotFound();
            }
            foreach (var p in persons)
            {
                PersonDTO person = _mapper.Map<PersonDTO>(p);
                var t = await _tabletRepo.GetById(p.TabletId);
                person.Tablet = _mapper.Map<TabletInClass>(t);
                Persons.Add(person);
            }
            return Ok(Persons.OrderBy(p => p.Tablet != null ? p.Tablet.UnitsSold : 0).Reverse().Take(3));
        }

    }
}