using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilscript : MonoBehaviour        
{
    private float speed;
    private float outofmap;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
        outofmap = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > outofmap)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    { 
        if (col.gameObject.tag == "ScrollBrick" || col.gameObject.tag == "NormalBrick" || col.gameObject.tag == "SpeedBrick" || col.gameObject.tag == "FirerateBrick")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
