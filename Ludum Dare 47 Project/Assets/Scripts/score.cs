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
    public int scoreNumber = 0;
    Text text;
    bool ran;
    spinCamera[] spinCamera;
    asteroidSpawning asteroidSpawning;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        ran = false;
        spinCamera = new spinCamera[3];
        spinCamera[0] = spawner.GetComponent<spinCamera>();
        spinCamera[1] = mainCamera.GetComponent<spinCamera>();
        spinCamera[2] = killScreen.GetComponent<spinCamera>();
        asteroidSpawning = spawner.GetComponent<asteroidSpawning>();
    }

    private void Update()
    {
        text.text = scoreNumber.ToString();
        if(scoreNumber % 500 == 0)
        {
            if(!ran)
            {
                for(int i = 0; i < spinCamera.Length; i++)
                {
                    spinCamera[i].increaseSpeed(0.00005f);
                }
                asteroidSpawning.increaseSpawnrate(1);
                ran = true;
            }
        } else
        {
            ran = false;
        }
    }
}
