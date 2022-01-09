using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;

    private PlayerController player;

    private float speed = 7;
    private float xBoundary = -42;

    public int damage = 2;
    public int score = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameIsRunning)
        {
            rb.AddForce(Vector2.left * speed);

            if (transform.position.x < xBoundary)
            {
                MainManager.coins += score;
                Destroy(gameObject);
            }
        }
    }
}
