//Episod 4
namespace MrX.DynamicCompiler.CompilerData.NeadClasss;

public class KeyValue<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }

    public KeyValue()
    {
    }

    public KeyValue(TKey key, TValue val)
    {
        this.Key = key;
        this.Value = val;
    }

    public override string ToString()
    {
        return $"{Key.ToString()} :: {Value.ToString()}";
    }
}