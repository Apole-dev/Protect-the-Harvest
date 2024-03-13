using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts.Ability
{
    public class AbilityController: MonoBehaviour
    {
        private readonly List<Action> _abilityList = new List<Action>();
        private Rigidbody _rigidBody;
        
        [SerializeField] private float accelerationValue;
        [SerializeField] private float slideDuration;
        [SerializeField] private GameObject player;
        private void Awake()
        {
            _rigidBody = transform.parent.gameObject.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _abilityList.Add(Slide);
        }

        public void Slide() => StartCoroutine(SlideForce());
        private IEnumerator SlideForce()
        {
            for (float time = 0; time < slideDuration; time += Time.deltaTime)
            {
                _rigidBody.AddForce(player.transform.forward * accelerationValue);
                yield return null;
            }
        }
    }
}