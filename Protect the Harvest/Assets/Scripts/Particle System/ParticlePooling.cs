using System.Collections.Generic;
using UnityEngine;

namespace Particle_System
{
    public class ParticlePooling:MonoBehaviour
    {
        [SerializeField] private GameObject playerShootPoint;
        
        private readonly List<GameObject> _particleList = new List<GameObject>();

        public void AddParticleToPool(GameObject particle)
        {
            _particleList.Add(particle);
            particle.SetActive(false);
            particle.transform.position = new Vector3(0,10,0);
        }

        public GameObject GetParticleFromPool()
        {
            if (_particleList.Count == 0)    
            {
                return null;
            }

            GameObject particleFromPool = _particleList[Random.Range(0, _particleList.Count)];
            _particleList.Remove(particleFromPool);
            return particleFromPool;
        }


        public int GetParticleCount()
        {
            return _particleList.Count;
        }
    }
}