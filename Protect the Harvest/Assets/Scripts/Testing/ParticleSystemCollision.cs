using System;
using System.Collections.Generic;
using UnityEngine;

namespace Testing
{
    public class ParticleSystemCollision : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        { 
           var cl = Physics.OverlapSphere(other.transform.position, 10f, LayerMask.GetMask("Enemy"));
           foreach (var VARIABLE in cl)
           {
               VARIABLE.gameObject.SetActive(false);
           }
        }

        
    }
}
