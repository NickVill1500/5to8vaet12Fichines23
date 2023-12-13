using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fichines.core;
using Fichines.core.Dapper;
using Xunit;

namespace Fichines.TestDapper
{
    public class TestAdo
    {
        protected readonly IAdo Ado;
        private const string _cadena = "Server=localhost;Database=5to_Fichines;Uid=5to_agbd;pwd=Trigg3rs!;Allow User Variables=True";
        public TestAdo() => Ado = new AdoDapper(_cadena);
        public TestAdo(string cadena) => Ado = new AdoDapper(cadena);
    }
}