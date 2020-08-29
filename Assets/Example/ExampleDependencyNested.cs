using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Example
{
    public class ExampleDependencyNested : MonoBehaviour
    {
        public void DoSomethingSimple()
        {
            Debug.Log("Something simple from a nested dependency: " + gameObject.GetInstanceID());
        }
    }
}
