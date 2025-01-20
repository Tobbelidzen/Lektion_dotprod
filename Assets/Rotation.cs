using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;

    void Start()
    {
        // Spara objektets ursprungliga rotation
        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0, 0, 180);

        // Starta rotationssekvensen
        StartCoroutine(RotateSequence());
    }

    IEnumerator RotateSequence()
    {
        while (true) // Loopar oändligt
        {
            // Rotera 180 grader
            yield return StartCoroutine(RotateOverTime(targetRotation, 1f));

            // Vänta i 5 sekunder
            yield return new WaitForSeconds(5f);

            // Rotera tillbaka till ursprungsläget
            yield return StartCoroutine(RotateOverTime(initialRotation, 1f));

            // Vänta i 5 sekunder innan nästa iteration
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator RotateOverTime(Quaternion target, float duration)
    {
        if (isRotating) yield break;

        isRotating = true;

        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Säkerställ att rotationen blir exakt den önskade
        transform.rotation = target;

        isRotating = false;
    }
}
