using SimpleDependencyInjection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class ExampleDependencyMonoBehaviour : MonoBehaviour
    {
        [InjectField]
        private ExampleDependencyNested dependencyNested;

        public void DoSomethingComplex()
        {
            dependencyNested.DoSomethingSimple();

            Debug.Log("Something complex just happened: " + gameObject.GetInstanceID());
        }
    }
}