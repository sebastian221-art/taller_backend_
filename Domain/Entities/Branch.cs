using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Branch
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public int ComercialNumber { get; private set; }
    public string Address { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string ContactName { get; private set; } = null!;
    public int Phone { get; private set; }
    public Guid CityId { get; set; }
    public virtual City? City { get; set; }
    public Guid CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public Branch() { }
    public Branch(int comercial_number, string address, string email, string contact_name, int phone)
    {
        ComercialNumber = comercial_number;
        Address = address;
        Email = email;
        ContactName = contact_name;
        Phone = phone;
    }
}
