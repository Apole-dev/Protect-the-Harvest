using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class AbilityController: MonoBehaviour
    {
        private readonly List<Action> _abilityList = new List<Action>();
        private Rigidbody _rigidBody;
        
        [SerializeField] private float accelerationValue;
        [SerializeField] private float slideDuration;
        [SerializeField] private GameObject player;

        [SerializeField] private Image buttonAbilityImage;
        [SerializeField] private float coolDown = 3f;
        [SerializeField] private bool isInCoolDown;

        public string currentAbility;

        private void Awake()
        {
            _rigidBody = transform.parent.gameObject.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _abilityList.Add(Slide);
            _abilityList.Add(Invisible);
        }

        public void Slide() => StartCoroutine(AddForce());
        private void Invisible() => StartCoroutine(SetInvisible());
        
        private IEnumerator AddForce()
        {
            for (float time = 0; time < slideDuration; time += Time.deltaTime)
            {
                _rigidBody.AddForce(player.transform.forward * accelerationValue);
                yield return null;
            }
        }
        
        private IEnumerator SetInvisible()
        {
            var parent = transform.parent;
            parent.gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
            parent.gameObject.SetActive(true);
        }


        public void GetRandomAbility()
        {
            var randomIndex = UnityEngine.Random.Range(0, _abilityList.Count);
            _abilityList[randomIndex]();
            currentAbility = _abilityList[randomIndex].ToString();
            AbilityCoolDown();
        }

        private void AbilityCoolDown()
        {
            StartCoroutine(CoolDown());
            StartCoroutine(AbilityCoolDownRepresentation());
        }
        
        
        private IEnumerator CoolDown()
        {
            if (isInCoolDown)
                yield break;

            yield return new WaitForSeconds(coolDown);
            isInCoolDown = false;
        }
        
        
        private IEnumerator AbilityCoolDownRepresentation()
        {
            for (var t = 0; t < coolDown; t += (int)Time.time)
            {
                buttonAbilityImage.fillAmount = 1f - 1f/coolDown;
                yield return null; 
            }
            buttonAbilityImage.fillAmount = 1f;
            isInCoolDown = true;
        }
        
    }
}