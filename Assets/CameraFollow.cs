using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
   public GameObject obj;
    public Vector3 offset;

    public bool lerp;
    public bool xBool;
    public bool yBool;
    public bool zBool;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = obj.transform.position + offset;

        if (!xBool)
            pos.x = 0;

        if (!yBool)
            pos.y = 0;

        if (!zBool)
            pos.z = 0;
        if (lerp)
            transform.position = Vector3.Lerp(transform.position, pos, 0.1f);
        else
            transform.position = pos;
    }
}
