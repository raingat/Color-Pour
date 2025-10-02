using UnityEngine;

public class Factory<T> : IFactory<T> where T : MonoBehaviour, IPoolable<T>
{
    private T _prefab;

    public Factory(T prefab)
    {
        _prefab = prefab;
    }

    public T Create()
    {
        return Object.Instantiate(_prefab).GetComponent<T>();
    }
}
