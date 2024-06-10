using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_principal : MonoBehaviour
{
    

    void Awake()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Niveau1()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Niveau2()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Niveau3()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void SceneRemerciements()
    {
        SceneManager.LoadSceneAsync(4);
    }
}