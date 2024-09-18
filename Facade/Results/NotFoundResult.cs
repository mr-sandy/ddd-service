namespace Facade.Results;

public class NotFoundResult<T> : IFacadeResult<T>
{
    public TOut Accept<TOut>(IFacadeResultVisitor<T, TOut> visitor)
    {
        return visitor.Visit(this);
    }
}
