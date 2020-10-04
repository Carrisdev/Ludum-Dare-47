using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCamera : MonoBehaviour
{
    public float angle;
    float radius;
    float speed;
    GameManager gameManager;
    
    void Start()
    {
        //check which object this script is attached to and adjust the starting angle as appropriate
        if (gameObject.name == "Main Camera")
        {
            angle = 0.0f;
        } else if(gameObject.name == "KillScreen")
        {
            angle = 1.00f;
        } else if(gameObject.name == "SpawnPoint")
        {
            angle = -0.35f;
        }
        
        //set the radius of the spin and initial speed
        radius = 100.0f;
        speed = 0.0001f;
        gameManager = FindObjectOfType<GameManager>();

        //move the object onto the edge of the circle
        float x;
        float y;
        angle -= speed;
        x = Mathf.Cos(angle) * radius;
        y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, -10.0f);
    }

    //move the camera every physics update to keep in line with the ship moving to avoid stuttering
    void FixedUpdate()
    {
        if(gameManager.state == GameManager.State.playing || gameManager.state == GameManager.State.dying)
        {
            float x;
            float y;
            angle -= speed;
            x = Mathf.Cos(angle) * radius;
            y = Mathf.Sin(angle) * radius;
            transform.position = new Vector3(x, y, -10.0f);
        }
    }

    //increase speed
    public void increaseSpeed(float increase)
    {
        speed += increase;
    }
}
