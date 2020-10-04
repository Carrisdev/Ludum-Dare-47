using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asteroidHealth : MonoBehaviour
{
    int health;
    Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        score = FindObjectOfType<Text>();
    }
    
    public void takeDamage()
    {
        health--;
        if(health <= 0)
        {
            score.GetComponent<score>().scoreNumber += 50;
            Destroy(gameObject);
        }
    }
}
