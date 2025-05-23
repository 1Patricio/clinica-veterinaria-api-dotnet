namespace BibliotecaApi.Repositories.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> AddAsync(Pet pet);
    Task UpdateAsync(Pet pet);
    Task<bool> DeleteAsync(int id);
    Task<Pet?> PutAsync(int id, Pet pet);
}