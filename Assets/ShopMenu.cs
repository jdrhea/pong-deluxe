using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;


public class ShopMenu : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject Paddle1;
    public GameObject VideoPlayer;
    public GameObject Wall;
    private float timer;
    private bool isCounting = false;
    public Text score;

    public GameObject BGChanger;
    

    //public Transform destination;

    void Start()
    {
        ShopUI.SetActive(false);
        VideoPlayer.gameObject.SetActive(false);
        BGChanger.gameObject.SetActive(false);
    }
    public void OpenShop()
    {
        ShopUI.SetActive(true);
    }
    void Update()
    {
        
        if (gameObject.CompareTag("shopui"))
        {    
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                transform.Translate(Vector3.up * 40,Space.World);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backward
            {
                transform.Translate(Vector3.down * 40,Space.World);
            }
        }
        if (isCounting)
        {
            timer += Time.deltaTime;    
            Wall.SetActive(true);
            if (timer >= 10)
            {
                timer = 0;
                isCounting = false;
                Wall.SetActive(false);
            }
            
        }
    
    }
    public void BuyItem1()
    {
        if(Ball.Score1 >= 2)
        {
            Paddle1.gameObject.transform.localScale += new Vector3(0,2,0);
            Ball.Score1 -= 2;
            ScoreUpdate();
            
        }
        
    }
    public void BuyItem2()
    {
        if(Ball.Score1 >= 5)
        {
            VideoPlayer.gameObject.SetActive(true);
            Ball.Score1 -= 5;
            ScoreUpdate();
        }
        
    }
    public void BuyItem3()
    {
        if(Ball.Score1 >= 8)
        {
            PlayerMovement pm = GetComponent<PlayerMovement>();

            if (pm != null)
            {    
                Ball.Score1 -= 8;
                pm.moveSpeed = 20;
                ScoreUpdate();
            }
            else
            {
                Debug.LogError("Wow! you really are a dumb freaking brat for not attaching the script to the game object!");    
            }    
        }
        
    }
    public void BuyItem4()
    {
        if(Ball.Score1 >= 10)
        {
            Ball.Score1 -= 10;
            isCounting = true;
            
        }
        
    }
    public void BuyItem5()
    {
        if(Ball.Score1 >= 15)
        {
            Ball.Score1 -= 15;
            BGChanger.gameObject.SetActive(true);
            ScoreUpdate();
            
        }
        
    }
    public void BuyItem6()
    {
        if(Ball.Score1 >= 20)
        {
            Ball.Score1 -= 20;
            Ball b = GetComponent<Ball>();

            if (b != null)
            {    
                Ball.Score1 -= 8;
                b.points = 2;
                ScoreUpdate();
            }
            else
            {
                Debug.LogError("Wow! you really are a dumb freaking brat for not attaching the script to the game object!");    
            }  
            
        }
        
    }
    private void ScoreUpdate()
    {
        score.text = Ball.Score1.ToString();
    }
}
