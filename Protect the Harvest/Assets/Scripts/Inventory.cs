using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    [SerializeField] private Image gunImage, shieldImage, healthImage;

    [SerializeField] private Button gunButton, shieldButton, healthButton;

    [SerializeField] private TMP_Text gunRarityText, shieldRarityText, healthRarityText;
    
    public float currentDamage, currentHealth, currentShield;
    
    [SerializeField] private GameObject cardSelectionScreen;

    private void Awake()
    {
        #region Contrroll

        if (ResourceManager.Instance.ResourceObjectExists() == false) return;
        if (gunImage == null || shieldImage == null || healthImage == null) return;
        if (gunRarityText == null || shieldRarityText == null || healthRarityText == null) return;
        if (gunButton == null || shieldButton == null || healthButton == null) return;

        
        cardSelectionScreen.SetActive(false);
        #endregion

    }

    private void Start()
    {
        ResourceManager.Instance.RandomObjectGenerator();
    }

    private void FixedUpdate()
    {
        if (UIManager.Instance.cardSelectionScreen == true)
        {
            cardSelectionScreen.SetActive(true);
            #region Assign Primarly

            gunImage.sprite = ResourceManager.Instance.clickWeaponResourceObject.gameObjectImage;
            shieldImage.sprite = ResourceManager.Instance.clickShieldResourceObject.gameObjectImage;
            healthImage.sprite = ResourceManager.Instance.clickHealthResourceObject.gameObjectImage;

            gunRarityText.text = ResourceManager.Instance.clickWeaponResourceObject.rarity.ToString();
            shieldRarityText.text = ResourceManager.Instance.clickShieldResourceObject.rarity.ToString();
            healthRarityText.text = ResourceManager.Instance.clickHealthResourceObject.rarity.ToString();

            #endregion
        }
        else
        {
            cardSelectionScreen.SetActive(false);
        }
    }

    public void WeaponClick()
    {
        currentDamage = ResourceManager.Instance.clickWeaponResourceObject.effectValue;
        UIManager.Instance.cardSelectionScreen = false;
        ResourceManager.Instance.RandomObjectGenerator();
        print("damage: " + currentDamage);
    }

    public void ShieldClick()
    {
        currentShield = ResourceManager.Instance.clickShieldResourceObject.effectValue;
        UIManager.Instance.cardSelectionScreen = false;
        ResourceManager.Instance.RandomObjectGenerator();
    }
    
    public void HealthClick()
    {
        currentHealth = ResourceManager.Instance.clickHealthResourceObject.effectValue;
        UIManager.Instance.cardSelectionScreen = false;
        ResourceManager.Instance.RandomObjectGenerator();
    }

}