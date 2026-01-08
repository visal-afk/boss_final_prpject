namespace boss.Persons;
using boss.CV;

public class Employer: person
{
    public List<Vacansi> Vacancies = new List<Vacansi>();
    public Employer(int id, string name, string surname, string Seher, int Yas, int nomre)
        : base(id, name, surname, Seher, Yas, nomre)
    {
        this.Vacancies = new List<Vacansi>();
    }

}
