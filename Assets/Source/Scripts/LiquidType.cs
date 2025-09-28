using UnityEngine;

[CreateAssetMenu(menuName = "Create new type of liquid", fileName = "LiquidType", order = 51)]
public class LiquidType : ScriptableObject
{
    [SerializeField] private float _height;

    public float Height => _height;
}
