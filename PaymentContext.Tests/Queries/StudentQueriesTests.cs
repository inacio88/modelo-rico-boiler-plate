using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;

[TestClass]
public class StudentQueriesTests
{
    public StudentQueriesTests()
    {
        _students = new List<Student>();
        for (var i = 0; i <= 10; i++)
        {
            _students.Add(new Student(
                new Name("Aluno", i.ToString()),
                new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                new Email(i.ToString() + "@balta.io")
            ));
        }
    }
    private IList<Student> _students;
    
    [TestMethod]
    public void ShouldReturnNullWhenDocumetnNotExists()
    {
        var exp = StudentQueries.GetStudent("1234567811");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();
        
        Assert.AreEqual(null, studn);
    }
    
    [TestMethod]
    public void ShouldReturnStudentWhenDocumetnExists()
    {
        var exp = StudentQueries.GetStudent("1111111111");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();
        
        Assert.AreEqual(null, studn);
    }
}