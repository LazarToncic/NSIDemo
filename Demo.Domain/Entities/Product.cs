namespace Demo.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Company Company { get; private set; }
    
    public Product(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }
    
    private Product()
    {
        
    }

    public Product AddCompany(Company company)
    {
        Company = company;
        return this;
    }
}