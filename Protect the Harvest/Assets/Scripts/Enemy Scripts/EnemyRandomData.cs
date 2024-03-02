using System;
using Singleton;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy_Scripts
{
    public class EnemyRandomData : MonoSingleton<EnemyRandomData>
    {
        [SerializeField] private EnemyData enemyData;
        
        [Header("Health Stats")]
        private int _maxHealth;
        private int _minHealth;
        [Space]
        
        [Header("Attack Stats")]
        private int _maxDamage;
        private int _minDamage;
        [Space]
        
        [Header("Movement Stats")]
        private int _maxSpeed;
        private int _minSpeed;
        [Space]
        
        [Header("Fire Stats")]
        private int _maxFireRate;
        private int _minFireRate;

        private void Awake()
        {
            AssignData();
        }

        private void AssignData()
        {
            _maxHealth =enemyData.maxHealth;
            _minHealth =enemyData.minHealth;
            
            _maxDamage =enemyData.maxDamage;
            _minDamage =enemyData.minDamage;
            
            _maxSpeed =enemyData.maxSpeed;
            _minSpeed =enemyData.minSpeed;
            
            _maxFireRate =enemyData.maxFireRate;
            _minFireRate =enemyData.minFireRate;
        }

        public int GetRandomHealth()
        {
            return Random.Range(_minHealth, _maxHealth);
        }

        public int GetRandomDamage()
        { 
            return Random.Range(_minDamage, _maxDamage);
        }

        public int GetRandomSpeed()
        {
            return Random.Range(_minSpeed, _maxSpeed);
        }

        public int GetRandomFireRate()
        {
            return Random.Range(_minFireRate, _maxFireRate);
        }
    }
}