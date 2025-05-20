public interface ITutorService
{
    IEnumerable<Tutor> GetAll();
    Tutor? GetById(int id);
    Tutor Add(Tutor tutor);
    bool Delete(int id);
}