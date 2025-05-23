using BibliotecaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;
    public TutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync() =>
        await _context.Tutor.ToListAsync();

    public async Task<Tutor?> GetByIdAsync(int id) =>
    await _context.Tutor
        .FirstOrDefaultAsync(l => l.Id == id);

    public async Task<Tutor> AddAsync(Tutor tutor)
    {
        _context.Tutor.Add(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task UpdateAsync(Tutor tutor)
    {
        _context.Tutor.Update(tutor);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tutor = await GetByIdAsync(id);
        if (tutor is null) return false;
        _context.Tutor.Remove(tutor);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<Tutor?> PutAsync(int id, Tutor tutor)
    {
        var update = await _context.Tutor.FindAsync(id);
        if (update == null)
            return null;

        update.Nome = tutor.Nome;
        update.Telefone = tutor.Telefone;
        update.Email = tutor.Email;

        await _context.SaveChangesAsync();
        return update;
    }
}