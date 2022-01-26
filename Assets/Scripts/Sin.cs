using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : MonoBehaviour
{
    public float speed = 1f;
    public float length = 1f;
    public float movSpeed = 3f;

    public float runningTime = 0f;
    public float yPos = 0f;

    private Transform startPosition;

    void Start()
    {
        startPosition = transform;
    }
    
    void Update()
    {
        runningTime += Time.deltaTime * speed;
        yPos = Mathf.Sin(runningTime) * length;
        Debug.Log(yPos);
        //transform.position = new Vector2(runningTime * 0.7f, yPos);
        transform.localPosition = new Vector2(startPosition.localPosition.x + Time.deltaTime * movSpeed, yPos);
        //transform.position = new Vector2(startPosition.position.x + Time.deltaTime * movSpeed, yPos);
    }
}
