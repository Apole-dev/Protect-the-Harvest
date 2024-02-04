using Abstracts;
using Enums;
using Managers;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MainMechanics 
{
    private AudioManager _audioManager;
    private UIManager _uiManager;
    
    [SerializeField] private AnimatorController playerAnimator;

    private void Awake()
    {
        if (playerAnimator == null)
        {
            Debug.LogError("No Animator Controller set on " + gameObject.name);
        }
        
        _audioManager = AudioManager.Instance;
        _uiManager = UIManager.Instance;
        
        
    }

    private void Start()
    {
        CombatController.Instance.CombatEvent += HandleCombatEvent;
        
    }

    public override void Attack()
    {
        //TODO: ANIMATION (player animation controller)
        
        //TODO: SHOOT EFFECT & SOUND (AudioManager)
        
        //TODO: REDUCE HEALTH OF ENEMY
        enemyHealthBar.value -= ResourceManager.Instance.clickWeaponResourceObject.effectValue;
    }

    public override void Defence()
    {
        //TODO: ANIMATION (player animation controller)
        
        //TODO: DEFENCE EFFECT & SOUND // (AudioManager) 
        
        //TODO: REDUCE DAMAGE OF ENEMY ATTACK
    }

    public override void Heal()
    {
        //TODO: ANIMATION (player animation controller)
        
        //TODO: HEAL EFFECT & SOUND // (AudioManager)
        
        //TODO: INCREASE HEALTH
    }

    private void HandleCombatEvent(object sender, CombatEventArgs e)
    {
      
        if (e.winner == "Player")
        {
            //TODO: PLAYER WIN
            print("Player win");
            _uiManager.UpdateScore(5);
            _audioManager.PlaySound(SoundType.PlayerWinSound);
        }
    }
}