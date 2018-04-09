using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Final_Project
{
    public interface ICharacter
    {
        void attack();
        void defend(int damage);
    }//end of interface
}//end of namespace
