using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidprefab;
    public float vengaBroHazMasLargoElNombreDeLaVariableEnElTutorialQuePonerSpawnrateASecasNoEraSuficiente = 30f;
    public float spawnrateincrement = 1f;
    public float x_limit = 1f;
    public float maxmetlimit = 4f;
    private float spawnNext = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / vengaBroHazMasLargoElNombreDeLaVariableEnElTutorialQuePonerSpawnrateASecasNoEraSuficiente;

            vengaBroHazMasLargoElNombreDeLaVariableEnElTutorialQuePonerSpawnrateASecasNoEraSuficiente += spawnrateincrement;

            float rand = Random.Range(-x_limit,x_limit);

            Vector2 spawnposition = new Vector2(rand, 8f);

            GameObject meteor = Instantiate(asteroidprefab, spawnposition, Quaternion.identity);

            Destroy(meteor,maxmetlimit);
        }
    }
}
