using Demo.Domain.Entities;

namespace Demo.BaseTest.Builders.Domain;

public class ProductBuilder
{
    private string _name = "-";
    private string _description = "-";
    public Product Build()
    {
        return new Product(_name, _description);
    }

    public ProductBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public ProductBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }
}