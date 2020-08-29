using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SimpleDependencyInjection
{
    public abstract class DependenciesContext : MonoBehaviour
    {
        protected DependenciesCollection dependencies = new DependenciesCollection();
        private InjectablesCollection injectables;


        private void Awake()
        {
            Setup();

            injectables = new InjectablesCollection(dependencies);

            var children = GetComponentsInChildren<MonoBehaviour>(true);
            foreach (var child in children)
            {
                injectables.Inject(child);
            }

            Configure();
        }

        protected abstract void Setup();

        protected abstract void Configure();

    }
}