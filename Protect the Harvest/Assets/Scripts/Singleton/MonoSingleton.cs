using UnityEngine;

namespace Singleton
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static volatile T _instance;

        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// Singleton instance
        /// If null, it will be created
        /// If not null, it will be returned
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType(typeof(T)) as T;

                return _instance;
            }
        }
    }
}