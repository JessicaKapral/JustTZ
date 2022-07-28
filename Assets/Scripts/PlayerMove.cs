using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Transform plTransform;              // трансформ персонажа
    private Vector3 destinationPosition;        // направление точки
    private float destinationDistance;          // расстояние между ними
    public float moveSpeed;                     // скорость, просто скорость
    public float defaultSpeed;                  // переменная, чтобы из инспектора быстро менять скорость при необходимости

    public List<Vector3> posList = new List<Vector3>(); // тут хранятся наши точки, которые игрок натыкал
    bool isMove2Point = false;

    void Start()
    {
        plTransform = transform;                            
        destinationPosition = plTransform.position;         
    }

    void FixedUpdate()
    {

        MovementLogic();

        if (Input.GetMouseButtonDown(0))  // Игрок нажал на мышь
        {
            Plane playerPlane = new Plane(Vector3.down, plTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);

                posList.Add(targetPoint);
                Debug.Log("Добавлена позиция: " + posList.Count);
            }
        }
    }

    private void MovementLogic()
    {
        destinationDistance = Vector3.Distance(destinationPosition, plTransform.position);  // Отслеживает расстояние между объектом и точкой назначения

        if (destinationDistance < .5f)
        {
            moveSpeed = 0; // игрок не двигается, если расстояние меньше 0.5
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

 