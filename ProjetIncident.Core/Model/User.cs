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
        public List<Incident> Inidents { get; set; }

        public User()
        {
        }
    }
}
