using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour {
    //Script from video: https://youtu.be/_xMhkK6GTXA, by Matt Wester
    //Add an empty gameobject to the FirstPersonCharacter in the FPSController, and call it "guide". 

    //Drag the item this script is attached to to this
    public GameObject item;

    //Drag guide child from player controller to this
    public GameObject tempParent;

    public float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public bool isHolding = false;





    // Use this for initialization
    void Start () {
        item.GetComponent<Rigidbody>().useGravity = true;

    }
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
   
        if (distance >= 1f)
        {
            isHolding = false;
        }
        //check if isholding
        if (isHolding)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if(Input.GetMouseButtonDown(1))
            {
                //throw
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        } else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
	}

    private void OnMouseDown()
    {
        if (distance <= 1f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
  
        }
        
    }

    private void OnMouseUp()
    {
        isHolding = false;
    }

}
