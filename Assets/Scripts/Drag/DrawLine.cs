using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer lr;
    public Vector3 pos1, pos2;
    public GameObject end;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = .05f;
        lr.endWidth = .05f;

        pos1 = gameObject.GetComponent<Transform>().position;
        pos2 = end.transform.position;
    }

    void Update()
    {
        lr.SetPosition(0, pos1);
        lr.SetPosition(1, Cannon.instance.hitVector);
        lr.SetPosition(2, Cannon.instance.spVector);
    }
}
