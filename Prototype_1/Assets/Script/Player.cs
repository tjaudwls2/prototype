using FIMSpace.GroundFitter;
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
    public bool stoprot;
    public int jumpCount=2;
    public float jumpPower;
    public bool buff;
    public float skill_chage_eff_scale;
    public GameObject skill_chage_eff;
    // Start is called before the first frame update
    void Start()
    {
      
        thisAnim = transform.GetChild(0).GetComponent<Animator>();
        //if (!town)
        //    StartCoroutine("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();

      //  transform.position += Vector3.forward * speed * Time.deltaTime;
        attack_Cooltime += Time.deltaTime;
        if (attack_Cooltime> attack_Speed)
        {
          
            if (Input.GetMouseButtonDown(0)&& Input.GetMouseButton(0)&& !stoprot)
            {
                stoprot = true;
                attack();
                attack_Cooltime = 0;
            }
         
            if (Input.GetKeyDown(KeyCode.Alpha1) && !stoprot)
            {
                stoprot = true;
                attackWheel();
                attack_Cooltime = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)&& !buff)
            {
                this.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
                buff = true;
                speed += 5f;
                attacktwo();
                attack_Cooltime = 0;
            }

        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            thisAnim.SetTrigger("ChageStart");
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            stoprot = true;
            thisAnim.SetBool("Chage", true);
            skill_chage_eff_scale += Time.deltaTime;
        
            attack_Cooltime = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {

            skill_chage_eff.transform.localScale = new Vector3(Mathf.Clamp(skill_chage_eff_scale, 0f,2f), Mathf.Clamp(skill_chage_eff_scale, 0f, 2f), Mathf.Clamp(skill_chage_eff_scale, 0f, 2f));
            thisAnim.SetBool("Chage", false);
            skill_chage_eff_scale = 0;
            attack_Cooltime = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount--;
            if (jumpCount > 0)
            {
           
               thisAnim.SetTrigger("JumpStart");
               thisAnim.SetBool("Jump", true);
              // GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
            }
        }




    }
    public void buffoff()
    {
        buff = false;
        speed -= 2f;
    }

   public void attackWheel()
    {
        thisAnim.SetTrigger("Wheel");
    }
    public void stoprotoff()
    {
        stoprot = false;



    }
    public void attack()
    {
        thisAnim.SetTrigger("Attack");
        //Invoke("stoprotoff", 0.8f);
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

        this.GetComponent<FGroundFitter_Movement>().BaseSpeed = speed;
        this.GetComponent<FGroundFitter_Movement>().SprintingSpeed = speed*2f;
        ray();
        if (isMove)
        {
          //  Vector3 lookForward = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
          //  Vector3 lookRight = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;
          //  Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
          //
          //
          //
          //
          //transform.forward = lookForward;
          //
          //  transform.position += moveDir * speed * Time.deltaTime;
          //  if (!stoprot)
          //  {
          //      
          //      transform.LookAt(transform.position + moveDir);
          //  }
            if (hAxis != 0)
                thisAnim.SetBool("Run", true);
            else if (vAxis != 0)
                thisAnim.SetBool("Run", true);
            else
                thisAnim.SetBool("Run", false);
        }
    }


    //void Turn()
    //{
    //    Vector3 dir = new Vector3(hAxis, 0, vAxis);

    //    if (!(hAxis == 0 && vAxis == 0))
    //    {
    //        transform.position += dir * speed * Time.deltaTime;
    //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotationSpeed);
    //    }
    //}
    private void FixedUpdate()
    {
        
    }
    public void ray()
    {
        if (this.GetComponent<Rigidbody>().velocity.y <= 0)
        {
  
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.05f, LayerMask.GetMask("Plane"));
            if (isGrounded)
            {

                thisAnim.SetBool("Jump", false);
                jumpCount = 2;
            }
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
