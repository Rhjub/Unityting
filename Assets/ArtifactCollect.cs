using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;
        transform.Translate(movement * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Add points
            score += 10;
            scoreText.text = "Score: " + score;

            // Remove the collected object from the scene
            Destroy(other.gameObject);
        }
    }
}
