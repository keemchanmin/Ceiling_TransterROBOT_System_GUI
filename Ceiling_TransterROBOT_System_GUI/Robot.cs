using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ceiling_TransterROBOT_System_GUI
{
    public class Robot
    {
        public char Id { get; set; }
        public int Priority { get; set; }
        public int Dir { get; set; }
        public int State { get; set; }
        public (int,int) start { get; set; }
        public (int, int) dst { get; set; }
        public (int, int) cur { get; set; }
        public (int,int)  wait_pos { get; set; }    
        public bool Wait_Flag { get; set; }
        public (int, int) pass_pos { get; set; }
        public (int, int) colli_pos { get; set; }
        public bool Pass_Flag { get; set; }
        public int Detail_Dir { get; set; } 
        public bool Start_Flag { get; set; }
        public bool Draw_Flag { get; set; }
        public bool Draw_Set_Flag { get; set; } 
        public bool Draw_Collision_Flag { get; set; }
        public List<MyPath> path { get; set; }
        public List<MyPath> bypass_path { get; set; }
        public PathFiner pathfinder;
        public ClientHandler client;

        public int Dst_NUM { get; set; }
        public Robot(char id, int pri,int dir, int state)
        {
            Id = id;
            Priority = pri;
            Dir = dir;
            State = state;
            dst = (-1, -1);
            Wait_Flag = false;
            Detail_Dir = -1;
            Draw_Flag = false;
            Start_Flag = false;
            Pass_Flag=false;
            Dst_NUM = -1;
            if (id == 0) { start = (1, 0); cur = (1, 0); }
            else if (id == 1) { start = (3, 0); cur = (3, 0); }


            path = new List<MyPath>();  
            bypass_path = new List<MyPath>();
            pathfinder = new PathFiner();

        }

        public void Set_Client(ClientHandler client)
        {
            this.client = client;

        }

        public void Dst_Clear()
        {
            dst = (-1, -1);
            Dst_NUM = -1;
        }

        public void Path_Clear()
        {
            path.Clear();
            bypass_path.Clear();
            pass_pos=(-1, -1);  
            Pass_Flag = false;
            Wait_Flag = false;
        }

        public void Time_Clear()
        {
            foreach(var t in path)
            {
                t.time = 0;
            }
            foreach (var t in bypass_path)
            {
                t.time = 0;
            }
        }


       public int find_index_path((int,int) p)
        {
            int idx = -1;
            for(int i=0;i<path.Count;i++)
            {
                if (path[i].pos==p)
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }



      


    }

  
    
}
