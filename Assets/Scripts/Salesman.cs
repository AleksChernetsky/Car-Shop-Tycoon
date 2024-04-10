using System;

using UnityEngine;

public class Salesman : MonoBehaviour
{
    private TradePlatform _tradePlatform;
    private BoxCollider _collider;
    public bool IsBusy { get; private set; }
    public bool CarSold = false;

    private void Start()
    {
        _tradePlatform = GetComponentInParent<TradePlatform>();
        _collider = GetComponent<BoxCollider>();
        IsBusy = true;

        _tradePlatform.OnReadyToTrade += CheckCarOnPlatform;
    }

    private void OnTriggerEnter(Collider other)
    {
        IsBusy = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Buyer>() != null && CarSold)
        {
            _tradePlatform.SellCar();
            _collider.isTrigger = false;
            CarSold = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IsBusy = false;
        _collider.isTrigger = true;
    }
    private void CheckCarOnPlatform() => IsBusy = false;
}
