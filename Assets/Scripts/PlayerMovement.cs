using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float jump = 5;
    Rigidbody2D rb;
    Collider2D col;
    bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        col.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("d"))
        {
            rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("space") && grounded)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            col.enabled = false;
        }
    }
}
