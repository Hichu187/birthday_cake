using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {        }

    }

    public GameObject cakeModel;
    public GameObject pickupBtn;
    public GameObject systemBtn;
    public GameObject playBtn;
    public GameObject winningBanner;
    public Candle candle;
    public Candle candle1;
    public Candle candle2;
    public List<Candle> candles;
    public GameObject matchStick; 
    public GameObject recycleBin; 
    public GameObject firePrefab;
    public SpriteRenderer background;

    public List<GameObject> cake;
    public List<Sprite> backgroundSprite;
    public List<GameObject> Toping;
    public List<GameObject> fire;

    private bool fired = false;
    public bool blow = false;
    private bool startCheck = false;
    
    void Start()
    {
        Application.targetFrameRate = 60;

        if (SceneManager.GetActiveScene().name == "PlayingScene")
        {
            background.sprite = backgroundSprite[PlayerPrefs.GetInt("background")];


            if (cakeModel != null)
            {
                cakeModel.GetComponent<SpriteRenderer>().sprite = cake[PlayerPrefs.GetInt("id")].GetComponent<Image>().sprite;
            }

            matchStick.gameObject.SetActive(false);
            pickupBtn.gameObject.SetActive(false);
            recycleBin.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "PlayingScene")
        {
            AddFire();
            Remove();
        }
    }

    public void SetModel(int i)
    {
        PlayerPrefs.SetInt("id", i);       
    }

    public void InstantiateToping(int i)
    {
        GameObject a =  Instantiate(Toping[i], cakeModel.transform);
        a.transform.position = cakeModel.transform.position;
    }

    void AddFire()
    {
        if (candle.gameObject.activeSelf==true)
        {
            if(candle.transform.GetChild(0).gameObject.activeSelf == true && !fire.Contains(candle.transform.GetChild(0).gameObject))
            {
                fire.Add(candle.transform.GetChild(0).gameObject);
                StartCoroutine(delay());
                SoundController.Instance.SingASong();
            }
            
        }
        else
        {
            if(candle1.transform.GetChild(0).gameObject.activeSelf == true && !fire.Contains(candle1.transform.GetChild(0).gameObject))
            {
                fire.Add(candle1.transform.GetChild(0).gameObject);
            }
            if(candle2.transform.GetChild(0).gameObject.activeSelf == true && !fire.Contains(candle2.transform.GetChild(0).gameObject))
            {
                fire.Add(candle2.transform.GetChild(0).gameObject);

            }

            if(fire.Count == 2 && fired ==false)
            {
                fired = true;
                SoundController.Instance.SingASong();
                StartCoroutine(delay());             
            }
            else
            {
                
            }
        }
    }

    IEnumerator delay()
    {
        fired = true;
        yield return new WaitForSeconds(1f);

        matchStick.gameObject.transform.position = new Vector3(0, 10, 0);
        

    }

    public void Remove()
    {
        if (fire.Count > 0)
        {
            for (int i = 0; i < fire.Count; i++)
            {
                if (fire[i].activeSelf == false)
                {
                    fire.Remove(fire[i]);
                }
            }
            CheckWin();
        }

    }
    void CheckWin()
    {
        if(fire.Count == 0)
        {
            SoundController.Instance.happySong.Stop();
            SoundController.Instance.Notice();
            winningBanner.gameObject.SetActive(true);
            pickupBtn.gameObject.SetActive(false);

            systemBtn.gameObject.SetActive(false);
        }
    }

    public void Playing()
    {
        matchStick.transform.position = new Vector3(0, 3f, 0);
        playBtn.gameObject.SetActive(false);
        matchStick.gameObject.SetActive(true);
        recycleBin.gameObject.SetActive(true);
        pickupBtn.gameObject.SetActive(true);
    }

    public void ChangeBackground(int id)
    {
        background.sprite = backgroundSprite[id];
        PlayerPrefs.SetInt("background", id);
    }

    public void AddTopping(int id)
    {
        GameObject a = Instantiate(Toping[id], cakeModel.transform);
        a.transform.position = cakeModel.transform.position;
    }
    #region scene
    public void Restart()
    {
        SceneManager.LoadScene("PlayingScene");
    }
    public void Next()
    {
        SceneManager.LoadScene("PlayingScene");
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion
}
