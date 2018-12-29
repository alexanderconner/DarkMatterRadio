using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//From this: https://unity3d.com/learn/tutorials/topics/scripting/events-creating-simple-messaging-system 


public class testEvent : MonoBehaviour {

    private UnityAction someListener;


    private void Awake()
    {
        someListener = new UnityAction(SomeFunction);
    }

    void OnEnable()
    {
        EventManager.StartListening("test", someListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("test", someListener);
    }

    void SomeFunction ()
    {
        Debug.Log("Some function was called in testEvent");
    }

}
