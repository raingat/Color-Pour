using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarDispenser : MonoBehaviour
{
    [SerializeField] private LiquidSpawner _liquidSpawner;

    [SerializeField] private Transform _exitPoint;

    [SerializeField] private int _startCount;

    private DispenserPump _pump;

    private Queue<Liquid> _liquids;

    public bool IsEmpty => _liquids.Count <= 0;

    private void Awake()
    {
        _pump = new DispenserPump();
        _liquids = new Queue<Liquid>();
    }

    private void Start()
    {
        FillFully();
    }

    public Liquid DischargeLiquid()
    {
        Liquid liquid = _liquids.Dequeue();

        _pump.MoveObject(_liquids.ToList(), _exitPoint.position);

        Liquid newLiquid = _liquidSpawner.Spawn();

        HandleLiquid(newLiquid);

        return liquid;
    }

    private void HandleLiquid(Liquid liquid)
    {
        Liquid lastLiquid = _liquids.LastOrDefault();

        liquid.transform.position = lastLiquid.transform.position - lastLiquid.Height * Vector3.up;

        _liquids.Enqueue(liquid);
    }

    private void FillFully()
    {
        Liquid lastLiquid = null;

        for (int i = 0; i < _startCount; i++)
        {
            Liquid liquid = _liquidSpawner.Spawn();

            if (i == 0)
            {
                liquid.transform.position = _exitPoint.position;
            }
            else
            {
                lastLiquid = _liquids.LastOrDefault();

                liquid.transform.position = lastLiquid.transform.position - lastLiquid.Height * Vector3.up;
            }

            _liquids.Enqueue(liquid);
        }
    }
}
