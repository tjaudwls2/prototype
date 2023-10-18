using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   
    public float hp,
                 maxhp;
    public float speed;
    public float attack_Power;
    public float attack_Speed,attack_Cooltime;
    public float defense;
    public bool die = false;

    public void DamageCalculate(float damage, GameObject hiteff)
    {
        hp -= damage;
        Instantiate(hiteff,this.transform.position,this.transform.rotation);
        if (hp <= 0)
        {
            DIE();


        }
    }
    protected virtual void DIE()
    {
        die = true;
        this.tag = "Die";
        this.gameObject.layer = 6;
    }
}
