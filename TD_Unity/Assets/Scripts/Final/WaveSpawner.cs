using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text waveCountdownText;
    private float timeBetweenWave = 5f;
    private float searchCountdown = 1f;
    private float waveCountdown;
    private int nextWave;
    private SpawnState state = SpawnState.E_Counting;

    void Start(){
        // GameObject[] _sp= GameObject.FindGameObjectsWithTag("SpawnPoint");
        // spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint").transform;
        if (spawnPoints.Length == 0){
            Debug.LogError("No spawn point reference.");
        }
        if (waves.Length == 0){
            Debug.LogError("No spawn point reference.");
        }
        waveCountdown = timeBetweenWave;
        nextWave = 0;
    }

    void Update(){
        if (state == SpawnState.E_Waiting){
            if (!EnemyIsAlive()){
                BeginNewWave();
            } else {
                return;
            }
        }

        if ( waveCountdown <= 0){
            if ( state != SpawnState.E_Spawning)
                StartCoroutine( SpawnWave( waves[nextWave]) ); 
        }else{
                waveCountdown -= Time.deltaTime;
        }

        int timer = (int)Mathf.Round(waveCountdown);
        if (timer == 0)
            waveCountdownText.text = "Waiting";
        else
            waveCountdownText.text = timer.ToString();
    }

    void BeginNewWave(){
        Debug.Log("Wave completed !");

        state = SpawnState.E_Counting;
        waveCountdown = timeBetweenWave;

        if (nextWave + 1 > waves.Length - 1)
                nextWave = 0;
        else
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
        state = SpawnState.E_Spawning;
        for (int i = 0; i < _wave.count; i++){
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate );
        }
        state = SpawnState.E_Waiting;
        yield break;
    }

    void SpawnEnemy(Transform _enemy){
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

}
