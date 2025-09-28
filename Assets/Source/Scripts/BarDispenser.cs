using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarDispenser : MonoBehaviour
{
    [SerializeField] private LiquidSpawner _liquidSpawner;

    [SerializeField] private Transform _exitPoint;

    [SerializeField] private Valve[] _valves;

    [SerializeField] private int _startCount;

    private List<Liquid> _liquids;

    private void Awake()
    {
        _liquids = new List<Liquid>();
    }

    private void OnEnable()
    {
        foreach (Valve valve in _valves)
        {
            valve.Pressed += TryDischargeLiquid;
        }
    }

    private void Start()
    {
        CreateStartCountLiquid();
    }

    private void OnDisable()
    {
        foreach (Valve valve in _valves)
        {
            valve.Pressed -= TryDischargeLiquid;
        }
    }

    private void TryDischargeLiquid()
    {
        if (_liquids.Count > 0)
        {
            Liquid liquid = _liquids.FirstOrDefault();

            _liquids.Remove(liquid);

            Destroy(liquid.gameObject);

            MoveLiquid();
        }
    }

    private void MoveLiquid()
    {
        for (int i = 0; i < _liquids.Count; i++)
        {
            Liquid liquid = _liquids[i];

            if (i == 0)
            {
                liquid.transform.position = _exitPoint.position;
            }
            else
            {
                int previousInstance = i - 1;

                liquid.transform.position = _liquids[previousInstance].transform.position - _liquids[previousInstance].Height * Vector3.up;
            }
        }
    }

    private void CreateStartCountLiquid()
    {
        for (int i = 0; i < _startCount; i++)
        {
            Liquid liquid = _liquidSpawner.Spawn();

            _liquids.Add(liquid);

            if (i == 0)
            {
                liquid.transform.position = _exitPoint.position;
            }
            else
            {
                int previousInstance = i - 1;

                liquid.transform.position = _liquids[previousInstance].transform.position - _liquids[previousInstance].Height * Vector3.up;
            }
        }
    }
}
