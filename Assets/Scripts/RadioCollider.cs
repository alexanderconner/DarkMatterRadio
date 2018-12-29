using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.CrossPlatformInput;

public class RadioCollider : MonoBehaviour {


    public UnityEvent onFire;


    public void OnTriggerStay()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            if (onFire != null)
            {
                onFire.Invoke();
            }
        }
    }
}
