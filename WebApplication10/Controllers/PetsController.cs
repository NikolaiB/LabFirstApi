using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using WebApplication10.Data;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : Controller
    {
        // GET: PetsController
        private readonly ApiPetContext _context;
        public PetsController(ApiPetContext context)
        {
            _context = context;

        }
       
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _context.Pets.ToList();
        }

        [HttpPost]
        public IEnumerable<Pet> Post(AddPetViewModel viewModel)
        {
            var pet = new Pet()
            {
                PetId = Guid.NewGuid(),
                PetName = viewModel.PetName,
                PetWeight = viewModel.PetWeight,
                PetType = viewModel.PetType,

            };
            _context.Pets.Add(pet);
            _context.SaveChanges(); 

            return _context.Pets.ToList();
        }

        [HttpPut]
        [Route("{petid:guid}")]
        public IActionResult Put([FromRoute] Guid petid, AddPetViewModel viewModel)
        {
            var pet = _context.Pets.Find(petid);
            if (pet != null)
            {
                pet.PetName = viewModel.PetName;
                pet.PetWeight = viewModel.PetWeight;
                pet.PetType = viewModel.PetType;

                _context.SaveChanges();
                return Ok(_context.Pets.ToList());

            }
            return NotFound();
        }

        [HttpGet]
        [Route("{petid:guid}")]
        public IActionResult GetPet([FromRoute] Guid petid)
        {
            var pet = _context.Pets.Find(petid);
            if (pet != null)
            {
               
                return Ok(pet);
                 
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{petid:guid}")]
        public IActionResult Delete([FromRoute] Guid petid)
        {
            var pet = _context.Pets.Find(petid);

            if (pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();

                return Ok(_context.Pets.ToList());

            }
            return NotFound();
        }

    }
}
