using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Joueur : MonoBehaviour
{
    //STATS
    public float vitesse;
    public float force_saut;
    public int vie;
    public Sprite[] vies;
    public Image UIvie;

    private bool invincible;
    private Vector3 zone_respawn;

    //COMPONENTS
    private Rigidbody2D rgbd;
    private Collider2D col;
    private Animator anim;

    //CONDITIONS
    private bool au_sol = true;
    public GameObject timerobject;

    //pour SAFE ZONE
    private Timer timer_barre;

    //pour SUIVRE la PLATEFORME
    private Transform plateforme_actuelle;
    private Vector3 derniere_plat_pos;
    private bool est_dessus;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        rgbd = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        timer_barre = FindObjectOfType<Timer>();
        


        est_dessus = false;
        invincible = false;
        zone_respawn = transform.position;
        //on enregistre le respawn dès que le joueur spawn comme ça si il meurt avant le checkpoint il respawn qd mm
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

        //permet de savoir si le perso doit suivre une plateforme.
        if (est_dessus && plateforme_actuelle != null)
        {
            Vector3 mouvement_plateforme = plateforme_actuelle.position - derniere_plat_pos;
            //stock le deplacement plateforme = vecteur qui represente le deplacement de la plat depuis sa derniere pos.
            transform.position += mouvement_plateforme;
            derniere_plat_pos = plateforme_actuelle.position;
        }

        //FLIP
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(-1f, 1f,1f);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }

        Debug.Log(invincible);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Sol")
        {
            au_sol = true; 
        }
        if(collision.gameObject.tag == "Plateforme")
        {
            plateforme_actuelle = collision.transform;
            derniere_plat_pos = plateforme_actuelle.transform.position;
            est_dessus = true;
            au_sol = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Plateforme")
        {   
            //plateforme reassignee a null pour montrer que le joueur n'est plus dessus. 
            plateforme_actuelle = null;
            est_dessus = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi") && !invincible)
        {
            anim.SetTrigger("touché");
            vie -=1;
            PerteVieUI();

            if(vie<=0)
            {
                Respawn();
            }
            else
            {
                invincible = true;
            }
        }
        
        if (other.CompareTag("Safe"))
        {
            timer_barre.StopTimer();
        }

        if (other.CompareTag("EnnemiVitesse"))
        {
            vitesse -= 1;
            if (vitesse <=0)
            {
                vitesse = 0;
            }
        }
        Debug.Log(vitesse);


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        timer_barre.ActiveTimer();
    }

    private void PerteVieUI()
    {
        UIvie.sprite = vies[vie];
        //UIvie fait ref au GameObject entier, donc si on ne met pas .sprite unity va essayer 
        //d'assigner un Sprite (vies[vie]) a une Image et il aime pas.
    }

    private void sauter()
    {
        rgbd.velocity = new Vector2 (rgbd.velocity.x,force_saut);
        au_sol = false;
    }

    public void mort()
    {
        gameObject.SetActive(false);
    }

    public void Iframe()
    {
        invincible = false; 
    }

    public void SetZoneRespawn(Vector3 nouv_z_respawn)
    {
        zone_respawn = nouv_z_respawn;
    }

    public void Respawn()
    {
        transform.position = zone_respawn;
        //on tp le player et on reinitialise ses stats
        vie = 3;
        PerteVieUI();
        
        vitesse = 10;
        timerobject.GetComponent<Timer>().Restart();
    }
}

