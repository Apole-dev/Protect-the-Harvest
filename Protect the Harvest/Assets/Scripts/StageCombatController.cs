using System;
using System.Collections;
using System.Collections.Generic;
using Enemy_Scripts;
using Managers;
using Player_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageCombatController : MonoBehaviour
{

    [SerializeField] private int stage;
    [SerializeField] private int enemyCountByStage;
    

    [SerializeField] private TMP_Text stageNumberText;

    [Header("Enemy Details")]
    [SerializeField] private Image enemyImage;
    [SerializeField] private Sprite enemyTypeSprite;

    [SerializeField] private float waitTimeForStagePass = 3f;
    
    
    public bool isStagePassed = false;
    

    private void Awake()
    {
        #region Default Values
        
        stage = 1; 
        enemyCountByStage = 2;
        
        #endregion
    }
    
    private void Start()
    {
        // First Stage
        EnemyGenerator.Instance.InstantiateEnemyWithCount(2);
    }

    private void Update()
    {
        print("Enemy Kill Count: " + Enemy.deathEnemyCount);
        
        StageController();
    }

    private void StageController()
    {
        if (Enemy.deathEnemyCount >= enemyCountByStage)
        {
            print("Stage Passed");
            
            isStagePassed = true;
            stage++;
            enemyCountByStage = stage +1;
            Enemy.deathEnemyCount = 0;

            StartCoroutine(ShowStageScreen());
            StartCoroutine(GenerateNewStageEnemies(enemyCountByStage));
        }
        else
        {
            print("Is stage can not be passed");
            isStagePassed = false;
        }
    }
    
    private IEnumerator GenerateNewStageEnemies(int enemyCountByStage)
    {
        if(enemyCountByStage == 0) throw new ArgumentException("enemyCountByStage can't be 0");
        
        yield return new WaitForSeconds(waitTimeForStagePass + 4f);

        var enemyPooling = EnemyPooling.Instance;
        List<Enemy> enemyScriptsInPool = enemyPooling.enemiesScriptInPool;
        int difference = enemyCountByStage - enemyScriptsInPool.Count;
        
        print("Enemy Script count in pool" +enemyScriptsInPool.Count);

        for (int i = enemyScriptsInPool.Count - 1; i >= 0; i--)
        {
            EnemyPooling.Instance.ReturnEnemyFromPool(enemyScriptsInPool[i]);
        }
        
        EnemyGenerator.Instance.InstantiateEnemyWithCount(difference);
        
    }
    

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator ShowStageScreen()
    {
        AssignDetailsOfStage();
        UIManager.Instance.ShowVictoryScreen(true);
        yield return new WaitForSeconds(waitTimeForStagePass);
        UIManager.Instance.ShowVictoryScreen(false);
    }
    
    private void AssignDetailsOfStage()
    {
        enemyImage.sprite = enemyTypeSprite;
        stageNumberText.text = stage.ToString();
    }
}