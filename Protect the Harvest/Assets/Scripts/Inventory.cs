using Managers;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image gunImage,shieldImage,healthImage;

    private void Awake()
    {
        if (ResourceManager.Instance.ResourceObjectExists() == false) return ;

        #region Game Primarly
            gunImage.sprite = ResourceManager.Instance.clickWeaponResourceObject.gameObjectImage;
            shieldImage.sprite = ResourceManager.Instance.clickShieldResourceObject.gameObjectImage;
            healthImage.sprite = ResourceManager.Instance.clickHealthResourceObject.gameObjectImage;
        #endregion
    }
}