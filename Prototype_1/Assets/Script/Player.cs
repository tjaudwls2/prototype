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
    public bool town;
    

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = transform.GetChild(0).GetComponent<Animator>();
        if(!town)
        StartCoroutine("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();

        attack_Cooltime += Time.deltaTime;
        if (attack_Cooltime> attack_Speed)
        {

            if(Input.GetMouseButtonDown(0))
            {
                attack();
                attack_Cooltime = 0;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                attacktwo();
                attack_Cooltime = 0;
            }

        }



    }
    public void attack()
    {
        thisAnim.SetTrigger("Attack");
    }
    public void attacktwo()
    {
        thisAnim.SetTrigger("Buff");
    }
    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
   
    }
    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;

        if (isMove)
        {
            Vector3 lookForward = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
            Vector3 lookRight = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;


            transform.forward = lookForward;
            


            transform.position += moveDir * speed * Time.deltaTime;
            transform.LookAt(transform.position + moveDir);

            if (hAxis != 0)
                thisAnim.SetBool("Run", true);
            else if (vAxis != 0)
                thisAnim.SetBool("Run", true);
            else
                thisAnim.SetBool("Run", false);
        }
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
