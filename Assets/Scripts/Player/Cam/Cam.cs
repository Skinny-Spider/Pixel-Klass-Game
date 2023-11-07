using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5.0f; // Anpassbare Geschwindigkeit der Kameraverfolgung
    public float horizontalOffset = 2.0f; // Anpassbares horizontales Kamera-Offset

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        float targetX = player.position.x + offset.x;
        float targetY = player.position.y + offset.y;

        // Anpassen des horizontalen Offsets basierend auf der Bewegungsrichtung des Spielers
        if (player.position.x < transform.position.x - horizontalOffset)
        {
            targetX = player.position.x + horizontalOffset;
        }
        else if (player.position.x > transform.position.x + horizontalOffset)
        {
            targetX = player.position.x - horizontalOffset;
        }

        Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z);

        // Verwenden Sie die Lerp-Funktion, um die Kamera glatt zu verfolgen
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
