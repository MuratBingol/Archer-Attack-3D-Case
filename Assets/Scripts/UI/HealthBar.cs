using System;
using Damagable;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _handler;
    [SerializeField] private Gradient _color;

    private void Awake()
    {
        transform.parent.GetComponent<IDamageable>().GetDamageAction().AddListener(SetBar);
    }

    private void SetBar(float currentHealth, float maxHealth)
    {
        if (currentHealth<=0 || maxHealth==0)
        {
            DisableBar();
            return;
        }
        _handler.fillAmount = currentHealth / maxHealth;
        _handler.color = _color.Evaluate(_handler.fillAmount);
    }

    private void DisableBar()
    {
        if (transform.parent.GetComponent<IDamageable>()!=null)
        {
            transform.parent.GetComponent<IDamageable>().GetDamageAction().RemoveListener(SetBar);
        }
    
     gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (transform.parent.GetComponent<IDamageable>()!=null)
        {
            DisableBar();
        }
       
    }
}