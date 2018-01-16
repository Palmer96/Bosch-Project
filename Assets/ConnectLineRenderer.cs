using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLineRenderer : MonoBehaviour
{

    public Transform obj1;
    public Transform obj2;

    LineRenderer line;
    
    // Use this for initialization
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, obj1.position);
        line.SetPosition(1, obj2.position);
    }
}
