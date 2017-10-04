using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda
{
    /// <summary>
    /// Interação lógica para ExpenseReportPage.xam
    /// </summary>
    public partial class Adicionar : Page
    {
        String connectionString = @"SERVER = .\;Database=bdCadastro;Trusted_Connection=True;";


        public Adicionar()
        {
            InitializeComponent();

        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            txtNomeContato.IsEnabled = true;
            txtCelular.IsEnabled = true;
            txtEmpresa.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtResidencial.IsEnabled = true;
            txtId.IsEnabled = true;
        }

        private void Button_Save(Object sender, EventArgs e)
        {



           
            
            string sql = "INSERT INTO tbCONTATOS (NOME, CELULAR, EMPRESA, EMAIL, RESIDENCIAL) VALUES ('"+ txtNomeContato.Text +"' , '" + txtCelular.Text + "', '" + txtEmpresa.Text + "', '" + txtEmail.Text + "', '" + txtResidencial.Text + "')";

            SqlConnection con = new SqlConnection(connectionString);
            System.Data.SqlClient.SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
        
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Adicionado");

                AgendaHome agenda = new AgendaHome();
                this.NavigationService.Navigate(agenda);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            
            }
            finally
            {
                con.Close();
            }

              
            
        }

    
        private void Button_Voltar(Object sender, EventArgs e)
        {

            AgendaHome agenda = new AgendaHome();
            this.NavigationService.Navigate(agenda);
        }


       

    }




}
