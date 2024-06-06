using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timer_barre;
    public float temps_max;
    private float temps_restant;
    private bool temps_passant;

    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        temps_restant = temps_max;
        temps_passant = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (temps_passant && temps_restant > 0)
        {
            temps_restant -= Time.deltaTime;
            timer_barre.fillAmount = temps_restant / temps_max;
            //.fillAmount sert a definir le pourcentage de remplissage de l'image (valeur entre 0 et 1).
        }
        else if (temps_restant <= 0)
        {
            temps_passant = false;
            playerObject.GetComponent<Joueur>().Respawn();
        }
    }

    public void StopTimer()
    {
        temps_passant = false;
    }

    public void ActiveTimer()
    {
        temps_passant = true;
    }

    public void Restart()
    {
        temps_restant = temps_max;
        timer_barre.fillAmount = 1;
    }
}
