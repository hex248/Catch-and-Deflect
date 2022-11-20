using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHighlight : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;

    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, 25.0f * Time.deltaTime);
            if (transform.position.y == endPos.y)
            {
                moving = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                moving = true;
                transform.position = startPos;
            }
        }
    }

}
