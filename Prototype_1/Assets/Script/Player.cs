using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
   
    public float rotationSpeed = 3f;

    float hAxis;
    float vAxis;
    Vector3 moveVec;
    public Animator thisAnim;
    


    // Start is called before the first frame update
    void Start()
    {
        thisAnim = transform.GetChild(0).GetComponent<Animator>();
        StartCoroutine("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();


    }
    
    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
   
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);

        if(hAxis!=0)
            thisAnim.SetBool("Run",true);
        else if (vAxis != 0)
            thisAnim.SetBool("Run", true);
        else
            thisAnim.SetBool("Run", false);
    }

    void Turn()
    {
        Vector3 dir = new Vector3(hAxis, 0, vAxis);

        if (!(hAxis == 0 && vAxis == 0))
        {
            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotationSpeed);
        }
    }


    IEnumerator Attack()
    {
        while (!die)
        {

            thisAnim.SetTrigger("Attack");


            yield return new WaitForSeconds(attack_Speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamageCalculate(collision.gameObject.GetComponent<Enemy>().attack_Power, GameManager.GameManagerthis.hiteff[1]);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Energy"))
        {
            GameManager.GameManagerthis.Exp++;
            GameManager.GameManagerthis.ExpGage.fillAmount = GameManager.GameManagerthis.Exp / GameManager.GameManagerthis.MaxExp;
            if (GameManager.GameManagerthis.Exp>= GameManager.GameManagerthis.MaxExp)
            {
                GameManager.GameManagerthis.LevelUp();
            }
            Destroy(other.gameObject);
        }
    }
}
