using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : EnvironmentBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _goldCount;
    [SerializeField] private GameObject _goldParticle;

    public override void TakeDamage(float damage, Vector3 contactPoint)
    {
        _animator.enabled = true;
        GoldManager.OnSetGold?.Invoke(_goldCount);
        StartCoroutine(CreateGold());
       
    }

    IEnumerator CreateGold()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject gold = Instantiate(_goldParticle, GoldManager.Instance.transform);
            Vector3 pos =Camera.main.WorldToScreenPoint(transform.position);
            gold.GetComponent<RectTransform>().position = pos;
            gold.SetActive(true);
            yield return new WaitForSeconds(0.07f);
        }
        Destroy(this);
    }

}
