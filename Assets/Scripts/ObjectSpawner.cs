using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] allObjects;
    [SerializeField] Transform objectsParent;

    [SerializeField] float timePassed;
    [SerializeField] float interval = 2.0f;

    void Update()
    {
        if (timePassed >= interval)
        {
            timePassed = 0;
            interval = Mathf.Clamp(interval * 0.99f, 0.2f, 3.0f);
            Spawn();
        }
        timePassed += Time.deltaTime;
    }

    public void Spawn()
    {
        GameObject randomObj = allObjects[Random.Range(0, allObjects.Length)];
        GameObject spawnedObj = Instantiate(randomObj, new Vector3(Random.Range(-2.4f, 2.4f), transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, Random.Range(0,360))), objectsParent);
        float direction = Random.Range(-10, 10);
        float force = 10.0f;
        spawnedObj.GetComponent<Rigidbody2D>().velocity = new Vector2(direction,-force);
    }
}
