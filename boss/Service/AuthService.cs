using boss.Exceptions;
using boss.Persons;
using boss.Service.Abstract;

namespace boss.Service.Concrets;

public class AuthService : BaseService, IAuthService
{
    public AuthService(BossDb bossDb) : base(bossDb) { }

    
    public Worker LoginWorker(string username, string password)
    {
        var worker = _bossDb.Workers.FirstOrDefault(w => w.Username == username && w.Password == password);

        if (worker == null)
            throw new NotFoundException("Giriş uğursuzdur: Belə bir işçi tapılmadı.");

        return worker;
    }

    
    public Employer LoginEmployer(string username, string password)
    {
        var employer = _bossDb.Employers.FirstOrDefault(e => e.Username == username && e.Password == password);

        if (employer == null)
            throw new NotFoundException("Giriş uğursuzdur: Belə bir işəgötürən tapılmadı.");

        return employer;
    }

    
    public void RegisterWorker(Worker worker)
    {
       
        if (_bossDb.Workers.Any(w => w.Username == worker.Username))
            throw new IdCheckException("Bu istifadəçi adı artıq işçi tərəfindən götürülüb.");

        
        worker.id = _bossDb.Workers.Select(w => w.id).DefaultIfEmpty(0).Max() + 1;

        _bossDb.Workers.Add(worker);
        _bossDb.SaveChanges();
    }

    
    public void RegisterEmployer(Employer employer)
    {
        if (_bossDb.Employers.Any(e => e.Username == employer.Username))
            throw new IdCheckException("Bu istifadəçi adı artıq işəgötürən tərəfindən götürülüb.");

        employer.id = _bossDb.Employers.Select(e => e.id).DefaultIfEmpty(0).Max() + 1;

        _bossDb.Employers.Add(employer);
        _bossDb.SaveChanges();
    }
}