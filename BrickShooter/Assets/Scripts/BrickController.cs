using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject brickPrefab;
    public Vector3 startPosition;

    public static List<GameObject> list = new List<GameObject>();

    private float timeCounter = 0;
    public float timeMax;
    public float cadency;
    public float nrmBrickProb;
    public float speed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter <= 0)
        {
            CreateBrickRow();
            timeCounter = timeMax;
        }
        timeCounter -= Time.deltaTime * cadency;
        MoveBricks();
    }

    void CreateBrick(Vector3 position = new Vector3(), string tag = "NrmBrick")
    {
        GameObject lBrick = Instantiate(brickPrefab) as GameObject;
        lBrick.transform.position = startPosition + position;
        lBrick.transform.SetParent(transform);
        lBrick.tag = tag;
        list.Add(lBrick);
        
    }

    void CreateBrickRow(int size = 10)
    {
        float startX = size * -1 / 2;
        for (int i = 0; i < size; i++)
        {
            float lRand = Random.value;
            
            if (lRand < nrmBrickProb)
            {
                CreateBrick(new Vector3(startX, 0, 0), "NrmBrick");
            }
            startX += 1;
        }
    }


    void MoveBricks()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}