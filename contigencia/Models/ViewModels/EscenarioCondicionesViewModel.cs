using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using contigencia;
namespace contigencia.Models.ViewModels
{
    public class EscenarioCondicionesViewModel
    {
        public Escenario escenary { get; set; }
        public IEnumerable<SelectListItem> AllConditions { get; set; }

        private List<int> _selectedConditions;
        public List<int> SelectedConditions
        {
            get
            {
                if (_selectedConditions == null)
                {
                    _selectedConditions = escenary.Condicion.Select(m => m.id).ToList();                    
                    
                }
                return _selectedConditions;
            }
            set { _selectedConditions = value; }
        }
    }
}