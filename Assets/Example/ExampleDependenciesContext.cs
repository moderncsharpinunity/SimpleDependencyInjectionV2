using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDependencyInjection;
using UnityEngine;

namespace Example
{
    public class ExampleDependenciesContext : DependenciesContext
    {
        [SerializeField]
        private ExampleDependencyMonoBehaviour exampleDependency;
        [SerializeField]
        private ExampleDependencyNested exampleDependencyNested;

        protected override void Setup()
        {
            dependenciesCollection.Add(new Dependency { Type = typeof(ExampleDependencyMonoBehaviour), Factory = DependencyFactory.FromGameObject(exampleDependency), IsSingleton = true });

            dependenciesCollection.Add(new Dependency { Type = typeof(ExampleDependencyPlainClass), Factory = DependencyFactory.FromClass<ExampleDependencyPlainClass>(), IsSingleton = false });

            dependenciesCollection.Add(new Dependency { Type = typeof(ExampleDependencyNested), Factory = DependencyFactory.FromPrefab(exampleDependencyNested), IsSingleton = true });
        }

        protected override void Configure()
        {
            
        }
    }
}
