using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJump : MonoBehaviour
{
    Rigidbody rigidbody;

    [SerializeField]
    private int jumpForce = 5;              // 점프에 부여할 힘을 저장할 변수를 선언하고 어트리뷰트를 지정하여 인스펙터상에서 변경이 가능하게 한다.

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();          // rigidbody에 Rigidbody 컴포넌트를 저장하여 초기화한다.
    }

    private void Start()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // 게임이 시작되면 Rigidbody컴포넌트에 jumpForce 만큼의 힘을 위로 부여한다.
    }
}
