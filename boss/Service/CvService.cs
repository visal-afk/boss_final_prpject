using boss.CV;
using boss.Exceptions;
using boss.Service;
using boss.Service.Abstract;

public class CvService : BaseService, ICvService
{
    public CvService(BossDb bossDb) : base(bossDb) { }

    public void Add(Cv item)
    {

    item.id = _bossDb.AllCvs.Select(c => c.id).DefaultIfEmpty(0).Max() + 1;

    var idCheck = _bossDb.AllCvs.Any(c => c.id == item.id);
        if (idCheck)
        {
            throw new IdCheckException("Bu Id-li CV artıq mövcuddur!");
        }

        _bossDb.AllCvs.Add(item);
        _bossDb.SaveChanges();
    }

    public void Delete(int id)
    {
        var cv = _bossDb.AllCvs.FirstOrDefault(c => c.id == id);
        if (cv != null)
        {
            _bossDb.AllCvs.Remove(cv);
            _bossDb.SaveChanges();
        }
        else
        {
            throw new NotFoundException("Belə bir CV mövcud deyil!");
        }
    }

    public List<Cv> GetAll() => _bossDb.AllCvs;

    public Cv GetById(int id)
    {
        var cv = _bossDb.AllCvs.FirstOrDefault(c => c.id == id);
        if (cv == null) throw new NotFoundException("CV tapılmadı!");
        return cv;
    }

    public void Update(int id, Cv item)
    {
        var existingCv = _bossDb.AllCvs.FirstOrDefault(c => c.id == id);
        if (existingCv != null)
        {
            existingCv.ixtisas = item.ixtisas;
            existingCv.mekteb = item.mekteb;
            _bossDb.SaveChanges();
        }
        else
        {
            throw new NotFoundException("Yenilənmək istənən CV mövcud deyil!");
        }
    }
}