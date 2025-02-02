using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rb;

    private Camera mainCamera;

    // Player Movement
    private float verticalMovement;
    private float horizontalMovement;
    private float speedMovement = 5f;
    private float speedLimiter = 0.7f;
    private Vector2 velocityMovement;

    // Mouse position
    private Vector2 mousePos;
    private Vector2 mouseOffset;

    // Bullet logic
    [SerializeField] private GameObject bullets;
    [SerializeField] private GameObject bulletSpawn;
    private bool isShooting = false;
    private float speedBullet = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Player Movement
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        velocityMovement = new Vector2(horizontalMovement, verticalMovement) * speedMovement;

        // Shooting logic
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
        }
    }

    private void FixedUpdate()
    {
        // To move the player
        MovePlayer();
        RotatePlayer();

        // Shooting logic
        if (isShooting)
        {
            StartCoroutine(Fire());
        }
    }

    private void MovePlayer()
    {
        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            if (horizontalMovement != 0 && verticalMovement != 0)
            {
                velocityMovement *= speedLimiter;
            }
            rb.velocity = velocityMovement;
        }
        else
        {
            velocityMovement = new Vector2(0f, 0f);
            rb.velocity = velocityMovement;
        }
    }

    private void RotatePlayer()
    {
        // Making player rotate to mouse position
        mousePos = Input.mousePosition;
        Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.localPosition);
        mouseOffset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y).normalized;

        // Angle/direction player needs to move to rotate to mouse position
        float angle = Mathf.Atan2(mouseOffset.y, mouseOffset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }

    private IEnumerator Fire()
    {
        isShooting = false;
        GameObject bullet = Instantiate(bullets, bulletSpawn.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = mouseOffset * speedBullet;
        yield return new WaitForSeconds(3);
        Destroy(bullet);
    }
}
