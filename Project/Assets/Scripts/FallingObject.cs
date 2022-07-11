using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public bool isGood;

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "DestroyBox")
        {
            if (isGood || col.gameObject.name == "Bottom Destroy")
            {
                gameManager.ChangeScore(-1);
            }
            else
            {
                gameManager.ChangeScore(1);
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Wall"))
        {
            Debug.Log("wall");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), gameManager.rotationSpeed * Time.deltaTime);
    }
}
