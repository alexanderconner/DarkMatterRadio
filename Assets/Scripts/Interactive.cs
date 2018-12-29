using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour {

    public GameObject manager = null;

    //this is for setting the outline shader when looked at
    public Material defaultMaterial;
    public Material outlineMaterial;
    public Renderer rend;
    private bool showOutline = false;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;
    }
	


    public void setOutline(bool show)
    {
        if (show)
        {
            rend.material = outlineMaterial;
        }
        else
        {
            rend.material = defaultMaterial;
        }
    }

    void OnMouseDown()
    {

        print("User clicked on " + gameObject.name);

    }
}
