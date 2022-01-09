using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer render;

    [SerializeField] private HealthBarController healthBar;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float jumpHeight = 700;

    private bool isOnGround;
    public bool gameIsRunning = true;

    private int maxHealth = 10;
    private int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        //render.material.color = MainManager.currentColour;

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsRunning)
        {
            jump();
            bars();
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpHeight);
        }
    }

    void bars()
    {
        if (health < 1)
        {
            gameIsRunning = false;
        }
        else if (health > 10)
        {
            health = 10;
        }
        healthBar.SetHealth(health);

        scoreText.text = "Coins: " + MainManager.coins;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else
        {
            Destroy(collision.gameObject);
            EnemyMove enemy = collision.gameObject.GetComponent<EnemyMove>();
            health -= enemy.damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
