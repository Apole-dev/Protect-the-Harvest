using Abstracts;
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
    
    public override void Attack()
    {
        //TODO: ANIMATION (player animation controller)
        
        //TODO: SHOOT EFFECT & SOUND (AudioManager)
        
        //TODO: REDUCE HEALTH OF ENEMY
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

    
    
    public override void PlayerWin()
    {
        //TODO: ANIMATION (player animation controller win animation)
        
        //TODO: OPEN WIN MENU
        
        //TODO: UPDATE COINS
        
        //MAYBE: UPDATE LEVEL
    }
    
}