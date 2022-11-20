using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTrigger : MonoBehaviour
{
    PaddleController paddleController;
    void Start()
    {
        paddleController = transform.parent.gameObject.GetComponent<PaddleController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        paddleController.PaddleTrigger(other);
    }
}
