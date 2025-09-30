using UnityEngine;

public class Liquid : MonoBehaviour
{
    [SerializeField] private LiquidType _type;

    public float Height => _type.Height;
}
