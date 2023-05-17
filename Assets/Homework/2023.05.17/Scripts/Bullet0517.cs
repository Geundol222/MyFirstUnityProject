using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet0517 : MonoBehaviour
{
    Rigidbody rb;
    MeshCollider mc;
    MeshRenderer mr;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject ImpactEffect;

    [SerializeField] private AudioSource explosionSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        mc = GetComponent<MeshCollider>();
    }

    private void Start()
    {
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ImpactEffect, transform.position, transform.rotation);
        mr.enabled = false;
        mc.enabled = false;
        explosionSound.Play();
        Destroy(gameObject, 1f);
    }
}
