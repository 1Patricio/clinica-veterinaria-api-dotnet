namespace BibliotecaApi.Repositories.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<Tutor?> GetByIdAsync(int id);
    Task<Tutor> AddAsync(Tutor tutor);
    Task UpdateAsync(Tutor tutor);
    Task<bool> DeleteAsync(int id);
    Task<Tutor?> PutAsync(int id, Tutor tutor);
}