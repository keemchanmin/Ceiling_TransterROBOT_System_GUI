namespace Ceiling_TransterROBOT_System_GUI
{
    public class PathFiner
    {
        public static int[,] Optimal_Route_arr = new int[5, 5]
        {
                {0,1,0,1,0},
                {1,1,1,1,1},
                {0,1,0,1,0},
                {1,1,1,1,1},
                {0,1,0,1,0}
        };

        public static int[,] Real_Move_Route_arr = new int[5, 5]
        {
                {0,0,0,0,0},
                {1,2,1,2,1},
                {0,0,0,0,0},
                {1,2,1,2,1},
                {0,0,0,0,0}
        };

        public static char[,] Real_Move_Route_arr_CHAR = new char[5, 5]
        {
                {'0','0','0','0','0'},
                {'0','C','0','C','0'},
                {'0','0','0','0','0'},
                {'0','C','0','C','0'},
                {'0','0','0','0','0'},
        };




        public (int, int)[] dead_lock_arr;
        public Robot robot1;
        public Robot robot2;
        public Dictionary<(int, int), int> rotary_state;


        public PathFiner()
        {

        }
        public PathFiner(Robot robot1, Robot robot2)
        {
            this.robot1 = robot1;
            this.robot2 = robot2;
            dead_lock_arr = new (int, int)[] { (1, 2), (2, 1), (2, 3), (3, 2), };
            rotary_state = new Dictionary<(int, int), int>();

            rotary_state.Add((1, 1), (int)ENUM.ceiling_dir.CENTER);
            rotary_state.Add((1, 3), (int)ENUM.ceiling_dir.CENTER);
            rotary_state.Add((3, 1), (int)ENUM.ceiling_dir.CENTER);
            rotary_state.Add((3, 3), (int)ENUM.ceiling_dir.CENTER);
        }

        public static void Set_Rotary(string num , string dir)
        {
            switch(num)
            {
                case "|1":
                    if (dir == "C")
                    {
                        Real_Move_Route_arr[1, 1] = 2;
                        Real_Move_Route_arr_CHAR[1, 1] = 'C';
                    }
                    else if(dir== "R")
                    {
                        Real_Move_Route_arr[1, 1] = 1;
                        Real_Move_Route_arr_CHAR[1, 1] = 'R';
                    }
                    else if ( dir == "L")
                    {
                        Real_Move_Route_arr[1, 1] = 1;
                        Real_Move_Route_arr_CHAR[1, 1] = 'L';
                    }
                break;
                case "|2":
                    if (dir == "C")
                    {
                        Real_Move_Route_arr[1, 3] = 2;
                        Real_Move_Route_arr_CHAR[1, 3] = 'C';

                       
                    }
                    else if (dir == "R")
                    {
                        Real_Move_Route_arr[1, 3] = 1;
                        Real_Move_Route_arr_CHAR[1, 3] = 'R';
                    }
                    else if (dir == "L")
                    {
                        Real_Move_Route_arr[1, 3] = 1;
                        Real_Move_Route_arr_CHAR[1, 3] = 'L';
                    }

                    break;
                case "|3":
                    if (dir == "C")
                    {
                        Real_Move_Route_arr[3,1] = 2;
                        Real_Move_Route_arr_CHAR[3,1] = 'C';
                    }
                    else if (dir == "R")
                    {
                        Real_Move_Route_arr[3, 1] = 1;
                        Real_Move_Route_arr_CHAR[3, 1] = 'R';
               
                    }
                    else if (dir == "L")
                    {
                        Real_Move_Route_arr[3, 1] = 1;
                        Real_Move_Route_arr_CHAR[3, 1] = 'L';

                    }
                    break;
                case "|4":
                    if (dir == "C")
                    {
                        Real_Move_Route_arr[3, 3] = 2;
                        Real_Move_Route_arr_CHAR[3, 3] = 'C';
                    }
                    else if (dir == "R")
                    {
                        Real_Move_Route_arr[3, 3] = 1;
                        Real_Move_Route_arr_CHAR[3, 3] = 'R';
                    }
                    else if (dir == "L")
                    {
                        Real_Move_Route_arr[3, 3] = 1;
                        Real_Move_Route_arr_CHAR[3, 3] = 'L';
                    }
                    break;
            }    
        }

        public static string Get_Rotary_ID((int,int) pos)
        {
            string str_id="";
            if (pos.Item1 == 1 && pos.Item2 == 1)
            {
                str_id = "|1";
            }

            else if (pos.Item1 == 1 && pos.Item2 == 3)
            {
                str_id = "|2";
            }

            else if (pos.Item1 == 3 && pos.Item2 == 1)
            {
                str_id = "|3";
            }
            else if (pos.Item1 == 3 && pos.Item2 == 3)
            {
                str_id = "|4";
            }
            return str_id;
        }

        public static bool isRotary((int,int) pos)
        {
            if(pos==(1,1)
                || pos==(1,3)
                || pos==(3,1)
                || pos==(3,3)) return true;
            else return false;

        }

        public bool FindShortestPath(Robot Me, Robot Another)

        {
            bool colli=false;
            if (((Me.dst == (3, 4) || Me.dst == (4, 3)) && Me.start == (1, 0)) 
                || ((Me.dst == (1, 4) || Me.dst == (0, 3)) && Me.start == (3, 0))
                || (Me.dst==(1,0) && (Me.start ==(3,4) || Me.start==(4,3)))
                || (Me.dst == (3, 0) && (Me.start == (1, 4) || Me.start == (0, 3)))
                )
            {
#if false
                if (Another.State == (int)ENUM.state.BLOKED)
                {
                    // 각자 다른걸로 배정 
                    Check_Short_Path_DeadLock(Me, Another);
                    return true;
                }
#endif

                if(Another.State == (int)ENUM.state.NON)
                {
                    Me.State = (int)ENUM.state.BLOKED;
                }

                else
                {
                    colli = Check_Short_Path(Me, Another, Me.start, Me.dst);
                }

            }
            else
            {
                colli= Check_Short_Path(Me, Another, Me.start, Me.dst);
            }

            return colli;

        }
        public void Check_Short_Path_DeadLock(Robot Me, Robot Another)
        {
            if(Me.path!=null &&Me.path.Count!=0) Me.Path_Clear();
            if (Another.path != null && Another.path.Count != 0) Another.Path_Clear();
            List<List<(int, int)>> tmp_Me = FindAllPaths(Me.start, Me.dst);
            List<List<(int, int)>> tmp_Another = FindAllPaths(Another.start, Another.dst);

            
            for(int i=1; i< tmp_Me[0].Count; i++) 
            {
                MyPath p = new MyPath();
                p.pos = tmp_Me[0][i];
                Me.path.Add(p);
            }

            for (int i = 1; i < tmp_Another[1].Count; i++)
            {
                MyPath p = new MyPath();
                p.pos = tmp_Another[1][i];
                Another.path.Add(p);
            }

            Me.State = (int)ENUM.state.ACTIVE;
            Another.State = (int)ENUM.state.ACTIVE;
        }
        public bool Check_Short_Path(Robot Me, Robot Another, (int, int) start, (int, int) end)         // return false 면 충돌 x
                                                                                                        // return ture 면 충돌 O 
        {
            bool colli = false;
            List<List<(int, int)>> tmp = FindAllPaths(start, end);
            List<(int, int)> tmp1 = tmp[0];
            
            List<MyPath> myPath1 = new List<MyPath>();
            double prv_time = 0;
            for (int i = 0; i < tmp1.Count; i++)
            {
                if (i <= tmp1.Count - 2)
                {
                    MyPath p = new MyPath();
                    (int, int) cur_pos = tmp1[i];
                    (int, int) next_pos = tmp1[i + 1];
                    p.time = prv_time;
                    p.time += PlusTime(cur_pos, next_pos);
                    prv_time = p.time;
                    p.pos = next_pos;
                    myPath1.Add(p);
                }
            }

            // 다시 확인
#if false
            if (!(Me.Id=='A' && end == (0,1) &&Me.Dir==(int)ENUM.dir.FRONT || Me.Id=='B'&& end==(4,1) && Me.Dir == (int)ENUM.dir.FRONT || 
                Me.start==(0,1) && Me.dst==(1,0) && Me.Dir == (int)ENUM.dir.BACK ||
                Me.start == (4, 1) && Me.dst == (3, 0) && Me.Dir == (int)ENUM.dir.BACK))
            {
                List<(int, int)> tmp2= tmp[1];
                List<MyPath> myPath2 = new List<MyPath>();
            
           
            
                 prv_time = 0;

                for (int i = 0; i < tmp2.Count; i++)
                {
                    if (i <= tmp2.Count - 2)
                    {
                        MyPath p = new MyPath();
                        (int, int) cur_pos = tmp2[i];
                        (int, int) next_pos = tmp2[i + 1];
                        p.time = prv_time;
                        p.time += PlusTime(cur_pos, next_pos);
                        prv_time = p.time;
                        p.pos = next_pos;
                        myPath2.Add(p);
                    }
                }


                if (myPath1[myPath1.Count - 1].time < myPath2[myPath2.Count - 1].time)
                {
                    Me.path = myPath1;                  // 실제 사용하는 Robot 객체의 path 리스트에서는 index 0 이 현재위치가 아닌 그 다음 위치부터... 
                    Me.bypass_path = myPath2;
                }
                else if(myPath1[myPath1.Count - 1].time > myPath2[myPath2.Count - 1].time)
                {
                    Me.path = myPath2;
                    Me.bypass_path = myPath1;
                }
                else
                {
                    Me.State = (int)ENUM.state.BLOKED;
                    return;
                }
                
            }
            else
            {
                Me.path = myPath1;
            }
#endif
            // 다시 확인

            if (tmp.Count == 2)
            {
                List<(int, int)> tmp2 = tmp[1];
                List<MyPath> myPath2 = new List<MyPath>();

                prv_time = 0;

                for (int i = 0; i < tmp2.Count; i++)
                {
                    if (i <= tmp2.Count - 2)
                    {
                        MyPath p = new MyPath();
                        (int, int) cur_pos = tmp2[i];
                        (int, int) next_pos = tmp2[i + 1];
                        p.time = prv_time;
                        p.time += PlusTime(cur_pos, next_pos);
                        prv_time = p.time;
                        p.pos = next_pos;
                        myPath2.Add(p);
                    }
                }

                if (Math.Truncate(myPath1[myPath1.Count - 1].time * 10) / 10 < Math.Truncate(myPath2[myPath2.Count - 1].time * 10) / 10)
                {
                    Me.path = myPath1;                  // 실제 사용하는 Robot 객체의 path 리스트에서는 index 0 이 현재위치가 아닌 그 다음 위치부터... 
                    Me.bypass_path = myPath2;
                  //  Me.State = (int)ENUM.state.ACTIVE;
                }
                else if (Math.Truncate(myPath1[myPath1.Count - 1].time * 10) / 10 > Math.Truncate(myPath2[myPath2.Count - 1].time * 10) / 10)
                {
                    Me.path = myPath2;
                    Me.bypass_path = myPath1;
                  //  Me.State = (int)ENUM.state.ACTIVE;
                }
                else
                {
                    if (Another.State == (int)ENUM.state.NON)
                    {
                        Me.State = (int)ENUM.state.BLOKED;
                        //    Me.path = myPath1;                
                        //    Me.bypass_path = myPath2;
                        return false;
                    }

                    else if (Another.State == (int)ENUM.state.ACTIVE)
                    {
                        Me.path = myPath1;                  // 실제 사용하는 Robot 객체의 path 리스트에서는 index 0 이 현재위치가 아닌 그 다음 위치부터... 
                        Me.bypass_path = myPath2;
                        Me.State = (int)ENUM.state.ACTIVE;
                    }
                }
            }

            else if (tmp.Count == 1) { Me.path = myPath1; Me.State = (int)ENUM.state.ACTIVE; }


                if (Another.State == (int)ENUM.state.BLOKED)
            {
                // Another 의 경로 다시 생성 . Me 의 로봇이 없는 경로로 

                List<List<(int, int)>> p_tmp = FindAllPaths(Another.start, Another.dst);

                List<(int, int)> p1 = p_tmp[0];
                List<MyPath> tmp_path1 = new List<MyPath>();
                prv_time = 0;
                for (int i = 0; i < p1.Count; i++)
                {
                    if (i <= p1.Count - 2)
                    {
                        MyPath p = new MyPath();
                        (int, int) cur_pos = p1[i];
                        (int, int) next_pos = p1[i + 1];
                        p.time = prv_time;
                        p.time += PlusTime(cur_pos, next_pos);
                        prv_time = p.time;
                        p.pos = next_pos;
                        tmp_path1.Add(p);
                    }
                }


                    List<(int, int)> p2 = p_tmp[1];
                    List<MyPath> tmp_path2 = new List<MyPath>();

                    prv_time = 0;

                    for (int i = 0; i < p2.Count; i++)
                    {
                        if (i <= p2.Count - 2)
                        {
                            MyPath p = new MyPath();
                            (int, int) cur_pos = p2[i];
                            (int, int) next_pos = p2[i + 1];
                            p.time = prv_time;
                            p.time += PlusTime(cur_pos, next_pos);
                            prv_time = p.time;
                            p.pos = next_pos;
                            tmp_path2.Add(p);
                        }
                    }

                    if (Collision_Check(tmp_path1, Me)) Another.path = tmp_path2;
                    else Another.path = tmp_path1;
                    Another.State = (int)ENUM.state.ACTIVE;
                    Me.State = (int)ENUM.state.ACTIVE;

                return false;
            }

            colli= IsCollision(Me, Another);

            return colli;
        }

        public double PlusTime((int, int) cur, (int, int) next)
        {
            double time = 0;
            int x = Math.Abs(GetValue_Real_Move_Route_arr(cur)
                                - GetValue_Real_Move_Route_arr(next));
            if (cur.Item1 == next.Item1)                // 좌우 이동
            {
                if (Math.Abs(GetValue_Real_Move_Route_arr(cur)
                                - GetValue_Real_Move_Route_arr(next)) == 1)
                {
                    time = 0.8 + 7;
                }
                else if (Math.Abs(GetValue_Real_Move_Route_arr(cur)
                                - GetValue_Real_Move_Route_arr(next)) == 0)
                {
                    time = 7;
                }
            }
            else if (cur.Item2 == next.Item2)           // 상하 이동   
            {
                if (Math.Abs(GetValue_Real_Move_Route_arr(cur)
                                - GetValue_Real_Move_Route_arr(next)) == 1)
                {
                    time = 0.8 + 7;
                }
                else if (Math.Abs(GetValue_Real_Move_Route_arr(cur)
                                - GetValue_Real_Move_Route_arr(next)) == 2)
                {
                    time = 7;
                }
            }

            return time;
        }

        // 만약에 이동 성공하면 Robot 의 List<MyPath> path 리스트에서는 현재 cur 위치는 삭제 할 것
        public void Set_timeAndpos(Robot r)
        {
            r.Time_Clear(); 
            double prv_time = 0;
            (int, int) prv_cur_pos = r.cur;
            if (r.path.Count>=2)
            {
                for(int i=0;i<r.path.Count;i++) 
                {
                    if (i <= r.path.Count - 1)
                    {
                        MyPath p = new MyPath();
                        (int, int) cur_pos = prv_cur_pos;
                        (int, int) next_pos = r.path[i].pos;
                        prv_cur_pos = next_pos;
                        r.path[i].time = prv_time;
                        r.path[i].time += PlusTime(cur_pos, next_pos);
                        prv_time = r.path[i].time;
                    }
                }
            }
        }

        public void Set_bypass_time(Robot r)
        {
            r.Time_Clear();
            double prv_time = 0;
            (int, int) prv_cur_pos = r.cur;
            if (r.bypass_path.Count >= 2)
            {
                for (int i = 0; i < r.bypass_path.Count; i++)
                {
                    if (i <= r.bypass_path.Count - 1)
                    {
                        MyPath p = new MyPath();
                        (int, int) cur_pos = prv_cur_pos;
                        (int, int) next_pos = r.bypass_path[i].pos;
                        prv_cur_pos = next_pos;
                        r.bypass_path[i].time = prv_time;
                        r.bypass_path[i].time += PlusTime(cur_pos, next_pos);
                        prv_time = r.bypass_path[i].time;
                    }
                }
            }

        }

        public bool Collision_Check(List<MyPath> p, Robot Me)
        {
            if(p.Count <=Me.path.Count)
            {
                for (int i = 0; i < p.Count; i++)
                {
                    if (((Me.path[i].pos == p[i].pos)
                        && ((Me.path[i].time == p[i].time) || Math.Abs(Me.path[i].time - p[i].time) < 5)))
                    {
                        return true;
                    }
                }
            }
            else if(p.Count > Me.path.Count)
            {
                for (int i = 0; i < Me.path.Count; i++)
                {

                
                    if (((Me.path[i].pos == p[i].pos)
                        && ((Me.path[i].time == p[i].time) || Math.Abs(Me.path[i].time - p[i].time) < 5)))
                    {
                        return true;
                    }
                }
            }
            return false;                       
        }
        public bool IsCollision(Robot Me, Robot Another)            // 충돌 확인 
        {
            bool colli = false;
            bool st_collision_flag = false;
            if (Another.State == (int)ENUM.state.ACTIVE)
            {
                      //  i가 0일 때 즉 출발지 바로 앞에 상대 로봇이 있을 경우
                Set_timeAndpos(Another);
                int collison_flag = 0;
                if (Me.path.Count >= Another.path.Count)
                {
                    for (int i = 0; i < Another.path.Count; i++)
                    {
                        if (((Me.path[i].pos == Another.path[i].pos)
                            && ((Me.path[i].time == Another.path[i].time) || Math.Abs(Me.path[i].time - Another.path[i].time) < 15) )
                            ||( i == 0 && Me.path[i].pos == Another.cur))
                        {
                            collison_flag = 1;
                            //정점 충돌 
                            if (isDeadLock(Me.path[i].pos) == true)
                            {
                                // 출발점에서 정지 
                                Me.Wait_Flag = true;
                                Me.wait_pos = Me.cur;                   //상대방이 wait_pos 지날 때 까지 정지
                                Me.State = (int)ENUM.state.BLOKED;
                                Me.colli_pos = Me.path[i].pos;
                                collison_flag = 1;
                                Me.Draw_Collision_Flag = true;

                                int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                                Another.pass_pos = Another.path[idx + 1].pos;
                                st_collision_flag = true;

                                colli = true;

                            }   
                            else
                            {
                                // 
                                Me.Wait_Flag = true;
                                if(i== 0)                                   //바로 시작할때 충돌
                                {
                                    Me.wait_pos = Me.path[0].pos;
                                    collison_flag = 1;
                                     int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                                     Another.pass_pos = Another.path[idx + 1].pos;
                                    Me.colli_pos = Me.path[i].pos;
                                    //Another.pass_pos = Me.path[i].pos;
                                    st_collision_flag = true;
                                    Me.Draw_Collision_Flag = true;
                                    colli = true;
                                    Me.State = (int)ENUM.state.BLOKED;
                                    break;
                                }
                                else
                                {

                                    MyPath? tmp_idx = null;
                                    tmp_idx = Another.path.Find(p => p.pos == Me.path[i - 1].pos);
                                    if (tmp_idx != null)
                                    {
                                        Me.wait_pos = Me.path[0].pos;
                                        collison_flag = 1;
                                        int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                                        Another.pass_pos = Another.path[idx + 1].pos;
                                        Me.colli_pos = Me.path[i].pos;
                                        //Another.pass_pos = Me.path[i].pos;
                                        st_collision_flag = true;
                                        Me.Draw_Collision_Flag = true;
                                        colli = true;
                                        Me.State = (int)ENUM.state.BLOKED;
                                        break;
                                    }
                                    else
                                    {
                                        Me.wait_pos = Me.path[i - 1].pos;
                                        collison_flag = 2;
                                        Me.colli_pos = Me.path[i].pos;
                                        //   Another.pass_pos = Me.path[i].pos;
                                        int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                                        Another.pass_pos = Another.path[idx + 1].pos;
                                        idx = Another.path.FindIndex(p => p.pos == Me.colli_pos);
                                        Another.pass_pos = Another.path[idx + 1].pos;
                                        Me.Draw_Collision_Flag = true;
                                        colli = true;
                                    }

                                    //Me.State = (int)ENUM.state.BLOKED;
                                } 
                                                           
                                // Another.Pass_Flag = true;
                                //Another.pass_pos = Another.path[i-1].pos;
                            }
                        }

                        else if ((i <= Another.path.Count - 2) && (Me.path[i].pos == Another.path[i + 1].pos)
                            && (Me.path[i + 1].pos == Another.path[i].pos)
                            && (Me.path[i].time == Another.path[i].time))
                        {
                            // 스와핑 충돌 
                            Me.Wait_Flag = true;
                            Me.wait_pos = Me.cur;                               //상대방이 wait_pos 지날 때 까지 정지
                            Me.State = (int)ENUM.state.BLOKED;
                            collison_flag = 1;
                            Me.Draw_Collision_Flag = true;
                            colli = true;
                            int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                            Another.pass_pos = Another.path[idx + 1].pos;
                        }

                        if (collison_flag != 0 && st_collision_flag ==false)
                        {
                            double time = 0;
                            if (collison_flag == 1)
                            {
                                int idx = Another.find_index_path(Me.path[1].pos);
                                time += Another.path[idx + 1].time;
                                time += Me.path[Me.path.Count - 1].time;
                            }
                            else if (collison_flag == 2)
                            {
                                if (i != 1)
                                {
                                    time += Me.path[i - 1].time;
                                    time += (Another.path[i + 1].time - Another.path[i - 1].time);
                                    time += Me.path[Me.path.Count - 1].time - Me.path[i - 1].time;
                                }
                                else
                                {
                                    int idx = Another.find_index_path(Me.path[1].pos);
                                    time += Another.path[idx + 1].time;
                                    time += Me.path[Me.path.Count - 1].time;
                                }

                            }
                            if (!(Me.Id == 'A' && Me.dst == (0, 1) || Me.Id == 'B' && Me.dst == (4, 1)))                // 만약 시작 다음이면 우회 X
                            {
                                Set_bypass_time(Me);
                                if (time >= Me.bypass_path[Me.bypass_path.Count - 1].time)
                                {
                                    // 우회 할당
                                    Me.Wait_Flag = false;
                                    Me.wait_pos = (-1, -1);
                                    Me.path = Me.bypass_path;
                                    colli = false;
                                    Me.State = (int)ENUM.state.ACTIVE;
                                }
                            }
                            break;
                        }
                        else if(collison_flag==0)
                        {
                            Me.State = (int)ENUM.state.ACTIVE;  //충돌 X
                            colli = false;
                        }
                    }
                }
                else if (Me.path.Count < Another.path.Count)
                {
                    for (int i = 0; i < Me.path.Count; i++)
                    {
                        if (((Me.path[i].pos == Another.path[i].pos)
                            && ((Me.path[i].time == Another.path[i].time) || Math.Abs(Me.path[i].time - Another.path[i].time) < 15))
                            || (i == 0 && Me.path[i].pos == Another.cur))
                        {

                            collison_flag = 1;
                            //정점 충돌 
                            if (isDeadLock(Me.path[i].pos) == true)
                            {
                                // 출발점에서 정지 
                                Me.Wait_Flag = true;
                                Me.wait_pos = Me.cur;               //상대방이 wait_pos 지날 때 까지 정지
                                Me.State = (int)ENUM.state.BLOKED;
                                Me.colli_pos = Me.path[i].pos;
                                collison_flag = 1;
                                Me.Draw_Collision_Flag = true;
                                //Another.Pass_Flag = true;
                                //  Another.pass_pos = Me.path[0].pos;

                                int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                                Another.pass_pos = Another.path[idx + 1].pos;
                                st_collision_flag = true;
                                colli = true;
                            }

                            else
                            {
                                // 
                                Me.Wait_Flag = true;
                                if (i == 0)                                   //바로 시작할때 충돌
                                {
                                    Me.wait_pos = Me.path[0].pos;
                                    collison_flag = 1;
                                    int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                                    Another.pass_pos = Another.path[idx + 1].pos;
                                    Me.colli_pos = Me.path[i].pos;
                                    //Another.pass_pos = Me.path[i].pos;
                                    st_collision_flag = true;
                                    Me.Draw_Collision_Flag = true;
                                    colli = true;
                                    Me.State = (int)ENUM.state.BLOKED;
                                    break;
                                }
                                else
                                {

                                    MyPath? tmp_idx = null;
                                    tmp_idx = Another.path.Find(p => p.pos == Me.path[i - 1].pos);
                                    if (tmp_idx != null)
                                    {
                                        Me.wait_pos = Me.path[0].pos;
                                        collison_flag = 1;
                                        int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                                        Another.pass_pos = Another.path[idx + 1].pos;
                                        Me.colli_pos = Me.path[i].pos;
                                        //Another.pass_pos = Me.path[i].pos;
                                        st_collision_flag = true;
                                        Me.Draw_Collision_Flag = true;
                                        colli = true;
                                        Me.State = (int)ENUM.state.BLOKED;
                                        break;
                                    }
                                    else
                                    {
                                        Me.wait_pos = Me.path[i - 1].pos;
                                        collison_flag = 2;
                                        Me.colli_pos = Me.path[i].pos;
                                        //   Another.pass_pos = Me.path[i].pos;
                                        int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                                        Another.pass_pos = Another.path[idx + 1].pos;
                                        idx = Another.path.FindIndex(p => p.pos == Me.colli_pos);
                                        Another.pass_pos = Another.path[idx + 1].pos;
                                        Me.Draw_Collision_Flag = true;
                                        colli = true;
                                    }

                                    //Me.State = (int)ENUM.state.BLOKED;
                                }

                                // Another.Pass_Flag = true;
                                //Another.pass_pos = Another.path[i-1].pos;
                            }






                        }
                        else if ((Me.path[i].pos == Another.path[i + 1].pos)
                            && (Me.path[i + 1].pos == Another.path[i].pos)
                            && (Me.path[i].time == Another.path[i].time))
                        {
                            // 스와핑 충돌 
                            Me.Wait_Flag = true;
                            Me.wait_pos = Me.path[1].pos;               //상대방이 wait_pos 지날 때 까지 정지
                            Me.State = (int)ENUM.state.BLOKED;
                            collison_flag = 1;
                            colli = true;
                            int idx = Another.path.FindIndex(p => p.pos == Me.path[0].pos);
                            Another.pass_pos = Another.path[idx + 1].pos;
                        }

                        if (collison_flag != 0)
                        {
                            double time = 0;
                            if (collison_flag == 1)
                            {
                                int idx = Another.find_index_path(Me.path[1].pos);
                                time += Another.path[idx + 1].time;
                                time += Me.path[Me.path.Count - 1].time;
                            }
                            else if (collison_flag == 2)
                            {
                                if (i != 1)
                                {
                                    time += Me.path[i - 1].time;
                                    time += (Another.path[i + 1].time - Another.path[i - 1].time);
                                    time += Me.path[Me.path.Count - 1].time - Me.path[i - 1].time;
                                }
                                else
                                {
                                    int idx = Another.find_index_path(Me.path[1].pos);
                                    time += Another.path[idx + 1].time;
                                    time += Me.path[Me.path.Count - 1].time;
                                }

                            }
                            Set_bypass_time(Me);
                            if (Me.bypass_path.Count!=0&&time >= Me.bypass_path[Me.bypass_path.Count - 1].time)
                            {
                                // 우회 할당
                                Me.Wait_Flag = false;
                                Me.wait_pos = (-1, -1);
                                Me.path = Me.bypass_path;
                                colli = false;
                                Me.State = (int)ENUM.state.ACTIVE;
                            }
                            break;
                        }
                        else if (collison_flag == 0)
                        {
                            Me.State = (int)ENUM.state.ACTIVE;  //충돌 X
                            colli = false;
                        }
                    }
                }
            }

            else
            {
                Me.State = (int)ENUM.state.ACTIVE;
                colli = false;
            }
            if(st_collision_flag == false && Me.State==(int)ENUM.state.NON)
            {
                Me.State = (int)ENUM.state.ACTIVE;
                colli = false;
            }
            return colli;
        }

        public List<List<(int, int)>> FindAllPaths((int, int) start, (int, int) end)
        {
            List<List<(int, int)>> allPaths = new List<List<(int, int)>>();
            List<(int, int)> currentPath = new List<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            DFS(start, end, currentPath, allPaths, visited);
            return allPaths;
        }

        private void DFS((int, int) current, (int, int) end,
                                List<(int, int)> currentPath, List<List<(int, int)>> allPaths,
                                HashSet<(int, int)> visited)
        {
            if (current == end)
            {
                currentPath.Add(current);
                allPaths.Add(new List<(int, int)>(currentPath));
                currentPath.RemoveAt(currentPath.Count - 1);
                return;
            }

            visited.Add(current);
            currentPath.Add(current);

            int[,] directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } }; // 상하좌우

            for (int i = 0; i < 4; i++)
            {
                int newX = current.Item1 + directions[i, 0];
                int newY = current.Item2 + directions[i, 1];

                if (newX >= 0 && newX < Optimal_Route_arr.GetLength(0) &&
                    newY >= 0 && newY < Optimal_Route_arr.GetLength(1) &&
                    Optimal_Route_arr[newX, newY] == 1 && !visited.Contains((newX, newY)))
                {
                    DFS((newX, newY), end, currentPath, allPaths, visited);
                }
            }

            visited.Remove(current);
            currentPath.RemoveAt(currentPath.Count - 1);
        }



        public  static int GetValue_Real_Move_Route_arr((int,int) pos)
        {
            return Real_Move_Route_arr[pos.Item1, pos.Item2];
        }
        public static int GetDIR_Real_Move_Route_arr((int, int) pos)
        {
            return Real_Move_Route_arr_CHAR[pos.Item1, pos.Item2];
        }

        public bool isDeadLock((int, int) pos)
        {
            bool flag = false;
            foreach (var it in dead_lock_arr)
            {
                if (it == pos) flag = true;
            }
            return flag;
        }


    }
}
