using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [SerializeField]
    GameObject spawner;
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameObject killScreen;
    [SerializeField]
    GameObject loopCompleted;
    GameManager gameManager;
    public int scoreNumber = 0;
    Text text;
    bool ran;
    spinCamera[] spinCamera;
    asteroidSpawning asteroidSpawning;

    //grab all the spinning objects and the score display text
    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        gameManager = FindObjectOfType<GameManager>();
        ran = false;
        spinCamera = new spinCamera[3];
        spinCamera[0] = spawner.GetComponent<spinCamera>();
        spinCamera[1] = mainCamera.GetComponent<spinCamera>();
        spinCamera[2] = killScreen.GetComponent<spinCamera>();
        asteroidSpawning = spawner.GetComponent<asteroidSpawning>();
    }

    
    private void Update()
    {
        //display the score
        text.text = scoreNumber.ToString();
        //if the score hits a milestone
        if (scoreNumber % 250 == 0)
        {
            //and the speed hasn't been updated yet
            if (!ran)
            {
                //increase the speed and spawnrate of the asteroids
                for (int i = 0; i < spinCamera.Length; i++)
                {
                    spinCamera[i].increaseSpeed(0.00005f);
                }
                //passing in 1 here is unnecessary
                asteroidSpawning.increaseSpawnrate(1);
                ran = true;
            }
        } else
        {
            ran = false;
        }
        //if the loop is completed, award a lot of points and increase the speed by a lot
        if (Mathf.Abs(spinCamera[1].angle) % 360 == 0 && spinCamera[1].angle != 0)
        {
            for(int i = 0; i < spinCamera.Length; i++)
            {
                spinCamera[i].increaseSpeed(0.0002f);
            }
            scoreNumber += 5000;
            loopCompleted.GetComponent<loopComplete>().startFlash();
        }
    }
}
