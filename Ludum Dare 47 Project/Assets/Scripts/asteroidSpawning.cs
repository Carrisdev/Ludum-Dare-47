using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawning : MonoBehaviour
{
    [SerializeField]
    GameObject[] asteroids;
    float variableX;
    float variableY;
    int numberSpawned;
    public int spawnrate;
    public int counter;
    GameManager gameManager;
    

    void Start()
    {
        variableX = 20.0f;
        variableY = 20.0f;
        numberSpawned = 10;
        spawnrate = 500;
        counter = spawnrate;
        gameManager = FindObjectOfType<GameManager>();
    }
    

    void Update()
    {
        //if the counter hits the spawnrate
        if(counter == spawnrate)
        {
            //spawn a number of asteroids in a random place within certain bounds
            for(int i = 0; i < numberSpawned; i++)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-variableX, variableX), Random.Range(-variableY, variableY));
                randomPosition += new Vector2(transform.position.x, transform.position.y);
                GameObject temp = Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(randomPosition.x, randomPosition.y, 0), Quaternion.identity);
            }
            counter = 0;
        }
        //only update the counter while the player is playing the game
        if(gameManager.state == GameManager.State.playing)
        {
            counter++;
        }
    }

    public void increaseSpawnrate(int increase)
    {
        spawnrate -= 10;
    }
}
