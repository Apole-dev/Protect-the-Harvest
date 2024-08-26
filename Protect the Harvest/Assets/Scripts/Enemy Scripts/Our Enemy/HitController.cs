using System;
using UnityEngine;

namespace Enemy_Scripts.Our_Enemy
{
    public class HitController : MonoBehaviour
    {
        private GameObject _hitGameObject;
        private void OnCollisionEnter(Collision other)
        {
            _hitGameObject = other.gameObject;
        }
        
        public GameObject GetHitGameObject() => _hitGameObject;


        private void Update()
        {
            ReSizer();
        }

        private void ReSizer()
        {
            float value = Mathf.PingPong(Time.time * 1, 0.2f - 0.05f) + 0.01f;
            transform.localScale = new Vector3(value, value, value);
        }
    }
}