using UnityEngine;

public abstract class ServiceStaffHandler : MonoBehaviour
{
    protected Buyer _buyer;

    [field: SerializeField] public bool IsBusy { get; protected set; }

    public virtual void OnTriggerEnter(Collider other)
    {
        IsBusy = true;
        if (other.TryGetComponent(out Buyer buyer))
        {
            _buyer = buyer;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        IsBusy = false;
        _buyer.IsOnSpot = false;
        _buyer = null;
    }
}
