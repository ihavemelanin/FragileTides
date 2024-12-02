using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> projectilePrefabs;
    [SerializeField] Transform spawnTransform;
    [SerializeField] float spawnRate = 1f;
    //[SerializeField] float spawnDistance = 100;
    public float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnRate){
            SpawnProjectile();
            timer = 0f;
        }
    }


    void SpawnProjectile(){
        //int minY = -3;
        //int maxY = 3;
        //float yVal = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnTransform.position.x, spawnTransform.position.y, spawnTransform.position.z);
        Instantiate(projectilePrefabs[Random.Range(0, projectilePrefabs.Count)], spawnPos, Quaternion.identity);
        //[Random.Range(0, projectilePrefabs.Count)]
    }
}
