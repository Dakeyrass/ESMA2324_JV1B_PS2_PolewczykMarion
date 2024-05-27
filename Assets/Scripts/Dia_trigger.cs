using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dia_trigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool isInRange;
    //indique si le joueur est dans la zone du pnj 
    private Text interactUI;



    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            Dia_manager.instance.EndDialogue();
            //si on part, le dialogue se casse aussi 
        }
    }

    private void Awake()//awake c'est quand �a passe d'actif � inactif. 
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void TriggerDialogue()
    {
        Dia_manager.instance.StartDialogue(dialogue);
    }
}