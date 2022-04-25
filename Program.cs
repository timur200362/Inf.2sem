using System;
using Inf107_2_.Tree;
using Inf107_2_.Delegate;
using Inf107_2_.EventExample.CustomExample;
using Inf107_2_.Reflection;

namespace Inf107_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomExampleRunner cesRunner = new CustomExampleRunner();
            //cesRunner.Run();
            ReflectionRunner rr = new ReflectionRunner();
            rr.Run();
        }
    }
}
