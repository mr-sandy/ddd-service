using Facade.Results;

namespace Service;

public class FacadeResultVisitor<T>(Func<T, string>? uriGenerator = null) : IFacadeResultVisitor<T, IResult>
{
    private readonly Func<T, string>? uriGenerator = uriGenerator;

    public IResult Visit(CreatedFacadeResult<T> createdResult)
    {
        string uri = uriGenerator == null ? "" : uriGenerator(createdResult.Resource);

        return Results.Created(uri, createdResult.Resource);
    }

    public IResult Visit(NotFoundFacadeResult<T> notFoundResult)
    {
        return Results.NotFound();
    }

    public IResult Visit(SuccessFacadeResult<T> successResult)
    {
        return Results.Ok(successResult.Resource);
    }
}
