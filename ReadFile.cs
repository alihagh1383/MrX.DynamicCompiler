using System.Net;

//Episod 1,2
namespace MrX.DynamicCompiler;

public class ReadFile
{
    public ReadFile(string FileName)
    {
        if (!System.IO.File.Exists(FileName))
            throw new("File Not Exist " + FileName);
        Stream File = System.IO.File.OpenRead(FileName);
        StreamReader ReadFile = new StreamReader(File);

        Statics.L_Tokens.AddRange(TokenList((ReadFile)));
    }


    public List<string> TokenList(StreamReader RF)
    {
        bool Comment = false;
        List<string> LT = new();
        string bufer = string.Empty;
        while (!RF.EndOfStream)
        {
            char c = (char)RF.Read();
            if (!Comment)
            {
                switch (c)
                {
                    case '/':
                    {
                        if (RF.Peek() == '*')
                        {
                            Comment = true;
                            bufer += c;
                        }

                        break;
                    }
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
            else
            {
                bufer += c;
                if (c == '*')
                    if (RF.Peek() != -1 && RF.Peek() == '/')
                    {
                        bufer += (char)RF.Read();
                        Comment = false;
                        add();
                    }
            }
        }

        add('\n');

        void add(char operator_ = ' ')
        {
            if (bufer != string.Empty) LT.Add(bufer);
            if (operator_ != ' ') LT.Add(operator_.ToString());
            bufer = string.Empty;
        }

        return LT;
    }
}