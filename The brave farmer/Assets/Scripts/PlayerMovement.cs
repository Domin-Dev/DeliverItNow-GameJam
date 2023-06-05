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
    Sounds sounds;


    bool isJumping;

    Vector3 startPosition;
    private void Start()
    {
        Cursor.visible = false;
        sounds = FindObjectOfType<Sounds>();
        startPosition = transform.position;
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        groundChecker = transform.GetComponentInChildren<GroundChecker>();
        animator = transform.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(transform.position.y < -2)
        {
            ResetPosition();
        }

        if(Input.GetKeyDown(KeyCode.Space) && groundChecker.IsGrounded())
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && groundChecker.CanHit())
        {
            sounds.PlaySound(0);
            animator.SetTrigger("Hit");
        } 
        
        if (Input.GetKeyDown(KeyCode.Q) && groundChecker.CanGrow())
        {
            sounds.PlaySound(1);
            animator.SetTrigger("Watering");
        } 
        


    }

    public void ResetPosition()
    {
        rigidbody2D.velocity = Vector2.zero;
        transform.position = startPosition;
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

        if(Horizontal != 0 && rigidbody2D.velocity.y < 0.01f)
        {
            sounds.PlaySound(3);
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
