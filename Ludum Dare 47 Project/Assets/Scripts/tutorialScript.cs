using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameManager gameManager;

    void Update()
    {
        //if the player has hit the start game button
        if(gameManager.state == GameManager.State.starting)
        {
            //move the two tutorial asteroids into their starting positions
            if (gameObject.name == "tutorialAsteroid01")
            {
                transform.position = new Vector3(mainCamera.transform.position.x - 6, mainCamera.transform.position.y - 3, 0);
            }
            else if (gameObject.name == "tutorialAsteroid02")
            {
                transform.position = new Vector3(mainCamera.transform.position.x + 6, mainCamera.transform.position.y - 3, 0);
            }
        }
    }
}
