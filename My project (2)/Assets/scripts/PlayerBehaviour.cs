using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    [Header("Statsit")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashSpeedFactor;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float maxHealth;
    [SerializeField] public float currentHealth;

    private Rigidbody2D rb;
    private Vector2 movementDirection;

    public bool isDashing = false;
    public bool iFrame = false;
    public float iFrameTimer = 0;


    public Dictionary<Stat, float> stats = new Dictionary<Stat, float>();
    public kuolemaRuutu kuolemaRuutu;
    private Animator animator;
    public helaBaari healthBar;


    public enum Stat  // KUN HAKEE STATSIÄ, KÄYTÄ GetStat(Stat."statin nimi") !!
    {

        maxHealth,
        movementSpeed,
        dashSpeedFactor,
        dashCooldown,
        currentHealth
    }
    void Start()
    {
        SetPlayerStats();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            float päivitys = GetStat(Stat.maxHealth) + 20f;
            Debug.Log("max hela + 20 on: " + päivitys);
            UpdateStat(Stat.maxHealth, päivitys);
            UpdateStat(Stat.currentHealth, päivitys);
            healthBar.SetMaxHealth();
            healthBar.SetHealth();
        }



        //helabaarin pitäis nyt päivittyä pelkästään dictionaryn mukaan
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TakeDamage(10);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * GetStat(Stat.movementSpeed);

        if (isDashing)
        {
            rb.velocity = rb.velocity * dashSpeedFactor + movementDirection * GetStat(Stat.movementSpeed) * dashSpeedFactor;
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
        float newHealth = GetStat(Stat.currentHealth) - damage;
        UpdateStat(Stat.currentHealth, newHealth);
        if (newHealth != currentHealth)
        {
            healthBar.SetHealth();
            currentHealth = newHealth;
        }

        // siirsin clampin tänne. pitäis pitää maxhealth ja 0 helarajat.
        Mathf.Clamp(currentHealth, 0, maxHealth);

        currentHealth = newHealth;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void SetPlayerStats() //asettaa pelaajan kaikki statsit Dictionaryyn "Stat".
    {
        stats.Add(Stat.maxHealth, maxHealth = 103);
        stats.Add(Stat.dashCooldown, dashCooldown = 0); // aluksi 0, että pystyy heti dashaa
        stats.Add(Stat.dashSpeedFactor, dashSpeedFactor = 20);
        stats.Add(Stat.movementSpeed, movementSpeed = 8);
        stats.Add(Stat.currentHealth, maxHealth);
    } 

    public float GetStat(Stat stat) //Hakee pelaajan yksittäisen statsin Dictionarysta.
    {
        if (stats.TryGetValue(stat, out float value))
        {
            return value;
        }
        else
        {
            Debug.LogError($"No stat value found for {stat} in {this.name}");
            return 0;
        }
    }

    private void UpdateStat(Stat stat, float value) // Päivittää pelaajan yksittäisen statsin Dictionaryyn.
    {
        if (stats.ContainsKey(stat))
        {
            stats[stat] = value;
        }
        else
        {
            Debug.LogError($"No stat value found for {stat} in {this.name}");
        }
    }
}
