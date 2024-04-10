using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformButtonHandler : MonoBehaviour, IPointerDownHandler
{
    private string _template;
    private TradePlatform _tradePlatform;
    private TextMeshProUGUI _costText;

    private int clickCount;

    private void Awake()
    {
        _tradePlatform = GetComponentInParent<TradePlatform>();
        _costText = GetComponentInChildren<TextMeshProUGUI>();

        _template = "${0}";
        _costText.text = string.Format(_template, _tradePlatform.PlatformCost);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (clickCount)
        {
            case 0:
                BuyPlatform();
                break;
            case 1:
                BuyCar();
                break;
            case 2:
                UpgradeCar();
                break;
            case 3:
                DestroyObject();
                break;
        }
    }

    private void BuyPlatform()
    {
        if (_tradePlatform.BuyPlatform())
        {
            _costText.text = string.Format(_template, _tradePlatform.CarCost);
            clickCount++;
        }
    }

    private void BuyCar()
    {
        if (_tradePlatform.BuyCar())
        {
            _costText.text = string.Format(_template, _tradePlatform.CarUpgradeCost);
            clickCount++;
        }
    }

    private void UpgradeCar()
    {
        if (_tradePlatform.UpgradeCar())
        {
            _costText.text = string.Format(_template, _tradePlatform.CarUpgradeCost);
            clickCount++;
        }
    }

    private void DestroyObject()
    {
        if (_tradePlatform.UpgradeCar())
        {
            Destroy(gameObject);
        }
    }
}