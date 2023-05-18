using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Transform bulletPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float repeatTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);  // ������ �ν��Ͻ�ȭ ��ȯ���� GameObject

        animator.SetTrigger("Fire");

        GameManager.Data.AddShootCount(1);
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
            animator.SetTrigger("Fire");
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
