public class PetService : IPetService
{
    private readonly List<Pet> _pet = new();

    public IEnumerable<Pet> GetAll() => _pet;
    public Pet? GetById(int id) =>
        _pet.FirstOrDefault(l => l.Id == id);

    public Pet Add(Pet pet)
    {
        pet.Id = _pet.Count + 1;
        _pet.Add(pet);
        return pet;
    }

    public bool Delete(int id)
    {
        var pet = GetById(id);
        if (pet is null)
            return false;
        return _pet.Remove(pet);
    }   
}