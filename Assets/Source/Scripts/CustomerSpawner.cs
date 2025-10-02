public class CustomerSpawner : TSpawner<Customer>
{
    protected override void Awake()
    {
        _objectPool = new ObjectPool<Customer>(_prefab, _startCount);
    }
}
