using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Text.Json;
using static Ceiling_TransterROBOT_System_GUI.ENUM;
using System.Drawing;
using System.Security.Policy;

namespace Ceiling_TransterROBOT_System_GUI
{
    public partial class Form1 : Form
    {

        public TcpListener listener = new TcpListener(IPAddress.Parse("192.168.0.162"), 5011);
        public List<ClientInfo> clients_list = new List<ClientInfo>();
        public List<ClientHandler> ClientHandle_list = new List<ClientHandler>();
        int Client_ID_Num = 0;
        delegate void SetTextDelegate(string s);
        public Thread ExecuteThread;
        string str_id = "";

        public Robot robot_1, robot_2;
        public PathFiner pathFinder;
        public int[] Stack_Box = new int[6];

        public Form1()
        {
            InitializeComponent();

            robot_1 = new Robot('A', 0, 0, (int)ENUM.state.NON);
            robot_2 = new Robot('B', 1, 0, (int)ENUM.state.NON);
            pathFinder = new PathFiner(robot_1, robot_2);
            Draw_initRail();

            for (int i = 0; i < 6; i++)
            {
                Stack_Box[i] = 0;
            }
        }



        public void Draw_initRail()
        {
            draw_init_stage();
            draw_init_intersection_rail();
            draw_init_normal_rail();
        }

        public void Draw_Path_1()
        {
            object graphicsLock = new object();

            if (panel4.InvokeRequired)
            {
                panel4.Invoke(new Action(Draw_Path_1));
            }

            else
            {
                lock (graphicsLock)
                {
                    using (Graphics g2 = panel4.CreateGraphics())
                    {

                        using (Pen pen = new Pen(Color.Blue, 3))
                        {

                            bool flag_1 = false;
                            if (robot_1.Draw_Flag == false)
                            {
                                Move_Robot_Path(robot_1.cur, robot_1.Id);
                                //pen = new Pen(Color.Blue, 3);

                                if (robot_1.path.Count != 0) g2.DrawLine(pen, robot_1.cur.Item2 * 60 + 60 / 2, robot_1.cur.Item1 * 60 + 60 / 2, robot_1.path[0].pos.Item2 * 60 + 60 / 2, robot_1.path[0].pos.Item1 * 60 + 60 / 2);
                                for (int i = 0; i < robot_1.path.Count(); i++)
                                {
                                    if (i + 1 < robot_1.path.Count())
                                    {
                                        g2.DrawLine(pen, robot_1.path[i].pos.Item2 * 60 + 60 / 2, robot_1.path[i].pos.Item1 * 60 + 60 / 2, robot_1.path[i + 1].pos.Item2 * 60 + 60 / 2, robot_1.path[i + 1].pos.Item1 * 60 + 60 / 2);
                                        flag_1 = true;
                                    }
                                }
                            }
                            robot_1.Draw_Flag = flag_1;
                        }

                    }
                }
            }

        }

        public void Draw_Path_2()
        {
            object graphicsLock = new object();

            if (panel_B.InvokeRequired)
            {
                panel_B.Invoke(new Action(Draw_Path_2));
            }

            else
            {
                lock (graphicsLock)
                {
                    using (Graphics g3 = panel_B.CreateGraphics())
                    {
                        using (Pen pen = new Pen(Color.Red, 3))
                        {
                            bool flag_2 = false;
                            if (robot_2.Draw_Flag == false)
                            {
                                Move_Robot_Path(robot_2.cur, robot_2.Id);
                                //pen = new Pen(Color.Red, 3);
                                if (robot_2.path.Count != 0) g3.DrawLine(pen, robot_2.cur.Item2 * 60 + 60 / 2, robot_2.cur.Item1 * 60 + 60 / 2, robot_2.path[0].pos.Item2 * 60 + 60 / 2, robot_2.path[0].pos.Item1 * 60 + 60 / 2);
                                for (int i = 0; i < robot_2.path.Count(); i++)
                                {
                                    if (i + 1 < robot_2.path.Count())
                                    {
                                        g3.DrawLine(pen, robot_2.path[i].pos.Item2 * 60 + 60 / 2, robot_2.path[i].pos.Item1 * 60 + 60 / 2, robot_2.path[i + 1].pos.Item2 * 60 + 60 / 2, robot_2.path[i + 1].pos.Item1 * 60 + 60 / 2);
                                        flag_2 = true;
                                    }
                                }
                            }
                            robot_2.Draw_Flag = flag_2;
                        }
                    }
                }
            }


        }

        public void Draw_initRail2()
        {
            object graphicsLock = new object();

            if (panel4.InvokeRequired)
            {
                panel4.Invoke(new Action(Draw_initRail2));
            }
            else
            {
                lock (graphicsLock)
                {
                    using (Graphics g2 = panel4.CreateGraphics())
                    {
                        g2.FillRectangle(Brushes.Black, panel4.ClientRectangle);

                        using (Pen pen = new Pen(Color.White, 3))
                        {
                            for (int i = 1; i < 5; i++)
                            {
                                g2.DrawLine(pen, i * (panel4.Width / 5), 0, i * (panel4.Width / 5), panel4.Height);
                                g2.DrawLine(pen, 0, i * (panel4.Width / 5), panel4.Height, i * (panel4.Width / 5));
                            }
                        }

                        draw_init_intersection_rail2();
                    }
                }
            }
        }
        public void Draw_initRail3()
        {

            object graphicsLock = new object();

            if (panel_B.InvokeRequired)
            {
                panel_B.Invoke(new Action(Draw_initRail3));
            }

            else
            {
                lock (graphicsLock)
                {
                    using (Graphics g3 = panel_B.CreateGraphics())
                    {
                        g3.FillRectangle(Brushes.Black, panel_B.ClientRectangle);

                        using (Pen pen = new Pen(Color.White, 3))
                        {
                            for (int i = 1; i < 5; i++)
                            {
                                g3.DrawLine(pen, i * (panel_B.Width / 5), 0, i * (panel_B.Width / 5), panel_B.Height);
                                g3.DrawLine(pen, 0, i * (panel_B.Width / 5), panel_B.Height, i * (panel_B.Width / 5));
                            }

                            draw_init_intersection_rail3();
                        }

                    }
                }
            }




        }

        public void Draw_initRail4()
        {

            object graphicsLock = new object();

            if (panel_collision.InvokeRequired)
            {
                panel_collision.Invoke(new Action(Draw_initRail4));
            }

            else
            {
                lock (graphicsLock)
                {
                    using (Graphics g4 = panel_collision.CreateGraphics())
                    {

                        g4.FillRectangle(Brushes.Black, panel_collision.ClientRectangle);

                        using (Pen pen = new Pen(Color.White, 3))
                        {
                            for (int i = 1; i < 5; i++)
                            {
                                g4.DrawLine(pen, i * (panel_collision.Width / 5), 0, i * (panel_collision.Width / 5), panel_collision.Height);
                                g4.DrawLine(pen, 0, i * (panel_collision.Width / 5), panel_collision.Height, i * (panel_collision.Width / 5));
                            }
                        }

                    }
                }
            }
        }

        public void Collision_box(Rectangle rect)
        {
            object graphicsLock = new object();

            if (panel_collision.InvokeRequired)
            {
                panel_collision.Invoke(new Action(() => Collision_box(rect)));
            }

            else
            {
                lock (graphicsLock)
                {
                    using (Graphics g4 = panel_collision.CreateGraphics())
                    {
                        g4.FillRectangle(Brushes.HotPink, rect);
                    }
                }
            }
        }

        private void draw_init_stage()
        {
            object graphicsLock = new object();
            if (panel2.InvokeRequired)
            {
                panel2.Invoke(new Action(draw_init_stage));
            }
            else
            {
                lock (graphicsLock)
                {
                    using (Graphics g = panel2.CreateGraphics())
                    {
                        g.FillRectangle(Brushes.Black, panel2.ClientRectangle);

                        using (Pen pen = new Pen(Color.White, 3))
                        {
                            for (int i = 1; i < 5; i++)
                            {
                                g.DrawLine(pen, i * (panel2.Width / 5), 0, i * (panel2.Width / 5), panel2.Height);
                                g.DrawLine(pen, 0, i * (panel2.Width / 5), panel2.Height, i * (panel2.Width / 5));
                            }
                        }
                    }
                }
            }
        }

        private void draw_init_intersection_rail()
        {

            if (PathFiner.Real_Move_Route_arr[1, 3] == 1)
                draw_init_rail(1, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 3]);
            else
                draw_init_rail(3, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 3]);


            if (PathFiner.Real_Move_Route_arr[3, 1] == 1)
                draw_init_rail(3, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 1]);
            else
                draw_init_rail(1, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 1]);




            draw_init_rail(1, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 1]);
            draw_init_rail(3, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 3]);
        }
        private void draw_init_intersection_rail2()
        {

            if (PathFiner.Real_Move_Route_arr[1, 3] == 1)
                draw_init_rail2(1, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 3]);
            else
                draw_init_rail2(3, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 3]);


            if (PathFiner.Real_Move_Route_arr[3, 1] == 1)
                draw_init_rail2(3, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 1]);
            else
                draw_init_rail2(1, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 1]);


            draw_init_rail2(1, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 1]);
            draw_init_rail2(3, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 3]);
        }
        private void draw_init_intersection_rail3()
        {

            if (PathFiner.Real_Move_Route_arr[1, 3] == 1)
                draw_init_rail3(1, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 3]);
            else
                draw_init_rail3(3, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 3]);


            if (PathFiner.Real_Move_Route_arr[3, 1] == 1)
                draw_init_rail3(3, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 1]);
            else
                draw_init_rail3(1, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 1]);


            draw_init_rail3(1, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 1]);
            draw_init_rail3(3, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 3]);
        }
        public void draw_init_intersection_rail4()
        {

            if (PathFiner.Real_Move_Route_arr[1, 3] == 1)
                draw_init_rail4(1, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 3]);
            else
                draw_init_rail4(3, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 3]);


            if (PathFiner.Real_Move_Route_arr[3, 1] == 1)
                draw_init_rail4(3, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 1]);
            else
                draw_init_rail4(1, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 1]);


            draw_init_rail4(1, 1, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[1, 1]);
            draw_init_rail4(3, 3, "Intersection_Vertical", 'y', PathFiner.Real_Move_Route_arr[3, 3]);
        }
        public void draw_init_rail2(int row, int col, string dir, char pen_color, int value)
        {
            Graphics g2 = panel4.CreateGraphics();
            object graphicsLock = new object();


            lock (graphicsLock)
            {
                int margin = 5;
                Pen pen;

                // 펜 색상 설정
                switch (pen_color)
                {
                    case 'y':
                        pen = new Pen(Color.Yellow, 4);
                        break;
                    case 's':
                        pen = new Pen(Color.Silver, 4);
                        break;
                    case 'b':
                        pen = new Pen(Color.Black, 4);
                        break;
                    default:
                        throw new ArgumentException("Invalid pen color");
                }

                using (pen)
                {
                    if (value != 0)
                    {
                        if (value == 2)
                        {
                            g2.DrawLine(pen, 60 * row + 60 / 4, 60 * col + margin, 60 * row + 60 / 4, 60 * col + 60 - margin);
                            g2.DrawLine(pen, 60 * row + 3 * (60 / 4), 60 * col + margin, 60 * row + 3 * (60 / 4), 60 * col + 60 - margin);
                        }
                        else if (value == 1)
                        {
                            g2.DrawLine(pen, 60 * col, 60 * row + 60 / 4, 60 * col + 60, 60 * row + 60 / 4);
                            g2.DrawLine(pen, 60 * col, 60 * row + 3 * (60 / 4), 60 * col + 60, 60 * row + 3 * (60 / 4));
                        }
                    }
                    else if (value == 0)
                    {
                        if (dir == "Normal_Vertical")
                        {
                            g2.DrawLine(pen, 60 * row + margin, 60 * col + 60 / 2, 60 * row + 60 - margin, 60 * col + 60 / 2);
                        }
                        else if (dir == "Normal_Horiz")
                        {
                            g2.DrawLine(pen, 60 * row + 60 / 2, 60 * col + margin, 60 * row + 60 / 2, 60 * col + 60 - margin);
                        }
                    }
                }
            }

        }
        public void draw_init_rail3(int row, int col, string dir, char pen_color, int value)
        {

            Graphics g3 = panel_B.CreateGraphics();
            object graphicsLock = new object();


            lock (graphicsLock)
            {

                int margin = 5;
                Pen pen = new Pen(Color.Yellow, 4); ;
                switch (pen_color)
                {
                    case 'y':
                        pen = new Pen(Color.Yellow, 4);
                        break;
                    case 's':
                        pen = new Pen(Color.Silver, 4);
                        break;
                    case 'b':
                        pen = new Pen(Color.Black, 4);
                        break;

                }
                using (pen)
                {
                    if (value != 0)
                    {
                        if (value == 2)
                        {
                            g3.DrawLine(pen, 60 * row + 60 / 4, 60 * col + margin, 60 * row + 60 / 4, 60 * col + 60 - margin);
                            g3.DrawLine(pen, 60 * row + 3 * (60 / 4), 60 * col + margin, 60 * row + 3 * (60 / 4), 60 * col + 60 - margin);

                        }

                        else if (value == 1)
                        {
                            g3.DrawLine(pen, 60 * col, 60 * row + 60 / 4, 60 * col + 60, 60 * row + 60 / 4);
                            g3.DrawLine(pen, 60 * col, 60 * row + 3 * (60 / 4), 60 * col + 60, 60 * row + 3 * (60 / 4));

                        }

                    }


                    else if (value == 0)
                    {
                        if (dir == "Normal_Vertical")
                        {
                            g3.DrawLine(pen, 60 * row + margin, 60 * col + 60 / 2, 60 * row + 60 - margin, 60 * col + 60 / 2);

                        }
                        else if (dir == "Normal_Horiz")
                        {
                            g3.DrawLine(pen, 60 * row + 60 / 2, 60 * col + margin, 60 * row + 60 / 2, 60 * col + 60 - margin);
                        }
                    }

                }

            }

        }
        public void draw_init_rail4(int row, int col, string dir, char pen_color, int value)
        {
            Graphics g4 = panel_collision.CreateGraphics();
            object graphicsLock = new object();
            lock (graphicsLock)
            {
                int margin = 5;
                Pen pen = new Pen(Color.Yellow, 4);
                switch (pen_color)
                {
                    case 'y':
                        pen = new Pen(Color.Yellow, 4);
                        break;
                    case 's':
                        pen = new Pen(Color.Silver, 4);
                        break;
                    case 'b':
                        pen = new Pen(Color.Black, 4);
                        break;

                }
                using (pen)
                {
                    if (value != 0)
                    {
                        if (value == 2)
                        {
                            g4.DrawLine(pen, 60 * row + 60 / 4, 60 * col + margin, 60 * row + 60 / 4, 60 * col + 60 - margin);
                            g4.DrawLine(pen, 60 * row + 3 * (60 / 4), 60 * col + margin, 60 * row + 3 * (60 / 4), 60 * col + 60 - margin);

                        }

                        else if (value == 1)
                        {
                            g4.DrawLine(pen, 60 * col, 60 * row + 60 / 4, 60 * col + 60, 60 * row + 60 / 4);
                            g4.DrawLine(pen, 60 * col, 60 * row + 3 * (60 / 4), 60 * col + 60, 60 * row + 3 * (60 / 4));

                        }

                    }


                    else if (value == 0)
                    {
                        if (dir == "Normal_Vertical")
                        {
                            g4.DrawLine(pen, 60 * row + margin, 60 * col + 60 / 2, 60 * row + 60 - margin, 60 * col + 60 / 2);

                        }
                        else if (dir == "Normal_Horiz")
                        {
                            g4.DrawLine(pen, 60 * row + 60 / 2, 60 * col + margin, 60 * row + 60 / 2, 60 * col + 60 - margin);
                        }
                    }
                }

            }


        }

        public void draw_init_rail(int row, int col, string dir, char pen_color, int value)
        {
            Graphics g = panel2.CreateGraphics();
            object graphicsLock = new object();
            lock (graphicsLock)
            {
                int margin = 5;
                Pen pen;

                switch (pen_color)
                {
                    case 'y':
                        pen = new Pen(Color.Yellow, 4);
                        break;
                    case 's':
                        pen = new Pen(Color.Silver, 4);
                        break;
                    case 'b':
                        pen = new Pen(Color.Black, 4);
                        break;
                    default:
                        return; // Invalid pen color, do nothing
                }

                using (pen)
                {
                    if (value != 0)
                    {
                        if (value == 2)
                        {
                            g.DrawLine(pen, 120 * row + 120 / 4, 120 * col + margin, 120 * row + 120 / 4, 120 * col + 120 - margin);
                            g.DrawLine(pen, 120 * row + 3 * (120 / 4), 120 * col + margin, 120 * row + 3 * (120 / 4), 120 * col + 120 - margin);
                        }
                        else if (value == 1)
                        {
                            g.DrawLine(pen, 120 * col, 120 * row + 120 / 4, 120 * col + 120, 120 * row + 120 / 4);
                            g.DrawLine(pen, 120 * col, 120 * row + 3 * (120 / 4), 120 * col + 120, 120 * row + 3 * (120 / 4));
                        }
                    }
                    else if (value == 0)
                    {
                        if (dir == "Normal_Vertical")
                        {
                            g.DrawLine(pen, 120 * row + margin, 120 * col + 120 / 2, 120 * row + 120 - margin, 120 * col + 120 / 2);
                        }
                        else if (dir == "Normal_Horiz")
                        {
                            g.DrawLine(pen, 120 * row + 120 / 2, 120 * col + margin, 120 * row + 120 / 2, 120 * col + 120 - margin);
                        }
                    }
                }
            }
        }

        private void draw_init_normal_rail()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (row == 0 || (row % 2 == 0))
                    {
                        if (col % 2 == 1)
                            draw_init_rail(row, col, "Normal_Vertical", 's', 0);
                    }
                    else if (row % 2 == 1)
                    {
                        if (col == 0 || (col % 2 == 0))
                            draw_init_rail(row, col, "Normal_Horiz", 's', 0);
                    }
                }
            }
        }



        public void Set_dst(Robot r, char num)
        {

            switch (num)
            {
                case '1':
                    r.dst = (0, 1);
                    r.Dst_NUM = 0;
                    break;
                case '2':
                    r.dst = (0, 3);
                    r.Dst_NUM = 1;
                    break;
                case '3':
                    r.dst = (1, 4);
                    r.Dst_NUM = 2;
                    break;
                case '4':
                    r.dst = (3, 4);
                    r.Dst_NUM = 3;
                    break;
                case '5':
                    r.dst = (4, 3);
                    r.Dst_NUM = 4;
                    break;
                case '6':
                    r.dst = (4, 1);
                    r.Dst_NUM = 5;
                    break;
            }
        }



        private void AcceptClient()
        {
            Socket? socketClient = null;
            while (true)
            {
                try
                {
                    socketClient = listener.AcceptSocket();      

                    ClientHandler clientHandler = new ClientHandler();
                    ClientHandle_list.Add(clientHandler);

                    clientHandler.ClientHandler_Setup(socketClient, this, Client_ID_Num);
                    Client_ID_Num++;


                    if (tb_Connectednum.InvokeRequired)
                    {
                        tb_Connectednum.Invoke(new Action(() =>
                        {
                            tb_Connectednum.Text = Client_ID_Num.ToString();
                        }));
                    }
                    else
                    {
                        tb_Connectednum.Text = Client_ID_Num.ToString();
                    }

                    if (Client_ID_Num == 4)
                    {
                        ClientHandle_list[0].SendMessageToClients(robot_1.Id.ToString() + "_" + "GIVE_DST", 0);
                        ClientHandle_list[0].SendMessageToClients(robot_2.Id.ToString() + "_" + "GIVE_DST", 0);
                    }

                    Thread thd_ChatProcess = new Thread(new ThreadStart(clientHandler.Operate_Process));
                    thd_ChatProcess.IsBackground = true;
                    thd_ChatProcess.Start();
                }
                catch (System.Exception)
                {
                    clients_list.Clear();
                }
            }
        }

        public void Move_Robot((int, int) pos, char id)
        {

            Rectangle robot = new Rectangle(120 * pos.Item2 + 120 / 4, 120 * pos.Item1 + 120 / 4, 60, 60);
            Graphics g = panel2.CreateGraphics();
            if (id == 'A') g.FillEllipse(Brushes.Blue, robot);
            else if (id == 'B') g.FillEllipse(Brushes.Red, robot);
        }

        public void Move_Robot_Path((int, int) pos, char id)
        {

            Rectangle robot = new Rectangle(60 * pos.Item2 + 60 / 4, 60 * pos.Item1 + 60 / 4, 30, 30);

            if (id == 'A') { Graphics g2 = panel4.CreateGraphics(); g2.FillEllipse(Brushes.Blue, robot); }
            else if (id == 'B') { Graphics g3 = panel_B.CreateGraphics(); g3.FillEllipse(Brushes.Red, robot); }
        }

        public void OP_Robot(Robot r)
        {
            if (r.Id == 'A')
            {
                if (r.Dir == (int)ENUM.dir.FRONT)
                {
                    ClientHandle_list[1].SendMessageToClients("A_R_f", 1);
                }
                else if (r.Dir == (int)ENUM.dir.BACK)
                {
                    ClientHandle_list[1].SendMessageToClients("A_R_b", 1);

                }
            }
            else if (r.Id == 'B')
            {
                if (r.Dir == (int)ENUM.dir.FRONT)
                {
                    ClientHandle_list[2].SendMessageToClients("B_R_f", 2);
                }
                else if (r.Dir == (int)ENUM.dir.BACK)
                {
                    ClientHandle_list[2].SendMessageToClients("B_R_b", 2);
                }
            }
        }



        public string search_available_goto(int st_row, int st_col, int dst_row, int dst_col)
        {
            if (st_row == dst_row && st_col != dst_col)     // 좌우 이동
            {
                if (dst_col > st_col) return "right";
                else if (dst_col < st_col) return "left";
            }
            else if (st_row != dst_row && st_col == dst_col)    // 상하 이동
            {
                if (dst_row > st_row) return "down";
                else if (dst_row < st_row) return "up";
            }
            return "";
        }

        public void Check_Able_Move(Robot r)
        {
            if (r.State == (int)ENUM.state.ACTIVE)
            {
                r.Start_Flag = true;
                if (r.path.Count >= 1)
                {

                    (int, int) cur_pos = r.cur;
                    (int, int) next_pos = r.path[0].pos;
                    string move = search_available_goto(cur_pos.Item1, cur_pos.Item2, next_pos.Item1, next_pos.Item2);
                    bool isRotary_flag = PathFiner.isRotary(r.cur);

                    if (move == "up" || move == "down")
                    {

                        if (Math.Abs(PathFiner.GetValue_Real_Move_Route_arr(cur_pos)
                                - PathFiner.GetValue_Real_Move_Route_arr(next_pos)) == 2)
                        {
                            if (next_pos.Item1 > cur_pos.Item1)
                            {
                                r.Detail_Dir = (int)ENUM.detail_dir.DOWN;
                            }
                            else if (next_pos.Item1 < cur_pos.Item1)
                            {
                                r.Detail_Dir = (int)ENUM.detail_dir.UP;
                            }
                            OP_Robot(r);
                        }
                        else
                        {
                            if (isRotary_flag == true)
                            {


                                if (r.Id == 'A')
                                {
                                    ClientHandle_list[1].SendMessageToClients("EXTI", 1);
                                }
                                else if (r.Id == 'B')
                                {
                                    ClientHandle_list[2].SendMessageToClients("EXTI", 2);
                                }


                                ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_MC" + PathFiner.Get_Rotary_ID(r.cur), 3);
                            }
                            else
                            {

                                ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_MC" + PathFiner.Get_Rotary_ID(next_pos), 3);
                            }
                        }

                    }
                    else if (move == "left" || move == "right")
                    {
                        if (Math.Abs(PathFiner.GetValue_Real_Move_Route_arr(cur_pos)
                                - PathFiner.GetValue_Real_Move_Route_arr(next_pos)) == 0)
                        {

                            if (r.path.Count >= 2)
                            {
                                string dir = search_available_goto(next_pos.Item1, next_pos.Item2, r.path[1].pos.Item1, r.path[1].pos.Item2);
                                bool go_flag = true;
                                if (dir == "up")
                                {
                                    if (r.Dir == (int)ENUM.dir.FRONT)
                                    {
                                        if (PathFiner.GetDIR_Real_Move_Route_arr(next_pos) != 'R')
                                        {
                                            go_flag = false;
                                            //우회전 
                                            ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_MR" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                        }
                                    }
                                    else if (r.Dir == (int)ENUM.dir.BACK)
                                    {
                                        if (PathFiner.GetDIR_Real_Move_Route_arr(next_pos) != 'L')
                                        {
                                            go_flag = false;
                                            //좌회전
                                            ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_ML" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                        }
                                    }
                                }
                                else if (dir == "down")
                                {
                                    if (r.Dir == (int)ENUM.dir.FRONT)
                                    {
                                        if (PathFiner.GetDIR_Real_Move_Route_arr(next_pos) != 'L')
                                        {
                                            go_flag = false;
                                            //좌회전 
                                            ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_ML" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                        }
                                    }
                                    else if (r.Dir == (int)ENUM.dir.BACK)
                                    {
                                        if (PathFiner.GetDIR_Real_Move_Route_arr(next_pos) != 'R')
                                        {
                                            go_flag = false;
                                            //우회전
                                            ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_MR" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                        }
                                    }
                                }

                                if (go_flag) OP_Robot(r);
                            }

                            else
                            {
                                OP_Robot(r);
                            }


                        }
                        else
                        {
                            if (isRotary_flag == true)   // 현재 로봇이 분기점 레일 위에 있나 ?
                            {
                                if (r.Detail_Dir == (int)ENUM.detail_dir.UP)
                                {
                                    if (move == "right")
                                    {

                                        if (r.Id == 'A')
                                        {
                                            ClientHandle_list[1].SendMessageToClients("EXTI", 1);
                                        }
                                        else if (r.Id == 'B')
                                        {
                                            ClientHandle_list[2].SendMessageToClients("EXTI", 2);
                                        }

                                        // 우회전
                                        ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_MR" + PathFiner.Get_Rotary_ID(r.cur), 3);
                                    }
                                    else if (move == "left")
                                    {

                                        if (r.Id == 'A')
                                        {
                                            ClientHandle_list[1].SendMessageToClients("EXTI", 1);
                                        }
                                        else if (r.Id == 'B')
                                        {
                                            ClientHandle_list[2].SendMessageToClients("EXTI", 2);
                                        }
                                        //좌회전
                                        ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_ML" + PathFiner.Get_Rotary_ID(r.cur), 3);

                                    }
                                }
                                else if (r.Detail_Dir == (int)ENUM.detail_dir.DOWN)
                                {
                                    if (move == "right")
                                    {

                                        if (r.Id == 'A')
                                        {
                                            ClientHandle_list[1].SendMessageToClients("EXTI", 1);
                                        }
                                        else if (r.Id == 'B')
                                        {
                                            ClientHandle_list[2].SendMessageToClients("EXTI", 2);
                                        }
                                        // 좌회전
                                        ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_ML" + PathFiner.Get_Rotary_ID(r.cur), 3);
                                    }
                                    else if (move == "left")
                                    {

                                        if (r.Id == 'A')
                                        {
                                            ClientHandle_list[1].SendMessageToClients("EXTI", 1);
                                        }
                                        else if (r.Id == 'B')
                                        {
                                            ClientHandle_list[2].SendMessageToClients("EXTI", 2);
                                        }
                                        // 우회전
                                        ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_MR" + PathFiner.Get_Rotary_ID(r.cur), 3);

                                    }
                                }

                            }
                            else                        //현재 로봇이 분기점 레일 위에 없음
                            {
                                string dir = search_available_goto(next_pos.Item1, next_pos.Item2, r.path[1].pos.Item1, r.path[1].pos.Item2);
                                if (dir == "up")
                                {
                                    if (r.Dir == (int)ENUM.dir.FRONT)
                                    {
                                        //우회전 
                                        ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_MR" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                    }
                                    else if (r.Dir == (int)ENUM.dir.BACK)
                                    {
                                        //좌회전
                                        ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_ML" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                    }
                                }
                                else if (dir == "down")
                                {
                                    if (r.Dir == (int)ENUM.dir.FRONT)
                                    {
                                        //좌회전 
                                        ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_ML" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                    }
                                    else if (r.Dir == (int)ENUM.dir.BACK)
                                    {
                                        //우회전
                                        ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_MR" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                    }
                                }
                                else
                                {
                                    ClientHandle_list[3].SendMessageToClients(r.Id.ToString() + "_" + "S_ML" + PathFiner.Get_Rotary_ID(next_pos), 3);
                                }
                            }
                        }
                    }
                }
            }

        }

        private void SERVER_OPEN(object sender, EventArgs e)
        {
            Draw_initRail();
            Draw_initRail2();
            Draw_initRail3();
            Draw_initRail4();
            Move_Robot((1, 0), 'A');
            Move_Robot((3, 0), 'B');
            if (bt_ServerOpen.Tag.ToString() == "Stop")
            {
                listener.Start();
                Thread waitTread = new Thread(new ThreadStart(AcceptClient));
                waitTread.IsBackground = true;
                waitTread.Start();

                bt_ServerOpen.Text = "Close";
                bt_ServerOpen.Tag = "Start";
            }
            else
            {
                ClientHandle_list[2].SendMessageToClients("x]", 2);
                MessageBox.Show("연결끊어짐");


                listener.Stop();
                bt_ServerOpen.Text = "Server Open";
                bt_ServerOpen.Tag = "Stop";
            }
        }

        private void bt_jog_Rotate_Click(object sender, EventArgs e)
        {
            int id = 0;
            char dir = ' ';

            if (rb_rail_1.Checked) id = 1;
            else if (rb_rail_2.Checked) id = 2;
            else if (rb_rail_3.Checked) id = 3;
            else if (rb_rail_4.Checked) id = 4;

            if (rb_rail_dir_C.Checked) dir = 'C';
            else if (rb_rail_dir_L.Checked) dir = 'L';
            else if (rb_rail_dir_R.Checked) dir = 'R';


            ClientHandle_list[3].SendMessageToClients('J' + "_" + "S_M" + dir + '|' + id.ToString(), 3);
        }

        private void bt_jog_Move_Click(object sender, EventArgs e)
        {
            char id = ' '; char dir = ' ';
            if (rb_robot_A.Checked) id = 'A';
            else if (rb_robot_B.Checked) id = 'B';

            if (rb_robot_dir_F.Checked) dir = 'F';
            else if (radioButton1.Checked) dir = 'B';
            else if (rb_robot_dir_S.Checked) dir = 'C';

            if (id == 'A') ClientHandle_list[1].SendMessageToClients("J_R_" + dir, 1);
            else if (id == 'B') ClientHandle_list[2].SendMessageToClients("J_R_" + dir, 2);
        }

        public string Get_Height_Stack_Box(char dst)
        {
            return Stack_Box[(dst - '0') - 1].ToString();
        }

        public void Reset_Stack_Box(int dst)
        {
            Stack_Box[dst] = 0;
        }

        public void Set_Stack_Box(int dst)
        {
            switch (dst)
            {
                case 0:
                    if (lb_BOX1.InvokeRequired)
                    {
                        lb_BOX1.Invoke(new Action(() =>
                        {
                            lb_BOX1.Text = Stack_Box[dst].ToString();
                        }));
                    }
                    else
                    {
                        lb_BOX1.Text = Stack_Box[dst].ToString();
                    }
                    break;

                case 1:
                    if (lb_BOX2.InvokeRequired)
                    {
                        lb_BOX2.Invoke(new Action(() =>
                        {
                            lb_BOX2.Text = Stack_Box[dst].ToString();
                        }));
                    }
                    else
                    {
                        lb_BOX2.Text = Stack_Box[dst].ToString();
                    }
                    break;

                case 2:
                    if (lb_BOX3.InvokeRequired)
                    {
                        lb_BOX3.Invoke(new Action(() =>
                        {
                            lb_BOX3.Text = Stack_Box[dst].ToString();
                        }));
                    }
                    else
                    {
                        lb_BOX3.Text = Stack_Box[dst].ToString();
                    }
                    break;


                case 3:
                    if (lb_BOX4.InvokeRequired)
                    {
                        lb_BOX4.Invoke(new Action(() =>
                        {
                            lb_BOX4.Text = Stack_Box[dst].ToString();
                        }));
                    }
                    else
                    {
                        lb_BOX4.Text = Stack_Box[dst].ToString();
                    }
                    break;



                case 4:
                    if (lb_BOX5.InvokeRequired)
                    {
                        lb_BOX5.Invoke(new Action(() =>
                        {
                            lb_BOX5.Text = Stack_Box[dst].ToString();
                        }));
                    }
                    else
                    {
                        lb_BOX5.Text = Stack_Box[dst].ToString();
                    }
                    break;



                case 5:
                    if (lb_BOX6.InvokeRequired)
                    {
                        lb_BOX6.Invoke(new Action(() =>
                        {
                            lb_BOX6.Text = Stack_Box[dst].ToString();
                        }));
                    }
                    else
                    {
                        lb_BOX6.Text = Stack_Box[dst].ToString();
                    }
                    break;
            }
        }

        private void bt_START_Click(object sender, EventArgs e)
        {
            ClientHandle_list[0].SendMessageToClients("START", 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void bt_ESTOP_Click(object sender, EventArgs e)
        {
            ClientHandle_list[1].SendMessageToClients("J_R_C", 1);
            ClientHandle_list[2].SendMessageToClients("J_R_C", 2);
        }

        private void bt_Restart_Click(object sender, EventArgs e)
        {
            ClientHandle_list[0].SendMessageToClients(robot_1.Id.ToString() + "_" + "GIVE_DST", 0);

        }

        private void bt_RV_B_Restart_Click(object sender, EventArgs e)
        {
            ClientHandle_list[0].SendMessageToClients(robot_2.Id.ToString() + "_" + "GIVE_DST", 0);
        }
    }
}