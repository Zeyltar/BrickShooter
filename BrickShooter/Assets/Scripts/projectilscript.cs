using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilscript : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        //BrickController.list.Remove(collision.gameObject);
        //Destroy(collision.gameObject);
    }
}
