namespace CostAccountingApp.ApplicationCore.Interfaces;

public interface IRepository<T> where T : class //TODO rename class to Entity when add any DB
{
    public List<T> ListAll();
}