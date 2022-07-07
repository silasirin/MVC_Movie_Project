using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tool
{
    public class DbContextSingleton
    {
        private DbContextSingleton()
        {

        }

        private static ProjectContext _context;
        public static ProjectContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ProjectContext();
                }
                return _context;
            }
        }
    }
}
