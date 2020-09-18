using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LearningCSharp
{
    public class Dtos
    {
        [Fact]
        public void DoingThem()
        {
            AddCustomer(new CustomerCreate { First = "Bob", Last = "Smith", Email = "mail", Mi = "K", Phone = "5551212" });
        }

        //public void AddCustomer(string first, string last, string mi, string address1, string address2, string phone, string email)
        //{
        //    //Way too many paramaters
        //}

        //Better and cleaner way to create the object. 
        public void AddCustomer(CustomerCreate customerToAdd)
        {

        }

        public class CustomerCreate //Simple Data Transfer Object
        {
            public string First { get; set; }
            public string Last { get; set; }
            public string Mi { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }
    }
}
