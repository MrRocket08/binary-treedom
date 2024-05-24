using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    public Vector2[] spawnLocations;

    public GameObject[] enemies;

    public Vector2[] interactableLocations;
    public GameObject[] interactables;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnLocations.Length > 0 && spawnLocations.Length == enemies.Length)
            for (int i = 0; i < spawnLocations.Length; i++)
            {
                Instantiate(enemies[i], spawnLocations[i], Quaternion.identity);
            }

        if (interactableLocations.Length > 0 && interactableLocations.Length == interactables.Length)
        {
            for (int i = 0; i < interactableLocations.Length; i++)
            {
                GameObject inter = Instantiate(interactables[i], interactableLocations[i], Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
