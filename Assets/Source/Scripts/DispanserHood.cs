using UnityEngine;

public class DispanserHood : MonoBehaviour
{
    [SerializeField] private Valve _valve;
    [SerializeField] private BarDispenser _barDispenser;
    [SerializeField] private Container[] _containers;

    private void OnEnable()
    {
        _valve.Pressed += TryDischargeLiquid;
    }

    private void OnDisable()
    {
        _valve.Pressed -= TryDischargeLiquid;
    }

    private void TryDischargeLiquid()
    {
        if (_barDispenser.IsEmpty)
            return;

        foreach (Container container in _containers)
        {
            if (container.IsEmpty == false)
            {
                Liquid liquid = _barDispenser.DischargeLiquid();

                container.Fill(liquid);

                break;
            }
        }
    }
}
