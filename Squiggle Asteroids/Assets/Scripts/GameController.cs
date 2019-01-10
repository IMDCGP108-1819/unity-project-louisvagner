using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector2 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text healthText;

    public float HealthRegenRate;
    public float MaxHealth;
    private int MinHealth;
    public GameObject playerExplosion;

    private bool gameOver;
    private bool restart;
    private int score;
    private float health;

    void Start()
    {
        gameOver = false; //set defeat to false
        restart = false; // set restart option to false
        restartText.text = "";//set to "nothing" so we don't see the text
        gameOverText.text = "";//set to "nothing" so we don't see the text
        health = 1000;
        score = 0;
        UpdateScore();
        MinHealth = 0;
        healthText.text = health.ToString(); //
        StartCoroutine(SpawnWaves());
        StartCoroutine(RegenerateHealth());
        UpdateHealth();
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    //Makes the multiple hazards go spawn after determined time,how many appear, how long they need to wait before spawning at the beginning and how much time between each wave
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            
            //GameOver message
            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }
    //add the score called from the file DestroyByContact
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    //addition all the score together
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    //take off the health called from the file DestroyByContact
    public void LoseHealth(int newHealth)
    {
        health -= newHealth;
        //defeat condition
        if (health <= MinHealth)
        {
            Destroy(gameObject);
            Instantiate(playerExplosion, transform.position, transform.rotation);
            GameOver();
            
        }
        UpdateHealth();

    }
    //update health changes together
    void UpdateHealth()
    {
        healthText.text = health + "";
    }

    //make the player win 1 health after a determined time/seconds
    private IEnumerator RegenerateHealth()
    {
        // we enter an infinite loop here; if we did not yield later, this would freeze up our game (and the editor).
        while (true)
        {
            // the yield keyword here makes the computer from running this function for the specified amount of time.
            // in this case, we say it should wait for however many seconds is specified in the HealthRegenRate variable
            yield return new WaitForSeconds(HealthRegenRate);

            // We update the CurrentHealth here - Mathf.Min returns the smaller value of the two provided - so we'll never set health to be greater than MaxHealth.
            health = Mathf.Min(health + 1, MaxHealth);

            // update the HUD element
            healthText.text = health.ToString();
        }
    }

    public void GameOver()
    {
        //set the defeat(gameOver) to true
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
