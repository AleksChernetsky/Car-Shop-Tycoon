using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : ServiceStaffHandler
{
    [SerializeField] private CashierButton _takeKeysButton;

    public override void OnTriggerEnter(Collider other)
    {
        _takeKeysButton.OnClickEvent += GiveKeys;
        _takeKeysButton.gameObject.SetActive(true);
        base.OnTriggerEnter(other);
    }
    private void GiveKeys()
    {
        _buyer.TookKeys = true;
    }
}
