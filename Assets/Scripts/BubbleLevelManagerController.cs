using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleLevelManagerController : MonoBehaviour
{
    public GameObject leftSpawningBound;
    public GameObject rightSpawningBound;
    public GameObject bubble;
    public float timeBetweenSpawns;
    private float timeTillSpawnLeft;
    private float _spawnLB;
    private float _spawnRB;
    private float _spawnY;

    // Start is called before the first frame update
    void Start()
    {
        _spawnLB = leftSpawningBound.transform.position.x;
        _spawnRB = rightSpawningBound.transform.position.x;
        _spawnY = leftSpawningBound.transform.position.y;
        timeTillSpawnLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeTillSpawnLeft <= 0)
        {
            timeTillSpawnLeft = timeBetweenSpawns;
            Instantiate(bubble,new Vector2(Random.Range(_spawnLB, _spawnRB), _spawnY), Quaternion.identity);
        }
        else
        {
            timeTillSpawnLeft -= Time.deltaTime;
        }
            
    }
}
