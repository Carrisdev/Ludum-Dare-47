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
        //get the bullet's trajectory
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        Vector2 mouseWorldCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerMouseLine = mouseWorldCoords - new Vector2(player.transform.position.x, player.transform.position.y);
        playerMouseLine.Normalize();
        rigidBody.velocity = playerMouseLine * 20;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the bullet hits an asteroid damage the asteroid and destroy the bullet
        if(collision.GetComponent<asteroidHealth>() != null)
        {
            collision.GetComponent<asteroidHealth>().takeDamage();
            Destroy(gameObject);
        //if the bullet leaves the edges of the screen destroy the bullet
        } else if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
