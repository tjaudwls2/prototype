using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoprot : MonoBehaviour
{
    public GameObject hiteff;
    public void stoprotoff() {
        this.transform.parent.gameObject.GetComponent<Player>().stoprot = false;



    }
    public void jumpstop()
    {
        this.transform.parent.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
   
    public void eff()
    {
        hiteff.SetActive(true); 
        hiteff.transform.position = this.transform.parent.gameObject.transform.position + (this.transform.parent.gameObject.transform.forward*2.5f);
        hiteff.GetComponent<ParticleSystem>().Play();
    }
}
