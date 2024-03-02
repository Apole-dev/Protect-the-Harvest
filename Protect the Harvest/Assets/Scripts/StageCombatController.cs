using System.Collections;
using System.Globalization;
using Enemy_Scripts;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageCombatController : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
    private EnemyMovement _enemyMovement;
    private EnemyAttack _enemyAttack;
    private EnemyPooling _enemyPooling;

    [SerializeField] private int _stage = 0;
    [SerializeField] private int _enemyCountByStage = 0;

    private float _stageAlgorithmTimer = 0f;

    [SerializeField] private TMP_Text stageNumberText;

    [Header("Enemy Details")]
    [SerializeField] private Image enemyImage;
    [SerializeField] private Sprite enemyTypeSprite;
    [SerializeField] private TMP_Text enemyType;

    [Header("Attack Details")]
    [SerializeField] private Image attackImage;
    [SerializeField] private Sprite attackTypeSprite;
    [SerializeField] private TMP_Text attackDamage;

    [Header("Speed Details")]
    [SerializeField] private Image speedImage;
    [SerializeField] private Sprite speedTypeSprite;
    [SerializeField] private TMP_Text speedValue;

    [SerializeField] private float waitTimeForStagePass = 3f;
    
    public bool isStagePassed = false;

    private void Awake()
    {
        _enemyAttack = FindObjectOfType<EnemyAttack>();
        _enemyHealth = FindObjectOfType<EnemyHealth>();
        _enemyMovement = FindObjectOfType<EnemyMovement>();
        _enemyPooling = FindObjectOfType<EnemyPooling>();
        _stage = 1; // default stage
    }

    private void Update()
    {
        // Ensure enemies are spawned only if needed
        if (_enemyCountByStage - Enemy.killedEnemies > 0)
        {
            SpawnController();
        }

        // Stage logic
        _stageAlgorithmTimer += Time.deltaTime;
        if (_stageAlgorithmTimer >= 1f && isStagePassed)
        {
            _stageAlgorithmTimer = 0f;
            StageAlgorithm();
            isStagePassed = false;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void StageAlgorithm()
    {
        StagePassed();
        AssignDetailsOfStage();
        StartCoroutine(ShowStageScreen());
    }

    private IEnumerator ShowStageScreen()
    {
        UIManager.Instance.ShowVictoryScreen(true);
        yield return new WaitForSeconds(waitTimeForStagePass);
        UIManager.Instance.ShowVictoryScreen(false);
    }

    private void StagePassed()
    {
        _stage++;
        _enemyCountByStage = _stage * 2;
        TryToReturnObjectsFromPool(_enemyCountByStage);
    }

    private void TryToReturnObjectsFromPool(int objectCount)
    {
        //todo GameObject.FindGameObjectsWithTag("Enemy") usage
        
        // Reuse objects from pool first
        for (int i = 0; i < Mathf.Min(objectCount, EnemyPooling.Instance.enemiesScriptInPool.Count); i++)
        {
            EnemyPooling.Instance.enemiesScriptInPool[i].ReturnFromPool();
        }

        // If pool is exhausted, instantiate remaining enemies
        if (objectCount > EnemyPooling.Instance.enemiesScriptInPool.Count)
        {
            int difference = objectCount - EnemyPooling.Instance.enemiesScriptInPool.Count;
            EnemyGenerator.Instance.InstantiateEnemyWithCount(difference);
        }
    }

    private void SpawnController()
    {
        if (_enemyCountByStage - Enemy.killedEnemies <= 0)
        {
            Enemy.killedEnemies = 0;
            isStagePassed = true;
        }
    }
    
    private void AssignDetailsOfStage()
    {
        enemyImage.sprite = enemyTypeSprite;
        attackImage.sprite = attackTypeSprite;
        speedImage.sprite = speedTypeSprite;
        
        stageNumberText.text = _stage.ToString();
        enemyType.text = _enemyAttack.enemyType;
        attackDamage.text = _enemyAttack.enemyDamage.ToString(CultureInfo.InvariantCulture);
        //speedValue.text = _enemyMovement.randomEnemySpeed.ToString(CultureInfo.InvariantCulture);
    }
}