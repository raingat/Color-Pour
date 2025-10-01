using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Distributor : MonoBehaviour
{
    [SerializeField] private int _maxNumberLiquid;

    [SerializeField] private CustomerController _customerController;

    private List<Liquid> _liquids;
    private List<Customer> _customers;

    private int CurrentLiquidNumber => _liquids.Count;

    private void Awake()
    {
        _liquids = new List<Liquid>();
        _customers = new List<Customer>();
    }

    private void OnEnable()
    {
        _customerController.CustomerCreated += OnCustomerHandle;
    }

    private void Update()
    {
        foreach (Customer customer in _customers)
        {
            if (_liquids.Count > 0)
            {
                if (customer.IsGetting == false)
                {
                    Liquid liquid = _liquids.FirstOrDefault();

                    _liquids.Remove(liquid);

                    customer.SetLiquid(liquid);

                    break;
                }
            }
        }
    }

    private void OnDisable()
    {
        _customerController.CustomerCreated -= OnCustomerHandle;
    }

    private void OnCustomerHandle(Customer customer)
    {
        _customers.Add(customer);

        Debug.Log("ADD!");
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
