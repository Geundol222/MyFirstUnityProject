using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        GameObject Obj = GameObject.Find("Player");
        audioSource = Obj.GetComponent<AudioSource>();

        GameObjectBasic();
        ComponentBasic();
    }

    public void GameObjectBasic()
    {
        // <게임오브젝트 접근?
        // 컴포넌트가 붙어있는 게임 오브젝트는 gameObject속성을 이용하여 접근 가능

        // 컴포턴트가 붙어있는 게임오브젝트
        // gameObject.name;         // 게임오브젝트의 이름 접근
        // gameObject.active;       // 게임오브젝트의 활성화 여부 접근
        // gameObject.tag;          // 게임오브젝트의 태그 접근
        // gameObject.layer;        // 게임오브젝트의 레이어 접근

        GameObject.Find("Player");                          // 이름으로 찾기, 느린방식, 오브젝트가 많아질경우 가장 처음 찾은 오브젝트를 참조
        GameObject.FindGameObjectWithTag("Player");         // 태그로 찾기 이 방식을 권장 ****
        GameObject.FindGameObjectsWithTag("Player");        // 해당 태그를 가진 오브젝트 모두 찾기, 배열형태로 나옴

        // <게임오브젝트 생성>
        GameObject newObject = new GameObject("New Game Object");

        // <게임오브젝트 삭제>
        Destroy(gameObject, 5f);            // 만약 체력이 다 닳았을 경우 Destroy를 써서 오브젝트 삭제 등을 진행함 뒤의 float은 삭제 전 유예시간
    }

    public Rigidbody body;

    public void ComponentBasic()
    {
        // <게임오브젝트 내 컴포넌트 접근>
        GetComponent<AudioSource>();                        // 컴포넌트에서 GetComponent를 사용할 경우 부착되어 있는 게임오브젝트를 기준으로 접근    ****
        GetComponents<AudioSource>();                       // 컴포넌트를 기준으로 여러개의 컴포넌트 접근 (배열 반환형)                              ****
        gameObject.GetComponent<AudioSource>();             // 게임오브젝트의 컴포넌트 접근                                                          ****
        gameObject.GetComponents<AudioSource>();            // 게임오브젝트의 여러 컴포넌트 접근                                                     ****

        GetComponentInChildren<Rigidbody>();                // 자식 게임오브젝트를 포함한 컴포넌트 접근 
        GetComponentsInChildren<Rigidbody>();               // 자식 게임오브젝트를 포함한 여러개의 컴포넌트 접근 => 생각보다 많이 사용됨 ****
        gameObject.GetComponentInChildren<Rigidbody>();     // 게임오브젝트의 자식 게임오브젝트를 포함한 컴포넌트 접근
        gameObject.GetComponentsInChildren<Rigidbody>();    // 게임오브젝트의 자식 게임오브젝트를 포함한 여러 컴포넌트 접근

        // 잘 사용되지 않음
        GetComponentInParent<Rigidbody>();                  // 부모 게임오브젝트를 포함한 컴포넌트 접근 
        GetComponentsInParent<Rigidbody>();                 // 부모 게임오브젝트를 포함한 여러개의 컴포넌트 접근
        gameObject.GetComponentInParent<Rigidbody>();       // 게임오브젝트의 부모 게임오브젝트를 포함한 컴포넌트 접근
        gameObject.GetComponentsInParent<Rigidbody>();      // 게임오브젝트의 부모 게임오브젝트를 포함한 여러 컴포넌트 접근

        // <컴포넌트 탐색> : 많이 쓰는 함수지만, 컴포넌트를 매번 검색해줘야하기 때문에 시간이 오래걸릴수 밖에 없으므로 매 프레임마다 찾는 것은 권장하지 않음
        FindObjectOfType<AudioSource>();                    // 씬 내의 컴포넌트 탐색
        FindObjectsOfType<AudioSource>();                   // 씬 내의 모든 컴포넌트 탐색

        // <컴포넌트 추가>
        // Rigidbody rigid = new Rigidbody();               // 가능은 하지만 의미가 없음, 컴포넌트는 게임오브젝트에 부착되어 동작함에 의미가 있는 것이기 때문 따라서 권장하지 않음
        gameObject.AddComponent<AudioSource>();             // 게임오브젝트에 컴포넌트 추가

        // <컴포넌트 삭제>
        Destroy(GetComponent<Collider>());
    }
}
