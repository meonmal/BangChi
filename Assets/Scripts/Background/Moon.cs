using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float minRightEnd = 30.0f;
    public float maxRightEnd = 50.0f;

    public float minY = -7.0f;
    public float maxY = 8.0f;

    float baseLineX;

    private void Start()
    {
        baseLineX = transform.position.x;
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * Vector3.left);
        if(transform.position.x < baseLineX)
        {
            transform.position = new Vector3(
                Random.Range(minRightEnd, maxRightEnd),
                Random.Range(minY, maxY));
        }
    }
}
