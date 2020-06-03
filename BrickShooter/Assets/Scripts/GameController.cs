using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameObject brickController;
    public static GameObject player;

    private void Awake()
    {
        brickController = GameObject.Find("BrickController");
        player = GameObject.Find("Player");

        GetConfigFromFile();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetConfigFromFile()
    {
        XmlDocument doc = new XmlDocument();
        Debug.Log(Application.dataPath + "/Scripts/options.xml");
        doc.Load(Application.dataPath + "/Scripts/options.xml");

        XmlNode root = doc.DocumentElement;
        XmlNode gameConfig = root.SelectSingleNode("gameconfig");

        GetBricksConfig(gameConfig.SelectSingleNode("bricks"));
        GetPlayerConfig(gameConfig.SelectSingleNode("player"));

    }

    void GetBricksConfig(XmlNode config)
    {
        XmlNodeList add = config.ChildNodes;
        
        int i;
        for (i = 0; i < add.Count; i++)
        {
            if (add[i].Attributes[0].Name == "cadency")
            {
                brickController.GetComponent<BrickController>().cadency = float.Parse(add[i].Attributes[0].Value, CultureInfo.InvariantCulture.NumberFormat);
            }
            else if (add[i].Attributes[0].Name == "speed")
            {
                brickController.GetComponent<BrickController>().speed = float.Parse(add[i].Attributes[0].Value, CultureInfo.InvariantCulture.NumberFormat);
            }
            else if (add[i].Attributes[0].Name == "spawnTime")
            {
                brickController.GetComponent<BrickController>().spawnTime = float.Parse(add[i].Attributes[0].Value, CultureInfo.InvariantCulture.NumberFormat);
            }
        }
    }

    void GetPlayerConfig(XmlNode config)
    {
        XmlNodeList add = config.ChildNodes;
        int i;
        for (i = 0; i < add.Count; i++)
        {
            if (add[i].Attributes[0].Name == "cadency")
            {
                player.GetComponent<PlayerScript>().cadency = float.Parse(add[i].Attributes[0].Value, CultureInfo.InvariantCulture.NumberFormat);
            }
            else if (add[i].Attributes[0].Name == "speed")
            {
                player.GetComponent<PlayerScript>().speed = float.Parse(add[i].Attributes[0].Value, CultureInfo.InvariantCulture.NumberFormat);
            }
            else if (add[i].Attributes[0].Name == "firerate")
            {
                player.GetComponent<PlayerScript>().firerate = float.Parse(add[i].Attributes[0].Value, CultureInfo.InvariantCulture.NumberFormat);
            }

        }
    }

    public static void IncreaseScrollSpeed(float scalingValue)
    {
        brickController.GetComponent<BrickController>().cadency *= scalingValue;
    }

    public static void IncreasePlayerSpeed(float scalingValue)
    {
        player.GetComponent<PlayerScript>().speed = Mathf.Min(player.GetComponent<PlayerScript>().speed * scalingValue, player.GetComponent<PlayerScript>().MaxSpeed);
    }

    public static void IncreasePlayerFirerate(float scalingValue)
    {
        player.GetComponent<PlayerScript>().cadency *= scalingValue;
    }

    public static float SCALING_VALUE
    {
        get => 1.1f;
    }
    
}
