﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PandoraSharpPlayer;

namespace PandoraList
{
    public partial class LoginForm : Form
    {
        public Player player { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            player.Connect(txtUser.Text, txtPassword.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
