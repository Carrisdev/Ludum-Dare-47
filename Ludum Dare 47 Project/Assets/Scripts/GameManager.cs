using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //the different game states
    public enum State
    {
        startScreen,
        starting,
        pause,
        playing,
        dying,
        dead
    }

    //all the different fields used by this script
    [SerializeField]
    GameObject[] titleScreenObjects;
    [SerializeField]
    GameObject[] gameObjects;
    [SerializeField]
    GameObject[] deadObjects;
    [SerializeField]
    GameObject scoreTracker;
    [SerializeField]
    GameObject timeTracker;
    [SerializeField]
    moveScript player;
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    asteroidSpawning asteroidSpawning;
    [SerializeField]
    score _score;
    [SerializeField]
    timer _timer;

    public int score;
    public int minutes;
    public float seconds;

    public State state;
    State lastState;
    //set the starting state values
    void Start()
    {
        state = State.startScreen;
        lastState = State.startScreen;
    }

    
    void Update()
    {
        //if the state has changed
        if(checkForChange())
        {
            //if the state is back to the start screen
            if(state == State.startScreen)
            {
                //turn on all the title screen objects
                for(int i = 0; i < titleScreenObjects.Length; i++)
                {
                    titleScreenObjects[i].SetActive(true);
                }
                //turn off all the in game objects
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].SetActive(false);
                }
                //turn off all the game over objects
                for (int i = 0; i < deadObjects.Length; i++)
                {
                    deadObjects[i].SetActive(false);
                }
            }
            //if the player has hit the start game button
            if(state == State.starting)
            {
                ////turn off all the title screen objects
                for (int i = 0; i < titleScreenObjects.Length; i++)
                {
                    titleScreenObjects[i].SetActive(false);
                }
                //turn on all the in game objects
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].SetActive(true);
                }
                //turn off all the game over objects
                for (int i = 0; i < deadObjects.Length; i++)
                {
                    deadObjects[i].SetActive(false);
                }
                StartCoroutine(playIntro());
            }
            //if the player has died
            if(state == State.dying)
            {
                //collect the final score and time
                score = scoreTracker.GetComponent<score>().scoreNumber;
                minutes = timeTracker.GetComponent<timer>().minutes;
                seconds = timeTracker.GetComponent<timer>().seconds;
            }
            //if the player has reached the game over screen
            if(state == State.dead)
            {
                //delete all asteroids so they don't clutter the screen
                GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
                for(int i = 0; i < asteroids.Length; i++)
                {
                    Destroy(asteroids[i]);
                }
                //turn off all the title screen objects
                for (int i = 0; i < titleScreenObjects.Length; i++)
                {
                    titleScreenObjects[i].SetActive(false);
                }
                //turn off all the in game objects
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].SetActive(false);
                }
                //turn on all the game over objects
                for (int i = 0; i < deadObjects.Length; i++)
                {
                    deadObjects[i].SetActive(true);
                }
            }
        }
    }

    //achnoledge the player hit the start game button
    public void startGame()
    {
        state = State.starting;
    }

    //check if the game state has been changed this frame
    bool checkForChange()
    {
        if(state == lastState)
        {
            return false;
        }
        lastState = state;
        return true;
    }

    //play the intro song
    IEnumerator playIntro()
    {
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4.25f);
        state = State.playing;
    }

    //reload the scene when the player hits the title screen button
    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //NYI restart the game immediately when the player hits the retry button
    public void restartGame()
    {
        player.resetExplodeTrigger();
        player.exploded = false;
        player.dead = false;
        player.gameObject.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, player.gameObject.transform.position.z);

        asteroidSpawning.counter = 0;
        asteroidSpawning.spawnrate = 0;
        _score.scoreNumber = 0;
        _timer.minutes = 0;
        _timer.seconds = 0.0f;

        state = State.starting;
    }
}