using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float scrollAmount;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public Vector3 moveDirection;

    public void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if(transform.position.x <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount;
        }
    }
}
