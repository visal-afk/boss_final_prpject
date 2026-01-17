namespace boss.Persons;
using boss.CV;

public class Employer : person
{
    public List<Vacansi> Vacancies = new List<Vacansi>();
    public Employer() : base() { }
    public Employer(int id, string name, string surname, string Seher, int Yas, int nomre, string username, string password)
        : base(id, name, surname, Seher, Yas, nomre, username, password)
    {
        this.Vacancies = new List<Vacansi>();
    }
}