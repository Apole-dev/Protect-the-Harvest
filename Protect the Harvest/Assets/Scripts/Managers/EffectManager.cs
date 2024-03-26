using System;
using Enums;
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
        [SerializeField] private ParticleSystem playerHealEffect;

        [Header("Weapon Attack Effects")]
        [SerializeField] private ParticleSystem pistolAttackEffect;
        [SerializeField] private ParticleSystem shotgunAttackEffect;
        [SerializeField] private ParticleSystem sniperRifleAttackEffect;
        [SerializeField] private ParticleSystem rifleAttackEffect;
        [SerializeField] private ParticleSystem machineGunAttackEffect;
        [SerializeField] private ParticleSystem assaultRifleAttackEffect;
        [SerializeField] private ParticleSystem rocketLauncherAttackEffect;

        public void PlayPlayerEffect(EffectType effectType, Transform playerEffectTransform)
        {
            switch (effectType)
            {
                case EffectType.PlayerHealEffect:
                    PlayPlayerHealEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerDeathEffect:
                    PlayPlayerDeathEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerHitEffect:
                    PlayPlayerHitEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerPistolAttackEffect:
                    PlayPlayerPistolAttackEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerShotgunAttackEffect:
                    PlayPlayerShotgunAttackEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerRifleAttackEffect:
                    PlayPlayerRifleAttackEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerSniperRifleAttackEffect:
                    PlayPlayerSniperRifleAttackEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerMachineGunAttackEffect:
                    PlayPlayerMachineGunAttackEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerAssaultRifleAttackEffect:
                    PlayPlayerAssaultRifleAttackEffect(playerEffectTransform);
                    break;
                case EffectType.PlayerRocketLauncherAttackEffect:
                    PlayPlayerRocketLauncherAttackEffect(playerEffectTransform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(effectType), effectType, null);
            }
        }

        private void PlayPlayerHealEffect(Transform playerEffectTransform)
        {
            // playerHealEffect.transform.position = playerEffectTransform.position;
            // playerHealEffect.Play();
            
            print("player heal effect");
        }

        public void PlayEnemyEffect(EffectType effectType, Transform enemyEffectTransform)
        {
            switch (effectType)
            {
                case EffectType.EnemyDeathEffect:
                    PlayEnemyDeathEffect(enemyEffectTransform);
                    break;
                case EffectType.EnemyHitEffect:
                    PlayEnemyHitEffect(enemyEffectTransform);
                    break;
                case EffectType.EnemyAttackEffect:
                    PlayEnemyAttackEffect();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(effectType), effectType, null);
            }
        }

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
        

        //TODO IT WILL CHANGE LATER 
        public void PlayPlayerAttackEffect()
        {
            playerAttackEffect.Play();
        }

        public void PlayPlayerDeathEffect(Transform playerTransform)
        {
            playerDeathEffect.transform.position = playerTransform.position;
            playerDeathEffect.Play();
        }

        public void PlayPlayerHitEffect(Transform playerTransform)
        {
            playerHitEffect.transform.position = playerTransform.position;
            playerHitEffect.Play();
        }


        private void PlayPlayerPistolAttackEffect(Transform shootPoint)
        {
            pistolAttackEffect.transform.position = shootPoint.position;
            pistolAttackEffect.Play();
        }

        private void PlayPlayerShotgunAttackEffect(Transform shootPoint)
        {
            shotgunAttackEffect.transform.position = shootPoint.position;
            shotgunAttackEffect.Play();
        }

        private void PlayPlayerSniperRifleAttackEffect(Transform shootPoint)
        {
            sniperRifleAttackEffect.transform.position = shootPoint.position;
            sniperRifleAttackEffect.Play();
        }

        private void PlayPlayerMachineGunAttackEffect(Transform shootPoint)
        {
            machineGunAttackEffect.transform.position = shootPoint.position;
            machineGunAttackEffect.Play();
        }
        private void PlayPlayerRifleAttackEffect(Transform playerEffectTransform)
        {
            rifleAttackEffect.transform.position = playerEffectTransform.position;
            rifleAttackEffect.Play();
        }

        private void PlayPlayerAssaultRifleAttackEffect(Transform shootPoint)
        {
            assaultRifleAttackEffect.transform.position = shootPoint.position;
            assaultRifleAttackEffect.Play();
        }

        private void PlayPlayerRocketLauncherAttackEffect(Transform shootPoint)
        {
            rocketLauncherAttackEffect.transform.position = shootPoint.position;
            rocketLauncherAttackEffect.Play();
        }
    }
}