using UnityEngine;

public abstract class TSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private TPool<T> _pool;

    public T Spawn()
    {
        T instance = _pool.Get();

        HandleObject(instance);

        return instance;
    }

    protected virtual void ReturnToPool(T instance)
    {
        _pool.Return(instance);
    }

    protected virtual void HandleObject(T instance)
    {
    }
}
