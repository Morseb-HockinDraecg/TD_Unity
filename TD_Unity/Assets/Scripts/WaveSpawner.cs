using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {E_Spawning, E_Waiting, E_Counting};

    [System.Serializable] // allow to edit in Unity directly
    public class Wave {
            public string name;
            public Transform enemy;
            public int count;
            public float rate;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    private int nextWave = 0;
    private float timeBetweenWave = 2f;
    public float waveCountdown = 0f;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.E_Counting;

    void Start(){
        if (spawnPoints.Length == 0){
            Debug.LogError("No spawn point reference.");
        }
        if (waves.Length == 0){
            Debug.LogError("No spawn point reference.");
        }
        waveCountdown = timeBetweenWave;
    }

    void Update(){
        if (state == SpawnState.E_Waiting){
            if (!EnemyIsAlive()){
                BeginNewWave();
            } else {
                // waveCountdown = timeBetweenWave;
                return;
            }
        }

        if ( waveCountdown <= 0){
            if ( state != SpawnState.E_Spawning)
                StartCoroutine( SpawnWave( waves[nextWave]) ); 
        }else{
                waveCountdown -= Time.deltaTime;
        }
    }

    void BeginNewWave(){
        Debug.Log("Wave completed !");

        state = SpawnState.E_Counting;
        waveCountdown = timeBetweenWave;

        if (nextWave + 1 > waves.Length - 1){
                nextWave = 0;
                Debug.Log("All waves completed ! Looping ...");
        } else
        nextWave++;
    }

    bool EnemyIsAlive(){
        searchCountdown -= Time.deltaTime;
        if (searchCountdown >= 0){
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
                return false;
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave){
        Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.E_Spawning;
        for (int i = 0; i < _wave.count; i++){
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate );
        }
        state = SpawnState.E_Waiting;
        yield break;
    }

    void SpawnEnemy(Transform _enemy){
        Debug.Log("Spawning enemy: " + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

}
