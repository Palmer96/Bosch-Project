using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BansheeGz.BGSpline.Components;
using UnityStandardAssets.Vehicles.Car;
public class MyCurve : MonoBehaviour
{

    public CameraFollow walls;
    public GameObject car;
    public GameObject cart;
    public float distance;
    public float speed;
    public float timer;

    // Use this for initialization
    void Start()
    {
        GetComponent<BGCcCursor>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            GetComponent<BGCcCursor>().enabled = true;
            GetComponent<BGCcCursor>().Distance += speed * Time.deltaTime;
            transform.GetChild(0).GetComponent<BGCcCursor>().Distance += speed * Time.deltaTime;

            if (GetComponent<BGCcCursor>().Distance >= 38)
            {
                walls.enabled = true;
                if (car)
                    car.GetComponent<CarUserControl>().disabled = false;
                //cart
                Destroy(transform.GetChild(0).gameObject);
                Destroy(gameObject);
            }
        }
    }
}
