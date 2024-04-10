using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class BuyerTakeCarButton : BuyerButtonHandler
{
    public event Action OnClickTakeCar;

    public override void OnPointerDown(PointerEventData eventData)
    {
        OnClickTakeCar?.Invoke();
        base.OnPointerDown(eventData);
    }
}