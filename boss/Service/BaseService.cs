namespace boss.Service;
public abstract class BaseService
{
    protected static BossDb _bossDb;
    public BaseService(BossDb bossDb)
    {
        _bossDb = bossDb;
    }
}
