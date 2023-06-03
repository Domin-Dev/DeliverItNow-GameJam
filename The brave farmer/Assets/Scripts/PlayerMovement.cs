using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float playerSpeed;
    [SerializeField] float jumpPower;



    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    GroundChecker groundChecker;
    Animator animator;


    bool isJumping;

    Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        groundChecker = transform.GetComponentInChildren<GroundChecker>();
        animator = transform.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Transform transformCart = GameObject.FindGameObjectWithTag("Cart").transform;
            transformCart.parent.GetChild(1).GetComponent<WheelJoint2D>().useMotor = true;
            transformCart.parent.GetChild(2).GetComponent<WheelJoint2D>().useMotor = true;
        }


        if(transform.position.y < -2)
        {
            rigidbody2D.velocity = Vector2.zero;
            transform.position = startPosition;
        }

        if(Input.GetKeyDown(KeyCode.Space) && groundChecker.IsGrounded())
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && groundChecker.CanHit())
        {
            animator.SetTrigger("Hit");
        } 
        
        if (Input.GetKeyDown(KeyCode.Q) && groundChecker.CanGrow(true))
        {
            animator.SetTrigger("Watering");
        } 
        
        if (Input.GetKeyDown(KeyCode.R) && groundChecker.CanGrow(false))
        {
            animator.SetTrigger("Seeding");
        }

    }

    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(Horizontal * playerSpeed * Time.fixedDeltaTime * 10, rigidbody2D.velocity.y);

        if(rigidbody2D.velocity.y > 0.01f)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping",false);
        }

        if(Horizontal < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            animator.SetBool("IsWalking", true);
        }
        else if(Horizontal > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if(isJumping)
        {
            rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = false;
        }

    }





}
