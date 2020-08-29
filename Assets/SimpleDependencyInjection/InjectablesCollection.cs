using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDependencyInjection
{
    public class InjectablesCollection
    {
        private Dictionary<Type, Injectable> injectables = new Dictionary<Type, Injectable>();

        public InjectablesCollection(DependenciesCollection dependencies)
        {
            foreach (var dependency in dependencies)
            {
                injectables.Add(dependency.Type, new Injectable { Factory = dependency.Factory, IsSingleton = dependency.IsSingleton });
            }
        }

        public object Get(Type type)
        {
            if (!injectables.ContainsKey(type))
            {
                throw new ArgumentException("Type not injectable: " + type.FullName);
            }

            var injectable = injectables[type];
            if (injectable.IsSingleton)
            {
                if (injectable.Instance == null)
                {
                    injectable.Instance = injectable.Factory(this);
                    injectables[type] = injectable;
                }
                return injectable.Instance;
            }
            else
            {
                return injectable.Factory(this);
            }
        }

        public object Inject(object dependant)
        {
            Type type = dependant.GetType();
            while (type != null)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance);
                foreach (var field in fields)
                {
                    if (field.GetCustomAttribute<InjectFieldAttribute>(false) == null) { continue; }

                    field.SetValue(dependant, Get(field.FieldType));
                }
                type = type.BaseType;
            }
            return dependant;
        }
    }
}
