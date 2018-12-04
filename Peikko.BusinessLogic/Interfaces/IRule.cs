namespace Peikko.BusinessLogic.Interfaces
{
    public interface IRule<TEntity>
    {
        bool Validate(TEntity entity);
        void PreActions(TEntity entity);
        void PostActions(TEntity entity);
    }
}
