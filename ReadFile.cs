using System.Net;
//Episod 1
namespace MrX.DynamicCompiler;
public class ReadFile
{
    public ReadFile(string FileName)
    {
        if (!System.IO.File.Exists(FileName))
            throw new("File Not Exist " + FileName);
        Stream File = System.IO.File.OpenRead(FileName);
        StreamReader ReadFile = new StreamReader(File);
        while (!ReadFile.EndOfStream)
        {
            Statics.L_Tokens.AddRange(TokenList(ReadLine(ReadFile)));
        }
    }
    public string ReadLine(StreamReader RF)
    {
        string line = string.Empty;
        line = RF.ReadLine();
        return line;
    }
    public List<string> TokenList(string Line)
    {
        List<string> LT = new();
        string bufer = string.Empty;
        for (int i = 0; i < Line.Length; i++)
        {
            char c = Line[i];
            switch (c)
            {
                case '(':
                {
                    add(c);
                    break;
                }
                case ')':
                {
                    add(c);
                    break;
                }
                case ';':
                {
                    add(c);
                    break;
                }
                case '\n':
                {
                    add(c);
                    break;
                }
                case '.':
                {
                    add(c);
                    break;
                }
                case ' ':
                {
                    add(c);
                    break;
                }
                default:
                {
                    bufer += c;
                    break;
                }
            }
        }
        void add(char operator_)
        {
            if (bufer != string.Empty) LT.Add(bufer);
            if (operator_ != ' ') LT.Add(operator_.ToString());
            bufer = string.Empty;
        }
        return LT;
    }
}