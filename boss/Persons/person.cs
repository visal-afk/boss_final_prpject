namespace boss.Persons;

public abstract class person
{
    public int id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string Seher { get; set; }
    public int Yas { get; set; }
    public int nomre { get; set; }

    public person(int id, string name, string surname, string Seher, int Yas, int nomre)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.Seher = Seher;
        this.Yas = Yas;
        this.nomre = nomre;
    }
   
}
