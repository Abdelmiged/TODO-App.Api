using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ToDoModule
{
    public class ToDoAddException(string msg) : ToDoCRUDException(msg)
    {
    }
}
