using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnStat{SPAWNING, WATTING, COUNTING};
    [SerializeField] private Wave[] waves;
    [SerializeField] private bool isLevelEnd;

    [SerializeField] private float timeBetweenWave;
    [SerializeField] private float timeBetweenStage ;
    [SerializeField] private float timeBetweenStageEnemies;
    [SerializeField] private float waveCountdown = 0;
    [SerializeField] private float stageCountdown = 0;
    [SerializeField] private float stageEnemiesCountdown = 0;
    private SpawnStat stat = SpawnStat.COUNTING;

    [SerializeField]private int currentWave;
    [SerializeField]private int currentStage;
    [SerializeField]private int currentStageEnemies;
    [SerializeField]private bool isStageEnemies;

    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private List<EnemyStats> enemyList;


    private void Start()
    {
        waveCountdown = timeBetweenWave;
        isLevelEnd = false;
        isStageEnemies = false;
        currentWave = 0;
    }

    private void Update()
    {
        if(stat == SpawnStat.WATTING)
        {
            if(!EnemiesAllDead())
                return;
            else
                CompleteWave();
        }
        if(!isLevelEnd)
        {
            if(waveCountdown <= 0)
            {
                stat=SpawnStat.SPAWNING;
            }
            else
                waveCountdown -= Time.deltaTime;       
        }

        if(stat == SpawnStat.SPAWNING)
        {
            if(stageCountdown <= 0)
            {
                if(stageEnemiesCountdown <= 0 && !isStageEnemies)
                {
                    StartCoroutine(SpawnWave(waves[currentWave].stage[currentStage].stageEnemies[currentStageEnemies]));
                }
                else
                    stageEnemiesCountdown -= Time.deltaTime;
            }
            else
                stageCountdown -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave(StageEnemy stageEnemy)
    {
        isStageEnemies = true;
        for(int i =0;i < stageEnemy.enemiesAmount;i++)
        {
            SpawnEnemy(stageEnemy.enemy);
            yield return new WaitForSeconds(stageEnemy.delay);
        }
        CompleteStageEnemies();

        yield break;
    }
    private void SpawnEnemy(GameObject enemy)
    {
        int randomint = Random.Range(1,spawnPoint.Length);
        Transform randomSpawner = spawnPoint[randomint];
        GameObject newEnemy =  Instantiate(enemy,randomSpawner.position,randomSpawner.rotation);
        EnemyStats newEnemyStats = newEnemy.GetComponent<EnemyStats>();

        enemyList.Add(newEnemyStats);
    }

    private bool EnemiesAllDead()
    {
        int i = 0;
        foreach(EnemyStats enemy in enemyList)
        {
            if(enemy.IsDead())
                i++;
            else
                return false;
        }
        return true;
    }
    private void CompleteStageEnemies()
    {
        Debug.Log("StageEnemies COMPLETED");
        stageEnemiesCountdown = timeBetweenStageEnemies;
        if(currentStageEnemies + 1 > waves[currentWave].stage[currentStage].stageEnemies.Length -1)
        {
            CompleteStage();
            currentStageEnemies = 0;
        }
        else
        {
            isStageEnemies = false;
            currentStageEnemies ++;            
        }        
    }
    private void CompleteStage()
    {
        Debug.Log("STAGE COMPLETED");
        stageCountdown = timeBetweenStage;
        if(currentStage + 1 > waves[currentWave].stage.Length -1)
        {           
            stat = SpawnStat.WATTING;
            currentStage = 0;
        }
        else
        {
            isStageEnemies = false;
            currentStage ++;            
        }        
    }
    private void CompleteWave()
    {
        Debug.Log("WAVE COMPLETED");

        stat = SpawnStat.COUNTING;
        waveCountdown = timeBetweenWave;

        if(currentWave + 1 > waves.Length -1)
        {
            LevelEnd();
        }
        else
        {
            isStageEnemies = false;
            stageCountdown = 0;
            stageEnemiesCountdown = 0;
            currentWave ++;            
        }
    }
    private void LevelEnd()
    {
        isLevelEnd = true;
        currentWave = 0;
        Debug.Log("通關");
    }
}
