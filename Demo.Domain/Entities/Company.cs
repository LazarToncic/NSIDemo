using System.Collections;

namespace Demo.Domain.Entities;

public class Company
{

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public IList<Product> Products { get; } = new List<Product>();
    
    public Company(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }
    
    private Company()
    {
        
    }
}