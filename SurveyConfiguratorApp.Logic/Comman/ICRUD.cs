using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic.Comman
{
    public interface ICRUD<T>
    {
       
            bool add(T data);
            bool update(T data);
            T Get(int id);        
    }
}
