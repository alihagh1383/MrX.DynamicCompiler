//Episod 1,2

using MrX.DynamicCompiler.CompilerData;

namespace MrX.DynamicCompiler;

public class Statics
{
    public static string MainFilePath { get; set; }
    public static List<string> L_Tokens { get; } = new();
    public static Dictionary<List<LabalTypes>, Gramer> Grammar { get; set; } = new();
    public static Dictionary<string, KeyValuePair<LabalTypes, object>> Labals { get; set; } = new();

    public enum LabalTypes
    {
        Unknown,
        Function,
        VariableType,
        VariableName,
        Class,
        Dot,
        Equal,
        Comment,
        Number,
        EndOfCode,
        StartParameter,
        EndParameter,
        Parameter,
    }
}