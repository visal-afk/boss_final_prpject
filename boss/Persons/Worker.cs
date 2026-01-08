namespace boss.Persons;
using boss.CV;

public class Worker : person
{
    new public Cv cv;
    public Worker(int id, string name, string surname, string Seher, int Yas, int nomre, Cv cv)
        : base(id, name, surname, Seher, Yas, nomre)
    {
        this.cv = cv;
    }
}

