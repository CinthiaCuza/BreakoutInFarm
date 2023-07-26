using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    public GameObject panel;
    public GameObject startPanel;
    public GameObject goPanel;
    public GameObject winPanel;

    public GameObject ball;
    public GameObject gameObjects;
    public float ballScale;

    private void Start()
    {
        if (GameController.instance.isGO)
        {
            goPanel.SetActive(true);
            GameController.instance.isGO = false;
        }
        else if (GameController.instance.gameWon)
        {
            winPanel.SetActive(true);
            GameController.instance.gameWon = false;
        }
        else
        {
            startPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && panel.activeSelf == true) StartLevel();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartLevel()
    {
        panel.SetActive(false);
        gameObjects.SetActive(true);

        GameObject newBall = Instantiate(ball, gameObjects.transform);
        newBall.transform.localScale = new Vector2(ballScale, ballScale);
    }
}
