using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreesPosition : MonoBehaviour
{
    private float screenWidth;

    public float newOffset = 1.0f;
    private float aspectRatio;

    public bool isInLeft;

    private void Start()
    {
        aspectRatio = Camera.main.aspect;

        screenWidth = Mathf.Abs(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x -
                                Camera.main.ScreenToWorldPoint(Vector3.zero).x);
    }

    private void Update()
    {
        Vector3 objectPosition = transform.position;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);

        float distanceToRightBorder = Screen.width - screenPosition.x;
        float distanceToLeftBorder = screenPosition.x;

        float distanceToRightEdge = distanceToRightBorder * (screenWidth / Screen.width);
        float distanceToLeftEdge = distanceToLeftBorder * (screenWidth / Screen.width);

        if (distanceToLeftEdge < newOffset && isInLeft || !isInLeft && distanceToRightEdge < newOffset)
        {
            float cameraWidth = Camera.main.orthographicSize * aspectRatio;
            objectPosition.x = (cameraWidth - newOffset) * Mathf.Sign(transform.position.x);
            transform.position = objectPosition;
        }
    }
}
