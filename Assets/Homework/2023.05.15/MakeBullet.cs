using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MakeBullet : MonoBehaviour
{
    [SerializeField] private float ShootSpeed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(transform.forward * ShootSpeed, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }
}
