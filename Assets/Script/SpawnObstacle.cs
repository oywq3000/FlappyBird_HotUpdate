using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    public GameObject obstaclePrefab;

    public float highLimit;
    public float lowLimit;

    public float spawnPositionX;
    
    void Start()
    {
        InvokeRepeating("Spawn",1,1);
    }


    void Spawn()
    {
        if (!GameManager.Instance.isGameOver)
        {
            Instantiate(obstaclePrefab, new Vector3(spawnPositionX, Random.Range(lowLimit, highLimit), 0),
                Quaternion.identity,transform);
        }
    
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
