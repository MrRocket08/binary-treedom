using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    public Vector2[] spawnLocations;

    public GameObject[] enemiesToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnLocations.Length > 0 && enemiesToSpawn.Length > 0)
            for (int i = 0; i < spawnLocations.Length; i++)
            {
                Instantiate(enemiesToSpawn[i], spawnLocations[i], Quaternion.identity);
            }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
