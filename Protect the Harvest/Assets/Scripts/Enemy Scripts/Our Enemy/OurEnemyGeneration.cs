using System;
using System.Collections;
using System.Collections.Generic;
using Enemy_Scripts.Our_Enemy.Interface;
using UnityEngine;

namespace Enemy_Scripts.Our_Enemy
{
    public class OurEnemyGeneration : MonoBehaviour
    {
        [SerializeField] private Transform ourEnemyInstantiateTransform;
        [SerializeField] private GameObject testEnemy;
        
        public bool instantiateController;
        public List<GameObject> instantiatedOurEnemies;
        public GameObject lastInstantiatedOurEnemy;
        
        private void Start()
        {
            //first instantiate
            StartCoroutine(InstantiateEnemy(testEnemy, 2, 3));
        }
        private void Update()
        {
            // if (instantiateController)
            // {
            //     StartCoroutine(InstantiateEnemy(testEnemy, 2, 3));
            //     instantiateController = false;
            // }
        }

        public List<GameObject> InstantiateOurEnemy(GameObject ourEnemy, int count, int delayCount)
        {
            StartCoroutine(InstantiateEnemy(ourEnemy, count, delayCount));
            return instantiatedOurEnemies;
        }

        private IEnumerator InstantiateEnemy(GameObject ourEnemy,int count,int delayCount)
        {
            instantiatedOurEnemies.Clear();
            
            for (int i = 0; i < count; i++)
            {
                print(GetRandomPositionForOurEnemy());
                lastInstantiatedOurEnemy = Instantiate(ourEnemy, GetRandomPositionForOurEnemy(), Quaternion.identity);
                lastInstantiatedOurEnemy.GetComponent<IOurEnemyMovement>().Stop();
                instantiatedOurEnemies.Add(lastInstantiatedOurEnemy);
                yield return new WaitForSeconds(delayCount);
            }
        }
        
        private Vector3 GetRandomPositionForOurEnemy()
        {
            float randomX = UnityEngine.Random.Range(-5, 5);
            var position = ourEnemyInstantiateTransform.position;
            Vector3 newPosition = position.AddXWidth(randomX);
            return newPosition;
        }
       
    }
}