using WebApplication10.Data;
using WebApplication10.Models;

namespace WebApplication12.NewFolder
{
    public class PetService : IPetService
    {
        private readonly ApiPetContext _context;

        public PetService(ApiPetContext context)
        {
            _context = context;
        }

        public PetService()
        {

        }
        public void AddPet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void DeletePet(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetAllPets()
        {
            throw new NotImplementedException();
        }

        public Pet GetPet(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
