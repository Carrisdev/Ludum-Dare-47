using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asteroidHealth : MonoBehaviour
{
    GameObject explodeSoundManager;
    int health;
    Text score;
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        explodeSoundManager = GameObject.FindGameObjectWithTag("SoundManager");
        gameManager = FindObjectOfType<GameManager>();
    }
    
    //if the asteroid gets shot, lower it's health. If the health reaches 0, award points and destroy the asteroid
    public void takeDamage()
    {
        health--;
        if(health <= 0)
        {
            score.GetComponent<score>().scoreNumber += 50;
            explodeSoundManager.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
