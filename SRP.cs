using System;


//SRP ->A class should only have a single responsibility, that is, only changes to one part of the software’s specification should be able to affect
//the specification of the class.

/// <summary>
/// Summary description for BankAccount
/// </summary>
public class BankAccount
{
	public BankAccount()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public string AccountNumber {get;set;}
	public string AccountBalance { get; set; }

	public decimal CalculateInterest()
    {
		//code to calculate interest
    }
}

// Change comes : add AccountHolderName property and modifiction in logic of calculating Interest 
// 1 is changing the feature and 1 is changing the functionality

//SRP to rescue

public class BankAccount:IBankAccount
{
	public string AccountNumber { get; set; }
	public string AccountBalance { get; set; }

}

public interface IBankAccount
{
	 string AccountNumber { get; set; }
	 string AccountBalance { get; set; }
} 

public interface ICalculateInterest
{
	decimal CalculateInterest();
}
public class CalculateInterest:ICalculateInterest
{
	public decimal CalculateInterest(IBankAccount bankAccount)
    {
		//custom logic 
		return 1000;
    }
}
//BAnkAccount class is responsible for bank account props.IF we wish to incorporate new rule in calculation of interest we don't need to modify the 
//BankAccount class anymore.Also InterestCalculator doen't need to change if we need to add any new Property AccountHolderName.

