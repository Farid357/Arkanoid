using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectsPool<T> where T : MonoBehaviour
{
    private readonly List<T> _objects = new();
    private int _count;

    public void Add(int count, T prefab, Vector3 position = new(), Quaternion quaternion = new(), Transform parent = null)
    {
        if (!_objects.Contains(prefab) && prefab != null)
        {
            _count = count;
            for (int i = 0; i < count; i++)
            {
                var createObject = Object.Instantiate(prefab, position, quaternion, parent);
                createObject.gameObject.SetActive(false);
                _objects.Add(createObject);
            }
        }
    }

    private int GetIndex()
    {
        for (int i = 0; i < _objects.Count - 1; i++)
        {
            if (!_objects[i].gameObject.activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
    public T Get(T prefab)
    {
        if (HaveObjects(_objects))
        {
            int index = GetIndex();
            return _objects[index];
        }
        else
        {
            Add(_count, prefab);
            return _objects[GetIndex()];
        }
    }

    private bool HaveObjects(List<T> objects)
    {
        for (int i = 0; i < objects.Count - 1; i++)
        {
            if (!objects[i].gameObject.activeInHierarchy)
                return true;
        }
        return false;
    }
}