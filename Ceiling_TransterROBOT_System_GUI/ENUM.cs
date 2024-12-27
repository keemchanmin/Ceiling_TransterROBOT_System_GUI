using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceiling_TransterROBOT_System_GUI
{
    public static class ENUM
    {
        public enum dir
        {
            FRONT,
            BACK
        }
        public enum detail_dir
        {
            UP,
            DOWN
        }


        public enum state
        {
            NON,            // 경로 할당 받기 전
            ACTIVE,         // 동작중
            BLOKED,          // 블락상태 ( Wait and Pass 에서 Wait 할 때, 상대방 한테 먼저 경로 할당 양보 할 때 ) 
            WORKING         // pick &place 작업 중

        }

        public enum ceiling_dir
        {
            CENTER,
            LEFT,
            RIGHT   
        }



    }
}
