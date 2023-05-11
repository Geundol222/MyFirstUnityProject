using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeName : MonoBehaviour
{
    public GameObject gameObject;       // 게임 오브젝트를 저장할 변수 gameObject를 만들어주고 public으로 선언하여 인스펙터창에서 오브젝트를 넣어줄 수 있게 한다.

    private void Awake()
    {
        Debug.Log("탱크 이름은 Player");
        gameObject.name = "Player";     // 게임이 처음 초기화 될때 Player로 이름을 바꿔준다.
    }
}
