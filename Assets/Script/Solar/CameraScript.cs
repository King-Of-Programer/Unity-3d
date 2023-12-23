using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;

    private float camEulerX;
    private float camEulerY;
    private float camSunEulerX;
    private float camSunEulerY;
    private Vector3 camSun; // ������ ����� -> ������

    private Camera _camera;
    

    private void Awake()
    {
        Debug.Log("Awake: " + LabirintState.checkPoint1Amount);
    }
    void Start()
    {
        camEulerX = this.transform.eulerAngles.x;
        camEulerY = this.transform.eulerAngles.y;
        camSun = sun.transform.position - this.transform.position;
        camSunEulerX = 0;
        camSunEulerY = 0;
        _camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X"); // �� �� ����������, � ���
        float my = Input.GetAxis("Mouse Y"); // ��� ����������� ����
        camEulerX -= my;
        camEulerY += mx;
        //this.transform.Rotate(-my, mx, 0);
        if (Input.GetMouseButton(0))
        {
            camSunEulerX -= my;
            camSunEulerY += mx;
        }
    }
    private void LateUpdate()
    {
        // ������� ������ ������� ����� ������
        this.transform.eulerAngles = new Vector3(camEulerX, camEulerY, 0f);
        // ������� ������� camSun
        if(Input.GetMouseButton(0)) 
        {
            this.transform.position =
           sun.transform.position -
           Quaternion.Euler(camSunEulerX, camSunEulerY, 0) * camSun;
        }
        Vector2 scroll = Input.mouseScrollDelta;
        if (scroll != Vector2.zero)
        {
            float newValue = _camera.fieldOfView - scroll.y;
            if (newValue >= 5 && newValue <= 120)
            {
                _camera.fieldOfView -= scroll.y;
            }
            else
            {
                if (_camera.fieldOfView < 5f) _camera.fieldOfView = 5f;
                if (_camera.fieldOfView > 120f) _camera.fieldOfView = 120f;
            }
        }
    }

}
/* ��������� �������
 * 1. ��������� ������ ����
 *  - ������������ ����� this.transform.Rotate(-my, mx, 0);
 *      ������� �� ���� ���� ���������� �� ������ �������� �� ����� ��.
 *      "������� �����������" ��� ���������� �� ��� ����.
 *  - ���� ���������� �����: ������������� �������������
 *      ���� �������� (���� ������) �� ����������� �������� 0 ��� Z
 * 2.г�� ������ ���������
 *  -��������� ����� ������� ���� ��
 *  -��������� ������� ������� ������ (���� �������)
 * 3.����������� ����� 
 *  -����� ���� ���� - ��������� ������� ������ ��
 *  -��� �� ���������� ������� - ��������� ������� �����
 */
