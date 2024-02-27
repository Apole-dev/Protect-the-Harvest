using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy_Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        public static float enemyHealth;
        
        private bool isDead; 
        
        [SerializeField] private GameObject player;
        [SerializeField] private Slider healthBar;
        [SerializeField] private ParticleSystem particleSystem;


        public void ReduceHealth(float damage)
        {
            healthBar.value -= damage;
            StartCoroutine(PlayParticleEffect());
            if (healthBar.value == 0)
            {
                isDead = true;
                EnemyGenerator.Instance.MoveToSafeArea(gameObject,isDead); // INSTEAD OF USING DESTROY
                healthBar.value =50f;
            }
        }
        
        private IEnumerator PlayParticleEffect()
        {
            yield return new WaitForSeconds(0.5f);
            particleSystem.Play();
        }
    }
}