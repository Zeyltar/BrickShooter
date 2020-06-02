using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript   : MonoBehaviour
{
    public float speed;

    public GameObject projectilePrefab;

    private float timeCounter = 0;
    public float firerate;
    public float cadency;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        Shoot();
    }

    void Shoot()
    {
        if (timeCounter <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                //fonction tire
                GameObject lProjectile = Instantiate(projectilePrefab) as GameObject;
                lProjectile.transform.position = transform.position;
                timeCounter = firerate;
            }
        }
        else
        {
            timeCounter -= Time.deltaTime * cadency;
        }
    }
}
