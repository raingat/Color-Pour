using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    [SerializeField] private CustomerSpawner _spawner;

    [SerializeField] private int _startCount;

    [SerializeField] private List<Seat> _freeSeats;

    private List<Customer> _customers;

    public event Action<Customer> CustomerCreated;

    private void Awake()
    {
        _customers = new List<Customer>();

        Invoke(nameof(CreateCustomer), 10.0f);
    }

    private void CreateCustomer()
    {
        for (int i = 0; i < _startCount; i++)
        {
            Customer customer = _spawner.Spawn();

            _customers.Add(customer);

            Seat seat = null;

            for (int j = 0; j < _freeSeats.Count; j++)
            {
                if (_freeSeats[j].IsOccupy == false)
                {
                    seat = _freeSeats[j];
                }
            }

            seat.Occupy(customer);

            customer.transform.position = seat.transform.position;

            CustomerCreated?.Invoke(customer);
        }
    }
}
