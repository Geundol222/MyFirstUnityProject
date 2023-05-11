using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJump : MonoBehaviour
{
    Rigidbody rigidbody;

    [SerializeField]
    private int jumpForce = 5;              // ������ �ο��� ���� ������ ������ �����ϰ� ��Ʈ����Ʈ�� �����Ͽ� �ν����ͻ󿡼� ������ �����ϰ� �Ѵ�.

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();          // rigidbody�� Rigidbody ������Ʈ�� �����Ͽ� �ʱ�ȭ�Ѵ�.
    }

    private void Start()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // ������ ���۵Ǹ� Rigidbody������Ʈ�� jumpForce ��ŭ�� ���� ���� �ο��Ѵ�.
    }
}
