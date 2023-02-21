namespace FastDeliveryApi.Exceptions;

public class CreditLimitException : ApplicationException
{
   public CreditLimitException(string customerName) : base($"{customerName} Sonia cannot increment the credit limit Sorry!")
   {
        
   }
}