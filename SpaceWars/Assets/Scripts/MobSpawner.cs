using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public enum SpawnState { Spawning,Waiting,Counting}

     [System.Serializable]
    public class Waves
    {
        public Transform enemy;
        public int amountofenemy;
        public int rate;
    }

    public Waves[] waves;
    private int nextwave=0;
    public float WaveCountDown;
    private float TimeBetweenWaves=3f;
    private float ControlEnemiesDelay = 2f;
    private SpawnState Spawn_State;
    public Transform[] SpawnPoints;
    
    void Start()
    {
        Spawn_State = SpawnState.Counting;
        WaveCountDown = TimeBetweenWaves;
    }

    
    void Update()
    {
        Debug.Log(EnemiesIsAlive());
        
        if(Spawn_State == SpawnState.Waiting)
        {
            
            if (!EnemiesIsAlive())
            {
                WaveCleared();
            }
            else
            {
                return;
            }
        }
       
        if (WaveCountDown <= 0)
        {
            if(Spawn_State != SpawnState.Spawning)
            {
                StartCoroutine(SpawnMobs(waves[nextwave]));
            }
        }
        else
        {
            WaveCountDown -= Time.deltaTime;
        }
    }
    void WaveCleared()
    {
        Debug.Log("WaveCleared");
        Spawn_State = SpawnState.Counting;
        WaveCountDown = TimeBetweenWaves;
        
        if (nextwave+1 == waves.Length)
        {
            Debug.Log("All StageClear Looping...");
            nextwave=0;
        }
        else
        {
            nextwave++;
        }
    }
    private bool EnemiesIsAlive()
    { 
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
                return false;
            else
                return true;
    }
     IEnumerator SpawnMobs(Waves _waves)
    {
        Spawn_State = SpawnState.Spawning;
        for (int i=0; i < _waves.amountofenemy; i++)
        {
            SpawnEnemyPrefab(_waves.enemy);
            yield return new WaitForSeconds(1f/_waves.rate);
        }
        Spawn_State=SpawnState.Waiting;
        yield return null;
    }
    void SpawnEnemyPrefab(Transform enemy)
    {
        Debug.Log("Spawing Mobs");
        Transform Random_sp=SpawnPoints[Random.Range(0,SpawnPoints.Length)];
        Instantiate(enemy, Random_sp.position, Random_sp.rotation);
    }

}


