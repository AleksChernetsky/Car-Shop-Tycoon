using TMPro;

using UnityEngine;

public class PlayerBalanceView : MonoBehaviour
{
    [SerializeField] private PlayerResources _playerBalance;
    [SerializeField] private string _template;

    private TextMeshProUGUI _moneyText;

    private void Awake()
    {
        _moneyText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _moneyText.text = string.Format(_template, _playerBalance.CurrentMoney);
    }
}
