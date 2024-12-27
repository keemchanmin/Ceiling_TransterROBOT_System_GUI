using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceiling_TransterROBOT_System_GUI
{
    public class Ceiling
    {
        public (int,int) pos { get; set; }
        public int dir { get; set; }    

        Ceiling((int,int) pos ) 
        {
            this.pos = pos;
            dir = (int)ENUM.ceiling_dir.CENTER;
        }

        void Change_Dir((int,int) pos, int dir) 
        {
            this.dir = dir; 
        }
    }
}
