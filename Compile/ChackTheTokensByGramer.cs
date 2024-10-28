using MrX.DynamicCompiler.CompilerData.NeadClasss;

namespace MrX.DynamicCompiler.Compile;
//Episod 4,5

public class ChackTheTokensByGramer
{
    public ChackTheTokensByGramer()
    {
        var Grammers = Statics.Grammar;
        int Grammerchek = -1;
        bool Start = false;
        int CountOfStart = 0;
        var list = new List<KeyValue<string, Statics.LabalTypes>>();
        for (int i = 0; i < Statics.L_Tokens.Count; i++)
        {
            var labal = Statics.L_Tokens[i];
            if (labal.Value == Statics.LabalTypes.Comment)
            {
                if (Statics.L_Tokens[i + 1].Value == Statics.LabalTypes.EndOfCode)
                {
                    i++;
                }

                continue;
            }

            if (labal.Key != "\n")
            {
                list.Add(labal);
                Grammerchek++;
            }


            Grammers = Grammers.Where(p =>
            {
                if (labal.Key == "\n")
                {
                    return true;
                }


                if (labal.Key == "(" || labal.Key == "{")
                {
                    Start = true;
                    CountOfStart++;
                }

                if (labal.Key == ")" || labal.Key == "}")
                {
                    CountOfStart--;
                    if (CountOfStart == 0)
                    {
                        Start = false;
                        Grammerchek++;
                    }
                }

                if (Grammerchek - 1 > 0 && p.Key[Grammerchek - 1] == Statics.LabalTypes.Any && !Start)
                {
                    if (p.Key[Grammerchek] == labal.Value)
                    {
                        Grammerchek++;
                        Grammerchek++;
                        return true;
                    }
                }
                else
                {
                    return true;
                }

                if (p.Key[Grammerchek] == Statics.LabalTypes.Any)
                    return true;


                return p.Key[Grammerchek] == labal.Value;
            }).ToDictionary();
            if (Grammers.Count == 1 && Grammers.First().Key.Count - 1 == Grammerchek)
            {
                Grammerchek = -1;
                Grammers.First().Value.Do(list);
                Grammers = Statics.Grammar;
                list = new();
                var s = Statics.L_Tokens;
            }
        }
    }
}