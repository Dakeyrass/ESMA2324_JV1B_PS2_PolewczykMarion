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

    //COMPONENTS
    private Rigidbody2D rgbd;
    private Collider2D col;

    //CONDITIONS
    private bool au_sol = true;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {
            vie -=1;
            PerteVieUI();
        }
        Debug.Log(vie);
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
        SceneManager.LoadSceneAsync(0);
    }
}

