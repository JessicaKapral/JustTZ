using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    //���� ������� ������ ��������� ���������
    private void FixedUpdate()
    {
        Quaternion rotationY = Quaternion.AngleAxis(1, Vector3.up);
        transform.rotation *= rotationY;
    }
}
