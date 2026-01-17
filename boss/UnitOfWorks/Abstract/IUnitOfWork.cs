using boss.Service.Abstract;

namespace boss.UnitOfWork.Abstract;

public interface IUnitOfWorks
{
    IVacansiService VacansiService { get; }
    ICvService CvService { get; }
    IAuthService AuthService { get; } 
    void Save();
}
