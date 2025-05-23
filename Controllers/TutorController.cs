using BibliotecaApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TutorController : ControllerBase
{
    private readonly ITutorRepository _ITutorRepo;

    public TutorController(ITutorRepository ITutorRepo)
    {
        _ITutorRepo = ITutorRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> Get() =>
        Ok(await _ITutorRepo.GetAllAsync());
    [HttpGet("{id}")]
    public async Task<ActionResult<Tutor>> GetByid(int id)
    {
        var tutor = await _ITutorRepo.GetByIdAsync(id);
        return tutor is null ? NotFound() : Ok(tutor);
    }

    [HttpPost]
    public async Task<ActionResult<Tutor>> Post(Tutor tutor)
    {
        var novoTutor = await _ITutorRepo.AddAsync(tutor);
        return CreatedAtAction(nameof(GetByid), new { id = novoTutor.Id }, novoTutor);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var pet = await _ITutorRepo.DeleteAsync(id);
        return pet ? NoContent() : NotFound();
    }
}