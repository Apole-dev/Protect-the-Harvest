using Abstracts;
using Managers;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MainMechanics 
{
    private AudioManager _audioManager;
    private UIManager _uiManager;
    
    
    [SerializeField] private AnimatorController enemyAnimator;

    private void Awake()
    {
        if (enemyAnimator == null)
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
        
        //TODO: REDUCE HEALTH OF Player
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
        enemyHealthBar.value += ResourceManager.Instance.clickHealthResourceObject.effectValue;
    }

    private void HandleCombatEvent(object sender, CombatEventArgs e)
    {
        if (e.winner == "Enemy")
        {
            //TODO: ENEMY WIN
        }

        if (e.winner == "Player")
        {
            //TODO: PLAYER WIN
            print("Player Wins Enemy Class");
        }
    }


}