using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ray : MonoBehaviour
{
    public float rayDistance = 100f; // Längd på RayCast
    public LayerMask layerMask;    // Vilka lager RayCast ska interagera med
    public Transform target;       // Objektet som denna ska titta på
    public Player player;           //Tror inte den används till något just nu
    public GameObject DeadTxt;

    void Update()
    {

    }
    private void Awake()
    {
        DeadTxt = GameObject.Find("Dead");
        DeadTxt.SetActive(false);
        
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

         
            /*if (hit.collider.GetComponent<Rigidbody2D>().linearVelocity != Vector2.zero)
            {
                //Debug.Log("DEAD!!!!");
                DeadTxt.SetActive(true);
            }
            else
                DeadTxt.SetActive(false);*/
        }
        else
        {
            // Ritar en röd linje om RayCast inte träffar en spelare
            Debug.DrawLine(transform.position, transform.position + (Vector3)direction * rayDistance, Color.red);
            DeadTxt.SetActive(false);
        }
        if (player != null)
        {
            Vector2 playerVelocity = player.GetComponent<Rigidbody2D>().linearVelocity;
            //Debug.Log("Spelarens hastighet: " + playerVelocity);
        }
    }
}
