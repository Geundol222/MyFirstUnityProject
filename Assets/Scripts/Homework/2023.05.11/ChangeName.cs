using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeName : MonoBehaviour
{
    public GameObject gameObject;       // ���� ������Ʈ�� ������ ���� gameObject�� ������ְ� public���� �����Ͽ� �ν�����â���� ������Ʈ�� �־��� �� �ְ� �Ѵ�.

    private void Awake()
    {
        gameObject.name = "Player";     // ������ ó�� �ʱ�ȭ �ɶ� Player�� �̸��� �ٲ��ش�.
    }
}
