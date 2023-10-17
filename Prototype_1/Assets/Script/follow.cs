using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{

    public GameObject followObject;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = followObject.transform.position+new Vector3(0,17,-8);
    }
}
