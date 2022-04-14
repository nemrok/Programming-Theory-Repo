using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour
{
    public float speed = 50.0f;
    private float zDestroy = 10.0f;
    private Rigidbody objectRb;
    private GameObject innerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance().IsGameOver)
        {
            objectRb.AddForce(Vector3.forward * speed);

            if (transform.position.z > zDestroy)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().enabled = false;
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }
}
