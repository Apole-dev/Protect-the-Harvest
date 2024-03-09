
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using Managers;
using Enums;
using Player_Scripts.Weapons;
using TMPro;



namespace Player_Scripts
{
    public class Inventory : MonoBehaviour
    {
        #region Serialized Fields

        [Header("UI Elements")]
        [SerializeField] private Image gunImage;
        [SerializeField] private Image shieldImage;
        [SerializeField] private Image healthImage;
        [Space]
        
        [SerializeField] private Button gunButton;
        [SerializeField] private Button shieldButton;
        [SerializeField] private Button healthButton;
        [Space]
        
        [SerializeField] private TMP_Text gunRarityText;
        [SerializeField] private TMP_Text shieldRarityText;
        [SerializeField] private TMP_Text healthRarityText;
            
        [SerializeField] private bool isCardSelection;

        [Header("Attributes")]
        public int selectedDamage;
        public int selectedHealth;
        public GunType gunType;
        public Weapon selectedWeapon;
        private List<Weapon> _weaponsList;

        [SerializeField] private Fence fence;
        [SerializeField] private PlayerHeal playerHeal;
        [SerializeField] private PlayerAttack playerAttack;
        

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            CheckReferences();
            _weaponsList = FindObjectsOfType<MonoBehaviour>().OfType<Weapon>().ToList();
        }

        private void Start()
        {
            //If Not Gun Chosen give pistol as a first gun 
            gunType = GunType.Pistol;
            selectedDamage = 1;
            
            ResourceManager.Instance.RandomObjectGenerator();

            
        }

        private void FixedUpdate()
        {
            UpdateCardSelectionScreen();
        }

        #endregion

        #region UI and Card Selection Logic

        private void CheckReferences()
        {
            if (ResourceManager.Instance.ResourceObjectExists() == false) return;
            if (gunImage == null || shieldImage == null || healthImage == null) return;
            if (gunRarityText == null || shieldRarityText == null || healthRarityText == null) return;
            if (gunButton == null || shieldButton == null || healthButton == null) return;

            UIManager.Instance.ShowCardSelectionScreen(false);
        }

        private void UpdateCardSelectionScreen()
        {
            UIManager.Instance.ShowCardSelectionScreen(isCardSelection);
        }

        private void AssignPrimaryAttributes()
        {
            gunImage.sprite = ResourceManager.Instance.clickWeaponResourceObject.gameObjectImage;
            shieldImage.sprite = ResourceManager.Instance.clickShieldResourceObject.gameObjectImage;
            healthImage.sprite = ResourceManager.Instance.clickHealthResourceObject.gameObjectImage;

            gunRarityText.text = ResourceManager.Instance.clickWeaponResourceObject.rarity.ToString();
            shieldRarityText.text = ResourceManager.Instance.clickShieldResourceObject.rarity.ToString();
            healthRarityText.text = ResourceManager.Instance.clickHealthResourceObject.rarity.ToString();
        }

        #endregion

        #region Button Click Handlers

        public void WeaponClick()
        {
            //Weapon Objects Data's  
            gunType = ResourceManager.Instance.clickWeaponResourceObject.gunType;
            selectedDamage = ResourceManager.Instance.clickWeaponResourceObject.effectValue;

            foreach (var weapon in _weaponsList)
            {
                if (weapon.gunType == gunType)
                {
                    selectedWeapon = weapon;
                    selectedWeapon.damage = selectedDamage;
                    print(selectedWeapon);
                }
            }
            
            playerAttack.AssignGun(gunType, selectedDamage); //Assign the gun type and damage for player attack script
            
            isCardSelection = false; //Show the card selection screen
            
            ResourceManager.Instance.RandomObjectGenerator(); //Reset the objects and generate new ones
        }

        public void ShieldClick()
        {
            isCardSelection = false;
            fence.ChangeFence(fence.GetRandomFenceType());
            ResourceManager.Instance.RandomObjectGenerator();
        }

        public void HealthClick()
        {
            selectedHealth = ResourceManager.Instance.clickHealthResourceObject.effectValue;
            playerHeal.Heal(selectedHealth);
            isCardSelection = false;
            ResourceManager.Instance.RandomObjectGenerator();
        }

        #endregion
    }
}
