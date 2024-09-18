namespace Facade.Results;

public class SuccessFacadeResult<T>(T resource) : IFacadeResult<T>
{
    public T Resource { get; set; } = resource;

    public TOut Accept<TOut>(IFacadeResultVisitor<T, TOut> visitor)
    {
        return visitor.Visit(this);
    }
}
