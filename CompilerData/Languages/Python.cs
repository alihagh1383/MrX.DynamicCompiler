//Episod 2
using MrX.DynamicCompiler.CompilerData.Types;
using MrX.DynamicCompiler.Static;

namespace MrX.DynamicCompiler.CompilerData.Languages;

public class Python
{
    public Python()
    {
        //////////////////////////////////////////////
        /// Other
        //////////////////////////////////////////////
        StaticWorker.AddLabal("=", new(Statics.LabalTypes.Equal, null));
        //////////////////////////////////////////////
        /// end Of Code
        //////////////////////////////////////////////
        StaticWorker.AddLabal("/n", new(Statics.LabalTypes.EndOfCode, null));
        //////////////////////////////////////////////
        /// Classs & Functions
        //////////////////////////////////////////////
        StaticWorker.AddLabal(
            "Print",
            new(
                Statics.LabalTypes.Function,
                new Function()
                {
                    Name = "Print"
                }
            ));
    }
}