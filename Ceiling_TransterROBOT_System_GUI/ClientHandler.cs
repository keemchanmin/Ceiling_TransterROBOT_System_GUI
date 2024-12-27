using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ceiling_TransterROBOT_System_GUI
{
    public class ClientHandler
    {

        // client[0] : 영상처리부
        // client[1] : 로봇 A
        // client[2] : 로봇 B
        // client[3] : 천장부 

        private Socket? socketClient = null;
        private NetworkStream? netstream = null;
        private Form1? form1;
        private int bytes;
        string? lstMessage;


        public void ClientHandler_Setup(Socket socketClient, Form1 form1, int id)
        {
            this.socketClient = socketClient;
            this.netstream = new NetworkStream(socketClient);
            this.form1 = form1;
        }
        public static bool IsDst(string str)
        {
            
            for (int i = 1; i <= 6; i++)
            {
                if (str.Contains(i.ToString()))
                { return true; }
            }
            return false;
        }
        public bool isZERO(string str)
        {
            int zero = 0;
            if (str.Contains(zero.ToString()))
            { return true; }
            return false;
        }

        public void Operate_Process()
        {
            try
            {
                int buffsize = socketClient.ReceiveBufferSize;

                byte[] buffer = new byte[buffsize];
                while (true)
                {
                    bytes = netstream.Read(buffer, 0, buffer.Length);

                    lstMessage = Encoding.Default.GetString(buffer, 0, bytes);
                    if (lstMessage != null)
                    {
                        if (IsDst(lstMessage) && lstMessage.Contains("|")==false)              // 목적지 입력
                        {
                            if(lstMessage.Contains("A"))
                            {
                                // Pick 동작 수행 명령 송신 

                                form1.ClientHandle_list[1].SendMessageToClients("PICK"+ form1.Get_Height_Stack_Box(lstMessage[2]), 1);
                                form1.Set_dst(form1.robot_1, lstMessage[2]);         
                                form1.robot_1.cur = (1, 0);
                                form1.robot_1.start = (1, 0);
                            }
                            else if(lstMessage.Contains("B"))
                            {
                                // Pick 동작 수행 명령 송신 
                                form1.ClientHandle_list[2].SendMessageToClients("PICK"+form1.Get_Height_Stack_Box(lstMessage[2]), 2);
                                form1.Set_dst(form1.robot_2, lstMessage[2]);
                                form1.robot_2.cur = (3, 0);
                                form1.robot_2.start = (3, 0);
                            }
                        }

                        else if (lstMessage.Contains("R_T"))    //로봇 이동 확인 시 (포토 센서 검출 )
                        {
                            if(lstMessage.Contains("A"))
                            {
                                if(form1.robot_1.State==(int)ENUM.state.ACTIVE)
                                {
                                   // form1.Move_  
                                   bool go_flag=true;
                                    form1.robot_1.cur = form1.robot_1.path[0].pos;
                                    form1.robot_1.path.RemoveAt(0);
                                     
                                    if(form1.robot_1.Wait_Flag == true && form1.robot_1.wait_pos==form1.robot_1.cur)
                                    {
                                        form1.robot_1.State = (int)ENUM.state.BLOKED;
                                    }

                                    if (form1.robot_1.path.Count != 0 &&form1.robot_1.State==(int)ENUM.state.ACTIVE)
                                    {
                                        if(form1.robot_2.State == (int)ENUM.state.ACTIVE)
                                        {
                                            if(form1.robot_2.path.Count>=1)
                                            {
                                                if(form1.robot_1.path[0].pos == form1.robot_2.cur)
                                                {
                                                    go_flag = false;
                                                    form1.robot_1.State = (int)ENUM.state.BLOKED;
                                                    form1.robot_2.pass_pos = form1.robot_2.path[0].pos;
                                                    form1.robot_2.Pass_Flag = false;
                                                    form1.robot_1.Wait_Flag = true;
                                                }
                                            }
                                        }

                                        if (go_flag) form1.Check_Able_Move(form1.robot_1);

                                    }
                                        
                               

                                    else if(form1.robot_1.path.Count == 0)
                                    {
                                        if (form1.robot_1.Dir == (int)ENUM.dir.FRONT)
                                        {
                                            form1.ClientHandle_list[1].SendMessageToClients("PLACE", 1);
                                        } 
                                        else if (form1.robot_1.Dir == (int)ENUM.dir.BACK)
                                        {
                                            // Pick 작업 명령 송신
                                            form1.robot_1.State = (int)ENUM.state.NON;
                                            form1.ClientHandle_list[0].SendMessageToClients(form1.robot_1.Id.ToString() + "_" + "GIVE_DST", 0);
                                        }
                                    }

                                    if (form1.robot_1.cur == form1.robot_1.pass_pos && form1.robot_1.Pass_Flag==false && form1.robot_2.Wait_Flag == true)
                                    {
                                        form1.Draw_initRail4();
                                        form1.robot_1.Pass_Flag = true;
                                        form1.robot_2.State = (int)ENUM.state.ACTIVE;
                                        form1.robot_2.wait_pos = (-1, -1);
                                        form1.robot_2.Wait_Flag = false;
                                        form1.Check_Able_Move(form1.robot_2);
                                    }
                                }

                                form1.Draw_initRail();
                                form1.Move_Robot(form1.robot_1.cur, form1.robot_1.Id);
                                form1.Move_Robot(form1.robot_2.cur, form1.robot_2.Id);
                                
                            }
                            else if (lstMessage.Contains("B"))
                            {
                                if (form1.robot_2.State == (int)ENUM.state.ACTIVE)
                                {
                                    bool go_flag = true;
                                    form1.robot_2.cur = form1.robot_2.path[0].pos;
                                    form1.robot_2.path.RemoveAt(0);

                                    if (form1.robot_2.Wait_Flag == true && form1.robot_2.wait_pos == form1.robot_2.cur)
                                    {
                                        form1.robot_2.State = (int)ENUM.state.BLOKED;
                                    }

                                    if (form1.robot_2.cur == form1.robot_2.pass_pos && form1.robot_2.Pass_Flag == false && form1.robot_1.Wait_Flag == true)
                                    {
                                        form1.Draw_initRail4();
                                        form1.robot_2.Pass_Flag = true;
                                        form1.robot_1.State = (int)ENUM.state.ACTIVE;
                                        form1.robot_1.wait_pos = (-1, -1);
                                        form1.robot_1.Wait_Flag = false;
                                        form1.Check_Able_Move(form1.robot_1);
                                    }

                                    if (form1.robot_2.path.Count != 0 && form1.robot_2.State == (int)ENUM.state.ACTIVE)
                                    {
                                        if (form1.robot_1.State == (int)ENUM.state.ACTIVE)
                                        {
                                            if (form1.robot_1.path.Count >= 1)
                                            {
                                                if (form1.robot_2.path[0].pos == form1.robot_1.cur)
                                                {
                                                    go_flag = false;
                                                    form1.robot_2.State = (int)ENUM.state.BLOKED;
                                                    form1.robot_1.pass_pos = form1.robot_1.path[0].pos;
                                                    form1.robot_1.Pass_Flag = false;
                                                    form1.robot_2.Wait_Flag = true;
                                                }
                                            }
                                        }

                                        if (go_flag) form1.Check_Able_Move(form1.robot_2);
                                    }
                                    else if (form1.robot_2.path.Count == 0)
                                    {
                                        // Pick & Place 작업
                                        if (form1.robot_2.Dir == (int)ENUM.dir.FRONT)
                                        {
                                            // Place 작업 명령 송신
                                            form1.ClientHandle_list[2].SendMessageToClients("PLACE", 2);
                                        }
                                        else if (form1.robot_2.Dir == (int)ENUM.dir.BACK)
                                        {
                                            // Pick 작업 명령 송신
                                            form1.robot_2.State = (int)ENUM.state.NON;
                                            form1.ClientHandle_list[0].SendMessageToClients(form1.robot_2.Id.ToString() + "_" + "GIVE_DST", 0);
                                        }
                                    }

                                }
                                form1.Draw_initRail();
                                form1.Move_Robot(form1.robot_1.cur, form1.robot_1.Id);
                                form1.Move_Robot(form1.robot_2.cur, form1.robot_2.Id);
                            }


                        }
                        else if(lstMessage.Contains("Pick_T"))                      
                        {
                            if (lstMessage.Contains("A"))
                            {
                                form1.robot_1.Start_Flag=false;
                                form1.robot_1.Dir = (int)ENUM.dir.FRONT;
                                form1.pathFinder.FindShortestPath(form1.robot_1, form1.robot_2);

                                form1.Check_Able_Move(form1.robot_1);
                                form1.robot_1.Draw_Flag = false;
                                form1.Draw_initRail2();
                                form1.Draw_Path_1();
                                if (/*form1.robot_2.State == (int)ENUM.state.ACTIVE && */form1.robot_2.Draw_Flag == false) form1.Draw_Path_2();
                                if (form1.robot_1.Wait_Flag && form1.robot_1.Draw_Collision_Flag) 
                                {
                                    form1.Draw_initRail4();
                                    Rectangle robot = new Rectangle((60 * form1.robot_1.colli_pos.Item2 + 60 / 4)-5, (60 * form1.robot_1.colli_pos.Item1 + 60 / 4)-5, 28, 28);
                                    form1.Collision_box(robot);
                                    form1.robot_1.Draw_Collision_Flag=false;
                                }

                                if (form1.robot_2.Start_Flag==false && form1.robot_2.State==(int)ENUM.state.ACTIVE) 
                                {
                                    form1.Check_Able_Move(form1.robot_2);
                                }
                            }
                            else if (lstMessage.Contains("B"))
                            {
                                form1.robot_2.Start_Flag = false;
                                form1.robot_2.Dir = (int)ENUM.dir.FRONT;
                                form1.pathFinder.FindShortestPath(form1.robot_2, form1.robot_1);


                                form1.Check_Able_Move(form1.robot_2);
                                form1.robot_2.Draw_Flag = false;
                                form1.Draw_initRail3();
                                form1.Draw_Path_2();
                                if (/*form1.robot_1.State == (int)ENUM.state.ACTIVE && */form1.robot_1.Draw_Flag == false) form1.Draw_Path_1();


                                //교착 상태에서 한쪽이 움직일 때 다른 쪽도 움직여야함
                                //블락 상태에서 지나쳤을때 움직여야함 
                                if (form1.robot_2.Wait_Flag && form1.robot_2.Draw_Collision_Flag)
                                {
                                    form1.Draw_initRail4();
                                    Rectangle robot = new Rectangle((60 * form1.robot_2.colli_pos.Item2 + 60 / 4)-5, (60 * form1.robot_2.colli_pos.Item1 + 60 / 4)-5, 53, 53);
                                    form1.Collision_box(robot);
                                    form1.robot_2.Draw_Collision_Flag = false;
                                }
                                if (!form1.robot_1.Start_Flag && form1.robot_1.State == (int)ENUM.state.ACTIVE)
                                {
                                    form1.Check_Able_Move(form1.robot_1);
                                }
                            }
                        }
                        else if (lstMessage.Contains("Place_T"))                    //  도착점에서 Place 동작 끝 
                        {
                            if (lstMessage.Contains("A"))
                            {
                                form1.robot_1.Start_Flag = false;

                                form1.robot_1.Path_Clear();
                                form1.Stack_Box[form1.robot_1.Dst_NUM]++;
                                form1.Set_Stack_Box(form1.robot_1.Dst_NUM);
                                //label 바꾸기
                                if (form1.Stack_Box[form1.robot_1.Dst_NUM]>=2)
                                {
                                    form1.Reset_Stack_Box(form1.robot_1.Dst_NUM);
                                    form1.Set_Stack_Box(form1.robot_1.Dst_NUM);
                                    //label 바꾸기
                                }

                                form1.robot_1.Dst_Clear();
                                form1.robot_1.Dir = (int)ENUM.dir.BACK;
                                form1.robot_1.start = form1.robot_1.cur;
                                form1.robot_1.dst = (1, 0);
                                form1.pathFinder.FindShortestPath(form1.robot_1, form1.robot_2);
                                form1.Check_Able_Move(form1.robot_1);
                                form1.robot_1.Draw_Flag = false;
                                form1.Draw_initRail2();
                                form1.Draw_Path_1();
                                if (/*form1.robot_2.State == (int)ENUM.state.ACTIVE && */form1.robot_2.Draw_Flag == false) form1.Draw_Path_2();

                                if (form1.robot_1.Wait_Flag && form1.robot_1.Draw_Collision_Flag)
                                {
                                    form1.Draw_initRail4();
                                    Rectangle robot = new Rectangle((60 * form1.robot_1.colli_pos.Item2 + 60 / 4)-5, (60 * form1.robot_1.colli_pos.Item1 + 60 / 4)-5, 28, 28);
                                    form1.Collision_box(robot);
                                    form1.robot_1.Draw_Collision_Flag = false;
                                }
                            }
                            else if (lstMessage.Contains("B"))
                            {
                                form1.robot_2.Start_Flag = false;
                                form1.robot_2.Path_Clear();

                                form1.Stack_Box[form1.robot_2.Dst_NUM]++;
                                form1.Set_Stack_Box(form1.robot_2.Dst_NUM);
                                //label 바꾸기
                                if (form1.Stack_Box[form1.robot_2.Dst_NUM] >= 2)
                                {
                                    form1.Reset_Stack_Box(form1.robot_2.Dst_NUM);
                                    form1.Set_Stack_Box(form1.robot_2.Dst_NUM);
                                    //label 바꾸기
                                }

                                form1.robot_2.Dst_Clear();
                                form1.robot_2.Dir = (int)ENUM.dir.BACK;
                                form1.robot_2.start = form1.robot_2.cur;
                                form1.robot_2.dst = (3, 0);
                                form1.pathFinder.FindShortestPath(form1.robot_2, form1.robot_1);
                                form1.Check_Able_Move(form1.robot_2);
                                form1.robot_2.Draw_Flag = false;
                                form1.Draw_initRail3();
                                form1.Draw_Path_2();
                                if (/*form1.robot_1.State == (int)ENUM.state.ACTIVE &&*/ form1.robot_1.Draw_Flag == false) form1.Draw_Path_1();
    

                                if (form1.robot_2.Wait_Flag && form1.robot_2.Draw_Collision_Flag)
                                {
                                    form1.Draw_initRail4();
                                    Rectangle robot = new Rectangle((60 * form1.robot_2.colli_pos.Item2 + 60 / 4)-5, (60 * form1.robot_2.colli_pos.Item1 + 60 / 4)-5, 28, 28);
                                    form1.Collision_box(robot);
                                    form1.robot_2.Draw_Collision_Flag = false;
                                }
                            }
                        }

                        else if (lstMessage.Contains("S_T"))    // STM 이 서보모터 회전 함 
                        {
                            if( lstMessage.Contains("C"))
                            {
                                if(lstMessage.Contains("|1"))
                                {
                                    PathFiner.Set_Rotary("|1", "C");
                                }
                                else if( lstMessage.Contains("|2"))
                                {
                                    PathFiner.Set_Rotary("|2", "C");
                                }
                                else if (lstMessage.Contains("|3"))
                                {
                                    PathFiner.Set_Rotary("|3", "C");
                                }
                                else if (lstMessage.Contains("|4"))
                                {
                                    PathFiner.Set_Rotary("|4", "C");

                                }
                            }
                            else if( lstMessage.Contains("L"))
                            {
                                if (lstMessage.Contains("|1"))
                                {
                                    PathFiner.Set_Rotary("|1", "L");
                                }
                                else if (lstMessage.Contains("|2"))
                                {
                                    PathFiner.Set_Rotary("|2", "L");
                                }
                                else if (lstMessage.Contains("|3"))
                                {
                                    PathFiner.Set_Rotary("|3", "L");
                                }
                                else if (lstMessage.Contains("|4"))
                                {
                                    PathFiner.Set_Rotary("|4", "L");
                                }
                            }
                            else if ( lstMessage.Contains("R"))
                            {
                                if (lstMessage.Contains("|1"))
                                {
                                    PathFiner.Set_Rotary("|1", "R");
                                }
                                else if (lstMessage.Contains("|2"))
                                {
                                    PathFiner.Set_Rotary("|2", "R");
                                }
                                else if (lstMessage.Contains("|3"))
                                {
                                    PathFiner.Set_Rotary("|3", "R");
                                }
                                else if (lstMessage.Contains("|4"))
                                {
                                    PathFiner.Set_Rotary("|4", "R");
                                }
                            }
                            if (lstMessage.Contains("A"))
                            {
                                form1.Check_Able_Move(form1.robot_1);
                            }
                            else if (lstMessage.Contains("B"))
                            {
                                form1.Check_Able_Move(form1.robot_2);
                            }

                            form1.Draw_initRail();
                            form1.Move_Robot(form1.robot_1.cur, form1.robot_1.Id);
                            form1.Move_Robot(form1.robot_2.cur, form1.robot_2.Id);
                        }

                        Set_State(form1.robot_1);
                        Set_State(form1.robot_2);

                    }

                }
            }
            catch (SocketException ex)
            {

                MessageBox.Show("채팅 오류 : " + ex.ToString());
                //  break;
                // 클라이언트 연결이 끊어졌을 때의 예외 처리
                if (ex.SocketErrorCode == SocketError.ConnectionReset)
                {

                    MessageBox.Show("Client disconnected.");
                    socketClient.Shutdown(SocketShutdown.Both);
                    socketClient.Close();
                    form1.listener.Stop();
                }
                else
                {
                    //
                    MessageBox.Show("SocketException: " + ex.Message);
                    socketClient.Shutdown(SocketShutdown.Both);
                    socketClient.Close();
                    form1.listener.Stop();
                }
            }


            finally
            {
                socketClient.Shutdown(SocketShutdown.Both);
                socketClient.Close();
                form1.listener.Stop();

                MessageBox.Show("송수신 이상"); 
            }


        }

        public void Set_State(Robot r)
        {
            if(r.Id=='A')
            {
                if (form1.tb_State_A.InvokeRequired)
                {
                    form1.tb_State_A.Invoke(new Action(() =>
                    {
                        switch (r.State)
                        {
                            case 0:
                                form1.tb_State_A.Text = "NON";
                                break;
                            case 1:
                                form1.tb_State_A.Text = "ACTIVE";
                                break;
                            case 2:
                                form1.tb_State_A.Text = "BLOCKED";
                                break;
                            case 3:
                                form1.tb_State_A.Text = "WORKING";
                                break;
                        }
                    }));
                }
                else
                {
                    switch (r.State)
                    {
                        case 0:
                            form1.tb_State_A.Text = "NON";
                            break;
                        case 1:
                            form1.tb_State_A.Text = "ACTIVE";
                            break;
                        case 2:
                            form1.tb_State_A.Text = "BLOCKED";

                            break;
                        case 3:
                            form1.tb_State_A.Text = "WORKING";
                            break;
                    }
                }
            }

            else
            {
                if (form1.tb_State_B.InvokeRequired)
                {
                    form1.tb_State_B.Invoke(new Action(() =>
                    {
                        switch (r.State)
                        {
                            case 0:
                                form1.tb_State_B.Text = "NON";
                                break;
                            case 1:
                                form1.tb_State_B.Text = "ACTIVE";
                                break;
                            case 2:
                                form1.tb_State_B.Text = "BLOCKED";

                                break;
                            case 3:
                                form1.tb_State_B.Text = "WORKING";
                                break;
                        }
                    }));
                }
                else
                {
                    switch (r.State)
                    {
                        case 0:
                            form1.tb_State_B.Text = "NON";
                            break;
                        case 1:
                            form1.tb_State_B.Text = "ACTIVE";
                            break;
                        case 2:
                            form1.tb_State_B.Text = "BLOCKED";

                            break;
                        case 3:
                            form1.tb_State_B.Text = "WORKING";
                            break;
                    }
                }
            }

        }


        public bool ContainsNumbers(string value)
        {

            for (int i = 1; i <= 9; i++)
            {
                if (value.Contains(i.ToString()))
                    return true;
            }

            return false;
        }

        public bool ContainsOnlyNumbers(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public void SendMessageToClients(string message, int id)
        {
            byte[]? messageBytes = null;


            if (id == 0) // 영상처리
            {
                messageBytes = Encoding.UTF8.GetBytes(message);
            }

            else if (id == 1) // 로봇
            {
                messageBytes = Encoding.UTF8.GetBytes(message);
            }

            else if (id == 2) // 로봇
            {
                messageBytes = Encoding.UTF8.GetBytes(message);

            }
            else if (id == 3) // stm
            {
                message += '\0';
                messageBytes = Encoding.UTF8.GetBytes(message);

            }
            if (messageBytes != null)
                _ = socketClient.Send(messageBytes);
        }
    }
}
