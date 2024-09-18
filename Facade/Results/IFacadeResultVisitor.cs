namespace Facade.Results;

public interface IFacadeResultVisitor<T, TOut>
{
    TOut Visit(CreatedResult<T> createdResult);

    TOut Visit(NotFoundResult<T> notFoundResult);

    TOut Visit(SuccessResult<T> successResult);
}
