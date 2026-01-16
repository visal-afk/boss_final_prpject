using boss.CV;
using boss.Exceptions;
using boss.Service.Abstract;

namespace boss.Service;

public class VacansiService : BaseService, IVacansiService
{
    public VacansiService(BossDb bossDb) : base(bossDb)
    {
    }

    public void Add(Vacansi item)
    {
        
        item.Id = _bossDb.Vacancies.Select(v => v.Id).DefaultIfEmpty(0).Max() + 1;

        if (_bossDb.Vacancies.Any(v => v.Id == item.Id))
            throw new IdCheckException("ID təyini zamanı gözlənilməz təkrar xətası!");

        _bossDb.Vacancies.Add(item);
        _bossDb.SaveChanges();
    }

    public void Delete(int id)
    {
        var vacancy = _bossDb.Vacancies.FirstOrDefault(v => v.Id == id);
        if (vacancy != null)
        {
            _bossDb.Vacancies.Remove(vacancy);
            _bossDb.SaveChanges();
        }
        else
        {
            throw new NotFoundException("Belə bir vakansiya mövcud deyil!");
        }
    }

    public List<Vacansi> GetAll()
    {
        return _bossDb.Vacancies;
    }

    public Vacansi GetById(int id)
    {
        var vacancy = _bossDb.Vacancies.FirstOrDefault(v => v.Id == id);
        if (vacancy != null)
        {
            return vacancy;
        }
        else
        {
            throw new NotFoundException("Axtarılan vakansiya tapılmadı!");
        }
    }

    public void Update(int id, Vacansi item)
    {
        var existingVacancy = _bossDb.Vacancies.FirstOrDefault(v => v.Id == id);

        if (existingVacancy != null)
        {
            
            existingVacancy.Title = item.Title;
            existingVacancy.Description = item.Description;
            existingVacancy.Salary = item.Salary;
            existingVacancy.Category = item.Category;

            _bossDb.SaveChanges();
        }
        else
        {
            throw new NotFoundException("Yenilənmək istənən vakansiya tapılmadı!");
        }
    }
}