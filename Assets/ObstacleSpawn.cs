using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{

    public List<GameObject> prefabs;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn(float progress)
    {


        Vector3 pos = new Vector3(-6 + Random.Range(0, 3) * 6, 0, progress + 150);
        Quaternion rot = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Count)], pos, rot);
        float rand = Random.Range(1, 3);
        obj.transform.localScale = new Vector3(rand, rand, rand);


    }
}
