using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMover0518 : MonoBehaviour
{
    private Vector3 moveDir;

    private Vector3 turretDir;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateAngle;

    [SerializeField] private AudioSource EngineSound;

    public UnityEvent OnMoved;
    public UnityEvent OnStoped;

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
    }

    private void Move()
    {
        if (moveDir.x != 0 || moveDir.z != 0)
        {
            transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
            OnMoved?.Invoke();
        }
        else if (moveDir.x == 0 && moveDir.z == 0)
        {
            OnStoped?.Invoke();
        }
    }

    private void Rotate()
    {
        Quaternion rotation = Quaternion.Euler(0, moveDir.x * rotateAngle * Time.deltaTime, 0);

        Vector3 eulerRotation = rotation.eulerAngles;

        transform.Rotate(eulerRotation, Space.Self);
    }

    private void OnTurretRotate()
    {

    }

    public void MovePitch()
    {
        EngineSound.pitch += Time.deltaTime / 2;
        if (EngineSound.pitch > 2)
            EngineSound.pitch = 2;
    }

    public void StopPitch()
    {
        EngineSound.pitch -= Time.deltaTime;
        if (EngineSound.pitch < 1)
            EngineSound.pitch = 1;
    }
}
