using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    //adjust this to change speed
    float speed = 1.1f;
    //adjust this to change how high it goes
    float height = 0.1f;
    private float yin;

    private void Start()
    {
        yin = transform.position.y;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * speed);
        transform.position = (new Vector3(pos.x, yin+(newY* height), pos.z) );
    }
}
