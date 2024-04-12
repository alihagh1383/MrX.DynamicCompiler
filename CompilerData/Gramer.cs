//Episod 2
namespace MrX.DynamicCompiler.CompilerData;

public class Gramer
{
    public Func<List<string>, object> Do;

    public Gramer(Func<List<string>, object> func)
    {
        Do = func;
    }
}