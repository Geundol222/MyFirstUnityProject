using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void SceneChangeByName(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void SceneChangeByIndex(int Index)
    {
        SceneManager.LoadScene(Index, LoadSceneMode.Single);
    }
}
