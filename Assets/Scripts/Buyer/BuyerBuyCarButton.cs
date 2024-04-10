using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class BuyerBuyCarButton : BuyerButtonHandler
{
    public event Action OnClickBuyCar;

    public override void OnPointerDown(PointerEventData eventData)
    {
        OnClickBuyCar?.Invoke();
        base.OnPointerDown(eventData);
    }
}
