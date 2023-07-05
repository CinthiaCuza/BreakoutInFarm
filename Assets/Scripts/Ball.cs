using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float maxSpeed;

    public UIController uiController;
    private void Update()
    {
        if (rb.velocity.magnitude > maxSpeed) rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) GameController.instance.GameOver();
        if (collision.gameObject.CompareTag("Apple")) Destroy(collision.gameObject);
    }
}