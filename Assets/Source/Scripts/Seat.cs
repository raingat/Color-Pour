using UnityEngine;

public class Seat : MonoBehaviour
{
    private Customer _customer;

    public bool IsOccupy => _customer != null;

    public void Occupy(Customer customer)
    {
        _customer = customer;
    }
}