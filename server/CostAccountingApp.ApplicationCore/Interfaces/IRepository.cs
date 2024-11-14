namespace CostAccountingApp.ApplicationCore.Interfaces;

public interface IRepository<T> where T : class
{
    public IReadOnlyList<T> ListAll();
}