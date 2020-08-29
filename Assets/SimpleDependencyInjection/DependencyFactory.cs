using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimpleDependencyInjection
{
    public static class DependencyFactory
    {
        public delegate object Delegate(InjectablesCollection injectables);

        public static Delegate FromClass<T>() where T : class, new()
        {
            return (injectables) =>
            {
                return injectables.Inject(new T());
            };
        }

        public static Delegate FromPrefab<T>(T prefab) where T : MonoBehaviour
        {
            return (injectables) =>
            {
                var instance = GameObject.Instantiate(prefab);
                var children = instance.GetComponentsInChildren<MonoBehaviour>(true);
                foreach (var child in children)
                {
                    injectables.Inject(child);
                }
                return instance.GetComponent<T>();
            };
        }

        public static Delegate FromGameObject<T>(T instance) where T : MonoBehaviour
        {
            return (injectables) =>
            {
                var children = instance.GetComponentsInChildren<MonoBehaviour>(true);
                foreach (var child in children)
                {
                    injectables.Inject(child);
                }
                return instance;
            };
        }
    }
}
