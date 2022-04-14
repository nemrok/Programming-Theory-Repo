using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float zBound = 6.0f;
    private float yBound = 1.5f;
    private Rigidbody playerRb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int healthAmount;
    [SerializeField]
    private int scoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance().IsGameOver)
        {
            MovePlayer();
            ConstrainPlayerPosition();
        }
        else
        {
            gameObject.GetComponent<Animator>().enabled = false;
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;

            GameObject[] hearts = GameObject.FindGameObjectsWithTag("Health");
            foreach (GameObject heart in hearts)
            {
                heart.GetComponent<AnimationScript>().isAnimated = false;
                heart.GetComponent<AnimationScript>().isRotating = false;
            }
        }
    }

    // Move the player based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }
    
    // Prevent the player from leaving the top, bottom of the screen as bouncing too
    // high
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        else if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.y > yBound)
        {
            playerRb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance().RemoveHealth(other.gameObject.GetComponent<Enemy>().GetDamage());
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Health"))
        {
            GameManager.Instance().AddHealth(healthAmount);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Prey"))
        {
            GameManager.Instance().AddScorePoints(scoreAmount);
            Destroy(other.gameObject);
        }    
    }
}
