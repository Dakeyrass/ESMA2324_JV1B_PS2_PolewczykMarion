using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    public Image journal;

    // Start is called before the first frame update
    void Start()
    {
        journal.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Affiche_journal();
    }

    private void Affiche_journal()
    {
        if (Input.GetKey(KeyCode.A))
        {
            journal.enabled = true; 
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            journal.enabled = false; 
        }

    }
}
