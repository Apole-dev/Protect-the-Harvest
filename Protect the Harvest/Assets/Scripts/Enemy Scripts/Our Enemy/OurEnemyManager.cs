using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Enemy_Scripts.Our_Enemy
{
    public class OurEnemyManager : MonoBehaviour
    {
        [SerializeField] private float delayCount;
        [SerializeField] private float firstInstantiateCount;
        
        [SerializeField] private OurEnemyGeneration ourEnemyGeneration;
        [SerializeField] private OurEnemyPooling ourEnemyPooling;
        
        [SerializeField] private GameObject[] instantiableOurEnemies;
        
        public int deadCount = 0;
        public int stagePassedCount = 2;

        private bool _isStagePassed;
        private int _stage;
        private int _tempStage;
        private float _time;
        
        [SerializeField] private List<GameObject> instantiatedEnemies;

        private void Awake()
        {
            _stage = 1;
            _time = 0;
            _isStagePassed = false;
        }



        private void Update()
        {
            StageAlgorithm();
        }

        private void StageAlgorithm()
        {
            int randomOurEnemy = Random.Range(0, instantiableOurEnemies.Length);
            _time += Time.deltaTime;
            _tempStage = _stage;

            if (deadCount > stagePassedCount)
            {
                _isStagePassed = true;
                deadCount = 0;
                stagePassedCount++;
            }
            
            if (_isStagePassed)
            {
                instantiatedEnemies = ourEnemyGeneration.InstantiateOurEnemy(instantiableOurEnemies[randomOurEnemy], 2, 3);
                _isStagePassed = false;
            }

            if (_stage != _tempStage)
            {
                print("Stage Passed");
                _isStagePassed = true;
            }
        }
    }
}