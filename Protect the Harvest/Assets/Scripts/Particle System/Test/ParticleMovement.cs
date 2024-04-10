using System;
using UnityEngine;

namespace Particle_System.Test
{
    public class ParticleMovement : MonoBehaviour
    {
        public float value;
        private void Update()
        {
            value += Time.deltaTime;
        }
    }
}
