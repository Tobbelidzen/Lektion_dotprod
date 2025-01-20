using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Spelarens rörelsehastighet
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Hämta referensen till Rigidbody2D-komponenten
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Läs in rörelseinput från tangentbordet
        float horizontal = Input.GetAxis("Horizontal"); // A/D eller vänster/höger
        float vertical = Input.GetAxis("Vertical");     // W/S eller upp/ner

        // Skapa en rörelsevektor
        movement = new Vector2(horizontal, vertical).normalized;
    }

    void FixedUpdate()
    {
        // Applicera kraft baserat på input
        rb.velocity = movement * speed;
    }
}
