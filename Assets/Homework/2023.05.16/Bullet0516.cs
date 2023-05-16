using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet0516 : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject ImpactEffect;

    [SerializeField] private AudioSource explosionSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ImpactEffect, transform.position, transform.rotation);
        explosionSound.Play();
        Destroy(gameObject);
    }
}
