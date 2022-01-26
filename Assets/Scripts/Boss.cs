using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pattern
{
    Pattern1,
    Pattern2,
    Pattern3
}
public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject sinContainer;
    public GameObject sinBullet;

    public Transform pos;

    public float oneSinShoting;

    public Pattern pattern;

    void Start()
    {
        pattern = Pattern.Pattern1;
        StartCoroutine(CircleSinRotatePattern());
    }
    
    void Update()
    {
        
    }

    IEnumerator CircleSinRotatePattern()
    {
        float angle = 360 / oneSinShoting;

        do
        {
            for (int i = 0; i < oneSinShoting; i++)
            {
                GameObject obj;
                obj = Instantiate(sinContainer, transform.position, Quaternion.identity);
                //obj = Instantiate(sinContainer);
                //obj.transform.parent = parent;
                //obj.transform.localScale = new Vector3(1, 1, 1);
                obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneSinShoting - 90));
                Destroy(obj, 10f);
            }
            yield return new WaitForSeconds(10f);
        } while (true);
    }
}
