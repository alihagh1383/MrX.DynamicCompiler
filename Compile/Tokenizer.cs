// Episod 3,4

using MrX.DynamicCompiler.CompilerData.NeadClasss;
using MrX.DynamicCompiler.Static;

namespace MrX.DynamicCompiler.Compile;

public class Tokenizer
{
    public Tokenizer()
    {
        for (int i = 0; i < Statics.L_Splits.Count; i++)
        {
            string l = Statics.L_Splits[i];
            Statics.LabalTypes find;

            if ((l != string.Empty || l != null)
                && l.Length > 2
                && l[0] == '/'
                && l[1] == '*'
                && l[l.Length - 2] == '*'
                && l[l.Length - 1] == '/'
               )
                find = Statics.LabalTypes.Comment;
            else if (int.TryParse(l, out _))
            {
                find = Statics.LabalTypes.Number;
            }
            else
            {
                var finds = Statics.Labals.Where(P => P.Key == l).Count();
                find = finds > 0
                    ? Statics.Labals.First(P => P.Key == l).Value.Key
                    : Statics.LabalTypes.Unknown;
            }


            if (i > 0
                && Statics.L_Tokens.Last().Value == Statics.LabalTypes.EndOfCode
                && find == Statics.LabalTypes.EndOfCode)
            {
            }
            else
            {
                var Token = new KeyValue<string, Statics.LabalTypes>(l, find);
                Statics.L_Tokens.Add(Token);
            }
        }
    }
}