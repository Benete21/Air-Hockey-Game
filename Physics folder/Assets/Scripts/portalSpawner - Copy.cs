using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class portalSpawner : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 10f;
    public Vector2 spawnAreaSize;
    public float portalDuration = 15f;
    public Vector2 resetPoint = new Vector2(4, 8);

    private void Start()
    {
        StartCoroutine(SpawnPortals());
    }

    IEnumerator SpawnPortals()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval)); // the timer for the amount of seconds that the the spawning runs for
            Vector2 spawnPosition1 = GetRandomSpawnPositionfor1();
            Vector2 spawnPosition2 = GetRandomSpawnPositionfor1();
            portal1.transform.position = spawnPosition1;    //Applies the random position to the portal 2 object
            portal2.transform.position = spawnPosition2;    //Applies the random position to the portal 2 object
        }
    }
    Vector2 GetRandomSpawnPositionfor1()    // gets the random position for portal 1
    {
        float x = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float y = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);
        return new Vector2(x, y);
    }
    Vector2 GetRandomSpawnPositionfor2()    // gets the random position for portal 1
    {
        float x = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float y = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);
        return new Vector2(x, y);
    }
    public void ResetPortalPosition()
    {
        portal1.transform.position = resetPoint;
        portal2.transform.position = resetPoint;
    }
}





