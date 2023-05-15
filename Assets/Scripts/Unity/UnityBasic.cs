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
        // <���ӿ�����Ʈ ����?
        // ������Ʈ�� �پ��ִ� ���� ������Ʈ�� gameObject�Ӽ��� �̿��Ͽ� ���� ����

        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ
        // gameObject.name;         // ���ӿ�����Ʈ�� �̸� ����
        // gameObject.active;       // ���ӿ�����Ʈ�� Ȱ��ȭ ���� ����
        // gameObject.tag;          // ���ӿ�����Ʈ�� �±� ����
        // gameObject.layer;        // ���ӿ�����Ʈ�� ���̾� ����

        GameObject.Find("Player");                          // �̸����� ã��, �������, ������Ʈ�� ��������� ���� ó�� ã�� ������Ʈ�� ����
        GameObject.FindGameObjectWithTag("Player");         // �±׷� ã�� �� ����� ���� ****
        GameObject.FindGameObjectsWithTag("Player");        // �ش� �±׸� ���� ������Ʈ ��� ã��, �迭���·� ����

        // <���ӿ�����Ʈ ����>
        GameObject newObject = new GameObject("New Game Object");

        // <���ӿ�����Ʈ ����>
        Destroy(gameObject, 5f);            // ���� ü���� �� ����� ��� Destroy�� �Ἥ ������Ʈ ���� ���� ������ ���� float�� ���� �� �����ð�
    }

    public Rigidbody body;

    public void ComponentBasic()
    {
        // <���ӿ�����Ʈ �� ������Ʈ ����>
        GetComponent<AudioSource>();                        // ������Ʈ���� GetComponent�� ����� ��� �����Ǿ� �ִ� ���ӿ�����Ʈ�� �������� ����    ****
        GetComponents<AudioSource>();                       // ������Ʈ�� �������� �������� ������Ʈ ���� (�迭 ��ȯ��)                              ****
        gameObject.GetComponent<AudioSource>();             // ���ӿ�����Ʈ�� ������Ʈ ����                                                          ****
        gameObject.GetComponents<AudioSource>();            // ���ӿ�����Ʈ�� ���� ������Ʈ ����                                                     ****

        GetComponentInChildren<Rigidbody>();                // �ڽ� ���ӿ�����Ʈ�� ������ ������Ʈ ���� 
        GetComponentsInChildren<Rigidbody>();               // �ڽ� ���ӿ�����Ʈ�� ������ �������� ������Ʈ ���� => �������� ���� ���� ****
        gameObject.GetComponentInChildren<Rigidbody>();     // ���ӿ�����Ʈ�� �ڽ� ���ӿ�����Ʈ�� ������ ������Ʈ ����
        gameObject.GetComponentsInChildren<Rigidbody>();    // ���ӿ�����Ʈ�� �ڽ� ���ӿ�����Ʈ�� ������ ���� ������Ʈ ����

        // �� ������ ����
        GetComponentInParent<Rigidbody>();                  // �θ� ���ӿ�����Ʈ�� ������ ������Ʈ ���� 
        GetComponentsInParent<Rigidbody>();                 // �θ� ���ӿ�����Ʈ�� ������ �������� ������Ʈ ����
        gameObject.GetComponentInParent<Rigidbody>();       // ���ӿ�����Ʈ�� �θ� ���ӿ�����Ʈ�� ������ ������Ʈ ����
        gameObject.GetComponentsInParent<Rigidbody>();      // ���ӿ�����Ʈ�� �θ� ���ӿ�����Ʈ�� ������ ���� ������Ʈ ����

        // <������Ʈ Ž��> : ���� ���� �Լ�����, ������Ʈ�� �Ź� �˻�������ϱ� ������ �ð��� �����ɸ��� �ۿ� �����Ƿ� �� �����Ӹ��� ã�� ���� �������� ����
        FindObjectOfType<AudioSource>();                    // �� ���� ������Ʈ Ž��
        FindObjectsOfType<AudioSource>();                   // �� ���� ��� ������Ʈ Ž��

        // <������Ʈ �߰�>
        // Rigidbody rigid = new Rigidbody();               // ������ ������ �ǹ̰� ����, ������Ʈ�� ���ӿ�����Ʈ�� �����Ǿ� �����Կ� �ǹ̰� �ִ� ���̱� ���� ���� �������� ����
        gameObject.AddComponent<AudioSource>();             // ���ӿ�����Ʈ�� ������Ʈ �߰�

        // <������Ʈ ����>
        Destroy(GetComponent<Collider>());
    }
}
