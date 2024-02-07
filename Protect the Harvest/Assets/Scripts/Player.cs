using System;
using UnityEditor.Animations;
using UnityEngine;
using Interfaces;
using Abstracts;
using Managers;
using Enums;

public class Player : MainMechanics , ICombatState
{
    private AudioManager _audioManager;
    private UIManager _uiManager;
    private Enemy _enemy;
    private Inventory _inventory;
    
    [SerializeField] private AnimatorController playerAnimator;

    private void Awake()
    {
        if (playerAnimator == null)
        {
            Debug.LogError("No Animator Controller set on " + gameObject.name);
        }
        
        _audioManager = AudioManager.Instance;
        _uiManager = UIManager.Instance;
        _enemy = FindObjectOfType<Enemy>();
        _inventory = FindObjectOfType<Inventory>();
        


    }

    private void Start()
    {
        CombatController.Instance.CombatEvent += HandleCombatEvent;
        
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (TouchPhase.Began == Input.GetTouch(0).phase)
            {
               //InstantiateEffect();
               Attack();
            }
        }
    }

    public override float currentDamage { get; set; }
    public override float currentHealth { get; set; }
    public override float currentDefence { get; set; }

    public override void Attack()
    {
        //TODO: ANIMATION (player animation controller)
        
        //TODO: SHOOT EFFECT & SOUND (AudioManager)
        
        //TODO: REDUCE HEALTH OF ENEMY
        var damageToDeal = _inventory.currentDamage;
        enemyHealthBar.value += damageToDeal;
        print(damageToDeal);

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

    public void Handle(CombatController combatController)
    {
        throw new System.NotImplementedException();
    }

    public override void InstantiateEffect()
    {
        base.InstantiateEffect();
        print("instantiate effect");
        //TODO CUSTOM EFFECT HERE
    }
}