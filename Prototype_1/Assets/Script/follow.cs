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
        //float r = Input.GetAxis("Mouse X");
        //float y = Input.GetAxis("Mouse Y");
        //transform.Rotate(new Vector3(500f * Time.deltaTime * y, 500f * Time.deltaTime * r, 0));

        LookAround();
        this.transform.position = followObject.transform.position+ startpos;

    }
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = transform.rotation.eulerAngles;

        //Ãß°¡
        float x = camAngle.x - mouseDelta.y;
        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 40f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        transform.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x*2f, camAngle.z);
    }

}
