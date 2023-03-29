using WebApplication10.Models;


namespace WebApplication12.NewFolder
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAllPets();

        Pet GetPet(Guid id);

        void AddPet(Pet pet);

        void DeletePet(Guid id);

    }
}
