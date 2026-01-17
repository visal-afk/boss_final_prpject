namespace boss.Persons;
using boss.CV;

public class Worker : person
{
    public Cv cv { get; set; }
    public Worker() : base() { }
    public Worker(int id, string name, string surname, string Seher, int Yas, int nomre, string username, string password, Cv cv)
        : base(id, name, surname, Seher, Yas, nomre, username, password) 
    {
        this.cv = cv;
    }
}

