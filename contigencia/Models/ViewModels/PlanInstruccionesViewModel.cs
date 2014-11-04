using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using contigencia;
namespace contigencia.Models.ViewModels
{
    public class PlanInstruccionesViewModel
    {
        public PlanContingencia plan { get; set; }
        public IEnumerable<SelectListItem> allInstructions { get; set; }

        private List<int> _selectedInstructions;
        public List<int> SelectedInstructions
        {
            get
            {
                if (_selectedInstructions == null)
                {
                    _selectedInstructions = plan.Instruccion.Select(m => m.id).ToList();                    
                    
                }
                return _selectedInstructions;
            }
            set { _selectedInstructions = value; }
        }
    }
}