using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDownScript : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float speed = 25f;
//powerdown bools
    public bool isFireball;
    public bool isBlackHole;
//scoretext
    public Text score;

    public GameObject Paddle1;
    public static bool startTimer;
//script component
    private PowerDownScript  pds;
    void Start()
    {
        if (isFireball)
        {
            Launch();
        }
        else if (isBlackHole)
        {
            Launch();

        }
    }
    private void Awake()
    {
        GameObject scoreObject = GameObject.Find("Score1Text");

        if (scoreObject != null)
        {
            score = scoreObject.GetComponent<Text>();
            
        }
        Paddle1 = GameObject.Find("Paddle1");

        if (Paddle1 != null)
        {
            pds = Paddle1.GetComponent<PowerDownScript>();
            
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
        if (isFireball)
        {
            if (collision.gameObject.tag == "leftgoal")
            {
                  
                Ball.Score1 -= 1;
                ScoreUpdate();
                ResetBall();
                
            }
           

        }
        if (isBlackHole)
        {
            if (collision.gameObject.tag == "paddle1")
            {
                startTimer = true;
                ResetBall();

            }
        }
    }
    public void ResetBall()
    {
        rb2d.position = Vector2.zero;
        Launch();
    }
    public void ScoreUpdate()
    {
        score.text = Ball.Score1.ToString();
    }
}
