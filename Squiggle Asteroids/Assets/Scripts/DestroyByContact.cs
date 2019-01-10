using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject starshipExplosion;

    private int scoreValue;
    private int healthLost;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Asteroids(Clone)")
        {
            Destroy(col.gameObject);
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
            scoreValue = 10;
            healthLost = 40;
        }
        else if (col.gameObject.name == "Asteroids (1)(Clone)")
        {
            Destroy(col.gameObject);
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
            scoreValue = 5;
            healthLost = 20;
        }
        else if (col.gameObject.name == "Asteroids (2)(Clone)")
        {
            Destroy(col.gameObject);
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
            scoreValue = 10;
            healthLost = 40;
        }
        else if (col.gameObject.name == "Starship(Clone)")
        {
            Destroy(col.gameObject);
            Instantiate(starshipExplosion, transform.position, transform.rotation);
            scoreValue = 20;
            healthLost = 50;
        }
        else if (col.gameObject.name == "Laser(Clone)")
        {
            Destroy(col.gameObject);
            healthLost = 20;
        }

    gameController.AddScore(scoreValue);
    gameController.LoseHealth(healthLost);
    
    }

    //void OnTriggerEnter(Collider col)
    //{
    //Instantiate(playerexplosion, transform.position, transform.rotation);
    //if (col.gameObject.name == "Asteroids")
    //{
    //Destroy(col.gameObject);
    //}
    //}
}

