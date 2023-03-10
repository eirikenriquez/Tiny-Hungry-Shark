using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParaTest : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    private float length;
    private float startPos;
    private GameObject cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}

