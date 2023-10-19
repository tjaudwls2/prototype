using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   
    public float hp,       //ü��
                 maxhp;
    public float speed;   //�̵��ӵ�
    public float attack_Power;  //���ݷ�
    public float attack_Speed,attack_Cooltime; //�⺻ ���ݼӵ�
    public float defense;   //����
    public float critcal_per, critcal_damage;  //ũ��Ƽ�� Ȯ��, ũ��Ƽ�� ������ 


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
