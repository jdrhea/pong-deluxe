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
    private float advertismentTimer;
    private bool isAdvertismentCounting = false;
    public Text score;
    AudioManager AudioManager;

    public GameObject BGChanger;
    public GameObject Ad1;
    public GameObject Ad2;
    public GameObject Ad3;
    public GameObject Ad4;
    

    //public Transform destination;
    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }

    void Start()
    {
        ShopUI.SetActive(false);
        VideoPlayer.gameObject.SetActive(false);
        BGChanger.gameObject.SetActive(false);
    }
    public void OpenShop()
    {
        //AudioManager.PlaySFX(AudioManager.mouseclick);
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
                
            }
            
        }
        if (isAdvertismentCounting)
        {
            advertismentTimer += Time.deltaTime;    
            if (advertismentTimer >= 2)
            {
                advertismentTimer = 0;
                isCounting = false;
                int randomNum = Random.Range(1, 4);
                if (randomNum == 1)
                {
                    Ad1.SetActive(true);
                    isAdvertismentCounting = true;
                    advertismentTimer = 0;
                }
                else if (randomNum == 2)
                {
                    Ad2.SetActive(true);
                    isAdvertismentCounting = true;
                    advertismentTimer = 0;
                }
                else if (randomNum == 3)
                {
                    Ad3.SetActive(true);
                    isAdvertismentCounting = true;
                    advertismentTimer = 0;
                }
                else if (randomNum == 4)
                {
                    Ad4.SetActive(true);
                    isAdvertismentCounting = true;
                    advertismentTimer = 0;
                }
            }
            
        }
    
    }
    public void BuyItem1()
    {
        AudioManager.PlaySFX(AudioManager.mouseclick);
        if(Ball.Score1 >= 2)
        {
            Paddle1.gameObject.transform.localScale += new Vector3(0,2,0);
            Ball.Score1 -= 2;
            ScoreUpdate();
            
        }
        
    }
    public void BuyItem2()
    {
        AudioManager.PlaySFX(AudioManager.mouseclick);
        if(Ball.Score1 >= 5)
        {
            VideoPlayer.gameObject.SetActive(true);
            Ball.Score1 -= 5;
            ScoreUpdate();
        }
        
    }
    public void BuyItem3()
    {
        AudioManager.PlaySFX(AudioManager.mouseclick);
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
        AudioManager.PlaySFX(AudioManager.mouseclick);
        if(Ball.Score1 >= 10)
        {
            Ball.Score1 -= 10;
            isCounting = true;
            
        }
        
    }
    public void BuyItem5()
    {
        AudioManager.PlaySFX(AudioManager.mouseclick);
        if(Ball.Score1 >= 15)
        {
            Ball.Score1 -= 15;
            BGChanger.gameObject.SetActive(true);
            ScoreUpdate();
            
        }
        
    }
    public void BuyItem6()
    {
        AudioManager.PlaySFX(AudioManager.mouseclick);
        if(Ball.Score1 >= 20)
        {
            Ball.Score1 -= 20;
            Ball b = GetComponent<Ball>();

            if (b != null)
            {    
                b.points = 2;
                ScoreUpdate();
            }
            else
            {
                Debug.LogError("Wow! you really are a dumb freaking brat for not attaching the script to the game object!");    
            }  
            
        }
        
    }
    public void BuyItem7()
    {
        AudioManager.PlaySFX(AudioManager.mouseclick);
        if(Ball.Score1 >= 25)
        {
            isAdvertismentCounting = true;
            Ball.Score1 -= 25;
            ScoreUpdate();
            Ball b = GetComponent<Ball>();

            if (b != null)
            {    
                b.autopoints = 1;
                ScoreUpdate();
            }
            else
            {
                Debug.LogError("Wow! you really are a dumb freaking brat for not attaching the script to the game object!");    
            }  
            
        }

    }
    public void Test()
    {
        Debug.Log("Button Clicked");
    }
    private void ScoreUpdate()
    {
        score.text = Ball.Score1.ToString();
    }
}
