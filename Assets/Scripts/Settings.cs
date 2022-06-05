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
        if (gameObject.transform.position.y < 60) LeanTween.moveY(gameObject, -619, 0.6f).setEaseInOutCirc();
        else LeanTween.moveY(gameObject, 619, 0.6f).setEaseInOutCirc();
    }
}
