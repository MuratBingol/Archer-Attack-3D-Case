using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel, _failPanel;
    [SerializeField] private Button _nextLevel, _restart;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private GameObject _gold;
    private void Awake()
    {
        EventManager.OnFail += SetFailPanel;
        EventManager.OnWin += SetWinPanel;
    }

    void Start()
    {
        _levelText.text = "Level "+LevelManager.Instance.playedLevel;
        _nextLevel.onClick.AddListener((() => LevelManager.Instance.OpenLastLevel()));
        _restart.onClick.AddListener((() => LevelManager.Instance.OpenLastLevel()));
    }

    private void SetWinPanel()
    {
        StartCoroutine(OpenPanel(_winPanel));
        StartCoroutine(CreateGold());
        GoldManager.OnSetGold?.Invoke(LevelManager.Instance.currentLevel.levelAward);
    }  
    private void SetFailPanel()
    {
        StartCoroutine(OpenPanel(_failPanel));
    }
    
    IEnumerator  OpenPanel(GameObject panel)
    {
        yield return new WaitForSeconds(2f);
        panel.SetActive(true);
    }
    private void OnDisable()
    {
        EventManager.OnFail -= SetFailPanel;
        EventManager.OnWin -= SetWinPanel;
    }
    
    
    IEnumerator CreateGold()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 10; i++)
        {
            GameObject gold = Instantiate(_gold, GoldManager.Instance.transform);
            Vector3 pos = transform.position;
            gold.GetComponent<RectTransform>().position = pos;
            gold.SetActive(true);
            yield return new WaitForSeconds(0.07f);
        }
        Destroy(this);
    }
}
