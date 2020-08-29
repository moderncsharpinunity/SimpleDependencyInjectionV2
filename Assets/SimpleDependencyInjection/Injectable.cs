using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDependencyInjection
{
    public struct Injectable
    {
        public DependencyFactory.Delegate Factory { get; set; }
        public bool IsSingleton { get; set; }
        public object Instance { get; set; }
    }
}
