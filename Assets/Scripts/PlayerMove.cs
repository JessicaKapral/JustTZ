using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Transform plTransform;              // ��������� ���������
    private Vector3 destinationPosition;        // ����������� �����
    private float destinationDistance;          // ���������� ����� ����
    public float moveSpeed;                     // ��������, ������ ��������
    public float defaultSpeed;                  // ����������, ����� �� ���������� ������ ������ �������� ��� �������������

    public List<Vector3> posList = new List<Vector3>(); // ��� �������� ���� �����, ������� ����� �������
    bool isMove2Point = false;

    void Start()
    {
        plTransform = transform;                            
        destinationPosition = plTransform.position;         
    }

    void FixedUpdate()
    {

        MovementLogic();

        if (Input.GetMouseButtonDown(0))  // ����� ����� �� ����
        {
            Plane playerPlane = new Plane(Vector3.down, plTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);

                posList.Add(targetPoint);
                Debug.Log("��������� �������: " + posList.Count);
            }
        }
    }

    private void MovementLogic()
    {
        destinationDistance = Vector3.Distance(destinationPosition, plTransform.position);  // ����������� ���������� ����� �������� � ������ ����������

        if (destinationDistance < .5f)
        {
            moveSpeed = 0; // ����� �� ���������, ���� ���������� ������ 0.5
            if (isMove2Point)
            {
                isMove2Point = false;
                posList.RemoveAt(0);
                Debug.Log("Pos achived");
            }
        }
        else if (destinationDistance > .5f)
        {
            moveSpeed = defaultSpeed; 
        }

        if(posList.Count > 0 && !isMove2Point)
        {
            destinationPosition = posList[0];
            Quaternion targetRotation = Quaternion.LookRotation(destinationPosition - transform.position);
            plTransform.rotation = targetRotation;
            isMove2Point = true;
        }
        

        if (destinationDistance > .5f)
        {
            plTransform.position = Vector3.MoveTowards(plTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
        }
    }


  
}

 