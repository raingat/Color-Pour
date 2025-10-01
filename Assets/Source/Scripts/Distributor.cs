using System.Collections.Generic;
using UnityEngine;

public class Distributor : MonoBehaviour
{
    [SerializeField] private int _maxNumberLiquid;

    private List<Liquid> _liquids;

    private int CurrentLiquidNumber => _liquids.Count;

    private void Awake()
    {
        _liquids = new List<Liquid>();
    }

    public void ObtainLiquid(Liquid liquid)
    {
        if (CurrentLiquidNumber < _maxNumberLiquid)
        {
            liquid.transform.position = transform.position;

            liquid.transform.SetParent(transform);

            _liquids.Add(liquid);
        }
    }
}
