using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float maxX;

    public float paddleOffsetX = 1.0f;
    public float paddleOffsetY = 1.0f;

    private float fixedYPosition;
    public bool touchBall;

    private float aspectRatio;

    private void Start()
    {
        aspectRatio = Camera.main.aspect;
        AdjustPosition();
    }

    private void Update()
    {
        if (touchBall)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 newPosition = new Vector2(Mathf.Clamp(mouseWorldPosition.x, -maxX, maxX), fixedYPosition);

            transform.position = newPosition;
        }

        if (Camera.main.aspect != aspectRatio)
        {
            aspectRatio = Camera.main.aspect;
            AdjustPosition();
        }
    }

    private void AdjustPosition()
    {
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * aspectRatio;

        maxX = (cameraWidth - paddleOffsetX) * Mathf.Sign(transform.position.x);
        fixedYPosition = (cameraHeight - paddleOffsetY) * Mathf.Sign(transform.position.y);
    }
}
