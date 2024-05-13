using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(menuName = "Player stats")]

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float dashSpeedFactor = 20f;
    [SerializeField] private float dashCooldown = 4f;
    public int maxHealth = 100;
    public Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator animator;
    public bool isDashing = false;
    public bool iFrame = false;
    public float iFrameTimer = 0;
    public float currentHealth;
    public helaBaari healthBar;
    public Dictionary<Stat, float> stats = new Dictionary<Stat, float>();
    public kuolemaRuutu kuolemaRuutu;

    public enum Stat  // KUN HAKEE STATSIÄ, KÄYTÄ GetStat(Stat."statin nimi") !!
    {
        maxHealth = 100,
        movementSpeed = 8,
        dashSpeedFactor = 10,
        dashCooldown = 3,
        currentHealth
    }
    void Start()
    {
        SetPlayerStats();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        UpdateStat(Stat.dashCooldown, 0f); //4s sob
        currentHealth = GetStat(Stat.maxHealth);
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat("Speed", Mathf.Abs(movementDirection.magnitude * GetStat(Stat.movementSpeed)));

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

       


        // JOuduin tän kommentoimaan et pystyn testaa noit juttuja mut jos saat toimimaan uudelleen mun muutoksien kanssa nii vois ottaa uudelleen käyttöön.
        //helabaarin pitäis nyt päivittyä pelkästään dictionaryn mukaan
        // also onks joku scriptable obj
        // sit pitäis saada ne fieldit tonne mistä voi muuttaa inspectorista niitä arvoja pelaajan statseihin ja nähä ne muutenki
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
            rb.velocity = rb.velocity * GetStat(Stat.dashSpeedFactor) + movementDirection * GetStat(Stat.movementSpeed) * GetStat(Stat.dashSpeedFactor);
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
        /*float oldHealth = GetStat(Stat.currentHealth);
        
        UpdateStat(Stat.currentHealth, healthAfterDamage);
        //currentHealth = Mathf.Clamp(currentHealth, 0, GetStat(Stat.maxHealth));

        if (oldHealth != healthAfterDamage)
        {
            healthBar.SetHealth();
        }*/


//////////////  tää pitää laittaa kokonaan uusiks varmaan. En osannu.
        float newHealth = GetStat(Stat.currentHealth) - damage;
        UpdateStat(Stat.currentHealth, newHealth);
        if (newHealth != currentHealth)
        {
            healthBar.SetHealth();
            currentHealth = newHealth;
        }
        

        currentHealth = newHealth;

        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void SetPlayerStats() //asettaa pelaajan kaikki statsit Dictionaryyn "Stat".
    {

//////////////// Statseja ei pysty säätää täl hetkellä mistään eikä getStat funktio tee mitään ku yhtäkään statsia ei oo määritelty/ei oo määrää.
        stats.Add(Stat.maxHealth, maxHealth);
        stats.Add(Stat.dashCooldown, dashCooldown);
        stats.Add(Stat.dashSpeedFactor, dashSpeedFactor);
        stats.Add(Stat.movementSpeed, movementSpeed);
        stats.Add(Stat.currentHealth, maxHealth);

        // siirsin clampin tänne. pitäis pitää maxhealth ja 0 helarajat.
        Mathf.Clamp(currentHealth, 0, maxHealth);
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
