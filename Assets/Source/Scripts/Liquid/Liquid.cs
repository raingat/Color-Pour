using UnityEngine;

public class Liquid : PoolObject<Liquid>
{
    [SerializeField] private LiquidType _type;

    public float Height => _type.Height;
}
