using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject obj;

    // Use this for initialization
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z + 11 < obj.transform.position.z)
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<ObstacleSpawn>().Spawn(transform.position.z);
            Destroy(gameObject);
        }
    }
}
