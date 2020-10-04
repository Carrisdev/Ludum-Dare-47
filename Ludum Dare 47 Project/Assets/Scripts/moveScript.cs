using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 playerPosition;
    float speed;
    Rigidbody2D rigidBody;
    Animator animator;
    AudioSource thruster;
    [SerializeField]
    AudioSource exploderSound;
    public bool exploded;
    public bool dead;
    GameManager gameManager;

    
    void Start()
    {
        //get the mouse and player positions
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = transform.position;
        speed = 3.0f;
        transform.position = Camera.main.transform.position;
        //grab all the needed components of the gameobject
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        thruster = gameObject.GetComponent<AudioSource>();
        //move the player to the camera once the game starts
        StartCoroutine(attachPlayerToCamera());
        exploded = false;
        dead = false;
        gameManager = FindObjectOfType<GameManager>();
    }


    
    void Update()
    {
        //rotate the player to be pointing the mouse at all times
        if(!exploded)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerPosition = transform.position;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, AngleBetweenTwoPoints(mousePosition, playerPosition) - 90);
        }
        //if the player dies stop rotating and die
        if(exploded && !dead)
        {
            StartCoroutine(explosion());
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.rotation = Quaternion.identity;
            thruster.Stop();
            exploderSound.Play();
            dead = true;
        }
        //when the player moves, play the thruster sound effect
        if (Input.GetMouseButtonDown(0) && gameManager.state == GameManager.State.playing)
        {
            animator.SetTrigger("Thrust");
            thruster.Play();
        }
    }

    void FixedUpdate()
    {
        //if the player isn't dead
        if(!exploded)
        {
            if (Input.GetMouseButton(0) && gameManager.state == GameManager.State.playing)
            {
                //set the velocity to move toward the mouse
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(mousePosition.x - playerPosition.x, mousePosition.y - playerPosition.y) * speed;
            }
            else
            {
                animator.ResetTrigger("Thrust");
                thruster.Stop();
            }
            
        }
    }
    
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    //move the player to the camera before the game starts
    IEnumerator attachPlayerToCamera()
    {
        yield return new WaitForEndOfFrame();
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
    }

    //start playing the explosion effect, and delay going to the game over screen
    IEnumerator explosion()
    {
        thruster.Stop();
        animator.SetTrigger("Explode");
        gameManager.state = GameManager.State.dying;
        yield return new WaitForSeconds(3);
        gameManager.state = GameManager.State.dead;
    }

    //NYI reset the player when the player hits the retry button
    public void resetExplodeTrigger()
    {
        animator.ResetTrigger("Explode");
    }
}
