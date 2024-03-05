using Singleton;
using UnityEngine;

namespace Managers
{
    public class EffectManager : MonoSingleton<EffectManager>
    {
        [Header("Enemy Effects")]
        [SerializeField] private ParticleSystem enemyHitEffect;
        [SerializeField] private ParticleSystem enemyDeathEffect;
        [SerializeField] private ParticleSystem enemyAttackEffect;
        
        [Header("Player Effects")]
        [SerializeField] private ParticleSystem playerHitEffect;
        [SerializeField] private ParticleSystem playerDeathEffect;
        [SerializeField] private ParticleSystem playerAttackEffect;
        
        public void PlayEnemyDeathEffect(Transform enemyTransform)
        {
            enemyDeathEffect.transform.position = enemyTransform.position;
            enemyDeathEffect.Play();
        }

        public void PlayEnemyHitEffect(Transform enemyTransform)
        {
            enemyDeathEffect.transform.position = enemyTransform.position;
            enemyHitEffect.Play();
        }
        
        public void PlayEnemyAttackEffect()
        {
            enemyAttackEffect.Play();
        }
        

        public void PlayPlayerAttackEffect()
        {
            playerAttackEffect.Play();
        }

        public void PlayPlayerDeathEffect()
        {
            playerDeathEffect.Play();
        }

        public void PlayPlayerHitEffect()
        {
            playerHitEffect.Play();
        }
        
        
    }
}