using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_suiveur : MonoBehaviour
{
    public float distance_detection;
    public float vie;
    public float vitesse;
    private Transform player;
    //pour avoir la position du joueur en x y z
    private Rigidbody2D rgbd;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance_joueur = Vector2.Distance(transform.position, player.position);
        if (distance_joueur<distance_detection)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            //on normalized pour avoir un vecteur proportionnel a speed. 
            //En gros si on normalized pas, si l'ennemi est proche le vecteur sera court et donc *vitesse l'ennemi lent et inversement.
            rgbd.velocity = direction * vitesse;
            //pas besoin de time.deltatime car la vitesse de l'objet est deja en unite p secondes.


            //Il n'aime pas en vecteur 2 + pb de rgbd (il s'envolait ou traversait le sol c'etait pas ouf)
            //transform.position += direction * vitesse * Time.deltaTime;
            //on utilise time.deltatime pour que le deplacement soit independant du taux de rafraichissement.(ue le pc tourne a 120 fps ou 60, le deplacement sera le mm). 
            //le deplacement de l'objet devient alors proportionnel au temps ecoule depuis la derniere frame.(mouvement constant)

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Atk"))
        {
            vie -=1;
            Debug.Log(vie);

            if (vie<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
