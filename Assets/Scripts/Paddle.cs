using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    private float valueMov;

    private void Update()
    {
        valueMov = Input.GetAxis("Horizontal");

        if (valueMov != 0)
        {
            transform.Translate(valueMov * speed * Time.deltaTime, 0f, 0f);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        }
    }
}
