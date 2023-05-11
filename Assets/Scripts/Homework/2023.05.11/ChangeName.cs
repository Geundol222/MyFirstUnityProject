using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeName : MonoBehaviour
{
    public GameObject gameObject;

    private void Awake()
    {
        gameObject.name = "Player";
    }
}
