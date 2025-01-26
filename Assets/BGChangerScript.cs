using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGChangerScript : MonoBehaviour
{
    public Sprite costume0;
    public Sprite costume1;
    public Sprite costume2;
    public Sprite costume3;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = costume0;
    }

    // Update is called once per frame
    public void SetToBackground()
    {
        if (spriteRenderer.sprite == costume0)
        {
            spriteRenderer.sprite = costume1;
            
        }
        else if (spriteRenderer.sprite == costume1)
        {
            spriteRenderer.sprite = costume2;
            
        }
        else if (spriteRenderer.sprite == costume2)
        {
            spriteRenderer.sprite = costume3;
                
        }
        else if (spriteRenderer.sprite == costume3)
        {
            spriteRenderer.sprite = costume0;
        }

    }

}
