using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShooter0518 : MonoBehaviour
{
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private Bullet0518 bullet;

    public UnityEvent OnFired;

    public void Fire()
    {
        Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);

        GameManager0518.DM.AddShootCount(1);
        OnFired?.Invoke();
    }
    private void OnFire()
    {
        Fire();
    }
}
