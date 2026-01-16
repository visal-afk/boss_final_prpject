using boss.Persons; 

public interface IAuthService
{
    
    void RegisterWorker(Worker worker);
    void RegisterEmployer(Employer employer);

    Worker LoginWorker(string username, string password);
    Employer LoginEmployer(string username, string password);
}