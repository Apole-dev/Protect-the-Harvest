using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Enemy_Scripts.Our_Enemy
{
    public class OurEnemyPooling : MonoBehaviour
    {
        [SerializeField] private List<GameObject> ourEnemyList;
        
        public void AddOurEnemyToPool(GameObject ourEnemy)
        {
            ourEnemyList.Add(ourEnemy);
            ourEnemy.SetActive(false);
        }
        
        public void RemoveOurEnemyFromPool()
        {
            if (ourEnemyList.Count == 0 )
            {
                return;
            }
            
            
            int randomIndex = Random.Range(0, ourEnemyList.Count);
            ourEnemyList[randomIndex].SetActive(true);
            ourEnemyList[randomIndex].transform.position = new Vector3(1,1,1);
            ourEnemyList.Remove(ourEnemyList[randomIndex]);
            
        }
    }
}