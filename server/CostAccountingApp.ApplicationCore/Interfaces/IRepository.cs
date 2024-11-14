namespace CostAccountingApp.ApplicationCore.Interfaces;

public interface IRepository<T> where T : class
{
    public List<T> ListAll();
}