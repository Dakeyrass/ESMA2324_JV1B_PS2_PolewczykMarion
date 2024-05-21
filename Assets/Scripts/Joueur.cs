using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    //STATS
    public float vie;
    public float vitesse;
    public float force_saut;

    //COMPONENTS
    private Rigidbody2D rgbd;
    private Collider2D col;

    //CONDITIONS
    private bool au_sol = true;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //deplacements basiques 
        float horizontal = Input.GetAxis("Horizontal");
        rgbd.velocity = new Vector2(horizontal * vitesse, rgbd.velocity.y);
        //saut
        if (Input.GetKeyDown(KeyCode.Space)&& au_sol == true)
        {
            sauter();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Sol")
        {
            au_sol = true; 
        }
    }
    private void sauter()
    {
        rgbd.velocity = new Vector2 (rgbd.velocity.x,force_saut);
        au_sol = false;
    }

}
