using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    private Vector3 go_left;
    private Vector3 go_right;
    // Start is called before the first frame update
    void Start()
    {
        go_left = new Vector3(-1, 0f, 0f);
        go_right = new Vector3(1, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            transform.Translate(go_left * speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(go_right * speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0));
        {
            //fonction tire
        }
    }
}
