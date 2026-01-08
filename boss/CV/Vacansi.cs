namespace boss.CV;

public class Vacansi
{
    public string Title { get; set; }
    public string Description { get; set; } 
    public double Salary { get; set; } 
    public string Category { get; set; } 
    public Vacansi(string title, string description, double salary, string category)
    {
        Title = title;
        Description = description;
        Salary = salary;
        Category = category;
    }
}
