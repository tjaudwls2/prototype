using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : Character
{
    Player player;
    float attack_cooltime;
    private void Awake()
    {
        player = GameObject.Find("Player").gameObject.GetComponent<Player>();
    }



    // Update is called once per frame
    void Update()
    {
        if (!die)
        {
            this.transform.GetChild(0).LookAt(player.transform.position);
            Vector3 pos = (player.transform.position - this.transform.position).normalized;
            //   this.GetComponent<Rigidbody>().velocity = (new Vector3(pos.x,0, pos.z) * speed );
            transform.Translate(pos * speed*Time.deltaTime);
            attack_cooltime += Time.deltaTime;
            if (Vector3.Distance(this.transform.position, player.transform.position) < 1 && attack_cooltime > attack_Speed)
            {
                this.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
                attack_cooltime = 0;
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            DamageCalculate(player.attack_Power,GameManager.GameManagerthis.hiteff[0]);
          //  Camera.main.DOShakePosition(0.1f,0.3f);
        }

    }
    protected override void DIE()
    {
        base.DIE();
        this.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Die");
        Instantiate(GameManager.GameManagerthis.enegry,this.transform.position,this.transform.rotation);
        Destroy(this.gameObject,1f);

    }




}
