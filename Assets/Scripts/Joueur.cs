using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    //STATS
    public float vie;
    public float poids;
    public float force;
    //COMPONENTS
    private Rigidbody2D rgbd;
    private Collider2D col;
    //DEPLACEMENTS
    public float vitesse;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rgbd.velocity = new Vector2(horizontal * vitesse, rgbd.velocity.y);
    }
}
