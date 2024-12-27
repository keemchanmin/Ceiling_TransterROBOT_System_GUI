namespace Ceiling_TransterROBOT_System_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            bt_ServerOpen = new Button();
            panel1 = new Panel();
            bt_ESTOP = new Button();
            label1 = new Label();
            tb_Connectednum = new TextBox();
            panel2 = new Panel();
            panel3 = new Panel();
            lb_BOX4 = new Label();
            lb_BOX3 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            lb_BOX2 = new Label();
            lb_BOX1 = new Label();
            label8 = new Label();
            label9 = new Label();
            label14 = new Label();
            bindingSource1 = new BindingSource(components);
            label15 = new Label();
            panel_B = new Panel();
            panel_collision = new Panel();
            groupBox1 = new GroupBox();
            tb_State_B = new TextBox();
            tb_State_A = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            bt_jog_Rotate = new Button();
            rb_rail_1 = new RadioButton();
            rb_rail_2 = new RadioButton();
            rb_rail_3 = new RadioButton();
            rb_rail_4 = new RadioButton();
            rb_rail_dir_C = new RadioButton();
            rb_rail_dir_L = new RadioButton();
            rb_rail_dir_R = new RadioButton();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            groupBox4 = new GroupBox();
            rb_robot_A = new RadioButton();
            rb_robot_B = new RadioButton();
            groupBox5 = new GroupBox();
            radioButton1 = new RadioButton();
            rb_robot_dir_S = new RadioButton();
            rb_robot_dir_F = new RadioButton();
            bt_jog_Move = new Button();
            backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            panel6 = new Panel();
            lb_BOX5 = new Label();
            lb_BOX6 = new Label();
            groupBox6 = new GroupBox();
            bt_RV_A_Restart = new Button();
            bt_RV_B_Restart = new Button();
            groupBox7 = new GroupBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            panel6.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // bt_ServerOpen
            // 
            bt_ServerOpen.FlatAppearance.BorderSize = 0;
            bt_ServerOpen.FlatStyle = FlatStyle.Flat;
            bt_ServerOpen.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_ServerOpen.ForeColor = Color.FromArgb(0, 126, 249);
            bt_ServerOpen.Location = new Point(4, 4);
            bt_ServerOpen.Margin = new Padding(4);
            bt_ServerOpen.Name = "bt_ServerOpen";
            bt_ServerOpen.Size = new Size(156, 45);
            bt_ServerOpen.TabIndex = 0;
            bt_ServerOpen.Tag = "Stop";
            bt_ServerOpen.Text = "OPEN_SERVER";
            bt_ServerOpen.UseVisualStyleBackColor = true;
            bt_ServerOpen.Click += SERVER_OPEN;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(bt_ESTOP);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tb_Connectednum);
            panel1.Controls.Add(bt_ServerOpen);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 53);
            panel1.TabIndex = 1;
            // 
            // bt_ESTOP
            // 
            bt_ESTOP.BackColor = Color.FromArgb(240, 30, 55);
            bt_ESTOP.FlatStyle = FlatStyle.Flat;
            bt_ESTOP.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_ESTOP.ForeColor = Color.Snow;
            bt_ESTOP.Location = new Point(167, 0);
            bt_ESTOP.Margin = new Padding(4);
            bt_ESTOP.Name = "bt_ESTOP";
            bt_ESTOP.Size = new Size(314, 53);
            bt_ESTOP.TabIndex = 15;
            bt_ESTOP.Text = "EMERGENCY STOP";
            bt_ESTOP.UseVisualStyleBackColor = false;
            bt_ESTOP.Click += bt_ESTOP_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Nirmala UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(1680, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(136, 46);
            label1.TabIndex = 14;
            label1.Text = "Clients :";
            // 
            // tb_Connectednum
            // 
            tb_Connectednum.BackColor = Color.FromArgb(24, 30, 54);
            tb_Connectednum.Dock = DockStyle.Right;
            tb_Connectednum.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            tb_Connectednum.ForeColor = Color.WhiteSmoke;
            tb_Connectednum.Location = new Point(1816, 0);
            tb_Connectednum.Margin = new Padding(4);
            tb_Connectednum.Name = "tb_Connectednum";
            tb_Connectednum.ReadOnly = true;
            tb_Connectednum.Size = new Size(108, 42);
            tb_Connectednum.TabIndex = 13;
            tb_Connectednum.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(258, 297);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(771, 800);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(46, 70, 100);
            panel3.Controls.Add(lb_BOX4);
            panel3.Controls.Add(lb_BOX3);
            panel3.Location = new Point(1053, 304);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(107, 793);
            panel3.TabIndex = 5;
            // 
            // lb_BOX4
            // 
            lb_BOX4.AutoSize = true;
            lb_BOX4.Font = new Font("Nirmala UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lb_BOX4.ForeColor = SystemColors.Control;
            lb_BOX4.Location = new Point(4, 493);
            lb_BOX4.Margin = new Padding(4, 0, 4, 0);
            lb_BOX4.Name = "lb_BOX4";
            lb_BOX4.Size = new Size(91, 106);
            lb_BOX4.TabIndex = 4;
            lb_BOX4.Text = "0";
            // 
            // lb_BOX3
            // 
            lb_BOX3.AutoSize = true;
            lb_BOX3.Font = new Font("Nirmala UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lb_BOX3.ForeColor = SystemColors.Control;
            lb_BOX3.Location = new Point(6, 164);
            lb_BOX3.Margin = new Padding(4, 0, 4, 0);
            lb_BOX3.Name = "lb_BOX3";
            lb_BOX3.Size = new Size(91, 106);
            lb_BOX3.TabIndex = 4;
            lb_BOX3.Text = "0";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(42, 112);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(386, 400);
            panel4.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(46, 70, 100);
            panel5.Controls.Add(lb_BOX2);
            panel5.Controls.Add(lb_BOX1);
            panel5.Location = new Point(258, 164);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new Size(771, 115);
            panel5.TabIndex = 6;
            // 
            // lb_BOX2
            // 
            lb_BOX2.AutoSize = true;
            lb_BOX2.Font = new Font("Nirmala UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lb_BOX2.ForeColor = SystemColors.Control;
            lb_BOX2.Location = new Point(512, 0);
            lb_BOX2.Margin = new Padding(4, 0, 4, 0);
            lb_BOX2.Name = "lb_BOX2";
            lb_BOX2.Size = new Size(91, 106);
            lb_BOX2.TabIndex = 3;
            lb_BOX2.Text = "0";
            // 
            // lb_BOX1
            // 
            lb_BOX1.AutoSize = true;
            lb_BOX1.Font = new Font("Nirmala UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lb_BOX1.ForeColor = SystemColors.Control;
            lb_BOX1.Location = new Point(186, 0);
            lb_BOX1.Margin = new Padding(4, 0, 4, 0);
            lb_BOX1.Name = "lb_BOX1";
            lb_BOX1.Size = new Size(91, 106);
            lb_BOX1.TabIndex = 1;
            lb_BOX1.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Nirmala UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(42, 21);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(141, 81);
            label8.TabIndex = 3;
            label8.Text = "R_A";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Nirmala UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(483, 21);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(137, 81);
            label9.TabIndex = 8;
            label9.Text = "R_B";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = SystemColors.Control;
            label14.Location = new Point(138, 547);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(71, 28);
            label14.TabIndex = 17;
            label14.Text = "State :";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = SystemColors.Control;
            label15.Location = new Point(567, 549);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(71, 28);
            label15.TabIndex = 18;
            label15.Text = "State :";
            // 
            // panel_B
            // 
            panel_B.BackColor = Color.Black;
            panel_B.Location = new Point(483, 112);
            panel_B.Margin = new Padding(4);
            panel_B.Name = "panel_B";
            panel_B.Size = new Size(386, 400);
            panel_B.TabIndex = 21;
            // 
            // panel_collision
            // 
            panel_collision.BackColor = Color.Black;
            panel_collision.Location = new Point(35, 31);
            panel_collision.Margin = new Padding(4);
            panel_collision.Name = "panel_collision";
            panel_collision.Size = new Size(386, 400);
            panel_collision.TabIndex = 22;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel_collision);
            groupBox1.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ActiveBorder;
            groupBox1.Location = new Point(1254, 228);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(437, 451);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Collision";
            // 
            // tb_State_B
            // 
            tb_State_B.Location = new Point(651, 549);
            tb_State_B.Margin = new Padding(4);
            tb_State_B.Name = "tb_State_B";
            tb_State_B.Size = new Size(130, 32);
            tb_State_B.TabIndex = 20;
            // 
            // tb_State_A
            // 
            tb_State_A.Location = new Point(219, 549);
            tb_State_A.Margin = new Padding(4);
            tb_State_A.Name = "tb_State_A";
            tb_State_A.Size = new Size(125, 32);
            tb_State_A.TabIndex = 19;
            // 
            // bt_jog_Rotate
            // 
            bt_jog_Rotate.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            bt_jog_Rotate.ForeColor = SystemColors.ActiveCaptionText;
            bt_jog_Rotate.Location = new Point(1998, 503);
            bt_jog_Rotate.Margin = new Padding(4);
            bt_jog_Rotate.Name = "bt_jog_Rotate";
            bt_jog_Rotate.Size = new Size(125, 52);
            bt_jog_Rotate.TabIndex = 24;
            bt_jog_Rotate.Text = "Rotate";
            bt_jog_Rotate.UseVisualStyleBackColor = true;
            bt_jog_Rotate.Click += bt_jog_Rotate_Click;
            // 
            // rb_rail_1
            // 
            rb_rail_1.AutoSize = true;
            rb_rail_1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_rail_1.ForeColor = SystemColors.ButtonHighlight;
            rb_rail_1.Location = new Point(15, 43);
            rb_rail_1.Margin = new Padding(4);
            rb_rail_1.Name = "rb_rail_1";
            rb_rail_1.Size = new Size(51, 35);
            rb_rail_1.TabIndex = 25;
            rb_rail_1.TabStop = true;
            rb_rail_1.Text = "1";
            rb_rail_1.UseVisualStyleBackColor = true;
            // 
            // rb_rail_2
            // 
            rb_rail_2.AutoSize = true;
            rb_rail_2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_rail_2.ForeColor = SystemColors.ButtonHighlight;
            rb_rail_2.Location = new Point(15, 77);
            rb_rail_2.Margin = new Padding(4);
            rb_rail_2.Name = "rb_rail_2";
            rb_rail_2.Size = new Size(51, 35);
            rb_rail_2.TabIndex = 26;
            rb_rail_2.TabStop = true;
            rb_rail_2.Text = "2";
            rb_rail_2.UseVisualStyleBackColor = true;
            // 
            // rb_rail_3
            // 
            rb_rail_3.AutoSize = true;
            rb_rail_3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_rail_3.ForeColor = SystemColors.ButtonHighlight;
            rb_rail_3.Location = new Point(15, 112);
            rb_rail_3.Margin = new Padding(4);
            rb_rail_3.Name = "rb_rail_3";
            rb_rail_3.Size = new Size(51, 35);
            rb_rail_3.TabIndex = 27;
            rb_rail_3.TabStop = true;
            rb_rail_3.Text = "3";
            rb_rail_3.UseVisualStyleBackColor = true;
            // 
            // rb_rail_4
            // 
            rb_rail_4.AutoSize = true;
            rb_rail_4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_rail_4.ForeColor = SystemColors.ButtonHighlight;
            rb_rail_4.Location = new Point(15, 147);
            rb_rail_4.Margin = new Padding(4);
            rb_rail_4.Name = "rb_rail_4";
            rb_rail_4.Size = new Size(51, 35);
            rb_rail_4.TabIndex = 28;
            rb_rail_4.TabStop = true;
            rb_rail_4.Text = "4";
            rb_rail_4.UseVisualStyleBackColor = true;
            // 
            // rb_rail_dir_C
            // 
            rb_rail_dir_C.AutoSize = true;
            rb_rail_dir_C.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_rail_dir_C.ForeColor = SystemColors.ButtonHighlight;
            rb_rail_dir_C.Location = new Point(21, 39);
            rb_rail_dir_C.Margin = new Padding(4);
            rb_rail_dir_C.Name = "rb_rail_dir_C";
            rb_rail_dir_C.Size = new Size(56, 35);
            rb_rail_dir_C.TabIndex = 29;
            rb_rail_dir_C.TabStop = true;
            rb_rail_dir_C.Text = "C";
            rb_rail_dir_C.UseVisualStyleBackColor = true;
            // 
            // rb_rail_dir_L
            // 
            rb_rail_dir_L.AutoSize = true;
            rb_rail_dir_L.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_rail_dir_L.ForeColor = SystemColors.ButtonHighlight;
            rb_rail_dir_L.Location = new Point(21, 92);
            rb_rail_dir_L.Margin = new Padding(4);
            rb_rail_dir_L.Name = "rb_rail_dir_L";
            rb_rail_dir_L.Size = new Size(51, 35);
            rb_rail_dir_L.TabIndex = 30;
            rb_rail_dir_L.TabStop = true;
            rb_rail_dir_L.Text = "L";
            rb_rail_dir_L.UseVisualStyleBackColor = true;
            // 
            // rb_rail_dir_R
            // 
            rb_rail_dir_R.AutoSize = true;
            rb_rail_dir_R.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_rail_dir_R.ForeColor = SystemColors.ButtonHighlight;
            rb_rail_dir_R.Location = new Point(21, 147);
            rb_rail_dir_R.Margin = new Padding(4);
            rb_rail_dir_R.Name = "rb_rail_dir_R";
            rb_rail_dir_R.Size = new Size(56, 35);
            rb_rail_dir_R.TabIndex = 31;
            rb_rail_dir_R.TabStop = true;
            rb_rail_dir_R.Text = "R";
            rb_rail_dir_R.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rb_rail_4);
            groupBox2.Controls.Add(rb_rail_3);
            groupBox2.Controls.Add(rb_rail_2);
            groupBox2.Controls.Add(rb_rail_1);
            groupBox2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(1768, 424);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(82, 216);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "ID";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rb_rail_dir_C);
            groupBox3.Controls.Add(rb_rail_dir_L);
            groupBox3.Controls.Add(rb_rail_dir_R);
            groupBox3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.ForeColor = SystemColors.ButtonHighlight;
            groupBox3.Location = new Point(1876, 424);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new Size(98, 216);
            groupBox3.TabIndex = 33;
            groupBox3.TabStop = false;
            groupBox3.Text = "DIR";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rb_robot_A);
            groupBox4.Controls.Add(rb_robot_B);
            groupBox4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.ForeColor = SystemColors.ButtonHighlight;
            groupBox4.Location = new Point(1768, 259);
            groupBox4.Margin = new Padding(4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4);
            groupBox4.Size = new Size(82, 157);
            groupBox4.TabIndex = 34;
            groupBox4.TabStop = false;
            groupBox4.Text = "ID";
            // 
            // rb_robot_A
            // 
            rb_robot_A.AutoSize = true;
            rb_robot_A.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_robot_A.ForeColor = SystemColors.ButtonHighlight;
            rb_robot_A.Location = new Point(13, 49);
            rb_robot_A.Margin = new Padding(4);
            rb_robot_A.Name = "rb_robot_A";
            rb_robot_A.Size = new Size(54, 35);
            rb_robot_A.TabIndex = 32;
            rb_robot_A.TabStop = true;
            rb_robot_A.Text = "A";
            rb_robot_A.UseVisualStyleBackColor = true;
            // 
            // rb_robot_B
            // 
            rb_robot_B.AutoSize = true;
            rb_robot_B.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_robot_B.ForeColor = SystemColors.ButtonHighlight;
            rb_robot_B.Location = new Point(13, 84);
            rb_robot_B.Margin = new Padding(4);
            rb_robot_B.Name = "rb_robot_B";
            rb_robot_B.Size = new Size(54, 35);
            rb_robot_B.TabIndex = 33;
            rb_robot_B.TabStop = true;
            rb_robot_B.Text = "B";
            rb_robot_B.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(radioButton1);
            groupBox5.Controls.Add(rb_robot_dir_S);
            groupBox5.Controls.Add(rb_robot_dir_F);
            groupBox5.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox5.ForeColor = SystemColors.ButtonHighlight;
            groupBox5.Location = new Point(1876, 259);
            groupBox5.Margin = new Padding(4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(4);
            groupBox5.Size = new Size(98, 157);
            groupBox5.TabIndex = 35;
            groupBox5.TabStop = false;
            groupBox5.Text = "DIR";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.Location = new Point(21, 69);
            radioButton1.Margin = new Padding(4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(54, 35);
            radioButton1.TabIndex = 40;
            radioButton1.TabStop = true;
            radioButton1.Text = "B";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // rb_robot_dir_S
            // 
            rb_robot_dir_S.AutoSize = true;
            rb_robot_dir_S.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_robot_dir_S.ForeColor = SystemColors.ButtonHighlight;
            rb_robot_dir_S.Location = new Point(21, 104);
            rb_robot_dir_S.Margin = new Padding(4);
            rb_robot_dir_S.Name = "rb_robot_dir_S";
            rb_robot_dir_S.Size = new Size(54, 35);
            rb_robot_dir_S.TabIndex = 39;
            rb_robot_dir_S.TabStop = true;
            rb_robot_dir_S.Text = "S";
            rb_robot_dir_S.UseVisualStyleBackColor = true;
            // 
            // rb_robot_dir_F
            // 
            rb_robot_dir_F.AutoSize = true;
            rb_robot_dir_F.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rb_robot_dir_F.ForeColor = SystemColors.ButtonHighlight;
            rb_robot_dir_F.Location = new Point(21, 39);
            rb_robot_dir_F.Margin = new Padding(4);
            rb_robot_dir_F.Name = "rb_robot_dir_F";
            rb_robot_dir_F.Size = new Size(53, 35);
            rb_robot_dir_F.TabIndex = 37;
            rb_robot_dir_F.TabStop = true;
            rb_robot_dir_F.Text = "F";
            rb_robot_dir_F.UseVisualStyleBackColor = true;
            // 
            // bt_jog_Move
            // 
            bt_jog_Move.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            bt_jog_Move.ForeColor = SystemColors.ActiveCaptionText;
            bt_jog_Move.Location = new Point(1998, 323);
            bt_jog_Move.Margin = new Padding(4);
            bt_jog_Move.Name = "bt_jog_Move";
            bt_jog_Move.Size = new Size(125, 52);
            bt_jog_Move.TabIndex = 36;
            bt_jog_Move.Text = "MOVE";
            bt_jog_Move.UseVisualStyleBackColor = true;
            bt_jog_Move.Click += bt_jog_Move_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(46, 70, 100);
            panel6.Controls.Add(lb_BOX5);
            panel6.Controls.Add(lb_BOX6);
            panel6.Location = new Point(258, 1105);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new Size(771, 115);
            panel6.TabIndex = 7;
            // 
            // lb_BOX5
            // 
            lb_BOX5.AutoSize = true;
            lb_BOX5.Font = new Font("Nirmala UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lb_BOX5.ForeColor = SystemColors.Control;
            lb_BOX5.Location = new Point(512, -4);
            lb_BOX5.Margin = new Padding(4, 0, 4, 0);
            lb_BOX5.Name = "lb_BOX5";
            lb_BOX5.Size = new Size(91, 106);
            lb_BOX5.TabIndex = 3;
            lb_BOX5.Text = "0";
            // 
            // lb_BOX6
            // 
            lb_BOX6.AutoSize = true;
            lb_BOX6.Font = new Font("Nirmala UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lb_BOX6.ForeColor = SystemColors.Control;
            lb_BOX6.Location = new Point(186, 0);
            lb_BOX6.Margin = new Padding(4, 0, 4, 0);
            lb_BOX6.Name = "lb_BOX6";
            lb_BOX6.Size = new Size(91, 106);
            lb_BOX6.TabIndex = 1;
            lb_BOX6.Text = "0";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(panel_B);
            groupBox6.Controls.Add(tb_State_B);
            groupBox6.Controls.Add(tb_State_A);
            groupBox6.Controls.Add(label15);
            groupBox6.Controls.Add(label14);
            groupBox6.Controls.Add(label9);
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(panel4);
            groupBox6.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox6.ForeColor = SystemColors.ActiveBorder;
            groupBox6.Location = new Point(1254, 685);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(892, 620);
            groupBox6.TabIndex = 37;
            groupBox6.TabStop = false;
            groupBox6.Text = "Path";
            // 
            // bt_RV_A_Restart
            // 
            bt_RV_A_Restart.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            bt_RV_A_Restart.ForeColor = SystemColors.ActiveCaptionText;
            bt_RV_A_Restart.Location = new Point(1476, 164);
            bt_RV_A_Restart.Margin = new Padding(4);
            bt_RV_A_Restart.Name = "bt_RV_A_Restart";
            bt_RV_A_Restart.Size = new Size(215, 52);
            bt_RV_A_Restart.TabIndex = 38;
            bt_RV_A_Restart.Text = "A_RESTART";
            bt_RV_A_Restart.UseVisualStyleBackColor = true;
            bt_RV_A_Restart.Click += bt_Restart_Click;
            // 
            // bt_RV_B_Restart
            // 
            bt_RV_B_Restart.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            bt_RV_B_Restart.ForeColor = SystemColors.ActiveCaptionText;
            bt_RV_B_Restart.Location = new Point(1716, 164);
            bt_RV_B_Restart.Margin = new Padding(4);
            bt_RV_B_Restart.Name = "bt_RV_B_Restart";
            bt_RV_B_Restart.Size = new Size(215, 52);
            bt_RV_B_Restart.TabIndex = 39;
            bt_RV_B_Restart.Text = "B_RESTART";
            bt_RV_B_Restart.UseVisualStyleBackColor = true;
            bt_RV_B_Restart.Click += bt_RV_B_Restart_Click;
            // 
            // groupBox7
            // 
            groupBox7.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox7.ForeColor = SystemColors.ActiveBorder;
            groupBox7.Location = new Point(1716, 228);
            groupBox7.Margin = new Padding(4);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(4);
            groupBox7.Size = new Size(429, 451);
            groupBox7.TabIndex = 40;
            groupBox7.TabStop = false;
            groupBox7.Text = "Jog Motion";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1924, 1055);
            Controls.Add(bt_RV_B_Restart);
            Controls.Add(bt_RV_A_Restart);
            Controls.Add(groupBox6);
            Controls.Add(panel6);
            Controls.Add(bt_jog_Move);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(bt_jog_Rotate);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(groupBox7);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button bt_ServerOpen;
        private Panel panel1;
        private Label label1;
        private TextBox tb_Connectednum;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label lb_BOX1;
        private Panel panel8;
        private Label label8;
        private Label label9;
        private Label label14;
        private BindingSource bindingSource1;
        private Label label15;
        private Panel panel_B;
        private Panel panel_collision;
        private GroupBox groupBox1;
        public TextBox tb_State_B;
        public TextBox tb_State_A;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button bt_jog_Rotate;
        private RadioButton rb_rail_1;
        private RadioButton rb_rail_2;
        private RadioButton rb_rail_3;
        private RadioButton rb_rail_4;
        private RadioButton rb_rail_dir_C;
        private RadioButton rb_rail_dir_L;
        private RadioButton rb_rail_dir_R;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private GroupBox groupBox4;
        private RadioButton rb_robot_A;
        private RadioButton rb_robot_B;
        private GroupBox groupBox5;
        private RadioButton rb_robot_dir_F;
        private RadioButton rb_robot_dir_B;
        private Button bt_jog_Move;
        private RadioButton rb_robot_dir_S;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private RadioButton radioButton1;
        private Label lb_BOX2;
        private Label lb_BOX4;
        private Label lb_BOX3;
        private Panel panel6;
        private Label lb_BOX5;
        private Label lb_BOX6;
        private GroupBox groupBox6;
        private Button bt_ESTOP;
        private Button bt_RV_A_Restart;
        private Button bt_RV_B_Restart;
        private GroupBox groupBox7;
        // private Panel panel8;
    }
}