using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveDir;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Header("Shooter")]
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float repeatTime;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Rotate();
        // LookAt();
    }

    // <MVC ����>
    // OnMove();        // �Է� input
    // Move();          // ó�� Controller
    // OnMoved();       // ������ Model + �̺�Ʈ


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
        Vector3 rotation = transform.rotation.eulerAngles;
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);  // ������ �ν��Ͻ�ȭ ��ȯ���� GameObject

        animator.SetTrigger("Fire");
    }

    private void OnFire(InputValue value)
    {
        Fire();
    }

    private Coroutine bulletRoutine;

    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            yield return new WaitForSeconds(repeatTime);
        }
    }

    private void OnRepeatFire(InputValue value)
    {
        if (value.isPressed)
        {
            bulletRoutine = StartCoroutine(BulletMakeRoutine());
        }
        else
        {
            StopCoroutine(bulletRoutine);
        }
    }
}
