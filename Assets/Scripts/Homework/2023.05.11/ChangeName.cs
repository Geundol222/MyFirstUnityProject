using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeName : MonoBehaviour
{
    public GameObject gameObject;       // ���� ������Ʈ�� ������ ���� gameObject�� ������ְ� public���� �����Ͽ� �ν�����â���� ������Ʈ�� �־��� �� �ְ� �Ѵ�.

    private void Awake()
    {
        Debug.Log("��ũ �̸��� Player");
        gameObject.name = "Player";     // ������ ó�� �ʱ�ȭ �ɶ� Player�� �̸��� �ٲ��ش�.
    }
}
