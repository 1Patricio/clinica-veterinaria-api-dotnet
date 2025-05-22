using BibliotecaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;
    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pet>> GetAllAsync() =>
        await _context.Pet.Include(l => l.Nome).ToListAsync();
    
        public async Task<Pet?> GetByIdAsync(int id) =>
        await _context.Pet.Include(l => l.Nome)
            .FirstOrDefaultAsync(l => l.Id == id);

    public async Task<Pet> AddAsync(Pet pet)
    {
        _context.Pet.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task UpdateAsync(Pet pet)
    {
        _context.Pet.Update(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pet = await GetByIdAsync(id);
        if (pet is null) return false;
        _context.Pet.Remove(pet);
        await _context.SaveChangesAsync();
        return true;
    }
}