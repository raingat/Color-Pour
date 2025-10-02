using System;
using UnityEngine;

public abstract class PoolObject<T> : MonoBehaviour, IPoolable<T> where T : PoolObject<T>
{
    private Action<T> _returnToPool;

    public void Initialize(Action<T> returnAction)
    {
        _returnToPool = returnAction;
    }

    public void ReturnToPool()
    {
        _returnToPool?.Invoke((T)this);
    }
}
