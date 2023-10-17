using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{

    public GameObject followObject;
    Vector3 startpos;

    private void Start()
    {
        startpos= this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float r = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * 500f * Time.deltaTime * r);
        this.transform.position = followObject.transform.position+ startpos;
    }
}
