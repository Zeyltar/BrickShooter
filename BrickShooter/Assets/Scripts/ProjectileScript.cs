using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour        
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ScrollBrick") || collision.gameObject.CompareTag("NormalBrick") || collision.gameObject.CompareTag("SpeedBrick") || collision.gameObject.CompareTag("FirerateBrick"))
        {
            BrickController.list.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
