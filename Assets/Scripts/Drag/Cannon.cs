using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public static Cannon instance;

    // 처음 클릭한 마우스 위치
    public Vector3 originPosition;

    // 마우스 클릭하고 드래그중인 실시간 좌표
    public Vector3 currentMousePosition;

    // 클릭중인지 여부
    private bool IsMouseClicked;

    // 마우스 드래그 벡터
    public Vector3 diffVector;

    // 마우스 드래그 normal 벡터
    private Vector3 diffNormalVector;

    // 드래그한 벡터의 길이
    private float diffVectorManitude;

    // 벡터를 통해서 구한 각도
    public float currentDegree;

    // 발사여부
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
                //Debug.Log("발사");
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
