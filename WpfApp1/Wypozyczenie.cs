using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Wypozyczenie
    {
        public int Id { get; set; }
        public int IdKlienta { get; set; }
        public int IdFilmu { get; set; }
        public string Name { get; set; }
        public DateTime DataWypozyczenia { get; set; }


    }
}
