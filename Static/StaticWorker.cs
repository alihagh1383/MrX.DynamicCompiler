//Episod 2

using MrX.DynamicCompiler.CompilerData;

namespace MrX.DynamicCompiler.Static;

public class StaticWorker
{
    public static KeyValuePair<bool, string> AddLabal(string name, KeyValuePair<Statics.LabalTypes, object> value)
    {
        if (Statics.Labals.ContainsKey(name))
            return new KeyValuePair<bool, string>(false, "Exist");
        else
        {
            Statics.Labals.Add(name, value);
            return new KeyValuePair<bool, string>(true, null);
        }
    }

    public static KeyValuePair<bool, string> AddGrammar(List<Statics.LabalTypes> Grammar, Gramer Class)
    {
        if (Statics.Grammar.ContainsKey(Grammar))
            return new KeyValuePair<bool, string>(false, "Exist");
        else
        {
            Statics.Grammar.Add(Grammar, Class);
            return new KeyValuePair<bool, string>(true, null);
        }
    }
}