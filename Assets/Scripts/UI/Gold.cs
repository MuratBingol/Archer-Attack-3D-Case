using System;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public static Action<int> OnSetGold;
    public static Action OnChangeGold;
    [SerializeField] private TextMeshProUGUI _goldText;

    public static int GoldCount
    {
        get => PlayerPrefs.GetInt("Gold", 0);
        private set => PlayerPrefs.SetInt("Gold", value);
    }

    private void Awake()
    {
        OnSetGold += ChangeGold;
    }

    private void Start()
    {
        _goldText.text = GoldCount.ToString();
    }

    private void ChangeGold(int amount)
    {
        GoldCount += amount;
        _goldText.text = GoldCount.ToString();
        OnChangeGold?.Invoke();
    }
}