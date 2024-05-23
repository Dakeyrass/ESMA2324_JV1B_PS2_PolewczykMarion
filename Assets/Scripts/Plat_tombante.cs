using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_tombante : MonoBehaviour
{

    public float t_av_chute;
    public float t_respawn;

    private Rigidbody2D rgbd;
    private bool tombe = false;
    private Vector3 pos_initiale; 
    private Quaternion rota_initiale;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.isKinematic = true;
        //on desactive la gravite au debut.
        pos_initiale = transform.position;
        rota_initiale = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !tombe)
        {
            tombe = true;
            StartCoroutine(TombeApresTemps());
        }
    }

    IEnumerator TombeApresTemps()
    {
        yield return new WaitForSeconds(t_av_chute);
        rgbd.isKinematic = false;
        //yield return new sert a suspendre temporairement une coroutine avant de reprendre a l'instruction suivante.

        yield return new WaitForSeconds(t_respawn);
        rgbd.isKinematic = true; 
        transform.position = pos_initiale; 
        transform.rotation = rota_initiale;
         //on reinitialise la velocite du rgbd
         
        //angularVelocity decrit la vitesse a laquelle un objet tourne autour de son axe (si l'axe de rotation est aligne avec l'axe Y, etc):
        //on le reintialise pour eviter des rotations inatendues et d'eventuelles erreurs liees. 
        tombe = false;
    }
}
