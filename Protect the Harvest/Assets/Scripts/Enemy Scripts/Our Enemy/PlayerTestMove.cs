using System;
using UnityEngine;

namespace Enemy_Scripts.Our_Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTestMove : MonoBehaviour
    {
        private Rigidbody _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            CharacterMove();
        }

        private void CharacterMove()
        {
            float value = Mathf.PingPong(Time.time * 3, 2.5f - 0.5f)+2f;
            _rb.position = new Vector3(value,transform.position.y,transform.position.z);
        }
    }
}