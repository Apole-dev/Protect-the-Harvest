using System;
using System.Collections;
using Enemy_Scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class StageCombatController : MonoBehaviour
{
    
    [SerializeField] private EnemyGenerator enemyGenerator;
    [SerializeField] private EnemyPooling enemyPooling;
    
    
    [SerializeField] private int firstStageEnemyCount;
    [SerializeField] private int enemyCountIncrement;
    [SerializeField] private int stageCount;
    [SerializeField] private float stageTimer;
    public int CurrentStage { get; private set; }
    public int CurrentEnemyCount { get; private set; }
    
    
    
    [SerializeField] private TMP_Text enemyCountText;
    [SerializeField] private TMP_Text enemyType;


    public bool isStagePassed;
    

    private void Awake()
    {
        CurrentEnemyCount = firstStageEnemyCount;
        enemyGenerator.InstantiateEnemyWithCount(firstStageEnemyCount);
    }

    private void Update()
    {
        ControlStage(); 
    }

    //Control Stage Settings
    private void ControlStage()
    {
        if (Enemy.deathEnemyCount >= CurrentEnemyCount)
        {
            Enemy.deathEnemyCount = 0;
            isStagePassed = true;
        }
        
        if (isStagePassed)
        {
            isStagePassed = false;
            StartCoroutine(StageTimer());
        }
    }
    
    private IEnumerator StageTimer()
    {
        print("sdfhjksdfhjkdfhjksdfhjksfsdjhdfjhsdfhjksdfhjksdjkhfjkdshjkhsjkdjkf");
        yield return new WaitForSeconds(stageTimer);
        stageCount++;
        CurrentStage = stageCount;
        CurrentEnemyCount = stageCount + enemyCountIncrement;
        EnemyInstantiateController(CurrentEnemyCount);
        
        print(CurrentEnemyCount);
    }
    
    private void EnemyInstantiateController(int currentEnemyCount)
    {
        int poolCount = enemyPooling.enemiesScriptInPool.Count;
        int difference = currentEnemyCount - poolCount;

        for (int i = poolCount - 1; i >= 0; i--)
        {
            enemyPooling.ReturnEnemyFromPool(enemyPooling.enemiesScriptInPool[i]);
        }
        
        enemyGenerator.InstantiateEnemyWithCount(difference);
    }
    
}