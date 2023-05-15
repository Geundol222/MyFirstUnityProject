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
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);  // �̵�
    }

    private void Rotate()
    {
        Quaternion rotation = Quaternion.Euler(0, moveDir.x * rotateSpeed * Time.deltaTime, 0);
        
        Vector3 rot = rotation.eulerAngles;         // ToEulerAngles�� ����ϸ� �������� ���� ������ ���� ����ϴ� EulerAngle�� ������ �ٸ� rotateSpeed�� �ʿ���
                                                    // �̷��� ������ ToEulerAngles�� ����Ƽ���� ���̻� ����Ǵ� ����� �ƴϴ�.

        transform.Rotate(rot, Space.Self);          // ���ʹϾ�
        // transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
}
