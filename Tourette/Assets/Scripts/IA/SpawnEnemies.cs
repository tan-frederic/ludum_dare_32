using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{

    public UnityEngine.EventSystems.EventTrigger.Entry CallbackIN;
    public UnityEngine.EventSystems.EventTrigger.Entry CallbackOUT;


    // Use this for initialization

    public GameObject enemy;
    public int enemyNumber;
    public float rangeToSpawnInX;
    public Transform MinY;
    public Transform MaxY;

    private bool DoOnce = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] mobs = GameObject.FindGameObjectsWithTag("Mob");
        if (DoOnce == false && mobs.Length == 0)
        {
            CallbackOUT.callback.Invoke(null);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && DoOnce)
        {
            instantiateEnemy();
            DoOnce = false;
            CallbackIN.callback.Invoke(null);
        }
    }

    void instantiateEnemy()
    {
        int number = 0;
        int randomPositionOrderX;
        float randomPositionOrderY;

        while (number < enemyNumber)
        {
            randomPositionOrderX = Random.Range(0, 100);
            randomPositionOrderY = Random.Range(MinY.transform.position.z, MaxY.transform.position.z);
            Instantiate(enemy, new Vector3(transform.position.x + ((randomPositionOrderX > 50) ? rangeToSpawnInX : -rangeToSpawnInX), transform.position.y, randomPositionOrderY), new Quaternion());
            number++;
        }
    }
}
