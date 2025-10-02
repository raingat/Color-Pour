using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : IPool<T> where T : MonoBehaviour, IPoolable<T>
{
    private Action<T> _pullObject;
    private Action<T> _pushObject;

    private Queue<T> _pool = new Queue<T>();

    private Factory<T> _factory;

    public ObjectPool(T _prefab, int count)
    {
        _factory = new Factory<T>(_prefab);

        Spawn(count);
    }

    public ObjectPool(T _prefab, Action<T> pullObject, Action<T> pushObject, int count)
    {
        _factory = new Factory<T>(_prefab);
        _pullObject = pullObject;
        _pushObject = pushObject;

        Spawn(count);
    }

    public int PooledObject => _pool.Count;

    public T Pull()
    {
        if (_pool.Count < 0)
            Spawn();

        T instance = _pool.Dequeue();

        instance.gameObject.SetActive(true);
        instance.Initialize(Push);

        _pullObject?.Invoke(instance);

        return instance;
    }

    public void Push(T instance)
    {
        _pushObject?.Invoke(instance);

        _pool.Enqueue(instance);

        instance.gameObject.SetActive(false);
    }

    private void Spawn()
    {
        T instance = _factory.Create();
        _pool.Enqueue(instance);
        instance.gameObject.SetActive(false);
    }

    private void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }
}
