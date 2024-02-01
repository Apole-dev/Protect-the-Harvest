using UnityEngine;
using Singleton;
using Enums;

namespace Managers
{
    public class ResourceManager : MonoSingleton<ResourceManager>
    {
        #region Resource Object Lists
            private ResourceObject[] _gunResourceObjects;
            private ResourceObject[] _shieldResourceObjects;
            private ResourceObject[] _healthResourceObjects;
        #endregion
        
        #region Resource Object Acsessers
            public ResourceObject clickWeaponResourceObject;
            public ResourceObject clickShieldResourceObject;
            public ResourceObject clickHealthResourceObject;
        #endregion

        private void Awake() => RandomObjectGenerator();

        /// <summary>
        /// Finds the scriptable objects for the specified object type.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        private ResourceObject[] FindScriptableObject(ObjectType objectType)
        {
            AssignScriptableObject();

            return objectType switch
            {
                ObjectType.Weapon => _gunResourceObjects,
                ObjectType.Health => _healthResourceObjects,
                ObjectType.Shield => _shieldResourceObjects,
                _ => _gunResourceObjects
            };
        }

        /// <summary>
        /// Assigns the ResourceObject.
        /// </summary>
        private void AssignScriptableObject()
        {
            _gunResourceObjects = LoadScriptableObjectsInFolder<ResourceObject>("Guns");
            _shieldResourceObjects = LoadScriptableObjectsInFolder<ResourceObject>("Shields");
            _healthResourceObjects = LoadScriptableObjectsInFolder<ResourceObject>("Healths");
        }

        /// <summary>
        /// Loads the ResourceObject in the specified folder.
        /// </summary>
        /// <param name="folderName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T[] LoadScriptableObjectsInFolder<T>(string folderName) where T : ResourceObject
        {
            T[] scriptableObjectArray = Resources.LoadAll<T>(folderName);
            T[] castedArray = new T[scriptableObjectArray.Length];

            for (int i = 0; i < scriptableObjectArray.Length; i++)
            {
                castedArray[i] = (T)scriptableObjectArray[i];
            }

            return castedArray;
        }
        
        /// <summary>
        /// Generates random objects for the UI.
        /// </summary>
        private void RandomObjectGenerator()
        {
            // Find ScriptableObjects in the ObjectsManager for accessing objects.
            var weaponObjects = ResourceManager.Instance.FindScriptableObject(ObjectType.Weapon);
            var healthObjects = ResourceManager.Instance.FindScriptableObject(ObjectType.Health);
            var shieldObjects = ResourceManager.Instance.FindScriptableObject(ObjectType.Shield);

            // Generate random indices for the objects.
            var randomWeaponIndex = Random.Range(0, weaponObjects.Length);
            var randomHealthIndex = Random.Range(0, healthObjects.Length);
            var randomShieldIndex = Random.Range(0, shieldObjects.Length);

            // Access the randomly selected objects.
            clickWeaponResourceObject = weaponObjects[randomWeaponIndex];
            clickHealthResourceObject = healthObjects[randomHealthIndex];
            clickShieldResourceObject = shieldObjects[randomShieldIndex];
        }
    }
}