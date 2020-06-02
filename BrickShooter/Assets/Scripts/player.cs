using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;

    public GameObject FirePrefab;
    public Vector3 offset;

    public static List<GameObject> listFire = new List<GameObject>();
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

        if (Input.GetMouseButtonDown(0))
        {
            //fonction tire
            GameObject lFire = Instantiate(FirePrefab) as GameObject;
            lFire.transform.position = transform.position;
            listFire.Add(lFire);
        }
    }
}
