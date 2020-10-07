using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjetoModelo.Domain.Enumerators
{
    public enum StatusException
    {
        [Description("Nenhum")]
        Nenhum= 0,
        [Description("Ocorreu algo inexperado")]
        Erro = 1
    }
}
