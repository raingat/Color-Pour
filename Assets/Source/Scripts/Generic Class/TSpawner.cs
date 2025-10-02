using UnityEngine;

public abstract class TSpawner<T> : MonoBehaviour where T : PoolObject<T>
{
    [SerializeField] protected T _prefab;

    [SerializeField] protected int _startCount;

    protected ObjectPool<T> _objectPool;

    protected abstract void Awake();

    public T Spawn()
    {
        T instance = _objectPool.Pull();

        HandleObject(instance);

        return instance;
    }

    protected virtual void HandleObject(T instance)
    {
    }
}
