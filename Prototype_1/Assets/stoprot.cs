using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoprot : MonoBehaviour
{
    public void stoprotoff() {
        this.transform.parent.gameObject.GetComponent<Player>().stoprot = false;



    }
}
