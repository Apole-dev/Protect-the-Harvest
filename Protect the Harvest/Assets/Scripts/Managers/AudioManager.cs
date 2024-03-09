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
        [SerializeField] private AudioClip assaultRifleSound;

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

        public void PlayGunSound(GunType gunType)
        {
            switch (gunType)
            {
                case GunType.Pistol:
                    PlayPistolSound();
                    break;
                case GunType.Shotgun:
                    PlayShotgunSound();
                    break;
                case GunType.Rifle:
                    PlayRifleSound();
                    break;
                case GunType.SniperRifle:
                    PlaySniperRifleSound();
                    break;
                case GunType.MachineGun:
                    PlayMachineGunSound();
                    break;
                case GunType.AssaultRifle:
                    PlayAssaultRifleSound();
                    break;
                case GunType.RocketLauncher:
                    PlayRocketLauncherSound();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gunType), gunType, null);
            }
        }

        #region Player Enemy General Sounds
        // Method to play the player win sound.
        private void PlayPlayerWinSound()
        {
            AudioSource.PlayClipAtPoint(playerWinSound, transform.position);
        }

        // Method to play the player lose sound.
        private void PlayPlayerLoseSound()
        {
            AudioSource.PlayClipAtPoint(playerLoseSound, transform.position);
        }

        // Method to play the enemy win sound.
        private void PlayEnemyWinSound()
        {
            AudioSource.PlayClipAtPoint(enemyWinSound, transform.position);
        }

        // Method to play the enemy lose sound.
        private void PlayEnemyLoseSound()
        {
            AudioSource.PlayClipAtPoint(enemyLoseSound, transform.position);
        }
        

        #endregion


        #region Weapon Specific Sounds

        // Method to play the pistol sound.
        private void PlayPistolSound()
        {
            print("PlayPistolSound");
            //AudioSource.PlayClipAtPoint(pistol, transform.position);
        }

        // Method to play the shotgun sound.
        private void PlayShotgunSound()
        {
            print("PlayShotgunSound");
            //AudioSource.PlayClipAtPoint(shotgun, transform.position);
        }

        // Method to play the rifle sound.
        private void PlayRifleSound()
        {
            print("PlayRifleSound");
            //AudioSource.PlayClipAtPoint(rifle, transform.position);
        }

        // Method to play the sniper rifle sound.
        private void PlaySniperRifleSound()
        {
            print("PlaySniperRifleSound");
            //AudioSource.PlayClipAtPoint(sniperRifle, transform.position);
        }

        // Method to play the machine gun sound.
        private void PlayMachineGunSound()
        {
            print("PlayMachineGunSound");
            //AudioSource.PlayClipAtPoint(machineGun, transform.position);
        }
        // Method to play the assault rifle sound.
        private void PlayAssaultRifleSound()
        {
            print("PlayAssaultRifleSound");
            //AudioSource.PlayClipAtPoint(assaultRifleSound, transform.position);
        }

        // Method to play the rocket launcher sound.
        private void PlayRocketLauncherSound()
        {
            print("PlayRocketLauncherSound");
            //AudioSource.PlayClipAtPoint(rocketLauncher, transform.position);
        }

        #endregion


        // Method to play the shield pickup sound.
        private void PlayShieldPickupSound()
        {
            AudioSource.PlayClipAtPoint(shieldPickup, transform.position);
        }

        // Method to play the shield break sound.
        private void PlayShieldBreakSound()
        {
            AudioSource.PlayClipAtPoint(shieldBreak, transform.position);
        }

        // Method to play the shield recharge sound.
        private void PlayShieldRechargeSound()
        {
            AudioSource.PlayClipAtPoint(shieldRecharge, transform.position);
        }

        // Method to play the health pickup sound.
        private void PlayHealthPickupSound()
        {
            AudioSource.PlayClipAtPoint(healthPickup, transform.position);
        }

        // Method to play the health recharge sound.
        private void PlayHealthRechargeSound()
        {
            AudioSource.PlayClipAtPoint(healthRecharge, transform.position);
        }
        

        public void PlayShieldBrokeSound()
        {
            // Implementation to play specific sound
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
