using UnityEngine.UI;
using UnityEngine;
using Managers;
using Enums;
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
        

        [Header("Attributes")]
        public float chosenDamage;
        public float chosenHealth;
        public float chosenShield;
        public GunType gunType;

        
        [Header("Card Selection")]
        [SerializeField] private GameObject cardSelectionScreen;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            CheckReferences();
        }

        private void Start()
        {
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

            cardSelectionScreen.SetActive(false);
        }

        private void UpdateCardSelectionScreen()
        {
            if (UIManager.Instance.cardSelectionScreen)
            {
                cardSelectionScreen.SetActive(true);
                AssignPrimaryAttributes();
            }
            else
            {
                cardSelectionScreen.SetActive(false);
            }
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
            chosenDamage = ResourceManager.Instance.clickWeaponResourceObject.effectValue;
            gunType = ResourceManager.Instance.clickWeaponResourceObject.gunType;
            UIManager.Instance.cardSelectionScreen = false;
            ResourceManager.Instance.RandomObjectGenerator();
        }

        public void ShieldClick()
        {
            chosenShield = ResourceManager.Instance.clickShieldResourceObject.effectValue;
            UIManager.Instance.cardSelectionScreen = false;
            ResourceManager.Instance.RandomObjectGenerator();
        }

        public void HealthClick()
        {
            chosenHealth = ResourceManager.Instance.clickHealthResourceObject.effectValue;
            UIManager.Instance.cardSelectionScreen = false;
            ResourceManager.Instance.RandomObjectGenerator();
        }

        #endregion
    }
}
