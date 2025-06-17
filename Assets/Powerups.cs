using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public int powerupID;
    public int powerdownID;
    private float powerupDespawnTimer;
    public float powerupSpawnTimer;
    public GameObject powerupPrefab;
    public GameObject powerup1Prefab;
    public GameObject poowerDownPrefab;
    public GameObject powerDown2Prefab;
    public GameObject powerDown3Prefab;
    GameObject cloneObject;
    GameObject cloneObject1;
    GameObject cloneObject2;
    GameObject cloneObject3;
    GameObject cloneObject4;
    public bool isStartingSpawn = false;



    void Update()
    {
        powerupSpawnTimer += Time.deltaTime;
        powerupDespawnTimer += Time.deltaTime;

    
        if (isStartingSpawn)
        {
            Debug.Log("Powerups spawning started");
            //powerups
            if (powerupSpawnTimer >= 5)
            {
                int powerupID = Random.Range(0, 3);
                if (powerupID == 1)
                {
                    int SpawnX = Random.Range(-10, 10);
                    int SpawnY = Random.Range(-10, 10);

                    cloneObject = Instantiate(powerupPrefab, new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
                    powerupSpawnTimer = 0;
                }
                else if (powerupID == 2)
                {
                    int SpawnX = Random.Range(-10, 10);
                    int SpawnY = Random.Range(-10, 10);
                    cloneObject1 = Instantiate(powerup1Prefab, new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
                    powerupSpawnTimer = 0;
                }

                int powerdownID = Random.Range(0, 4);
                if (powerdownID == 1)
                {
                    int SpawnX = Random.Range(-10, 10);
                    int SpawnY = Random.Range(-10, 10);
                    cloneObject2 = Instantiate(poowerDownPrefab, new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
                    powerupSpawnTimer = 0;
                }
                else if (powerdownID == 2)
                {
                    int SpawnX = Random.Range(-10, 10);
                    int SpawnY = Random.Range(-10, 10);
                    cloneObject3 = Instantiate(powerDown2Prefab, new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
                    powerupSpawnTimer = 0;
                }
                else if (powerdownID == 3)
                {
                    int SpawnX = Random.Range(-10, 10);
                    int SpawnY = Random.Range(-10, 10);
                    cloneObject4 = Instantiate(powerDown3Prefab, new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
                    powerupSpawnTimer = 0;
                }
            }
            if (powerupDespawnTimer >= 5)
            {
                Destroy(cloneObject);
                Destroy(cloneObject1);
                Destroy(cloneObject2);
                Destroy(cloneObject3);
                Destroy(cloneObject4);
                powerupDespawnTimer = 0;
            }
        }
    }
    public void StartSpawning()
    {
        isStartingSpawn = true;
    }

}
