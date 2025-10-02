public class Customer : PoolObject<Customer>
{
    private Liquid _liquid;

    public bool IsGetting => _liquid != null;

    private void Update()
    {
        if (_liquid != null)
            Destroy(gameObject, 5.0f);
    }

    public void SetLiquid(Liquid liquid)
    {
        _liquid = liquid;

        _liquid.transform.position = transform.position;

        _liquid.transform.SetParent(transform);
    }
}
