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
    public bool gameWon;

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
}

