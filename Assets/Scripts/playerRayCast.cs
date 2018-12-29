using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class playerRayCast : MonoBehaviour {

    private bool hover_state = false;
    private GameObject lastSeenObject;

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        //If we are seeing something close!
//Debug.DrawRay(transform.position, fwd, Color.blue, 5f);

        if (Physics.Raycast(transform.position, fwd, out hit, 5f))
        {
            //print("There is something in front of the player!");
            // If we weren't alredy hovering then this is a new object. check what it is
            if (!hover_state)
            {
                if (hit.transform.GetComponent<Interactive>() != null)
                {
                    hit.transform.gameObject.GetComponent<Interactive>().setOutline(true);
                    lastSeenObject = hit.transform.gameObject;
                    hover_state = true;
                }
            }
            //If hoverstate true and we are looking at an object, we don't need to change anything 

      
        } //but if we don't see anything, set Outline off and set hover false
        else
        {
            hover_state = false;
            if (lastSeenObject != null)
            {
                if (lastSeenObject.GetComponent<Interactive>() != null)
                {
                    lastSeenObject.GetComponent<Interactive>().setOutline(false);
                }
            }
        }
    }
}
