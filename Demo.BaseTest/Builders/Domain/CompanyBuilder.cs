using Demo.Domain.Entities;

namespace Demo.BaseTest.Builders.Domain;

public class CompanyBuilder
{
    public Company Build()
    {
        return new Company("-", "-");
    }
}