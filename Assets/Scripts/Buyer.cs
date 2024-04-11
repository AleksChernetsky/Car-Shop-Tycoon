using UnityEngine;
using UnityEngine.AI;

public class Buyer : MonoBehaviour
{
    private Salesman[] _salesMans;
    private Cashier _cashier;
    private CarReleaser _carReleaser;
    private NavMeshAgent _agent;

    private Vector3 _startPosition;
    public int _randomSalesman;

    public GameObject BoughtCarPrefab { get; set; }
    [field: SerializeField] public bool BoughtCar { get; set; }
    [field: SerializeField] public bool TookKeys { get; set; }
    [field: SerializeField] public bool TookCar { get; set; }
    [field: SerializeField] public bool IsOnSpot { get; set; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _salesMans = FindObjectsOfType<Salesman>();
        _cashier = FindObjectOfType<Cashier>();
        _carReleaser = FindObjectOfType<CarReleaser>();

        _startPosition = transform.position;
        _randomSalesman = Random.Range(0, _salesMans.Length);
    }

    private void Update()
    {
        if (!BoughtCar)
        {
            ChooseFreeSalesman();
        }
        if (BoughtCar && !TookKeys)
        {
            TakeKeys();
        }
        if (TookKeys)
        {
            TakeCar();
        }
    }
    private void ChooseFreeSalesman()
    {
        if (!_salesMans[_randomSalesman].IsBusy && !IsOnSpot)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_salesMans[_randomSalesman].transform.position);
        }
        else
        {
            for (int i = 0; i < _salesMans.Length; i++)
            {
                if (!_salesMans[i].IsBusy)
                {
                    _randomSalesman = i;
                }
                else
                {
                    _agent.isStopped = true;
                }
            }
        }
    }
    private void TakeKeys()
    {        
        if (_cashier.IsBusy)
        {
            _agent.isStopped = true;
        }
        else
        {
            _agent.isStopped = false;
            _agent.SetDestination(_cashier.transform.position);
        }
    }
    private void TakeCar()
    {
        if (_carReleaser.IsBusy)
        {
            _agent.isStopped = true;
        }
        else
        {
            _agent.isStopped = false;
            _agent.SetDestination(_carReleaser.transform.position);
        }
    }
    public void ResetCharacter()
    {
        gameObject.SetActive(false);
        BoughtCar = false;
        TookKeys = false;
        TookCar = false;
        transform.position = _startPosition;
    }
}