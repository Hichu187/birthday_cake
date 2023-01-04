using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {

        }

    }

    public AudioSource happySong;
    public AudioSource sfx;

    public List<AudioClip> btnClick;
    public AudioClip song;
    public AudioClip notice;

    public Button btnSound;

    public List<Sprite> sfxButtonImg;

    private bool muted;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        IconImg();
        AudioListener.pause = muted;
    }


    public void click()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        IconImg();
    }

    private void IconImg()
    {
        if(muted == false)
        {
            btnSound.GetComponent<Image>().sprite = sfxButtonImg[0];
        }
        else
        {
            btnSound.GetComponent<Image>().sprite = sfxButtonImg[1];
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;

        if (muted == true)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    public void SingASong()
    {
        happySong.PlayOneShot(song);
    }

    public void Notice()
    {
        sfx.PlayOneShot(notice);
    }

    public void sfxClick()
    {
        sfx.PlayOneShot(btnClick[0]);
    }

    public void sfxSlider()
    {
        sfx.PlayOneShot(btnClick[1]);
    }
}
