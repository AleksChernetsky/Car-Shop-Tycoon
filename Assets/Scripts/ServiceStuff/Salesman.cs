using UnityEngine;

public class Salesman : ServiceStaffHandler
{
    [SerializeField] private SalesmanButton _salesmanButton;
    private TradePlatform _tradePlatform;

    private void Start()
    {
        _tradePlatform = GetComponentInParent<TradePlatform>();
        IsBusy = true;

        _salesmanButton.OnClickEvent += Sell;
        _tradePlatform.OnReadyToTrade += CheckCarOnPlatform;
    }

    public override void OnTriggerEnter(Collider other)
    {
        _salesmanButton.gameObject.SetActive(true);
        base.OnTriggerEnter(other);
        _buyer.IsOnSpot = true;
    }

    private void CheckCarOnPlatform() => IsBusy = false;
    private void Sell()
    {
        _tradePlatform.SellCar();
        _buyer.BoughtCar = true;
        _buyer.BoughtCarPrefab = _tradePlatform.ActiveCarType();
    }
}
