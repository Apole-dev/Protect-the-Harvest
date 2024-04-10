using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using Managers;
using Game_Scriptable_Objects;
using Particle_System;
using Player_Scripts.Weapons;
using TMPro;
using Random = UnityEngine.Random;

namespace Player_Scripts
{
    public class Inventory : MonoBehaviour
    {
        #region Serialized Fields

        [Header("UI Elements")]
        [SerializeField] private Button gunButton;
        [SerializeField] private TMP_Text gunValueText;
        [SerializeField] private Image gunImage;
        [SerializeField] private TMP_Text gunRarityText;
        
        [Space]
        
        [SerializeField] private Button healthButton;
        [SerializeField] private TMP_Text healthValueText;
        [SerializeField] private Image healthImage;
        [SerializeField] private TMP_Text healthRarityText;

        [Space]
        
        [SerializeField] private Button shieldButton;
        [SerializeField] private TMP_Text shieldValueText;
        [SerializeField] private Image shieldImage;
        [SerializeField] private TMP_Text shieldRarityText;

        [Header("Attributes")]
        public Weapon selectedWeaponType;
        [SerializeField] private ObjectsScriptableData newWeapon;
        [SerializeField] private List<Weapon> weaponsList;
        
        [SerializeField] private Fence fence;
        [SerializeField] private PlayerHeal playerHeal;
        [SerializeField] private PlayerAttack playerAttack;
        
        

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            weaponsList = FindObjectsOfType<MonoBehaviour>().OfType<Weapon>().ToList();
            UIManager.Instance.ShowCardSelectionScreen(true);
            
            CheckReferences();
            // AssignPrimaryWeaponAttributes();
            // AssignPrimaryShieldAttributes();
            // AssignPrimaryHealthAttributes();
            
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
        

        private void AssignPrimaryWeaponAttributes()
        {
            selectedWeaponType = weaponsList[Random.Range(0, weaponsList.Count)]; //Get Random Weapon Type From Weapon List
            newWeapon = selectedWeaponType.AssignNewWeapon(); //Get Random Weapon From Weapon Type
            playerAttack.ChangeWeapon(selectedWeaponType,newWeapon);
        }
        
        private void AssignPrimaryHealthAttributes()
        {
           var healthObject = playerHeal.GetRandomHealthObject();
           //healthImage.sprite = healthObject.healthObjectSprite; //todo
           healthValueText.text = healthObject.effectValue.ToString();
           healthRarityText.text = healthObject.rarity.ToString();

           playerHeal.Heal(healthObject.effectValue);

        }
        
        private void AssignPrimaryShieldAttributes()
        {
            var shieldObject = fence.GetRandomShield();
            fence.IncreaseShield(shieldObject.effectValue);
            
            shieldValueText.text = shieldObject.effectValue.ToString();
            shieldRarityText.text = shieldObject.rarity.ToString();
            
            //shieldImage.sprite = shieldObject.shieldObjectSprite;
            
        }

        #endregion

        #region Button Click Handlers

        public void WeaponClick()
        {
            UIManager.Instance.ShowCardSelectionScreen(false); //Hide the card selection screen
            AssignPrimaryWeaponAttributes();
        }

        public void HealthClick()
        {
            UIManager.Instance.ShowCardSelectionScreen(false); //Hide the card selection screen
            AssignPrimaryHealthAttributes();
        }

        public void ShieldClick()
        {
            UIManager.Instance.ShowCardSelectionScreen(false); //Hide the card selection screen
            AssignPrimaryShieldAttributes();
        }

        #endregion
    }
}