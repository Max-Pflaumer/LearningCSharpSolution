using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LearningCSharp
{
    public class WaysToImplementInterface 
    {
        [Fact]
        public void MakingARegistration()
        {
            var e2 = new Emailer();
            var invite = new SpecialEventRegistration(new Emailer())
            {
                DateOfEvent = new DateTime(2021, 4, 20),
                Employee = new Employee("Ben", "DEV", 200000),
                Event = "Jeff's Birthday Bash"
            };

            invite.Invite();
        }
    }
    public enum ContentType { Plain, Html, Rtf}
    public class Emailer : IEmailPartyInvitations
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public ContentType ContentType { get; set; }
        public string Content { get; set; }

       

        public void Send()
        {
            // actuall send the email.
        }

        void IEmailPartyInvitations.Invite(string v, string message) //Explicit interface implementation
        {
            Recipient = v;
            Content = message;
            ContentType = ContentType.Plain;
            From = "PartyHost";
            Send();
        }
    }

    public class SpecialEventRegistration 
    {
        private IEmailPartyInvitations _emailer;

        public SpecialEventRegistration(IEmailPartyInvitations emailer)
        {
            _emailer = emailer;
        }

        public Employee Employee { get; set; }
        public string Event { get; set; }
        public DateTime DateOfEvent { get; set; }

        public void Invite()
        {
            //Save it to our calendar, mark one spot as taken, etc
            //Send teh employee and email with a reminder
            
            _emailer.Invite(Employee.Name + "@company.com", "Invite sent");
        }

    }
        
}
