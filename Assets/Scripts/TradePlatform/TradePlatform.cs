using System;
using System.Collections.Generic;

using UnityEngine;

public class TradePlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] _carPrefabs;
    [SerializeField] private GameObject _dividers;
    [SerializeField] private Transform _carPrefabSpawnPoint;

    private PlayerResources _playerResources;
    private List<GameObject> _newCars = new List<GameObject>();

    [field: SerializeField] public int PlatformCost { get; private set; }
    [field: SerializeField] public int CarCost { get; private set; }
    [field: SerializeField] public int CarUpgradeCost { get; private set; }
    [field: SerializeField] public int CarUpgradeCostIncrement { get; private set; }
    [field: SerializeField] public int CarPrice { get; private set; }

    public event Action<int> OnSpendMoney;
    public event Action<int> OnGetMoney;
    public event Action OnReadyToTrade;

    public int CurrentCarStage { get; private set; }
    public bool MaxCarStage { get; private set; }

    private void Start()
    {
        _playerResources = FindObjectOfType<PlayerResources>();
        PreparePlatform();
    }

    private void PreparePlatform()
    {
        for (int i = 0; i < _carPrefabs.Length; i++)
        {
            GameObject newCar = Instantiate(_carPrefabs[i], _carPrefabSpawnPoint);
            _newCars.Add(newCar);
            newCar.SetActive(false);
        }
    }

    public bool BuyPlatform()
    {
        if (_playerResources.CurrentMoney >= PlatformCost)
        {
            OnSpendMoney?.Invoke(PlatformCost);
            Destroy(_dividers);
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }

    public bool BuyCar()
    {
        if (_playerResources.CurrentMoney >= CarCost)
        {
            OnSpendMoney?.Invoke(CarCost);
            OnReadyToTrade?.Invoke();
            for (int i = 0; i < _newCars.Count; i++)
            {
                _newCars[CurrentCarStage].SetActive(true);
            }
            CarPrice = CarCost / 10;
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }

    public bool UpgradeCar()
    {
        if (_playerResources.CurrentMoney >= CarUpgradeCost && CurrentCarStage <= _newCars.Count)
        {
            CurrentCarStage++;
            OnSpendMoney?.Invoke(CarUpgradeCost);

            for (int i = 0; i < _newCars.Count; i++)
            {
                _newCars[CurrentCarStage - 1].SetActive(false);
                _newCars[CurrentCarStage].SetActive(true);
            }

            if (CurrentCarStage == _newCars.Count - 1)
            {
                MaxCarStage = true;
            }
            CarUpgradeCost *= CarUpgradeCostIncrement;
            CarPrice = (CarCost + CarUpgradeCost) / 10;
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }

    public void SellCar()
    {
        OnGetMoney?.Invoke(CarPrice);
    }
}
