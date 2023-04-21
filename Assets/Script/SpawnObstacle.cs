using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[Hotfix]
[LuaCallCSharp]
public class SpawnObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstaclePrefab;

    public float highLimit;
    public float lowLimit;

    public float spawnPositionX;

    public float spawnCd=3;
    public float obstacleSpeed=-5;

    void Start()
    {
        StartCoroutine(SpawnShell());
        
    }


    IEnumerator SpawnShell()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnCd);
        }
    }
    
    [LuaCallCSharp]
   public void Spawn()
    {
        Instantiate(obstaclePrefab, new Vector3(spawnPositionX, Random.Range(lowLimit, highLimit), 0),
            Quaternion.identity, transform).GetComponent<SimpleStroll>().speed = obstacleSpeed;
    }

   
  
    // Update is called once per frame
    void Update()
    {
    }
}