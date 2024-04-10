using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private TradePlatform[] _tradePlatform;

    [field: SerializeField] public int CurrentMoney { get; private set; }

    private void Start()
    {
        CurrentMoney = 10000;
        _tradePlatform = FindObjectsOfType<TradePlatform>();

        for (int i = 0; i < _tradePlatform.Length; i++)
        {
            _tradePlatform[i].OnSpendMoney += SpendMoney;
            _tradePlatform[i].OnGetMoney += GetMoney;
        }
    }

    private void GetMoney(int amount)
    {
        CurrentMoney += amount;
    }

    private void SpendMoney(int amount)
    {
        CurrentMoney -= amount;
    }
}