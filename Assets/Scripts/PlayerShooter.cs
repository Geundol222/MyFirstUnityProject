using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float repeatTime;

    public UnityEvent OnFired;

    public void Fire()
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);  // 프리팹 인스턴스화 반환형은 GameObject

        GameManager.Data.AddShootCount(1);
        OnFired?.Invoke();
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
            OnFired?.Invoke();
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

    public void Test(int count)
    {
        Debug.Log($"데이터의 슛 카운트가 {count}만큼 변했습니다.");
    }
}
