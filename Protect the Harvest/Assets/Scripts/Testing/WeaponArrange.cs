using System;
using UnityEngine;

namespace Testing
{
    public class WeaponArrange : MonoBehaviour
    {
        public float radius;
        public float height;

        public float castDistance;
        

        public LayerMask layerMask;

        private void OnDrawGizmos()
        {
            Vector3 castDirection = transform.forward;
            Vector3 castOrigin = transform.position + Vector3.up * height / 2.0f;

            Gizmos.color = Color.red;
            

            if (Physics.CapsuleCast(castOrigin, castOrigin + castDirection * castDistance, height, castDirection, out RaycastHit hit, castDistance))
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(hit.point, 0.1f);
            }
        }


        private void Update()
        {
            Draw();
        }

        private void Draw()
        {
            
            Vector3 castDirection = transform.forward;
            Vector3 castOrigin = transform.position + Vector3.up * height / 2.0f;

            RaycastHit hit;

            if (Physics.CapsuleCast(castOrigin, castOrigin + castDirection * castDistance, radius, castDirection, out hit, castDistance))
            {
                
                Debug.Log("Engelle çarpışma!");
            }
        }
    }
}
