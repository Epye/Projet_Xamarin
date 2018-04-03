using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetIncident.Core.Model
{
    public class Incident
    {
        public enum StatusValues
        {
            NotSubmitted = 0,
            Submitted = 1,
            InProgress = 2,
            WaitingReview = 3,
            Closed = 4,
            Rejected = 5
        }

        [Key]
        public DateTime SubmissionDate { get; set; }

        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public StatusValues Status { get; set; }
        public DateTime StatusChangedDate { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [InverseProperty(nameof(Photo.Incident))]
        public List<Photo> Photos { get; set; }

        public Incident()
        {
        }

        public Incident(String description, double Latitude, double Longitude, double Altitude, StatusValues Status, DateTime StatusChangedDate, Category categorie, User user, List<Photo> photos){
            this.SubmissionDate = DateTime.Now;
            this.Description = description;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Altitude = Altitude;
            this.Status = Status;
            this.StatusChangedDate = StatusChangedDate;
            this.Category = categorie;
            this.User = user;
            this.Photos = photos;
        }

        public Incident(string incident){
            this.Description = incident;
        }

		public override string ToString()
		{
            return this.Description;
		}
	}
}
