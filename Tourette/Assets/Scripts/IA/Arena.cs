using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arena : MonoBehaviour
{

    public GameObject[] Wave1;
    public GameObject[] Wave2;
    public GameObject[] Wave3;
    public GameObject[] Wave4;
    private List<GameObject> EnemiesAlivesBeforeNextWave = new List<GameObject>();

    bool initialized = false;
    int currentWaveIndex = 0;

    public float rangeToSpawnInX;
    public float rangeToSpawnInZ;

    private Collider col;


    // Use this for initialization
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in EnemiesAlivesBeforeNextWave)
        {
            if (!item)
            {
                EnemiesAlivesBeforeNextWave.Remove(item);
                break;
            }
        }
        if (EnemiesAlivesBeforeNextWave.Count == 0 && initialized)
            instantiateWaves();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            instantiateWaves();
            col.enabled = false;
            initialized = true;
        }
    }

    Vector3 getRandomPosition()
    {
        int randomPositionOrder;

        randomPositionOrder = Random.Range(0, 2);

        if (randomPositionOrder < 1.0)
            return (new Vector3(transform.position.x + rangeToSpawnInX, transform.position.y, transform.position.z + rangeToSpawnInZ));
        else if (randomPositionOrder >= 1.0 && randomPositionOrder < 2.0)
            return (new Vector3(transform.position.x + rangeToSpawnInX, transform.position.y, transform.position.z - rangeToSpawnInZ));
        else if (randomPositionOrder >= 2.0 && randomPositionOrder < 3.0)
            return (new Vector3(transform.position.x - rangeToSpawnInX, transform.position.y, transform.position.z + rangeToSpawnInZ));
        else
            return (new Vector3(transform.position.x - rangeToSpawnInX, transform.position.y, transform.position.z - rangeToSpawnInZ));
    }

    void instantiateWaves()
    {
        int number;

        switch (currentWaveIndex)
        {
            case 0:
                for (number = 0; number < Wave1.Length; number++)
                    EnemiesAlivesBeforeNextWave.Add(Instantiate(Wave1[number], getRandomPosition(), transform.rotation) as GameObject);
                break;
            case 1:
                for (number = 0; number < Wave2.Length; number++)
                    EnemiesAlivesBeforeNextWave.Add(Instantiate(Wave2[number], getRandomPosition(), transform.rotation) as GameObject);
                break;
            case 2:
                for (number = 0; number < Wave3.Length; number++)
                    EnemiesAlivesBeforeNextWave.Add(Instantiate(Wave3[number], getRandomPosition(), transform.rotation) as GameObject);
                break;
            case 3:
                for (number = 0; number < Wave4.Length; number++)
                    EnemiesAlivesBeforeNextWave.Add(Instantiate(Wave4[number], getRandomPosition(), transform.rotation) as GameObject);
                break;
            default:
                break;
        }
        ++currentWaveIndex;
        if (currentWaveIndex == 4)
        {
            Destroy(gameObject);
        }
    }
}
