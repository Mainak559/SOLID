
//ISP ->  “Many client-specific interfaces are better than one general-purpose interface.”
        //Clients shouldn't be forced to depend upon interfaces that they donot use 

public interface IMessage
{
    IList<string> ToAddress{get;set;}
    
    IList<string> BccAddress{get;set;}
    string MessageBody{get;set;}
    string Subject{get;set;}
    bool Send();
}

public class SmtpMessage:IMessage
{
    public IList<string> ToAddress { get; set; }
    public IList<string> BccAddress { get; set; }
    public string MessageBody { get; set; }
    public string Subject { get; set; }
    public bool Send()
    {
        //code for sending Email
    }
}

public class SmsMessage:IMessage
{
    public IList<string> ToAddress { get; set; }
    public IList<string> BccAddress { get{throw new NotImplementedException();} set{throw new NotImplementedException();} }

    public string MessageBody { get; set; }
    public string Subject { get{throw new NotImplementedException();} set{throw new NotImplementedException();} } 
    public bool Send()
    {
        //code for sending sms
    }
}


//here you can see smsMEssage doesn't need BccAddress and Subject.BUt as these props are present in interface
// we had to implement in our smsMessage class.To avoid this violation we implement ISP

public interface IMessage
{
    bool Send(IList<string> toAddress , string messageBody);
}

public interface IEmailMessage: IMessage
{
    string Subject{get;set;}
    IList<string> BccAddress{get;set;}
}
public class SmtpMessage:IEmailMessage
{
    public IList<string> BccAddress { get; set; }
    public string Subject { get; set; }
    public bool Send(IList<string> toAddress , string messageBody)
    {
        //code for sending email
    }
}

public class SmsMessage:IMessage
{
    public bool Send(IList<string> toAdddress , string messageBody)
    {
        //code for sending message
    }
}


//This way smsMessage needs only ToAddress and messageBody to work and we can use IMessage interface to avoid 
// unnecessary confusion