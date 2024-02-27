using System.Collections;
using System.Globalization;
using Enemy_Scripts;
using Player_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
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


    private void Awake()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
        _stage = 1; // default stage
    }

    public void StageChangeTesting()
    {
        _stage += 1;
        PlayerAttack.stagePassed = true;
        StageAlgorithm();
        StartCoroutine(ResetValue());
    }

    private IEnumerator ResetValue()
    {
        yield return new WaitForSeconds(0.3f);
        PlayerAttack.stagePassed = false;
    }

    private void StageAlgorithm()
    {
        _tempStage = _stage;
        
        // If stage is passed, increase stage
        if (PlayerAttack.stagePassed) _stage += 1;
        
        if (_tempStage < _stage)
        {
            EnemyGenerator.enemiesLimitNum += 1;
            print(EnemyGenerator.enemiesLimitNum);
            AssignDetails();
        }

    }

    private void AssignDetails()
    {
        enemyImage.sprite = enemyTypeSprite;
        attackImage.sprite = attackTypeSprite;
        speedImage.sprite = speedTypeSprite;
        
        
        stageNumberText.text = _stage.ToString();
        enemyType.text = EnemyAttack.enemyType.ToString(CultureInfo.InvariantCulture);
        attackDamage.text = EnemyAttack.enemyDamage.ToString(CultureInfo.InvariantCulture);
        speedValue.text = EnemyMovement.enemySpeed.ToString(CultureInfo.InvariantCulture);
    }
}