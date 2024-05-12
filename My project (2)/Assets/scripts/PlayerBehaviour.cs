using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float dashSpeedFactor = 20f;
    [SerializeField] private float dashCooldown = 4f;
    public Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator animator;
    public bool isDashing = false;
    public bool iFrame = false;
    public float iFrameTimer = 0;

    public int maxHealth = 100;
    public int currentHealth;
    public helaBaari healthBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dashCooldown = 0; // 4s sob
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat("Speed", Mathf.Abs(movementDirection.magnitude * movementSpeed));

        bool flipped = movementDirection.x < 0;
        transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

        if (rb.velocity.magnitude >= 2 && Input.GetMouseButtonDown(1) && dashCooldown <= 0)
        {
            isDashing = true;
        }

        dashCooldown = Mathf.Clamp(dashCooldown - Time.deltaTime, 0, dashCooldown);

        iFrameTimer = Mathf.Clamp(iFrameTimer - Time.deltaTime, 0, iFrameTimer);
        if (iFrameTimer == 0)
        {
            iFrame = false;
            animator.SetBool("iFrameFlashing", false);
            rb.excludeLayers = 0;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;

        if (isDashing)
        {
            rb.velocity = rb.velocity * dashSpeedFactor + movementDirection * movementSpeed * dashSpeedFactor;
            dashCooldown = 4f;
            isDashing = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !iFrame)
        {
            TakeDamage(10);
            animator.SetBool("iFrameFlashing", true);
            iFrame = true;
            iFrameTimer = 2f;
            rb.excludeLayers = 256;
        }
    }

    public void TakeDamage(int damage)
    {
        int oldHealth = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (oldHealth != currentHealth)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
