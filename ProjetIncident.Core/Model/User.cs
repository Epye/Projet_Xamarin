using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetIncident.Core.Model
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EMail { get; set; }
        public string EncryptedPassword { get; set; }


        [InverseProperty(nameof(Incident.User))]
        public List<Incident> Incidents { get; set; }

        public User(string LastName, string FirstName, string EMail, string EncryptedPassword)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.EMail = EMail;
            this.EncryptedPassword = EncryptedPassword;
        }
    }
}
