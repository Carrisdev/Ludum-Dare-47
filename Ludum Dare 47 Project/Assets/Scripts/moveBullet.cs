using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour
{
    Rigidbody2D rigidBody;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        Vector2 mouseWorldCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerMouseLine = mouseWorldCoords - new Vector2(player.transform.position.x, player.transform.position.y);
        playerMouseLine.Normalize();
        rigidBody.velocity = playerMouseLine * 20;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<asteroidHealth>() != null)
        {
            collision.GetComponent<asteroidHealth>().takeDamage();
            Destroy(gameObject);
        } else if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
