using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_RoomState : MonoBehaviour
{
    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            Instantiate(spawnPoint.GetComponent<scr_SpawnEnemyType>().EnemyType, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(EnemyCount <= 0)
        {
            Debug.Log("Room Clear");
        }
    }
}
