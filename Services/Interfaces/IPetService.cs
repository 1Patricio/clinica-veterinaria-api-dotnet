public interface IPetService
{
    IEnumerable<Pet> GetAll();
    Pet Add(Pet pet);
    Pet? GetById(int id);
    bool Delete(int id);
}