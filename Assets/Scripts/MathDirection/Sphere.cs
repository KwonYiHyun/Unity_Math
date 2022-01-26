using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    public float speed;
    public float angle;
    Vector3 direction;
    bool enter;

    // Use this for initialization
    void Start()
    {
        angle = Mathf.Deg2Rad * angle;
        direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        enter = false;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enter)
            return;
        if (collision.gameObject.tag == "Player")
        {
            Vector3 incommingVector = direction;
            incommingVector = incommingVector.normalized;
            Vector3 normalVector = collision.contacts[0].normal;
            Debug.Log("Normal : " + normalVector);
            Vector3 reflectVector = Vector3.Reflect(incommingVector, normalVector);
            Debug.Log(reflectVector);
            direction = reflectVector.normalized;
            Debug.Log(direction);
            enter = true;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (enter)
    //        return;
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Vector3 incommingVector = direction;
    //        incommingVector = incommingVector.normalized;
    //        Vector3 normalVector = collision.contacts[0].normal;
    //        //Debug.Log("Normal : " + normalVector);
    //        Vector3 reflectVector = Vector3.Reflect(incommingVector, normalVector);
    //        Debug.Log(reflectVector);
    //        direction = reflectVector.normalized;
    //        //Debug.Log(direction);
    //        enter = true;
    //    }
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        enter = false;
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    enter = false;
    //}
}