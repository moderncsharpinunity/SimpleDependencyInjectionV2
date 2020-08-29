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
            dependencies.Add(new Dependency { Type = typeof(ExampleDependencyMonoBehaviour), Factory = DependencyFactory.FromGameObject(exampleDependency), IsSingleton = true });

            dependencies.Add(new Dependency { Type = typeof(ExampleDependencyPlainClass), Factory = DependencyFactory.FromClass<ExampleDependencyPlainClass>(), IsSingleton = false });

            dependencies.Add(new Dependency { Type = typeof(ExampleDependencyNested), Factory = DependencyFactory.FromPrefab(exampleDependencyNested), IsSingleton = true });
        }

        protected override void Configure()
        {
            
        }
    }
}
