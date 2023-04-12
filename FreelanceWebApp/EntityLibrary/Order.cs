using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Order
    {
        public Order(int id, string title, string status, int price, string place, string description, string deadLine, int employerId, int specialistId)
        {
            Id = id;
            Title = title;
            Status = status;
            Price = price;
            Place = place;
            Description = description;
            DeadLine = deadLine;
            EmployerId = employerId;
            SpecialistId = specialistId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string DeadLine { get; set; }
        public int EmployerId { get; set; }
        public int SpecialistId { get; set; }
    }
}
