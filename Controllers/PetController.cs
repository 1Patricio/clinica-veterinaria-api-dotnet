using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase{
    private readonly IPetService _petService;

    public PetController(IPetService petService){
        _petService = petService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pet>> Get() =>
        Ok(_petService.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Pet>GetById(int id){
        var pet = _petService.GetById(id);
        return pet is null ? NotFound() : Ok(pet);
    }

    [HttpPost]
    public ActionResult<Pet> Post(Pet pet){
        var novoPet = _petService.Add(pet);
        return CreatedAtAction(nameof(GetById), new {id = novoPet.Id}, novoPet);
    }
}