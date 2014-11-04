using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using contigencia;
namespace contigencia.Models.ViewModels
{
    public class PlanEscenariosViewModel
    {
        public PlanContingencia plan { get; set; }
        public IEnumerable<SelectListItem> allEscenaries { get; set; }

        private List<int> _selectedEscenaries;
        public List<int> SelectedEscenaries
        {
            get
            {
                if (_selectedEscenaries == null)
                {
                    _selectedEscenaries = plan.Escenario.Select(m => m.id).ToList();                    
                    
                }
                return _selectedEscenaries;
            }
            set { _selectedEscenaries = value; }
        }
    }
}