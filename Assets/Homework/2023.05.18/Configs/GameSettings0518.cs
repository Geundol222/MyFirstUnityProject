using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings0518 : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    private static void Init()
    {
        // ������ �����ϱ� �� �ʿ��� ������
        if (GameManager0518.GM == null)
        {
            GameObject gameManager = new GameObject() { name = "GameManager" };
            gameManager.AddComponent<GameManager0518>();
        }
    }
}
