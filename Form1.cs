using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace IESFLIX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            LblUserName.Text = "";
            string username;
            Iesflix iesflix = new Iesflix();
            DataTable user = new DataTable();
            DataTable titles = new DataTable();
            
            user = iesflix.usuario(TxtEmail.Text, TxtPassword.Text);
            titles = iesflix.getTabla("Titles");

            if (user.Rows.Count != 0)
            {
                username = user.Rows[0]["username"].ToString();

                LblUserName.Text = username;
                iesflix.score(Convert.ToInt32(user.Rows[0]["userID"]), titles, Grilla);
                
            }
            else
            {
                MessageBox.Show("El email o la contraseña son incorrectos");
            }
        }
    }
}
