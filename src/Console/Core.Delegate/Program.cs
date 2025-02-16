
namespace Core.Delegate;

class Program
{
    static void Main(string[] args)
    {
       // _ = new DelegateImplementation();

        var guild = new Guild();
        
        guild.NewMemberAdded += WelcomeMember.SendWelcomeMessage;
        guild.NewMemberAdded += AssignRoomToMember.MemberRoomInformation;
        
        
        guild.AddNewMember("Joseph Barrigah");

        SendCallback((i) =>
        {
            Console.WriteLine("Callback received => {0}",i);
        });

        void SendCallback(Action<int> callback)
        {
            callback(4);
        }
    }

}