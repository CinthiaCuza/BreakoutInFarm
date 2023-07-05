using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject panel;

    public GameObject ball;
    public GameObject gameObjects;

    private void Start()
    {
        StartLevel();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartLevel()
    {
        Debug.Log("Start");

        panel.SetActive(false);
        gameObjects.SetActive(true);

        Instantiate(ball, gameObjects.transform);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(GameController.instance.level);
    }

}
