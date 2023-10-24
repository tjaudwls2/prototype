using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
   public void des()
    {
        Destroy(this.gameObject);
    }
    public void dis() { 
    
       this.gameObject.SetActive(false);
    
  
    }
}
