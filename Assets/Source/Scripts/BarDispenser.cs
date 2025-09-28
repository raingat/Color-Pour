using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarDispenser : MonoBehaviour
{
    [SerializeField] private LiquidSpawner _liquidSpawner;

    [SerializeField] private Transform _exitPoint;

    [SerializeField] private Container[] _containers;

    [SerializeField] private Valve _valve;

    [SerializeField] private int _startCount;

    private List<Liquid> _liquids;

    private void Awake()
    {
        _liquids = new List<Liquid>();
    }

    private void OnEnable()
    {
        _valve.Pressed += TryDischargeLiquid;
    }

    private void Start()
    {
        CreateStartCountLiquid();
    }

    private void OnDisable()
    {
        _valve.Pressed -= TryDischargeLiquid;
    }

    private void TryDischargeLiquid()
    {
        if (_liquids.Count > 0)
        {
            Liquid liquid = _liquids.FirstOrDefault();

            foreach (Container container in _containers)
            {
                if (container.IsEmpty == false)
                {
                    _liquids.Remove(liquid);

                    container.Fill(liquid);

                    MoveLiquid();

                    CreateLiquid();

                    break;
                }
            }
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

    private void CreateLiquid()
    {
        Liquid newLiquid = _liquidSpawner.Spawn();

        Liquid lastLiquid = _liquids.LastOrDefault();

        newLiquid.transform.position = lastLiquid.transform.position - lastLiquid.Height * Vector3.up;

        _liquids.Add(newLiquid);
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
