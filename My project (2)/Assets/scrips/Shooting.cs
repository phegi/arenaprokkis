using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    public UnityEngine.Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;


    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        UnityEngine.Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x)  * Mathf.Rad2Deg;

        transform.rotation = UnityEngine.Quaternion.Euler(0, 0, rotZ);


        if(!canFire){
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring){
                timer = 0;
                canFire = true;
            }
        }


        if (Input.GetMouseButton(0) && canFire){
            canFire = false;
            Instantiate(bullet, bulletTransform.position, UnityEngine.Quaternion.identity);
        }
    }
}
