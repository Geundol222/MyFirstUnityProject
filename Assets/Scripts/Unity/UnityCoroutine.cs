using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
    /************************************************************************
	 * �ڷ�ƾ (Coroutine) : *******!!!!��û �߿���!!!!*******
	 * 
	 * �۾��� �ټ��� �����ӿ� �л��� �� �ִ� �񵿱�� �۾� (Updata�� �ٸ��� ���� ���ư��� �ϱ� ���� ��)
	 * Update�� ���ư��µ��� �ڷ�ƾ�� ���� ���ư��� �ִ�.
	 * �ݺ������� �۾��� �л��Ͽ� �����ϸ�, ������ �Ͻ������ϰ� �ߴ��� �κк��� �ٽý����� �� ����
	 * ��, �ڷ�ƾ�� �����尡 �ƴϸ� �ڷ�ƾ�� �۾��� ������ ���� �����忡�� ����
	 * ���� ��ó�� ������ ���� �����带 �־� ���ư��� ���� �ƴ϶� �����۾��� ���ν����忡�� ���ݾ� �س����� �����̴�.
	 ************************************************************************/

    // <�ڷ�ƾ ����>
    // �ݺ������� �۾��� StartCorouine�� ���� ����    
    IEnumerator SubRoutine()
    {
        for (int i = 0; i < 10; i++)
        {            
            yield return new WaitForSeconds(1f);
            Debug.Log($"{i}�� ����");
        }
    }

    private Coroutine routine;

    private void CoroutineStart()
    {
        routine = StartCoroutine(SubRoutine());
    }

    // <�ڷ�ƾ ����>
    // StopCoroutine�� ���� ���� ���� �ڷ�ƾ ����
    // StopAllCoroutine�� ���� ���� ���� ��� �ڷ�ƾ ����
    // �ݺ������� �۾��� ��� �Ϸ�Ǿ��� ��� �ڵ� ����
    // �ڷ�ƾ�� �����Ų ��ũ��Ʈ�� ��Ȱ��ȭ�� ��� �ڵ� ����
    private void CoroutineStop()
    {
        StopCoroutine(routine);     // ������ �ڷ�ƾ ����
        StopAllCoroutines();        // ��� �ڷ�ƾ ����
    }

    // <�ڷ�ƾ �ð� ����>
    // �ڷ�ƾ�� �ð� ������ �����Ͽ� �ݺ������� �۾��� ���� Ÿ�̹��� ������ �� ����
    IEnumerator CoroutineWait()
    {
        yield return new WaitForSeconds(1);     // n�ʰ� �ð�����
        yield return null;                      // 1������ ���� (��ǻ� �ð����� ����)
    }
}
