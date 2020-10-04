using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player leaves the screen kill the player
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<moveScript>().exploded = true;
        }
    }
}
