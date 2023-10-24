using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class cameramove : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 rot;
   
    public void movecamera()
    {
        Camera.main.transform.DOLocalMove(pos, 1f);
        Camera.main.transform.DOLocalRotate(rot, 1f);

    }
  

}
