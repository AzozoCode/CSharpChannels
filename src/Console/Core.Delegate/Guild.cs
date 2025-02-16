namespace Core.Delegate;

public class Guild
{
    private readonly List<string> _members = [];

    public event Action<string>? NewMemberAdded;


    public void AddNewMember(string memberName)
    {
        _members.Add(memberName);
        NewMemberAdded?.Invoke(memberName);
    }
}

public static class WelcomeMember
{
    public static void SendWelcomeMessage(string memberName)
    {
        Console.WriteLine("Welcome {0}",memberName);
    }
}



public static class AssignRoomToMember
{
    public static  void MemberRoomInformation(string memberName)
    {
        Console.WriteLine("A room has been assigned to {0} in the Guild Hall",memberName);
    }
}