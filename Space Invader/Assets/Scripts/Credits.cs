using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    void Start()
    {
        Invoke("BackMainMenu", 5f);
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
