using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject apple;
    public Sprite badAppleSprite;

    public int level;
    public int applesAmount = 0;

    public bool isGO;

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
        applesAmount = 0;
        isGO = true;
        SceneManager.LoadScene(level);
    }

    public void RestApple()
    {
        --applesAmount;

        if(applesAmount == 0)
        {
            level++;
            SceneManager.LoadScene(level);
        }
    }
}

