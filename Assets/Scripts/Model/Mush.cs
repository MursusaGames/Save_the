using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mush : MonoBehaviour
{
    public float radius = 5f; // ������ ��������
    public float speed = 1f; // �������� ��������

    private float _angle; // ������� ����

    private void Update()
    {
        _angle += speed * Time.deltaTime; // ����������� ���� �� ������� � ��������

        // ��������� ����� ���������� ������� �� ���������� � ������� ������������������ �������
        float x = Mathf.Cos(_angle) * radius;
        float y = Mathf.Sin(_angle) * radius;

        transform.localPosition = new Vector3(x, y, transform.localPosition.z); // ��������� ������� �������
    }
}
