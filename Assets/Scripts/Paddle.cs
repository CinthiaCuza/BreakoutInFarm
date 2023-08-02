using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float minX;
    private float maxX;

    public float paddleOffsetX = 1.0f;
    public float paddleOffsetY = 1.0f;

    private float fixedYPosition;
    public bool touchBall;

    private Camera mainCamera;
    private float aspectRatio;

    private void Start()
    {
        mainCamera = Camera.main;
        aspectRatio = mainCamera.aspect;
        AdjustPosition();
    }

    private void Update()
    {
        if (touchBall)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 newPosition = new Vector2(Mathf.Clamp(mouseWorldPosition.x, minX, maxX), fixedYPosition);

            transform.position = newPosition;
        }

        if (mainCamera.aspect != aspectRatio)
        {
            aspectRatio = mainCamera.aspect;
            AdjustPosition();
        }
    }

    private void AdjustPosition()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * aspectRatio;

        maxX = (cameraWidth - paddleOffsetX) * Mathf.Sign(transform.position.x);
        minX = -maxX;

        fixedYPosition = (cameraHeight - paddleOffsetY) * Mathf.Sign(transform.position.y);

        Vector3 newPosition = transform.position;
        newPosition.y = fixedYPosition;
        transform.position = newPosition;
    }
}
