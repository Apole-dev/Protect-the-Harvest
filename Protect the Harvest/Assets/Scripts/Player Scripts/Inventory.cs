using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using Managers;
using Game_Scriptable_Objects;
using Player_Scripts.Weapons;
using TMPro;
using Random = UnityEngine.Random;

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

        [Header("Attributes")]
        public Weapon selectedWeapon;
        [SerializeField] private AllScriptableData newWeapon;
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
            AssignPrimaryWeaponAttributes();
            AssignPrimaryShieldAttributes();
            AssignPrimaryHealthAttributes();
            
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
            selectedWeapon = weaponsList[Random.Range(0, weaponsList.Count)]; //Get Random Weapon Type From Weapon List
            newWeapon = selectedWeapon.AssignNewWeapon(); //Selected Weapon 
            //gunImage.sprite = newWeapon.weaponImage.sprite;
            gunRarityText.text = newWeapon.rarity.ToString();
            
            //Assign Current Damage and Range
            playerAttack.currentGunType = selectedWeapon.GunType;
            playerAttack.currentDamage = newWeapon.damage;
            playerAttack.currentRange = newWeapon.range;
        }
        
        private void AssignPrimaryHealthAttributes()
        {
            
        }
        
        private void AssignPrimaryShieldAttributes()
        {
            
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