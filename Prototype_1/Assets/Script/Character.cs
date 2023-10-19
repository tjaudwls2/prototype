using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   
    public float hp,       //체력
                 maxhp;
    public float speed;   //이동속도
    public float attack_Power;  //공격력
    public float attack_Speed,attack_Cooltime; //기본 공격속도
    public float defense;   //방어력
    public float critcal_per, critcal_damage;  //크리티컬 확률, 크리티컬 데미지 


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
