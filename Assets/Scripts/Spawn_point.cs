using UnityEngine;

public class Spawn_point : MonoBehaviour
{
    private GameObject monPersoSpawn;

    private void Awake()
    {
        monPersoSpawn = GameObject.FindGameObjectWithTag("Player");

        if (monPersoSpawn != null)
        {
            monPersoSpawn.transform.position = transform.position;
        }
        else
        {
            Debug.LogError("Pas vu pas pris");
        }
    }
}