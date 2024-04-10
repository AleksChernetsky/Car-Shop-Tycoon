using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class BuyerTakeKeysButton : BuyerButtonHandler
{
    public event Action OnClickTakeKeys;

    public override void OnPointerDown(PointerEventData eventData)
    {
        OnClickTakeKeys?.Invoke();
        base.OnPointerDown(eventData);
    }
}