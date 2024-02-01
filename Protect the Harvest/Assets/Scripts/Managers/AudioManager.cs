using System;
using System.Collections.Generic;
using Enums;
using Singleton;
using UnityEngine;


namespace Managers
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        [SerializeField] private List<AudioSource> gunSounds;
        [SerializeField] private List<AudioSource> shieldSounds;
        [SerializeField] private List<AudioSource> generalSounds ;
        
        
        public void PlaySound(SoundType soundType)
        {
            // TODO: Implement some error handling if no audios have here
            switch (soundType)
            {
                case SoundType.Pistol:
                    gunSounds[SoundType.Pistol.GetHashCode()].Play();
                    break;
                case SoundType.Shotgun:
                    gunSounds[SoundType.Shotgun.GetHashCode()].Play();
                    break;
                case SoundType.Rifle:
                    gunSounds[SoundType.Rifle.GetHashCode()].Play();
                    break;
                case SoundType.SniperRifle:
                    gunSounds[SoundType.SniperRifle.GetHashCode()].Play();
                    break;
                case SoundType.MachineGun:
                    gunSounds[SoundType.MachineGun.GetHashCode()].Play();
                    break;
                case SoundType.RocketLauncher:
                    gunSounds[SoundType.RocketLauncher.GetHashCode()].Play();
                    break;
                case SoundType.GrenadeLauncher:
                    gunSounds[SoundType.GrenadeLauncher.GetHashCode()].Play();
                    break;
                case SoundType.ShieldPickup:
                    shieldSounds[SoundType.ShieldPickup.GetHashCode()].Play();
                    break;
                case SoundType.ShieldBreak:
                    shieldSounds[SoundType.ShieldBreak.GetHashCode()].Play();
                    break;
                case SoundType.ShieldRecharge:
                    shieldSounds[SoundType.ShieldRecharge.GetHashCode()].Play();
                    break;
                case SoundType.HealthPickup:
                    generalSounds[SoundType.HealthPickup.GetHashCode()].Play();
                    break;
                case SoundType.HealthRecharge:
                    generalSounds[SoundType.HealthRecharge.GetHashCode()].Play();
                    break;
                case SoundType.WinSound:
                    generalSounds[SoundType.WinSound.GetHashCode()].Play();
                    break;
                case SoundType.LoseSound:
                    generalSounds[SoundType.LoseSound.GetHashCode()].Play();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void StopSound(string soundName)
        {
            
        }

        public void AdjustVolume(int volumeLevel)
        {
            
        }
    }
}