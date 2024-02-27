using System;
using Enums;
using Singleton;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoSingleton<AudioManager>
    {
        private AudioSource _audioSource;

        #region Audio Clips

        [Header("Player Sounds")]
        [SerializeField] private AudioClip playerWinSound;
        [SerializeField] private AudioClip playerLoseSound;

        [Header("Enemy Sounds")]
        [SerializeField] private AudioClip enemyWinSound;
        [SerializeField] private AudioClip enemyLoseSound;

        [Header("Weapon Sounds")]
        [SerializeField] private AudioClip pistol;
        [SerializeField] private AudioClip shotgun;
        [SerializeField] private AudioClip rifle;
        [SerializeField] private AudioClip sniperRifle;
        [SerializeField] private AudioClip machineGun;
        [SerializeField] private AudioClip rocketLauncher;
        [SerializeField] private AudioClip grenadeLauncher;

        [Header("Shield Sounds")]
        [SerializeField] private AudioClip shieldPickup;
        [SerializeField] private AudioClip shieldBreak;
        [SerializeField] private AudioClip shieldRecharge;

        [Header("Health Sounds")]
        [SerializeField] private AudioClip healthPickup;
        [SerializeField] private AudioClip healthRecharge;

        #endregion

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.PlayerWinSound:
                    AudioSource.PlayClipAtPoint(playerWinSound, transform.position);
                    break;
                case SoundType.PlayerLoseSound:
                    AudioSource.PlayClipAtPoint(playerLoseSound, transform.position);
                    break;
                case SoundType.EnemyWinSound:
                    AudioSource.PlayClipAtPoint(enemyWinSound, transform.position);
                    break;
                case SoundType.EnemyLoseSound:
                    AudioSource.PlayClipAtPoint(enemyLoseSound, transform.position);
                    break;
                case SoundType.Pistol:
                    AudioSource.PlayClipAtPoint(pistol, transform.position);
                    break;
                case SoundType.Shotgun:
                    AudioSource.PlayClipAtPoint(shotgun, transform.position);
                    break;
                case SoundType.Rifle:
                    AudioSource.PlayClipAtPoint(rifle, transform.position);
                    break;
                case SoundType.SniperRifle:
                    AudioSource.PlayClipAtPoint(sniperRifle, transform.position);
                    break;
                case SoundType.MachineGun:
                    AudioSource.PlayClipAtPoint(machineGun, transform.position);
                    break;
                case SoundType.RocketLauncher:
                    AudioSource.PlayClipAtPoint(rocketLauncher, transform.position);
                    break;
                case SoundType.GrenadeLauncher:
                    AudioSource.PlayClipAtPoint(grenadeLauncher, transform.position);
                    break;
                case SoundType.ShieldPickup:
                    AudioSource.PlayClipAtPoint(shieldPickup, transform.position);
                    break;
                case SoundType.ShieldBreak:
                    AudioSource.PlayClipAtPoint(shieldBreak, transform.position);
                    break;
                case SoundType.ShieldRecharge:
                    AudioSource.PlayClipAtPoint(shieldRecharge, transform.position);
                    break;
                case SoundType.HealthPickup:
                    AudioSource.PlayClipAtPoint(healthPickup, transform.position);
                    break;
                case SoundType.HealthRecharge:
                    AudioSource.PlayClipAtPoint(healthRecharge, transform.position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null);
            }
        }

        public void StopSound(string soundName)
        {
            // Implementation to stop specific sound
        }

        public void AdjustVolume(int volumeLevel)
        {
            // Implementation to adjust volume
        }
    }
}
