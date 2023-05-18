using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera0518 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera main;
    [SerializeField] private CinemachineVirtualCamera turret;

    [SerializeField] private AudioSource EngineSound;

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
