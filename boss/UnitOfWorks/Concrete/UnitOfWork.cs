using boss.Service;
using boss.Service.Abstract;
using boss.Service.Concrets;
using boss.UnitOfWork.Abstract;

namespace boss.UnitOfWork.Concrets;

public class UnitOfWork : IUnitOfWorks
{
    private readonly BossDb _bossDb;
    public IVacansiService VacansiService { get; private set; }
    public ICvService CvService { get; private set; }
    public IAuthService AuthService { get; private set; }

    public UnitOfWork(BossDb bossDb)
    {
        _bossDb = bossDb;

        
        VacansiService = new VacansiService(_bossDb);
        CvService = new CvService(_bossDb);
        AuthService = new AuthService(_bossDb);
    }

    public void Save()
    {
        
        _bossDb.SaveChanges();
    }
}