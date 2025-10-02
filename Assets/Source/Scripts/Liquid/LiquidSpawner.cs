public class LiquidSpawner : TSpawner<Liquid>
{
    protected override void Awake()
    {
        _objectPool = new ObjectPool<Liquid>(_prefab, _startCount);
    }
}
