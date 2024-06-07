using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_pause : MonoBehaviour
{
    public Canvas pause;
    public Sprite[] stades;
    public Image UIstade;

    private Joueur joueur;
    private GameObject player;

    public Text compteur_vitesse;
    private bool est_pause;




    // Start is called before the first frame update
    void Start()
    {
        est_pause = false;
        pause.enabled = false;
        joueur = GetComponent<Joueur>();
        player = GameObject.FindWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(est_pause)
            {
                RetourNormal();
            }
            else
            {
                MenuPause();
            }
            
        }
    }

    private void MenuPause()
    {
        Time.timeScale = 0f;
        pause.enabled = true;
        est_pause = true;
        compteur_vitesse.text = " Vitesse: " + joueur.vitesse.ToString();
        //transforme l'int en string 
    }

    public void UpdateContam()
    {
        int niveau_de_conta = Mathf.FloorToInt(joueur.vie / 2);
        if (niveau_de_conta >=0 && niveau_de_conta<stades.Length)
        {
            UIstade.sprite = stades[niveau_de_conta];
        }
        
    }

    private void RetourNormal()
    {
        pause.enabled = false;
        Time.timeScale = 1f;
        est_pause = false;
    }

    public void Reset_Conta_Image()
    {
        UIstade.sprite = stades[3];
    }
}   
    
