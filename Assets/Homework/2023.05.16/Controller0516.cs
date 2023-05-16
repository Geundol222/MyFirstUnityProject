using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller0516 : MonoBehaviour
{
    Vector3 moveDir;

    [Header("CM Camera")]
    [SerializeField] private CinemachineVirtualCamera main;
    [SerializeField] private CinemachineVirtualCamera turret;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateAngle;

    [Header("Shooter")]
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private Bullet0516 bullet;

    [Header("Sound")]
    [SerializeField] private AudioSource EngineSound;
    [SerializeField] private AudioSource ShootSound;
    [SerializeField] private AudioClip Idle;
    [SerializeField] private AudioClip Driving;

    private void Awake()
    {
        EngineSound.loop = true;
    }

    private void Start()
    {
        EngineSound.Play();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;

        EngineSound.clip = Driving;
        EngineSound.Play();
    }

    private void Move()
    {
        if (moveDir.x != 0 || moveDir.z != 0)
        {
            transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);

            EngineSound.pitch += Time.deltaTime / 2;
            if (EngineSound.pitch > 2)
                EngineSound.pitch = 2;
        }
        else if (moveDir.x == 0 && moveDir.z == 0)
        {
            EngineSound.pitch -= Time.deltaTime;
            if (EngineSound.pitch < 1)
                EngineSound.pitch = 1;
        }
               
    }

    private void Rotate()
    {
        Quaternion rotation = Quaternion.Euler(0, moveDir.x * rotateAngle * Time.deltaTime, 0);

        Vector3 eulerRotation = rotation.eulerAngles;

        transform.Rotate(eulerRotation, Space.Self);
    }

    private void OnFire()
    {
        ShootSound.Play();
        Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
    }

    private void OnCameraTransition(InputValue value)
    {
        if (value.isPressed)
        {
            main.Priority = 0;
            turret.Priority = 100;
            EngineSound.volume = 0.3f;
        }
        else
        {
            turret.Priority = 0;
            main.Priority = 100;
            EngineSound.volume = 1f;
        }
    }
}
