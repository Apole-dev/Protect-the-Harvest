using TMPro;
using UnityEngine;


namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int damage;
        [SerializeField] private int shield;
        [SerializeField] private int speed;
        
        
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text damageText;
        [SerializeField] private TMP_Text shieldText;
        
        
        private StageCombatController _stageCombatController;
        
        private PlayerController _playerController;
        private PlayerAttack _playerAttack;
        private PlayerHeal _playerHeal;
        private Fence _fence;


        private void Awake()
        {
            _playerAttack = GetComponentInChildren<PlayerAttack>();
            _playerHeal = GetComponentInChildren<PlayerHeal>();
            _playerController = GetComponentInChildren<PlayerController>();
            
            
            _stageCombatController = FindObjectOfType<StageCombatController>();
        }
        
        private void Update()
        {
            _playerAttack.DrawWeaponShootLine();
            AssignPlayerInformation();
        }
        
        private void AssignPlayerInformation()
        {
            if (!_stageCombatController.isStagePassed) return;

            
            speed = _playerController.currentSpeed;
            damage = _playerAttack.currentAttackDamage;
            health = _playerHeal.currentHealth;
            //shield = _fence.currentShield;
            
            healthText.text = health.ToString();
            damageText.text = damage.ToString();
            shieldText.text = shield.ToString();
        }
        
    }
}