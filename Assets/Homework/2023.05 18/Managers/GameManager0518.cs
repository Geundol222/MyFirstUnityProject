using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager0518 : MonoBehaviour
{
    private static GameManager0518 gameManager0518;
    private static DataManager0518 dataManager0518;

    public static GameManager0518 GM { get { return gameManager0518; } }
    public static DataManager0518 DM { get { return dataManager0518; } }

    private void Awake()
    {
        if (gameManager0518 != null)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
        gameManager0518 = this;
        InitManagers();
    }

    private void OnDestroy()
    {
        if (gameManager0518 == this)
            gameManager0518 = null;
    }

    private void InitManagers()
    {
        GameObject data = new GameObject() { name = "DataManager" };
        data.transform.SetParent(transform);
        dataManager0518 = data.AddComponent<DataManager0518>();
    }
}
