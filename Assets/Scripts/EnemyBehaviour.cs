using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;

    // Enemy movement
    private float enemySpeedMovement = 2f;
    private Quaternion targetRotation;
    private Vector2 moveDirection;

    // When Enemy is hit
    private float enemyHealth = 100f;
    private bool disableEnemy = false;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameManager.gameOver && !disableEnemy)
        {
            MoveEnemy();
            RotateEnemy();
        }
    }

    private void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeedMovement * Time.deltaTime);
    }

    private void RotateEnemy()
    {
        moveDirection = player.transform.position - transform.position;
        moveDirection.Normalize();

        targetRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);

        if (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 200 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(Damaged());

            enemyHealth -= 20f;

            if (enemyHealth <= 0f)
            {
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            gameManager.gameOver = true;
            collision.gameObject.SetActive(false);
        }
    }

    private IEnumerator Damaged()
    {
        disableEnemy = true;
        yield return new WaitForSeconds(0.5f);
        disableEnemy = false;
    }
}
