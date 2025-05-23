using BibliotecaApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly IPetRepository _petIRepo;

    public PetController(IPetRepository petIRepo)
    {
        _petIRepo = petIRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> Get() =>
        Ok(await _petIRepo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetByid(int id)
    {
        var pet = await _petIRepo.GetByIdAsync(id);
        return pet is null ? NotFound() : Ok(pet);
    }

    [HttpPost]
    public async Task<ActionResult<Pet>> Post(Pet pet)
    {
        var novoPet = await _petIRepo.AddAsync(pet);
        return CreatedAtAction(nameof(GetByid), new { id = novoPet.Id }, novoPet);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var pet = await _petIRepo.DeleteAsync(id);
        return pet ? NoContent() : NotFound();
    }
}