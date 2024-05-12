using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float dashSpeedFactor = 20f;
    [SerializeField] private float dashCooldown = 4f;
    [SerializeField] public float knockbackForce;
    public Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator animator;

    private BoxCollider2D boxCollider;
    public UnityEngine.Vector3 mousePos;

    public playerStats playerStats;

    public bool isDashing = false;

    public bool iFrame = false;

    public float iFrameTimer = 0;

    //private float horizontal;

    //private bool isFacingRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dashCooldown = 0;//4s sob

        }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");

        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));  

        animator.SetFloat("Speed", Mathf.Abs(movementDirection.magnitude * movementSpeed));

        bool flipped = movementDirection.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

        if (rb.velocity.magnitude >= 2 && Input.GetMouseButtonDown(1) && dashCooldown <= 0)
    {
            isDashing = true;

    }

        //Flip();

        dashCooldown = Mathf.Clamp(dashCooldown - Time.deltaTime, 0, dashCooldown);


        iFrameTimer = Mathf.Clamp(iFrameTimer - Time.deltaTime, 0, iFrameTimer);
        if (iFrameTimer == 0){
            iFrame = false;
            this.animator.SetBool("iFrameFlashing", false);
            rb.excludeLayers = 0;
        }

    }

    void FixedUpdate(){
        rb.velocity = movementDirection * movementSpeed;

        if (movementDirection != Vector2.zero){

        }
        if (isDashing){
            rb.velocity = rb.velocity * dashSpeedFactor + movementDirection * movementSpeed * dashSpeedFactor;
            dashCooldown = 4f; 
            isDashing = false;           
        }




    //dash

    }
    private void OnCollisionStay2D(Collision2D collision){
    if (collision.gameObject.CompareTag("Enemy") && !iFrame){
        this.playerStats.TakeDamage(10);
        this.animator.SetBool("iFrameFlashing", true);
        iFrame = true;
        iFrameTimer = 2f;
        rb.excludeLayers = 256;
    }
    }
    
    /*private void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }*/



}
