using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TapToPlay : MonoBehaviour
{
    private PointerEventData _eventData;
    private List<RaycastResult> _result;

    private void Start()
    {
        _eventData = new PointerEventData(EventSystem.current);
        _result = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ControlUITouch())
        {
            EventManager.OnSetAction?.Invoke(ActionType.run);
            gameObject.SetActive(false);
        }
    }
    
    
    private bool ControlUITouch()
    {
        _result.Clear();
        _eventData.position = Input.mousePosition;
        EventSystem.current.RaycastAll(_eventData, _result);

        if (_result.Count > 0) return false;

        return true;
    }
}
