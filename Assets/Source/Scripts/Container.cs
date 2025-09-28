using UnityEngine;

public class Container : MonoBehaviour
{
    private Liquid _liquid;

    private bool _isEmpty = false;

    public bool IsEmpty => _isEmpty;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_liquid == null)
                return;

            Liquid liquid = _liquid;

            _liquid = null;

            Destroy(liquid.gameObject);

            _isEmpty = false;
        }
    }

    public void Fill(Liquid liquid)
    {
        _isEmpty = true;
        _liquid = liquid;

        _liquid.transform.position = transform.position;
    }
}
