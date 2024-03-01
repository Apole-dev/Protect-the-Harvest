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
    
    
    [SerializeField] private TMP_Text stageNumberText;
    private int _stage = 0;
    private int _tempStage;
    
    [SerializeField] private Image enemyImage;
    [SerializeField] private Sprite enemyTypeSprite;
    [SerializeField] private TMP_Text enemyType;

    [SerializeField] private Image attackImage;
    [SerializeField] private Sprite attackTypeSprite;
    [SerializeField] private TMP_Text attackDamage;

    [SerializeField] private Image speedImage;
    [SerializeField] private Sprite speedTypeSprite;
    [SerializeField] private TMP_Text speedValue;

    public bool isStagePassed = false;
    private void Awake()
    {
        _enemyAttack = FindObjectOfType<EnemyAttack>();
        _enemyHealth = FindObjectOfType<EnemyHealth>();
        _enemyMovement = FindObjectOfType<EnemyMovement>();
        _stage = 1; // default stage
    }


    private void Update()
    {
        StageAlgorithm();
    }

    private void StageAlgorithm()
    {
        //Todo> STAGE PASSED AREA
        if (Enemy.killedEnemies - EnemyGenerator.enemiesLimitNum == 0)
        {
            isStagePassed = true;
            print("stage passed");
            _stage += 1;
            Enemy.killedEnemies = 0;
            EnemyGenerator.enemiesLimitNum += 1;
            
            StartCoroutine(ShowStageScreen());
            AssignDetails();
        }
    }
    
    private IEnumerator ShowStageScreen()
    {
        UIManager.Instance.ShowVictoryScreen(true);
        yield return new WaitForSeconds(3f);
        UIManager.Instance.ShowVictoryScreen(false);
    }

    private void AssignDetails()
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