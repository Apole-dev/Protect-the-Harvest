using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts.Ability
{
    public class CoolDownController : MonoBehaviour
    {
        public float abilityCoolDownTime;
        public float weaponAttackCoolDownTime;
        private float tempWeaponCoolDownTime;
        private float tempAbilityCoolDownTime;

        [SerializeField] private Button weaponButton;
        [SerializeField] private Button abilityButton;
        
        [SerializeField] private Image weaponButtonCoolDownImage;
        [SerializeField] private Image abilityButtonCoolDownImage;
        
        private bool _isAbilityInCoolDown = false;
        private bool _isWeaponAttackInCoolDown = false;

        private void Awake()
        {
            tempWeaponCoolDownTime = weaponAttackCoolDownTime;
            tempAbilityCoolDownTime = abilityCoolDownTime;
        }

        public void SetWeaponCoolDown()
        {
            if (!_isWeaponAttackInCoolDown)
            {
                _isWeaponAttackInCoolDown = true;
                StartCoroutine(StartWeaponCoolDown());
            }
        }
        
        public void SetAbilityCoolDown()
        {
            if (!_isAbilityInCoolDown)
            {
                _isAbilityInCoolDown = true;
                StartCoroutine(StartAbilityCoolDown());
            }
        }

        private IEnumerator StartWeaponCoolDown()
        {
            float timer = 0f;

            while (timer < weaponAttackCoolDownTime)
            {
                weaponButton.interactable = false;
                timer += Time.deltaTime;

                float fillAmount = 1f - (timer / weaponAttackCoolDownTime);
                weaponButtonCoolDownImage.fillAmount = fillAmount;
                
                yield return null;
            }

            if (weaponButtonCoolDownImage.fillAmount <= 0f ) 
            {
                weaponButtonCoolDownImage.fillAmount = 1f;
                weaponButton.interactable = true;
            }
            
            _isWeaponAttackInCoolDown = false;
        }

        private IEnumerator StartAbilityCoolDown()
        {
            float timer = 0f;

            while (timer < abilityCoolDownTime)
            {
                abilityButton.interactable = false;
                timer += Time.deltaTime;
                
                float fillAmount = 1f - (timer / abilityCoolDownTime);
                abilityButtonCoolDownImage.fillAmount = fillAmount;
                
                yield return null;
            }

            if (abilityButtonCoolDownImage.fillAmount <= 0f )
            {
                abilityButtonCoolDownImage.fillAmount = 1f;
                abilityButton.interactable = true;
            }
            
            _isAbilityInCoolDown = false;
        }
    }
}