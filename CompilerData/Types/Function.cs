//Episod 2,4

using MrX.DynamicCompiler.CompilerData.NeadClasss;

namespace MrX.DynamicCompiler.CompilerData.Types;

public class Function
{
    public string Name;
    public List<KeyValue<string, Statics.LabalTypes>> Code;
    public List<KeyValue<string, Statics.LabalTypes>> Prameter;
}