using System;
using Enums;
using Singleton;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager :MonoSingleton<AudioManager>
    {
        
        [SerializeField] private AudioClip playerWinSound ;
        [SerializeField] private AudioClip playerLoseSound;
        
        [SerializeField] private AudioClip enemyWinSound;
        [SerializeField] private AudioClip enemyLoseSound;
        
        [SerializeField] private AudioClip pistol,shotgun,rifle,sniperRifle,machineGun,rocketLauncher,grenadeLauncher;
        
        [SerializeField] private AudioClip shieldPickup,shieldBreak,shieldRecharge;
        
        [SerializeField] private AudioClip healthPickup,healthRecharge;
        

        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
           CombatController.Instance.CombatEvent += HandleCombatEvent;
        }

        public void PlaySound(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.PlayerWinSound:
                    AudioSource.PlayClipAtPoint(playerWinSound,transform.position);
                    break;
                case SoundType.PlayerLoseSound:
                    AudioSource.PlayClipAtPoint(playerLoseSound,transform.position);
                    break;
                case SoundType.EnemyWinSound:
                    AudioSource.PlayClipAtPoint(enemyWinSound,transform.position);
                    break;
                case SoundType.EnemyLoseSound:
                    AudioSource.PlayClipAtPoint(enemyLoseSound,transform.position);
                    break;
                case SoundType.Pistol:
                    AudioSource.PlayClipAtPoint(pistol,transform.position);
                    break;
                case SoundType.Shotgun:
                    AudioSource.PlayClipAtPoint(shotgun,transform.position);
                    break;
                case SoundType.Rifle:
                    AudioSource.PlayClipAtPoint(rifle,transform.position);
                    break;
                case SoundType.SniperRifle:
                    AudioSource.PlayClipAtPoint(sniperRifle,transform.position);
                    break;
                case SoundType.MachineGun:
                    AudioSource.PlayClipAtPoint(machineGun,transform.position);
                    break;
                case SoundType.RocketLauncher:
                    AudioSource.PlayClipAtPoint(rocketLauncher,transform.position);
                    break;
                case SoundType.GrenadeLauncher:
                    AudioSource.PlayClipAtPoint(grenadeLauncher,transform.position);
                    break;
                case SoundType.ShieldPickup:
                    AudioSource.PlayClipAtPoint(shieldPickup,transform.position);
                    break;
                case SoundType.ShieldBreak:
                    AudioSource.PlayClipAtPoint(shieldBreak,transform.position);
                    break;
                case SoundType.ShieldRecharge:
                    AudioSource.PlayClipAtPoint(shieldRecharge,transform.position);
                    break;
                case SoundType.HealthPickup:
                    AudioSource.PlayClipAtPoint(healthPickup,transform.position);
                    break;
                case SoundType.HealthRecharge:
                    AudioSource.PlayClipAtPoint(healthRecharge,transform.position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null);
            }
        }

        public void StopSound(string soundName)
        {
            
        }

        public void AdjustVolume(int volumeLevel)
        {
            
        }

        private void HandleCombatEvent(object sender, CombatEventArgs e)
        {
            switch (e.winner)
            {
                case "Player":
                    //TODO: PLAYER WIN
                    break;
                case "Enemy":
                    //TODO: ENEMY WIN
                    break;
            }
        }
        
    }
}