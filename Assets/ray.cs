using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour
{
    public float rayDistance = 100f; // Längd på RayCast
    public LayerMask layerMask;    // Vilka lager RayCast ska interagera med
    public Transform target;       // Objektet som detta ska titta på
    public Player player;

    void Update()
    {

    }
    public void CheckVision()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned.");
            return;
        }

        // Beräkna riktningen mot målet
        Vector2 direction = (target.position - transform.position).normalized;

        // Utför RayCast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance, layerMask);

        // Kontrollera om RayCast träffar ett objekt
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            // Ritar en grön linje om RayCast träffar en spelare
            Debug.DrawLine(transform.position, hit.point, Color.green);

            if (hit.collider.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                Debug.Log("DEAD!!!!");
            }

        }
        else
        {
            // Ritar en röd linje om RayCast inte träffar en spelare
            Debug.DrawLine(transform.position, transform.position + (Vector3)direction * rayDistance, Color.red);
        }
        if (player != null)
        {
            Vector2 playerVelocity = player.GetComponent<Rigidbody2D>().velocity;
            Debug.Log("Spelarens hastighet: " + playerVelocity);
        }
    }
}
