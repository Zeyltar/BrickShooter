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
        Debug.Log(BrickController.NORMAL_BRICK);
        if (collision.gameObject.CompareTag(BrickController.NORMAL_BRICK) || collision.gameObject.CompareTag(BrickController.SCROLL_BRICK) ||  collision.gameObject.CompareTag(BrickController.SPEED_BRICK) || collision.gameObject.CompareTag(BrickController.FIRERATE_BRICK))
        {
            if (collision.gameObject.CompareTag(BrickController.SCROLL_BRICK))
            {
                GameController.IncreaseScrollSpeed(GameController.SCALING_VALUE);
            }
            else if (collision.gameObject.CompareTag(BrickController.SPEED_BRICK))
            {
                GameController.IncreasePlayerSpeed(GameController.SCALING_VALUE);
            }
            else if (collision.gameObject.CompareTag(BrickController.FIRERATE_BRICK))
            {
                GameController.IncreasePlayerFirerate(GameController.SCALING_VALUE);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {

            }

            BrickController.list.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
