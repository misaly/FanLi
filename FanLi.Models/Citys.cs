using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.Models
{
    public class Citys
    {
        
        public int Id { get; set; }
         	
        
        public int ParentId { get; set; }
         
        public string CityName { get; set; }
        
        public int Levels { get; set; }
    }
}
