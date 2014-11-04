using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using contigencia;
namespace contigencia.Models.ViewModels
{
    public class DestinatarioPersonasViewModel
    {
        public Destinatario destinatario { get; set; }
        public IEnumerable<SelectListItem> allPersonas { get; set; }

        private List<int> _selectedPersonas;
        public List<int> SelectedPersonas
        {
            get
            {
                if (_selectedPersonas == null)
                {
                    _selectedPersonas = destinatario.Persona.Select(m => m.id).ToList();                    
                    
                }
                return _selectedPersonas;
            }
            set { _selectedPersonas = value; }
        }
    }
}