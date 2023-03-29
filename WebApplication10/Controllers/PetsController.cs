using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using WebApplication10.Data;
using WebApplication10.Models;
using WebApplication12.NewFolder;

namespace WebApplication10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : Controller
    {
        // GET: PetsController
        private readonly IPetService _service;

        public PetsController(IPetService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _service.GetAllPets();
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
            _service.AddPet(pet);


            return _service.GetAllPets();
        }

        [HttpPut]
        [Route("{petid:guid}")]
        public IActionResult Put([FromRoute] Guid petid, AddPetViewModel viewModel)
        {
            var pet = _service.GetPet(petid);
            if (pet != null)
            {
                pet.PetName = viewModel.PetName;
                pet.PetWeight = viewModel.PetWeight;
                pet.PetType = viewModel.PetType;

                
                return Ok(_service.GetAllPets());

            }
            return NotFound();
        }

        [HttpGet]
        [Route("{petid:guid}")]
        public IActionResult GetPet([FromRoute] Guid petid)
        {
            var pet = _service.GetPet(petid);
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
            var pet = _service.GetPet(petid);

            if (pet != null)
            {
                _service.DeletePet(petid);

                return Ok(_service.GetAllPets());

            }
            return NotFound();
        }

    }
}
