using System;
using ProjetIncident.Core.Model;

namespace ProjetIncident.Core.ViewModel
{
    public class Details_IncidentViewModel
    {
        public String description { get; protected set; }

        public Details_IncidentViewModel(Incident item)
        {
            description = item.Description;
        }
    }
}
