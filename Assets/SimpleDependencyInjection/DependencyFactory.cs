using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Runtime.Serialization;

namespace SimpleDependencyInjection
{
    public static class DependencyFactory
    {
        public delegate object Delegate(DependenciesProvider injectables);

        public static Delegate FromClass<T>() where T : class, new()
        {
            return (dependencies) =>
            {
                var type = typeof(T);
                var obj = FormatterServices.GetUninitializedObject(type);

                dependencies.Inject(obj);

                var defaultConstructor = type.GetConstructor(Type.EmptyTypes);
                if (defaultConstructor == null) 
                {
                    throw new InvalidOperationException("Cannot inject class without parameterless constructor");
                }
                defaultConstructor.Invoke(obj, null);

                return (T)obj;
            };
        }

        public static Delegate FromPrefab<T>(T prefab) where T : MonoBehaviour
        {
            return (dependencies) =>
            {
                bool wasActive = prefab.gameObject.activeSelf;
                prefab.gameObject.SetActive(false);
                var instance = GameObject.Instantiate(prefab);
                prefab.gameObject.SetActive(wasActive);
                var children = instance.GetComponentsInChildren<MonoBehaviour>(true);
                foreach (var child in children)
                {
                    dependencies.Inject(child);
                }
                instance.gameObject.SetActive(wasActive);
                return instance.GetComponent<T>();
            };
        }

        public static Delegate FromGameObject<T>(T instance) where T : MonoBehaviour
        {
            return (dependencies) =>
            {
                var children = instance.GetComponentsInChildren<MonoBehaviour>(true);
                foreach (var child in children)
                {
                    dependencies.Inject(child);
                }
                return instance;
            };
        }
        
    }
}
