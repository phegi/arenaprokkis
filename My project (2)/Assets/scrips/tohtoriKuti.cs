using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TohtoriKuti : MonoBehaviour
{
    public float speed = 1000f;
    private UnityEngine.Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float lifeTime = 5;
    public float knockbackForce;

    private float timer = 0;

    // Start is called before the first frame update

    void Start(){
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector3 direction = mousePos - transform.position;
        UnityEngine.Vector3 rotation = transform.position - mousePos;
        rb.velocity = new UnityEngine.Vector2(direction.x, direction.y).normalized;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = UnityEngine.Quaternion.Euler(0, 0, rot + 90);

        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position += transform.up * Time.deltaTime * speed;

        timer += Time.deltaTime;

        if (timer > lifeTime){
            Destroy(gameObject);
        } 
        /*if (playerMovement.isFacingRight){
        transform.position += -transform.right * Time.deltaTime * speed;
        }
        if (!playerMovement.isFacingRight){
        transform.position += transform.right * Time.deltaTime * speed;
        }*/

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D colliderRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(GetComponent<Rigidbody2D>().name + " hit " + collision.gameObject.name);
            if (colliderRigidbody != null)
            {
                colliderRigidbody.AddForce(-transform.position * knockbackForce, ForceMode2D.Force);
            }
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
