using UnityEngine;
using UnityEngine.AI;

public class Buyer : MonoBehaviour
{
    [SerializeField] private BuyerBuyCarButton _carBuyButton;
    [SerializeField] private BuyerTakeKeysButton _takeKeysButton;
    [SerializeField] private BuyerTakeCarButton _takeCarButton;

    private Salesman _salesMan;
    private Cashier _cashier;
    private CarReleaser _carReleaser;
    private NavMeshAgent _agent;

    private RectTransform _canvas;

    public bool BoughtCar { get; private set; }
    public bool TookKeys { get; private set; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _salesMan = FindObjectOfType<Salesman>();
        _cashier = FindObjectOfType<Cashier>();
        _carReleaser = FindObjectOfType<CarReleaser>();
        _canvas = GetComponentInChildren<RectTransform>();

        _carBuyButton.OnClickBuyCar += TakeKeys;
        _takeKeysButton.OnClickTakeKeys += TakeCar;
        _takeCarButton.OnClickTakeCar += ResetCharacter;
    }

    private void Update()
    {
        if (!_salesMan.IsBusy && !BoughtCar)
        {
            BuyCar();
        }
    }

    private void LateUpdate()
    {
        _canvas.transform.LookAt(-Camera.main.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Salesman>() != null && !BoughtCar)
        {
            _carBuyButton.gameObject.SetActive(true);
        }
        if (other.GetComponent<Cashier>() != null && !TookKeys)
        {
            _takeKeysButton.gameObject.SetActive(true);
        }
        if (other.GetComponent<CarReleaser>() != null)
        {
            _takeCarButton.gameObject.SetActive(true);
        }
    }

    private void BuyCar()
    {
        _agent.SetDestination(_salesMan.transform.position);
    }
    private void TakeKeys()
    {
        BoughtCar = true;
        _salesMan.CarSold = true;
        _agent.SetDestination(_cashier.transform.position);
    }
    private void TakeCar()
    {
        _agent.SetDestination(_carReleaser.transform.position);
    }
    private void ResetCharacter()
    {
        gameObject.SetActive(false);
        BoughtCar = false;
    }
}