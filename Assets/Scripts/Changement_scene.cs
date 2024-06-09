using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changement_scene : MonoBehaviour
{
    public int scene_index;
    private Camera camera_joueur;
    
    void Start()
    {
        camera_joueur = FindObjectOfType<Camera>();
        Camera camera_principale = Camera.main;
        if (camera_principale != null)
        {
            camera_principale.gameObject.SetActive(false);
        }
        if (camera_joueur != null)
        {
            camera_joueur.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(scene_index);
        }
    }
}
