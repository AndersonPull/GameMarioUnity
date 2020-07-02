using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{

    public Rigidbody rb;
    public Animator anim;
    public float speedMove;
    public float speedRotate;
    public float limitedSpeed;
    public float jumpForce;
    public bool isGround;
    public bool isRunningL;
    public bool isJumpingL;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if( rb.velocity.z <= limitedSpeed && rb.velocity.z >= -limitedSpeed)
            {
                    rb.AddForce(transform.forward * speedMove * Time.deltaTime);
            }

            if(isGround)
            {
                this.isRunningL = true;
                anim.SetBool("isRunning", true);
            }
        }

        if(Input.GetKey(KeyCode.S))
        {
            if( rb.velocity.z <= limitedSpeed && rb.velocity.z >= -limitedSpeed)
            {
                rb.AddForce(transform.forward * -speedMove * Time.deltaTime);
            }

            if(isGround)
            {
                this.isRunningL = true;
                anim.SetBool("isRunningBack", true);
            }
        }

        if(Input.GetKey(KeyCode.D))
            rb.transform.Rotate(0,speedRotate * Time.deltaTime,0);


        if(Input.GetKey(KeyCode.A))
            rb.transform.Rotate(0,-speedRotate * Time.deltaTime,0);


        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            anim.SetBool("isJumping", true);
            isJumpingL = true;
            rb.AddForce(0, jumpForce, 0);
            isGround = false;
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            this.isRunningL = false;
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKeyUp(KeyCode.S))
        {
            this.isRunningL = false;
            anim.SetBool("isRunningBack", false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            isJumpingL = false;
            anim.SetBool("isJumping", false);
        }
    }
}
