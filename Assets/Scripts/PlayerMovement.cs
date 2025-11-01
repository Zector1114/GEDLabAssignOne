using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Subject
{
    [SerializeField] float speed = 5;
    [SerializeField] float jump = 5;
    Rigidbody2D rb;
    Collider2D col;

    public AudioClip jumpSFX;
    public AudioClip deathSFX;
    public bool grounded { get; private set; } = true;
    public bool isDead { get; private set; } = false;

    private Factory factory;
    private AudioManager audioManager;
    private GameManager gameManager;

    void Awake()
    {
        factory = FindObjectOfType<Factory>();
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        col.enabled = true;
    }

    void OnEnable()
    {
        if (audioManager) Attach(audioManager);
        if (factory) Attach(factory);
        if (gameManager) Attach(gameManager);
    }

    void OnDisable()
    {
        if (audioManager) Detach(audioManager);
        if (factory) Detach(factory);
        if (gameManager) Detach(gameManager);
    }

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

            NotifyObservers();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            isDead = true;
            col.enabled = false;

            NotifyObservers();
        }
    }
}
