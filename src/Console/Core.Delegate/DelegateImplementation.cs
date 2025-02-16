
namespace Core.Delegate;

public class DelegateImplementation
{
    private delegate void ActionDel(int item);

    private delegate string FuncDel(string name);

    private readonly Action<int> _actionDele = DisplayNumber;

    private readonly Func<int, int, int> _funcDele = (i, j) => i + j;

    private readonly Func<int,int,string> _funDele2;

    public DelegateImplementation()
    {
        ActionDel? actionDel = null;
        actionDel += DisplayNumber;
        actionDel += DisplayNumber2;
        actionDel.Invoke(2);

        FuncDel? funcDel = null;
        funcDel = DisplayName;
        Console.WriteLine(funcDel.Invoke("Joseph Barrigah"));
        _actionDele.Invoke(200);
       Console.WriteLine(_funcDele.Invoke(20, 30));

        _funDele2 = ConvertIntToString;
        Console.WriteLine(_funDele2.Invoke(20, 20));
    }


    private static void DisplayNumber(int item)
    {
        Console.WriteLine("The value is {0}",item);
    }
    
    
    private static void DisplayNumber2(int item)
    {
        Console.WriteLine("The value is {0}",item);
    }
    
    
    private static string DisplayName(string name)
    {
        return name;
    }

    private static string ConvertIntToString(int a, int b)
    {
        return $"{a + b}";
    }
}