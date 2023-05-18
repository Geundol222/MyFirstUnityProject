using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootCountView0518 : MonoBehaviour
{
    private int shootCount;

    private TMP_Text textView0518;

    private void Awake()
    {
        textView0518 = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        GameManager0518.DM.OnShootCountChanged += ChangeText;
    }

    private void OnDisable()
    {
        GameManager0518.DM.OnShootCountChanged -= ChangeText;
    }

    private void ChangeText(int count)
    {
        textView0518.text = count.ToString();
    }
}
