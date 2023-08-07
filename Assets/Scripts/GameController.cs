using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class Sound
{
    public string clipName;
    public AudioClip clip;
}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject apple;
    public Sprite badAppleSprite;

    public int level;
    public int applesAmount = 0;

    public bool isGO;
    public bool gameWon;

    public Sound[] sfxSounds;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        PlaySFX("Lose");

        applesAmount = 0;
        isGO = true;
        SceneManager.LoadScene(level);
    }

    public void RestApple()
    {
        --applesAmount;

        if(applesAmount == 0)
        {
            PlaySFX("Win");

            if (level == 4)
            {
                level = 0;
                gameWon = true;
            }
            else
            {
                level++;
            }

            SceneManager.LoadScene(level);
        }
    }

    public void PlaySFX(string name)
    {
        Sound clipToPlay = Array.Find(sfxSounds, x => x.clipName == name);
        sfxSource.PlayOneShot(clipToPlay.clip);
    }
}

