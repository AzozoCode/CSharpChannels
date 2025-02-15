namespace Core.Delegate;

public class DelegateImplementation
{
    private delegate void ActionDel(string name);

    private ActionDel actionDel;
    
    public DelegateImplementation()
    {
        actionDel = PrintName;
        actionDel.Invoke("testing");
        
    }
    
    
    
    private string GetFullName(string lastName)
    {
        return "Azozo" + lastName;
    }


    private void PrintName(string fullName)
    {
        Console.WriteLine(fullName);
    }
    
    
    private void PrintSound(string sound)
    {
        Console.WriteLine(sound);
    }
}