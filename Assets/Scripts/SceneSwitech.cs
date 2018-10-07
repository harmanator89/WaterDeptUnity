using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitech : MonoBehaviour
{

    public void SceneSwitcher(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }

}
