using DesignPattern.CQRS.PresentationLayer.CQRS.Results.StudentResult;
using MediatR;
using System.Collections.Generic;

namespace DesignPattern.CQRS.PresentationLayer.CQRS.Queries.StudentQueries
{
    public class GetAllStudentQuery:IRequest<List<GetAllStudentQueryResult>>
    {
    }
}
