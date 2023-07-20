using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : Singleton<GoldManager>
{
    public static Action<int> OnSetGold;
    public static Action OnChangeGold;
    [SerializeField] private TextMeshProUGUI _goldText;
    public Image icon;

    public static int GoldCount
    {
        get => PlayerPrefs.GetInt("Gold", 0);
        private set => PlayerPrefs.SetInt("Gold", value);
    }

    protected override void Awake()
    {
        base.Awake();
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