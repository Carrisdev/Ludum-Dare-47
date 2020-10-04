using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    [SerializeField]
    GameObject leftBlaster;
    [SerializeField]
    GameObject rightBlaster;
    [SerializeField]
    GameObject shot;
    [SerializeField]
    GameManager gameManager;
    bool shootRight;
    
    void Start()
    {
        shootRight = false;
    }

    
    void Update()
    {
        //shoot when the player presses right click, and alternate shooting between the left and right blaster
        if(Input.GetMouseButtonDown(1) && gameManager.state == GameManager.State.playing)
        {
            if (shootRight)
            {
                Instantiate(shot, rightBlaster.transform.position, rightBlaster.transform.rotation);
            } else
            {
                Instantiate(shot, leftBlaster.transform.position, leftBlaster.transform.rotation);
            }
            shootRight = !shootRight;
        }
    }
}
