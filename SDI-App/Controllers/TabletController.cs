using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SDI_App.DTO.PersonDTOs;
using SDI_App.DTO.TableDTOs;
using SDI_App.Errors;
using SDI_App.Models;
using SDI_App.Repository.Interfaces;

namespace SDI_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TabletController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ITabletRepository _repo;
        private IPersonRepository _personRepo;
        private IAccessedWebsiteRepository _awRepo;

        public TabletController(ITabletRepository repo, IMapper mapper, IAccessedWebsiteRepository accessedWebsiteRepo, IPersonRepository personRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _personRepo = personRepo;
            _awRepo = accessedWebsiteRepo;
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAllTablets()
        {
            var Tablets = await _repo.GetAll();
            if (Tablets == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IList<TabletDTO>>(Tablets));
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetTabletById(int id)
        {
            var Tablet = await _repo.GetById(id);
            if (Tablet == null) throw new TabletDoesNotExistException(id);

            var p = await _personRepo.GetById(Tablet.PersonId);
            var t = _mapper.Map<TabletDTO>(Tablet);
            t.Person = _mapper.Map<PersonInClass>(p);

            return Ok(t);
        }

        [HttpPost("add")]
        public async Task<IActionResult> PostTablet(AddTabletDTO addTabletDTO)
        {
            var TabletExists = await _repo.TabletExists(addTabletDTO.UnitsSold);
            if (TabletExists) throw new TabletExistsAlreadyException(addTabletDTO.UnitsSold);

            var newTablet = _mapper.Map<Tablet>(addTabletDTO);
            await _repo.Add(newTablet);

            var personToUpdate = await _personRepo.GetById(addTabletDTO.PersonId);
            if (personToUpdate == null) throw new PersonDoesNotExistException(addTabletDTO.PersonId);

            var addedTablet = await _repo.GetTabletByUnitsSold(addTabletDTO.UnitsSold);
            if (addedTablet != null) personToUpdate.TabletId = addedTablet.Id;
            await _personRepo.Update(personToUpdate);

            return Created(nameof(GetTabletById), _mapper.Map<TabletInClass>(newTablet));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTablet(int id)
        {
            var TabletToDelete = await _repo.GetById(id);
            if (TabletToDelete == null) throw new TabletDoesNotExistException(id);

            await _repo.Delete(TabletToDelete);
            await _repo.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTablet([FromRoute] int id, [FromBody] EditTabletDTO editTabletDto)
        {
            var Tablet = await _repo.GetById(id);
            if (Tablet == null) return BadRequest();

            Tablet = _mapper.Map<EditTabletDTO, Tablet>(editTabletDto, Tablet);
            await _repo.Update(Tablet);
            if (await _repo.SaveChanges()) return Ok(Tablet);
            throw new TabletDoesNotExistException(id);
        }

        [HttpGet("persons_tablets_with_pen/")]
        public async Task<IActionResult> GetPersonsTabletsWithPen()
        {
            IList<Person> PersonsWithTabletsWithPen = new List<Person>();
            foreach (var tablet in await _repo.GetAll())
            {
                if (tablet.HasPen)
                {
                    var person = await _personRepo.GetById(tablet.PersonId);
                    if (person != null) PersonsWithTabletsWithPen.Add(person);
                }
            }

            return Ok(_mapper.Map<IList<PersonDTO>>(PersonsWithTabletsWithPen));
        }
    }
}