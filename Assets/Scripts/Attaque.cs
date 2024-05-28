using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    public BoxCollider2D atk;
    private Animator anim;
    private bool a_arme;

    // Start is called before the first frame update
    void Start()
    {
        a_arme = false;
        anim = GetComponent <Animator>();
        atk.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //attaque
        if (Input.GetKeyDown(KeyCode.P) && a_arme)
        {
            Attack();
            Debug.Log("J'attaque");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arme"))
        {
            a_arme = true;
            Destroy(other.gameObject);
        }
    }

    private void Attack()
    {
        atk.enabled = true;
        anim.SetTrigger("attaque");
    }

    public void AttackEnd()
    {
        atk.enabled = false;
    }
}