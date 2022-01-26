using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public static Cannon instance;

    // ó�� Ŭ���� ���콺 ��ġ
    public Vector3 originPosition;

    // ���콺 Ŭ���ϰ� �巡������ �ǽð� ��ǥ
    public Vector3 currentMousePosition;

    // Ŭ�������� ����
    private bool IsMouseClicked;

    // ���콺 �巡�� ����
    public Vector3 diffVector;

    // ���콺 �巡�� normal ����
    private Vector3 diffNormalVector;

    // �巡���� ������ ����
    private float diffVectorManitude;

    // ���͸� ���ؼ� ���� ����
    public float currentDegree;

    // �߻翩��
    private bool fireConfirm;

    public Vector3 lineVector;

    public Vector3 hitVector;

    public Vector3 spVector;

    //public GameObject Laser;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //originPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            originPosition = transform.position;
            IsMouseClicked = true;
        }else if (Input.GetMouseButtonUp(0))
        {
            //Laser.SetActive(false);
            IsMouseClicked = false;
            if (fireConfirm)
            {
                //Debug.Log("�߻�");
            }
        }

        if (IsMouseClicked)
        {
            currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            diffVector = (currentMousePosition - originPosition) * -1;
            diffVectorManitude = diffVector.magnitude;
            diffNormalVector = diffVector.normalized;

            float rot_z = Mathf.Atan2(diffNormalVector.y, diffNormalVector.x) * Mathf.Rad2Deg;

            if(CheckHasPower() && rot_z > 0)
            {
                currentDegree = Mathf.Clamp(rot_z - 90, -65, 65);
                transform.rotation = Quaternion.AngleAxis(currentDegree, Vector3.forward);
                fireConfirm = true;
                //Laser.SetActive(true);
            }
            else
            {
                fireConfirm = false;
                //Laser.SetActive(false);
            }

            Vector3 dir = originPosition - currentMousePosition;
            lineVector = dir + originPosition;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dir.magnitude);
            if (hit)
            {
                hitVector = hit.point;
            }
            Debug.DrawRay(transform.position, dir, Color.red);

            Vector3 d = originPosition - hitVector;
            Vector3 s = new Vector3(d.x, d.y * -1, d.z);
            spVector = hitVector + s;
        }
    }

    private bool CheckHasPower()
    {
        return diffVectorManitude > 1.5f;
    }
}
