using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject sinContainer;
    public GameObject sinBullet;

    public Transform pos;

    public float rotSpeed;

    public float movSpeed;
    public float oneShoting;
    public float oneSinShoting;

    void Start()
    {
        StartCoroutine(CirclePattern());
    }

    void Update()
    {
        
    }

    IEnumerator CirclePattern()
    {
        do
        {
            pos.transform.Rotate(Vector3.forward * rotSpeed * 100 * Time.deltaTime);

            GameObject g = Instantiate(bullet);
            Destroy(g, 2f);
            g.transform.position = pos.transform.position;
            g.transform.rotation = pos.transform.rotation;

            yield return new WaitForSeconds(0.01f);
        } while (true);
    }

    IEnumerator CircleRotatePattern()
    {
        float angle = 360 / oneShoting;

        do
        {
            for (int i = 0; i < oneShoting; i++)
            {
                GameObject obj;
                obj = (GameObject)Instantiate(bullet2, transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(movSpeed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), movSpeed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));
                obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoting - 90));
                Destroy(obj, 2f);
            }
            yield return new WaitForSeconds(4f);
        } while (true);
    }
}
