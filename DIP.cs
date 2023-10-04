//Dependency Invertion Principle or IOC -> Inversion of control.
//DIP -> One should depend upon abstractions, [not] concretions.
//it suggests that classes should rely on abstract classes/interfaces and not on concrete types.
//LSP + OCP = DIP
//If classes rely on each other, then they are tightly coupled with each other. 
//When classes are tightly coupled, then modifications in one class bring about modifications in all 
//other dependent classes. Rather, low-level classes should incorporate contracts using abstract
//classes or interface and high-level classes should adopt these contracts to access concrete types.
public class Email
{
    public string ToAddress { get; set; }
    public string  Subject { get; set; }
    public string Content { get; set; }
    public void SendEmail()
    {
        //send email
    }
}

public class SMS{
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public void SendSMS()
    {
        //send sms
    }
}

public class Notification
{
    private Email _email;
    private SMS _sms;
    public Notification()
    {
        _email = new Email();
        _sms = new SMS();

    }

    public void Send()
    {
        _email.SendEmail();
        _sms.SendSMS();
    }
}

//high class-> notifiction , low-class -> SMS and email 
//higher class has dependency on lower classes so violation DIP as it wants both high & low level classes
// to have dependencies on abstractions.


public class Notification
{
    public ICollection<IMessage> messages;
    public Notification(ICollection<IMessage> messages)
    {
        this.messages = messages;
        
    }

    public void Send()
    {
        foreach(var message in messages)
        {
            message.SendMessage();
        
        }
    }
}

// in this way high and low level classes are  dependent on only abstractions.