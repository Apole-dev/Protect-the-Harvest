using System;
using System.Collections.Generic;
using Enemy_Scripts.Our_Enemy.Interface;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy_Scripts.Our_Enemy
{
    public class OurEnemyUIInteract : MonoBehaviour
    { 
        public Witcher.Witcher[] ourEnemies;
        public void KillEnemies()
        {
            ourEnemies = FindObjectsOfType<Witcher.Witcher>();
            foreach (var witcher in ourEnemies)
            {
                witcher.GetComponent<IOurEnemyHealth>().Death();
            }
        }
        
        
    }
}