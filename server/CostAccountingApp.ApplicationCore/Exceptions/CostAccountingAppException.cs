namespace CostAccountingApp.ApplicationCore.Exceptions;

public class CostAccountingAppException : Exception
{
    public CostAccountingAppException()
    {
    }

    public CostAccountingAppException(string message)
        : base(message)
    {
    }

    public CostAccountingAppException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}