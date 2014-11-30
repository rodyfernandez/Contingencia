using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using contigencia;
namespace contigencia.Models.ViewModels
{
    public class PlanDestinatariosViewModel
    {
        public PlanContingencia plan { get; set; }
        public IEnumerable<SelectListItem> allDestinatarios { get; set; }

        private List<int> _selectedDestinatarios;
        public List<int> SelectedDestinatarios
        {
            get
            {
                if (_selectedDestinatarios == null)
                {
                    _selectedDestinatarios = plan.Destinatario.Select(m => m.id).ToList();                    
                    
                }
                return _selectedDestinatarios;
            }
            set { _selectedDestinatarios = value; }
        }
    }
}