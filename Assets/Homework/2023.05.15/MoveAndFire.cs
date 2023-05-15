using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAndFire : MonoBehaviour
{
    private Vector3 moveDir;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Header("Shooter")]
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private MakeBullet bullet;
    [SerializeField] private float repeatSpeed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void Rotate()
    {
        Quaternion rotation = Quaternion.Euler(0, moveDir.x * rotateSpeed * Time.deltaTime, 0);
        Vector3 rot = rotation.eulerAngles;     
        transform.Rotate(rot, Space.Self);          
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void OnFire(InputValue value)
    {
        Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
    }

    private Coroutine repeat;

    IEnumerator MakeBulletRoutine()
    {
        while(true)
        {
            Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
            yield return new WaitForSeconds(repeatSpeed);
        }
    }

    private void OnRepeatFire(InputValue value)
    {
        if (value.isPressed)
        {
            repeat = StartCoroutine(MakeBulletRoutine());
        }
        else
        {
            StopCoroutine(repeat);
        }
    }
}
