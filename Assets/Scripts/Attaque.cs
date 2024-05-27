using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    public BoxCollider2D atk;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent <Animator>();
        atk.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //attaque
        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
            Debug.Log("J'attaque");
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