namespace boss.Presistence.Abstract;

public interface IJsonRepository<T>
{
    void SaveData(List<T> items);
    List<T> LoadData();

}
