using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTranform : MonoBehaviour
{
    /************************************************************************
	* Ʈ������ (Transform)
	* 
	* ���ӿ�����Ʈ�� ��ġ, ȸ��, ũ�⸦ �����ϴ� ������Ʈ
	* ���ӿ�����Ʈ�� �θ�-�ڽ� ���¸� �����ϴ� ������Ʈ
	* ���ӿ�����Ʈ�� �ݵ�� �ϳ��� Ʈ������ ������Ʈ�� ������ ������ �߰� & ������ �� ����
	************************************************************************/

    private void Start()
    {
		TranslateMove();
    }

    private void TranslateMove()
	{
		transform.position = new Vector3(10, 10, 10);
		transform.localScale = new Vector3(3, 3, 3);
	}

    // <Quarternion & Euler>
    // Quarternion	: ����Ƽ�� ���ӿ�����Ʈ�� 3���� ������ �����ϰ� �̸� ���⿡�� �ٸ� ���������� ��� ȸ������ ����
    //				  �������� ȸ������ ������ ������ �߻����� ����
    // EulerAngle	: 3���� �������� ���������� ȸ����Ű�� ���
    //				  ������������ ������ ������ �߻��Ͽ� ȸ���� ��ġ�� ���� ���� �� ����
    // ������		: ���� �������� ������Ʈ�� �� ȸ�� ���� ��ġ�� ����

    // Quarternion�� ���� ȸ�������� ����ϴ� ���� ���������� �ʰ� �����ϱ� �����
    // ������ ��� ���ʹϾ� -> ���Ϸ����� -> �������� -> ������Ϸ����� -> ������ʹϾ� �� ���� ������ ��� ���ʹϾ��� �����
    private void Rotation()
    {
        // Ʈ�������� ȸ������ Euler���� ǥ���� �ƴ� Quaternion�� �����
        transform.rotation = Quaternion.identity;

        // Euler������ Quaternion���� ��ȯ
        transform.rotation = Quaternion.Euler(0, 90, 0);
        Vector3 rotation = transform.rotation.eulerAngles;
    }

    // <Ʈ������ �θ�-�ڽ� ����>
    // Ʈ�������� �θ� Ʈ�������� ���� �� ����
    // �θ� Ʈ�������� �ִ� ��� �θ� Ʈ�������� ��ġ, ȸ��, ũ�� ������ ���� �����
    // �̸� �̿��Ͽ� ������ ������ �����ϴµ� ������ (ex. ���� �����̸�, �հ����� ���� ������)
    // ���̾��Ű â �󿡼� �巡�� & ����� ���� �θ�-�ڽ� ���¸� ������ �� ����
    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };

        // �θ�����
        transform.parent = newGameObject.transform;

        // �θ� �������� �� Ʈ������
        // transform.localPosition : �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ��ġ
        // transform.localRotation : �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ȸ��
        // transform.localScale    : �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ũ��

        // �θ� ����
        transform.parent = null;    // �θ�Ʈ�������� ���� ��� ���ӿ�����Ʈ�� ���带 �θ���Ѵ�.

        // ���带 �������� �� Ʈ������
        // transform.localPosition == transform.position : �θ�Ʈ�������� ���� ��� �θ� �������� �� ��ġ
        // transform.localRotation == transform.rotation : �θ�Ʈ�������� ���� ��� �θ� �������� �� ȸ��
        // transform.localScale                          : �θ�Ʈ�������� ���� ��� �θ� �������� �� ũ��
    }
}
