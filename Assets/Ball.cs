using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 15f; // Ball speed
    public Rigidbody2D rb2d;
    public Text score;
    public Text score2;
    public int points = 1; // Points for scoring a goal

    public int autopoints = 0;
    public float autoclick = 0;

    public static int Score1 = 0; //score player1
    private int Score2 = 0; // score player2
    private bool isCounting = false;

    AudioManager AudioManager;

    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }
    public void MouseClickPlay()
    {
        AudioManager.PlaySFX(AudioManager.mouseclick);
    }
    void Start()
    {
        Launch(); // Launch the ball in a random direction at the start
        ScoreUpdate();
        Score1 = 0;
        autopoints = 0;
        isCounting = true;
    }
    void Update()
    {
        if (rb2d.velocity.x < 0.5 && rb2d.velocity.x > 0)
        {
            Launch();
        }
        if (isCounting)
        {
            autoclick += Time.deltaTime;
            if (autoclick >= 2)
            {
                autoclick = 0;
                Score1 += autopoints;
                ScoreUpdate();
            
            }
            
        }
        
    }

    public void Launch()
    {
        // Generate a random launch direction
        float randomAngle = Random.Range(1f, 1.5f * Mathf.PI); // Full circle in radians
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;

        rb2d.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "rightgoal")
        {
            Score1 += points;
            ScoreUpdate();
            ResetBall();
            AudioManager.PlaySFX(AudioManager.bonk);
        }
        else if (collision.gameObject.tag == "leftgoal")
        {
            Score2 += 1;
            ScoreUpdateLeft();
            ResetBall();
            AudioManager.PlaySFX(AudioManager.bonk);
        }
        else if (collision.gameObject.tag == "wall")
        {
            AudioManager.PlaySFX(AudioManager.thump);
        }
        else
        {
            AudioManager.PlaySFX(AudioManager.boop);
        }
        
    }
    

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        Launch();
    }



    private void ScoreUpdate()
    {
        score.text = Score1.ToString();
    }

    private void ScoreUpdateLeft()
    {
        score2.text = Score2.ToString();
    }
}
