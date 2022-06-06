using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private bool _isHiden = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeSettings()
    {
        if (_isHiden)
        {
            LeanTweenExt.LeanMoveLocalY(gameObject, 0, 1.2f).setEaseOutElastic();
            _isHiden = false;
        } else
        {
            LeanTweenExt.LeanMoveLocalY(gameObject, 608, 0.8f).setEaseOutBounce();
            _isHiden = true;
        }
    }
}
