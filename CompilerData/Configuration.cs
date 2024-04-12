//Episod 2

using MrX.DynamicCompiler.CompilerData.Languages;

namespace MrX.DynamicCompiler.CompilerData;

public class Configuration
{
    public Configuration(string[] args)
    {
        Statics.MainFilePath = args[0];
        new CSharp();
        new Python();
    }
}