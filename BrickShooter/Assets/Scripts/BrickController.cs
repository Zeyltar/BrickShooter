﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject brickPrefab;
    public Vector3 startPosition;

    public static List<GameObject> list = new List<GameObject>();

    private float timeCounter = 0;
    public float spawnTime;

    //vitesse de spawn/défilement
    public float cadency;

    //pas de défilement
    public float speed;

    public SpawnProbability[] spawnRates = new SpawnProbability[4];

    private const string _NORMAL_BRICK = "NormalBrick";
    private const string _SCROLL_BRICK = "ScrollBrick";
    private const string _SPEED_BRICK = "SpeedBrick";
    private const string _FIRERATE_BRICK = "FirerateBrick";

    // Update is called once per frame
    void Update()
    {
        if (timeCounter <= 0)
        {
            CreateBrickRow();
            timeCounter = spawnTime;
            MoveBricks();
        }
        timeCounter -= Time.deltaTime * cadency;
        
    }

    void CreateBrick(Vector3 position, string tag)
    {
        GameObject lBrick = Instantiate(brickPrefab) as GameObject;
        lBrick.transform.position = startPosition + position;
        lBrick.transform.SetParent(transform);
        lBrick.tag = tag;
        lBrick.name = tag;

        if (tag == SCROLL_BRICK)
        {
            ChangeColor(lBrick, Color.red);
        }
        else if (tag == SPEED_BRICK)
        {
            ChangeColor(lBrick, Color.blue);
        }
        else if (tag == FIRERATE_BRICK)
        {
            ChangeColor(lBrick, Color.green);
        }

        list.Add(lBrick);
        
    }

    void ChangeColor(GameObject go, Color color)
    {
        go.GetComponent<Renderer>().material.color = color;
    }

    void CreateBrickRow(int size = 10)
    {
        float startX = size * -1 / 2;
        for (int i = 0; i < size; i++)
        {
            int lRange = Random.Range(0, 100);

            for (int j = 0; j < spawnRates.Length; j++)
            {
                if (lRange >= spawnRates[j].minProbailityRange && lRange <= spawnRates[j].maxProbabilityRange)
                {
                    CreateBrick(new Vector3(startX, 0, 0), spawnRates[j].tag);
                    
                }
            }
            startX += 1;

        }
    }

    void MoveBricks()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.Translate(Vector3.down * speed);
        }
    }

    public static string NORMAL_BRICK
    {
        get => _NORMAL_BRICK;
    }
    public static string SCROLL_BRICK
    {
        get => _SCROLL_BRICK;
    }
    public static string SPEED_BRICK
    {
        get => _SPEED_BRICK;
    }
    public static string FIRERATE_BRICK
    {
        get => _FIRERATE_BRICK;
    }
}

[System.Serializable]
public class SpawnProbability
{
    public string tag;
    public int minProbailityRange;
    public int maxProbabilityRange;
}