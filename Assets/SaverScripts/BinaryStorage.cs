using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public sealed class BinaryStorage : IStorage, IDeletable, IExistable
{
    private BinaryFormatter _formatter;

    public BinaryStorage()
    {
        _formatter = new BinaryFormatter();
    }

    public void Delete(string path)
    {
        if (Exists(path))
        {
            File.Delete(path);
        }
    }

    public T Load<T>(string path, T loadObject)
    {
        if (Exists(path))
        {
            using (FileStream file = File.Open(path, FileMode.Open))
            {
                loadObject = (T)_formatter.Deserialize(file);
            }
        }

        return loadObject;
    }
    public bool Exists(string path)
    {
        return File.Exists(path);
    }
    public void Save<T>(string path, T saveObject)
    {
        using (var file = File.Create(path))
        {
            _formatter.Serialize(file, saveObject);
        }
    }
}
