using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimscript : MonoBehaviour
{
    public float desTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, desTime);
    }

}
