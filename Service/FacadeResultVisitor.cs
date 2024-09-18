using System;
using Facade.Results;

namespace Service;

public class FacadeResultVisitor<T> : IFacadeResultVisitor<T, IResult>
{
    public IResult Visit(CreatedResult<T> createdResult)
    {
        return Results.Created("/123", createdResult.Resource);
    }

    public IResult Visit(NotFoundResult<T> notFoundResult)
    {
        return Results.NotFound();
    }

    public IResult Visit(SuccessResult<T> successResult)
    {
        return Results.Ok(successResult.Resource);
    }
}
