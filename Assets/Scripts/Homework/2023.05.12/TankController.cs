using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    private Vector3 moveDir;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);  // 이동
    }

    private void Rotate()
    {
        Quaternion rotation = Quaternion.Euler(0, moveDir.x * rotateSpeed * Time.deltaTime, 0);
        
        Vector3 rot = rotation.eulerAngles;
        
        transform.Rotate(rot, Space.Self);                              // ?? 돌아가긴 하는데 맞는진 모르겠습니다. rotateSpeed 값을 5000은 줘야 만족스럽게 돌아갑니다.

        // transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
}
