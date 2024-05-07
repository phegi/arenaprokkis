using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private float dashSpeedFactor = 8f;
    [SerializeField] private float dashCooldown = 4f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator animator;
    public UnityEngine.Vector3 mousePos;

    //private float horizontal;

    //private bool isFacingRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");

        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));  

        animator.SetFloat("Speed", Mathf.Abs(movementDirection.magnitude * movementSpeed));

        bool flipped = movementDirection.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

        //Flip();

        dashCooldown = Mathf.Clamp(dashCooldown - Time.deltaTime, 0, dashCooldown);

    }

    void FixedUpdate(){
        rb.velocity = movementDirection * movementSpeed;

        if (movementDirection != Vector2.zero){

        }

    //dash
    if (rb.velocity.magnitude >= 2 && Input.GetMouseButtonDown(1) && dashCooldown <= 0)
    {
        rb.velocity = rb.velocity * dashSpeedFactor + movementDirection * movementSpeed * dashSpeedFactor;
        dashCooldown = 5;
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
