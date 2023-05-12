using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Vector3 moveDir;

    [SerializeField]
    private float moveSpeed;
    [SerializeField] 
    private float rotateSpeed;
    [SerializeField]
    private float jumpPower;

    private void Awake()
    {
       
    }

    private void Update()
    {
        Move();
        Rotate();
        // LookAt();
    }

    public void Move()
    {
        // transform.position += moveSpeed * moveDir * Time.deltaTime;     // deltaTime : �� �����Ӵ� �ɸ��� �ð�
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
        
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);
    }

    public void LookAt()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }

    public void Rotation()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 rotation = transform.rotation.ToEulerAngles();
    }

    private void Jump()
    {
        
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void OnJump(InputValue value)
    {
        Jump();
    }
}
