namespace Facade.Results;

public interface IFacadeResult<T>
{
    TOut Accept<TOut>(IFacadeResultVisitor<T, TOut> visitor);
}
