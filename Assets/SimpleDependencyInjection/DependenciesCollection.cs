using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDependencyInjection
{
    public class DependenciesCollection : IEnumerable<Dependency>
    {
        private List<Dependency> dependencies = new List<Dependency>();

        public void Add(Dependency dependency) => dependencies.Add(dependency);

        public IEnumerator<Dependency> GetEnumerator() => dependencies.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => dependencies.GetEnumerator();
    }
}