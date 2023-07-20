using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldParticle : MonoBehaviour
{
    private Vector3 target;
    private Camera _camera;
    private RectTransform _rectTransform;


    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
       
        transform.position = Vector3.Lerp(_rectTransform.position, GoldManager.Instance.icon.transform.position, 0.05f);
        if (Vector3.Distance(transform.position, GoldManager.Instance.icon.transform.position) < 50f)
        {
            gameObject.SetActive(false);
        }
    }
}
