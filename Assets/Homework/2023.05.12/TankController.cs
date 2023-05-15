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
        
        Vector3 rot = rotation.eulerAngles;         // ToEulerAngles를 사용하면 라디안으로 들어가기 때문에 원래 사용하는 EulerAngle의 값과는 다른 rotateSpeed가 필요함
                                                    // 이러한 이유로 ToEulerAngles는 유니티에서 더이상 권장되는 방식이 아니다.

        transform.Rotate(rot, Space.Self);          // 쿼터니언
        // transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
}
