using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject;

class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class CustomerBuilder
{
    Customer newCustomer = new Customer();

    public CustomerBuilder WithName(string name)
    {
        newCustomer.Name = name;
        return this;
    }
    public CustomerBuilder WithAVeryLongName(string name)
    {
        newCustomer.Name = new string('s', 400);
        return this;
    }
    public CustomerBuilder WithAge(int age)
    {
        newCustomer.Age = age;
        return this;
    }
    public CustomerBuilder WithInvalidAge()
    {
        newCustomer.Age = -274;
        return this;
    }
    public Customer Build()
    {
        return newCustomer;
    }
}
