using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MV.Factory.Domain.Implementaciones
{    
    public class ZonaClima
    {        
        public int ID { get; set; }
        public string Nombre {get;set;}
	    public string Pais { get; set; }
    }
}
