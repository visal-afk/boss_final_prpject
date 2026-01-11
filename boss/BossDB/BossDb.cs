using boss.CV;      
using boss.Persons; 
using boss.Presistence.Concrete; 


public class BossDb
{
    public List<Worker> Workers { get; set; } = new List<Worker>();
    public List<Employer> Employers { get; set; } = new List<Employer>();
    public List<Vacansi> Vacancies { get; set; } = new List<Vacansi>();
    public List<Cv> AllCvs { get; set; } = new List<Cv>();

    private readonly JsonRepository<Worker> _workerRepo;
    private readonly JsonRepository<Employer> _employerRepo;
    private readonly JsonRepository<Vacansi> _vacancyRepo;
    private readonly JsonRepository<Cv> _cvRepo;

    public BossDb()
    {
        
        _workerRepo = new JsonRepository<Worker>("workers.json");
        _employerRepo = new JsonRepository<Employer>("employers.json");
        _vacancyRepo = new JsonRepository<Vacansi>("vacancies.json");
        _cvRepo = new JsonRepository<Cv>("cvs.json");

        
        
        Workers = _workerRepo.LoadData() ?? new List<Worker>();
        Employers = _employerRepo.LoadData() ?? new List<Employer>();
        Vacancies = _vacancyRepo.LoadData() ?? new List<Vacansi>();
        AllCvs = _cvRepo.LoadData() ?? new List<Cv>();
    }

   
    public void SaveChanges()
    {
        _workerRepo.SaveData(Workers);
        _employerRepo.SaveData(Employers);
        _vacancyRepo.SaveData(Vacancies);
        _cvRepo.SaveData(AllCvs);
    }
}