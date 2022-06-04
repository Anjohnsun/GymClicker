using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeSettings()
    {
       // LeanTween.moveY(gameObject, 450, 0.8f);
        LeanTweenExt.LeanMoveLocalY(gameObject, 0, 0.8f);
    }
}
