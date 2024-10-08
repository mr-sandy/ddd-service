namespace Facade.Results;

public class NotFoundFacadeResult<T> : IFacadeResult<T>
{
    public TOut Accept<TOut>(IFacadeResultVisitor<T, TOut> visitor)
    {
        return visitor.Visit(this);
    }
}
