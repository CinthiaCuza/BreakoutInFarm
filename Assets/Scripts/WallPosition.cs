using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPosition : MonoBehaviour
{
    public float wallOffset = 1.0f; 

    private Camera mainCamera;
    private float aspectRatio;

    private void Start()
    {
        mainCamera = Camera.main;
        aspectRatio = mainCamera.aspect;
        RepositionWall();
    }

    private void Update()
    {
        if (mainCamera.aspect != aspectRatio)
        {
            aspectRatio = mainCamera.aspect;
            RepositionWall();
        }
    }

    private void RepositionWall()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * aspectRatio;

        Vector3 newPosition = transform.position;

        if(transform.name == "Roof" || transform.name == "Floor")
            newPosition.y = (cameraHeight - wallOffset) * Mathf.Sign(transform.position.y);
        else
            newPosition.x = (cameraWidth - wallOffset) * Mathf.Sign(transform.position.x);

        transform.position = newPosition;
    }
}
