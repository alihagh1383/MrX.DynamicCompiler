//Episod 2

using MrX.DynamicCompiler.CompilerData.NeadClasss;

namespace MrX.DynamicCompiler.CompilerData;

public class Gramer
{
    public Func<List<KeyValue<string, Statics.LabalTypes>>, object> Do;

    public Gramer(Func<List<KeyValue<string, Statics.LabalTypes>>, object> func)
    {
        Do = func;
    }
}