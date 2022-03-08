using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
    {
    public class Seller
        {
        public int Id { get; set; }


        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should between {2} and {1}")]
        [Display(Name = "Seller")]
        public String Name { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} required")]
        public DateTime BirthTime { get; set; }

        [Required(ErrorMessage = "{0} required")]
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
