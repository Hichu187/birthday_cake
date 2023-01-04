using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CakeController : MonoBehaviour
{
    public int number;
    public List<Sprite> cakeSprites;
    public List<Sprite> numberSprites;
    public GameObject candle;
    public GameObject candle1;
    public GameObject candle2;

    private int _a;
    private int _b;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetUpCandle();
    }

    void SetUpCandle()
    {
        if (number >= 10)
        {
            candle.SetActive(false);
            candle1.SetActive(true);
            candle2.SetActive(true);
            
            ImgToNumber(number/10,candle1); 
            ImgToNumber((number - (number / 10) * 10), candle2); 
        }
        else if (number < 10)
        {
            candle.SetActive(true);
            candle1.SetActive(false);
            candle2.SetActive(false);
            ImgToNumber(number, candle);
        }
    }

    public void AddNumber()
    {
        number++;
    }

    public void MinusNumber()
    {
        number--;
        if(number < 0)
        {
            number = 0;
        }
    }

    void ImgToNumber(int i, GameObject cd)
    {
        switch (i)
        {
            case 0: 
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[0];
                break;
            case 1: 
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[1];
                break;
            case 2:
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[2];
                break;
            case 3:
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[3];
                break;
            case 4:
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[4];
                break;
            case 5:
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[5];
                break;
            case 6:
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[6];
                break;
            case 7:
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[7];
                break;
            case 8:
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[8];
                break;
            case 9:
                cd.GetComponent<SpriteRenderer>().sprite = numberSprites[9];
                break;

        }
    }
}
