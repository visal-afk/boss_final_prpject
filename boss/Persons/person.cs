namespace boss.Persons;

public abstract class person
{
    public int id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string Seher { get; set; }
    public int Yas { get; set; }
    public int nomre { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public person() { }
    public person(int id, string name, string surname, string Seher, int Yas, int nomre, string username, string password)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.Seher = Seher;
        this.Yas = Yas;
        this.nomre = nomre;
        this.Username = username; 
        this.Password = password;
    }

}
