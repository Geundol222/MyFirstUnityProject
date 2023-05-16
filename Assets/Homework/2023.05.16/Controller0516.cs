using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller0516 : MonoBehaviour
{
    Vector3 moveDir;

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
        EngineSound.clip = Idle;
    }

    private void Start()
    {
        EngineSound.loop = true;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;


        EngineSound.clip = Driving;
        EngineSound.pitch += Time.deltaTime;
        if (EngineSound.pitch > 3)
            EngineSound.pitch = 3;
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
}
