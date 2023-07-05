using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    public GameObject panel;

    public GameObject ball;
    public GameObject gameObjects;

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
}
