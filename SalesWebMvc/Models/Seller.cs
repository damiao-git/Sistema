using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
    {
    public class Seller
        {
        public int Id { get; set; }
        [Display(Name = "Seller")]
        public String Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthTime { get; set; }
        [Display(Name = "Base Salary")]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
            {
            }

        public Seller(int id, string name, string email, DateTime birthTime, double baseSalary, Department department)
            {
            Id = id;
            Name = name;
            Email = email;
            BirthTime = birthTime;
            BaseSalary = baseSalary;
            Department = department;
            }

        public void AddSales(SalesRecord sr)
            {
            Sales.Add(sr);
            }
        public void RemoveSales(SalesRecord sr)
            {
            Sales.Remove(sr);
            }

        public double TotalSales(DateTime initial, DateTime final)
            {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
            }
        }
    }
