namespace Facade.Results;

public interface IFacadeResultVisitor<T, TOut>
{
    TOut Visit(CreatedFacadeResult<T> createdResult);

    TOut Visit(NotFoundFacadeResult<T> notFoundResult);

    TOut Visit(SuccessFacadeResult<T> successResult);
}
