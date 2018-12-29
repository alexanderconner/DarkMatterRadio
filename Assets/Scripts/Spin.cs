using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public enum SpinVector {x, y, z };
    public SpinVector selectedVector;
    public float speed = 10;
	
	// Update is called once per frame
	void Update () {

        switch (selectedVector)
        {
            case (SpinVector.x):
                transform.Rotate(Vector3.right, speed * Time.deltaTime);
                break;
            case (SpinVector.y):
                transform.Rotate(Vector3.up, speed * Time.deltaTime);
                break;
            case (SpinVector.z):
                transform.Rotate(Vector3.forward, speed * Time.deltaTime);
                break;
            default:
                print("No spin vector selected for " + gameObject.name.ToString());
                break;
        }

      
	}
}
