using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    GameObject prefabMeteor1;

    [SerializeField]
    GameObject prefabMeteor2;

   
    // spawn control
    const float minSpawn = 0;
    const float maxSpawn = 1f;
    Timer spawnTimer;

    //spawn location control
    const int spawnBorderSize = 70;
    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;
    void Start()
    {

        minSpawnX = spawnBorderSize;
        maxSpawnX = Screen.width - spawnBorderSize;
        minSpawnY = Screen.height + spawnBorderSize-1;
        maxSpawnY = Screen.height + spawnBorderSize*10;

        //Create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(minSpawn, maxSpawn);
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            int randomN = Random.Range(1, 2);
            for (int i = 0; i < randomN; i++)
            { 
            SpawnMeteor();

            spawnTimer.Duration = Random.Range(minSpawn, maxSpawn);
            spawnTimer.Run();
            }
        }
    }

    void SpawnMeteor()
    {

        int spriteNumber = Random.Range(0, 6);
        if (spriteNumber <=4)
        {

            Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
            Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
            Instantiate<GameObject>(prefabMeteor1, worldLocation, Quaternion.identity);
        }
        if (spriteNumber > 4)
        {

            float posX = MainBehavior.Posicion;
            
            Vector3 location1 = new Vector3(posX, Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
            Vector3 worldLocation1 = Camera.main.ScreenToWorldPoint(location1);
            worldLocation1.x = posX;
            Instantiate<GameObject>(prefabMeteor2, worldLocation1, Quaternion.identity);
        }
    }
}
