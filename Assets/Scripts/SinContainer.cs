using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinContainer : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        StartCoroutine(SinPattern());
    }

    void Update()
    {
        
    }

    IEnumerator SinPattern()
    {
        do
        {
            GameObject g = Instantiate(bullet);
            g.transform.parent = gameObject.transform;
            //g.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            g.transform.position = transform.position;
            Destroy(g, 5f);
            yield return new WaitForSeconds(0.5f);
        } while (true);
    }
}
