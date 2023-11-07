using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float NewSprintSpeed;
    

    public bool isGrounded = true;
    private Rigidbody2D rb;

    public float teleportHeight = -9.0f; // Die Höhe, bei der der Spieler teleportiert wird
    public Vector3 teleportPosition = new Vector3(-9f, -90f, 0f); // Zielteleportposition

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Floor")
        {
            isGrounded = true;
        }

        //Sterben
        

        if (collision.collider.tag == "Respawn")
        {
            transform.position = new Vector3(-89f, -8f, 0f);

        }

    }


   



    private void Update()
    {
        if (Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.LeftShift))
        {
            transform.position -= new Vector3(NewSprintSpeed * Time.deltaTime, 0, 0);
        }

        // Spielerbewegung       
        if (Input.GetKey(KeyCode.A))
        {
            transform.position-= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }


        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(NewSprintSpeed * Time.deltaTime, 0, 0);
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }


        // Spieler springen
        // Prüfen, ob der Spieler den Boden berührt
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }

        




        // Überprüfen der Höhe und Teleportieren
        if (transform.position.y <= teleportHeight)
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        transform.position = teleportPosition;
    }
}
