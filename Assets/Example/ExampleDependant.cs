using SimpleDependencyInjection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class ExampleDependant : MonoBehaviour
    {
        [InjectField]
        private ExampleDependencyMonoBehaviour dependency = null;
        [InjectField]
        private ExampleDependencyPlainClass dependency2 = null;

        void Awake()
        {
            dependency.DoSomethingComplex();

            dependency2.DoSomethingAlsoComplex();
        }
    }
}