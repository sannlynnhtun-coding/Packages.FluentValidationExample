using FluentValidation;
using FluentValidation.Results;

Console.WriteLine("Hello, World!");

Customer customer = new Customer();
CustomerValidator validator = new CustomerValidator();

ValidationResult results = validator.Validate(customer);

if (!results.IsValid)
{
    foreach (var failure in results.Errors)
    {
        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
        Console.WriteLine(failure.ErrorMessage);
    }
}

Console.ReadLine();

public class Customer
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Forename { get; set; }
    public decimal Discount { get; set; }
    public string Address { get; set; }
}

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Surname).NotNull()
            .WithMessage("Invalid Surname.");
        RuleFor(customer => customer.Forename).NotNull()
            .WithMessage("Invalid Forename.");
        RuleFor(customer => customer.Discount).NotEqual(0)
            .WithMessage("Discount must be greater than zero.");
        RuleFor(customer => customer.Address).NotNull()
            .WithMessage("Invalid Address.");
    }
}