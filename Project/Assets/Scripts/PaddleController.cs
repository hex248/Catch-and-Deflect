using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum InputModes
{
    keyboard,
    mouse
}

[ExecuteAlways]
public class PaddleController : MonoBehaviour
{
    [SerializeField][Range(0,50)] float paddleSpeed = 5.0f;

    [SerializeField] float minX = -5.0f;
    [SerializeField] float maxX = 5.0f;
    [SerializeField] bool snapToMin = true;
    [SerializeField] float startX = 0.0f;

    bool holeOpen = false;
    GameManager gameManager;

    [SerializeField] Sprite openSprite;
    [SerializeField] Sprite closedSprite;

    [SerializeField]InputModes inputMode;

    void Start()
    {
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Application.IsPlaying(gameObject))
        {
            if (inputMode == InputModes.keyboard)
            {
                float horizontal = Input.GetAxisRaw("Horizontal");
                if (horizontal < 0)
                {
                    transform.position -= new Vector3(paddleSpeed * 2 * Time.deltaTime, 0.0f, 0.0f);
                }
                else if (horizontal > 0)
                {
                    transform.position += new Vector3(paddleSpeed * 2 * Time.deltaTime, 0.0f, 0.0f);
                }

                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    ToggleHole();
                }
            }
            else if (inputMode == InputModes.mouse)
            {
                transform.position = new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -1.8f, 1.8f), transform.position.y, transform.position.z);

                if (Input.GetMouseButtonDown(0))
                {
                    ToggleHole();
                }
            }
        }
        else {
            if (snapToMin)
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        
        

    }

    void ToggleHole()
    {
        if (holeOpen)
        {
            holeOpen = false;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = closedSprite;
        }
        else
        {
            holeOpen = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = openSprite;
        }
    }

    public void PaddleTrigger(Collider2D other)
    {
        if (other.gameObject.tag == "FallingObject")
        {
            if (holeOpen)
            {
                Destroy(other.gameObject);
                if (other.gameObject.GetComponent<FallingObject>().isGood)
                {
                    gameManager.ChangeScore(1);
                }
                else
                {
                    gameManager.ChangeScore(-1);
                }
            }
        }
    }
}
