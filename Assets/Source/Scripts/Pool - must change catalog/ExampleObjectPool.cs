using System;
using UnityEngine;

public class ExampleObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    [SerializeField] private int _count;

    private ObjectPool<PoolObject> _objectPool;

    private void Awake()
    {
        _objectPool = new ObjectPool<PoolObject>(_prefab, OnPull, OnPush, _count);
    }

    public void Spawn()
    {
        PoolObject poolObject = _objectPool.Pull();
    }

    private void OnPull(PoolObject poolObject)
    {
        throw new NotImplementedException();
    }

    private void OnPush(PoolObject poolObject)
    {
        throw new NotImplementedException();
    }
}
