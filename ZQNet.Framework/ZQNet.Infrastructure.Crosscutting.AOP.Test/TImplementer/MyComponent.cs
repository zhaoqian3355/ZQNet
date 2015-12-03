using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZQNet.Infrastructure.Crosscutting.AOP.Test.ITImplementer;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Test.TImplementer
{
    public class MyComponent
    {
        public MyComponent() { /* ... */ }
        public MyComponent(ILogger logger) { /* ... */ }
        public MyComponent(ILogger logger, IConfigReader reader) { /* ... */ }
    }
}