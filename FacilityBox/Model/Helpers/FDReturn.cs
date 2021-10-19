using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityBox.Model.Helpers
{
    public class FDReturn
    {
        public FDReturn()
        {
            HasError = false;
            Content = "Operação realizada com SUCESSO!";
        }

        public bool HasError { get; set; }
        public string Content { get; set; }

    }
}
