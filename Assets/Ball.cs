using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro.Examples;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 15f; // Ball speed
    public Rigidbody2D rb2d;
    public Text score;
    public Text score2;
    public int points = 1; // Points for scoring a goal
    public int leftPoints = 1; // Points for scoring a goal    

    public int autopoints = 0;
    public float autoclick = 0;

    public static int Score1 = 0; //score player1
    private static int Score2 = 0; // score player2
    private bool isCounting = false;

    public Text Countdowntext;
    public int countdown = 3;
    //question
    public GameObject question;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ScoreUpdate();
        ScoreUpdateRight();
        Countdown();
        question.SetActive(true);
    }
    public void YesButton()
    {
        ScoreUpdateRight();
        ScoreUpdate();
        question.SetActive(false);
    }
    public void NoButton()
    {
        Score1 = 0;
        Score2 = 0;
        ScoreUpdateRight();
        question.SetActive(false);
        ScoreUpdate();
    }
    
    public void Countdown()
    {
        if (countdown > 0)
        {
            Countdowntext.text = countdown.ToString();
            countdown--;
            Invoke("Countdown", 1);
        }
        else if (countdown == 0)
        {
            Countdowntext.text = "GO!";
            Invoke("StartRound", 1); // Delay starting the round slightly after "GO!"
            countdown--; // Ensure this block only runs once
        }
        else
        {
            Countdowntext.text = ""; // Clear countdown text after "GO!"
        }
    }

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
    
    public void StartRound()
    {
        Launch(); // Launch the ball in a random direction at the start
        ScoreUpdate();
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
        float randomAngle = Random.Range(0f, 2f * Mathf.PI); // Full circle in radians
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
            Score2 += leftPoints;
            ScoreUpdateRight();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "greenapple")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "redapple")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
        }
    }
    

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        Launch();
    }
    public void LaunchButton()
    {
        if(Score1 >= 3)
        {
            Score1 -= 3;
            ScoreUpdate();
            transform.position = Vector2.zero;
            Launch();
        }
    }



    private void ScoreUpdate()
    {
        score.text = Score1.ToString();
    }

    private void ScoreUpdateRight()
    {
        score2.text = Score2.ToString();
    }
}
