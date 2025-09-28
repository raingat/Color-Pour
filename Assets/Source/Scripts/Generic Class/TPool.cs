using System.Collections.Generic;
using UnityEngine;

public abstract class TPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T[] _prefabs;

    private Queue<T> _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public T Get()
    {
        if (_pool.Count == 0)
            Expend();

        T instance = _pool.Dequeue();
        instance.gameObject.SetActive(true);

        return instance;
    }

    public void Return(T instance)
    {
        instance.gameObject.SetActive(false);
        _pool.Enqueue(instance);
    }

    private void Expend()
    {
        T instance = Instantiate(SelectRandomPrefab());

        _pool.Enqueue(instance);
    }

    private T SelectRandomPrefab()
    {
        int randomIndex = Random.Range(0, _prefabs.Length);

        return _prefabs[randomIndex];
    }
}
