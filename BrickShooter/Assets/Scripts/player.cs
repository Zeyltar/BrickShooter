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
<<<<<<< HEAD
=======
        go_left = new Vector3(-1, 0f, 0f);
        go_right = new Vector3(1, 0f, 0f);
>>>>>>> 49a59a9eaa5a8fb350120b0d5bcd34fb70ac16a6
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
<<<<<<< HEAD
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
=======
            transform.Translate(go_left * speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(go_right * speed * Time.deltaTime);
>>>>>>> 49a59a9eaa5a8fb350120b0d5bcd34fb70ac16a6
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
