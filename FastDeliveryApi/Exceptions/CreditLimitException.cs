namespace FastDeliveryApi.Exceptions;

public class CreditLimitException : ApplicationException
{
   public CreditLimitException(string name) : base($"{Customer} cannot increment the credit limit")
   {
        
   }
}