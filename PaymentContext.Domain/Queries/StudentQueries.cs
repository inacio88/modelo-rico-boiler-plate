using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries;

public static class StudentQueries
{
    public static Expression<Func<Student, bool>> GetStudent(string document)
    {
        return student => student.Document.Equals(document);
    }
}