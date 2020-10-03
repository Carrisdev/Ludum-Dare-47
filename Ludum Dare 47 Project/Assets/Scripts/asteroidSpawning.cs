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
    int spawnrate;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        variableX = 20.0f;
        variableY = 20.0f;
        numberSpawned = 10;
        spawnrate = 500;
        counter = spawnrate;
    }
    //+-20 +-20
    // Update is called once per frame
    void Update()
    {
        if(counter == spawnrate)
        {
            for(int i = 0; i < numberSpawned; i++)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-variableX, variableX), Random.Range(-variableY, variableY));
                randomPosition += new Vector2(transform.position.x, transform.position.y);
                Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(randomPosition.x, randomPosition.y, 0), Quaternion.identity);
            }
            counter = 0;
        }
        counter++;
    }
}
