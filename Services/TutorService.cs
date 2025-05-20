public class TutorService : ITutorService
{
    private readonly List<Tutor> _tutor = new();

    public IEnumerable<Tutor> GetAll() => _tutor;
    public Tutor? GetById(int id) =>
        _tutor.FirstOrDefault(l => l.Id == id);

    public Tutor Add(Tutor tutor)
    {
        tutor.Id = _tutor.Count + 1;
        _tutor.Add(tutor);
        return tutor;
    }
    public bool Delete(int id)
    {
        var tutor = GetById(id);
        if (tutor is null)
            return false;
        return _tutor.Remove(tutor);
    }   
}