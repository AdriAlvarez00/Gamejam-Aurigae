using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed = 5f;
    public float acc = 2f;
    public float jumpForce = 5f;
    public float dashSpeed = 15f;
    public float dashCD =1;
    public float dashLength = 0.2f;
    public int stage = 3;
    
    float moveSpeed;
    Vector2 dir;
    bool canJump;
    bool isCaving;
    bool canDash;
    public KeyCode jumpKey,DashKey,cavingKey,bugKey;
    private float lateralInertia;
    bool isDashing = false;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = speed;
        dir = new Vector2(0, 0);
        canJump = false;
        isCaving = false;
        canDash = true;

        rb = GetComponent<Rigidbody2D>();
        if (!rb) Debug.Log("Mete el rigidbody",this);

        anim = GetComponent<Animator>();
        if (!anim) Debug.Log("Mete el animator", this);
        else
        {
            anim.SetBool("HitGround", false);
            anim.SetBool("Jumping", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        transform.Translate(dir * speed*Time.deltaTime);
        
        if (canJump && Input.GetKeyDown(jumpKey) && !isDashing && stage >= 1) {
            Jump();
        }

        if(canDash && Input.GetKeyDown(DashKey))
        {
            Dash();
        }

        if (Input.GetKeyDown(cavingKey))
        {
            isCaving = true;
        }else if (isCaving)
        {
            isCaving = false;
        }

        

        //if (Input.GetKeyDown(bugKey))
        //{
        //    bug()
        //}

    }
    private void FixedUpdate()
    {
        
    }
    private void Dash()
    {
        isDashing = true;
        anim.SetBool("Dashing",true);
        canDash = false;
        lateralInertia = rb.velocity.x;
        rb.velocity = new Vector2(rb.velocity.x, 0); //para la inercia vertical
        rb.AddForce(Vector2.right * dashSpeed * Mathf.Sign(Input.GetAxis("Horizontal")), ForceMode2D.Impulse);
        Invoke("StopDash", dashLength);
        Invoke("ResetDash", dashCD);
    }
    private void StopDash()
    {
        anim.SetBool("Dashing",false);
        isDashing = false;
        rb.velocity = new Vector2(rb.velocity.y,lateralInertia);
    }
    private void ResetDash()
    {
        canDash = true;
    }
    private void Jump()
    {
        canJump = false;
        anim.SetBool("Jumping", true);
        anim.SetBool("HitGround", false);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && canJump == false)
        {
            canJump = true;
            anim.SetBool("HitGround", true);
            anim.SetBool("Jumping", false);
        }
    }


}
