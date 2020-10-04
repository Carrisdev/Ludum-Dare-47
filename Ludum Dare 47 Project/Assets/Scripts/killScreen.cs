using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScreen : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        //destroys anything it touches, used to delete leftover asteroids behind the player
        Destroy(collider.gameObject);
    }
}
