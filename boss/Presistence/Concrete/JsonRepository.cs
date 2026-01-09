namespace boss.Presistence.Concrete;
using boss.Presistence.Abstract;
using System.Text.Json;
public class JsonRepository<T>:IJsonRepository<T>
{
    private readonly string _filePath;
    public JsonRepository(string filePath)
    {
        _filePath = filePath;
    }
    public List<T> LoadData()
    {
        if (!File.Exists(_filePath))
            return new List<T>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    public void SaveData(List<T> items)
    {
        var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}
