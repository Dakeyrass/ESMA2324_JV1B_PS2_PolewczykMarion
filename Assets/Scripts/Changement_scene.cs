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
        GameObject joueur = GameObject.FindGameObjectWithTag("Player");
        if (joueur!=null)
        {
            camera_joueur = joueur.GetComponentInChildren<Camera>();
            if(camera_joueur!=null)
            {
                camera_joueur.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(scene_index);
        }
        if (other.CompareTag("Player") && scene_index !=1)
        {
            SceneManager.LoadSceneAsync(scene_index);
            ParallaxCamera script = camera_joueur.GetComponent<ParallaxCamera>();
            Destroy(script);
        }
    }
}
