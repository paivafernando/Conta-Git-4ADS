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
    public partial class ContatosSalvos : Page 
    {
        String connectionString = @"SERVER = .\;Database=bdCadastro;Trusted_Connection=True;";


        public ContatosSalvos()
        {
            InitializeComponent();
        }

        public ContatosSalvos(object data):this(){
            this.DataContext= data;

            string sql = "SELECT * FROM tbCONTATOS  WHERE ID =  "+"'"+ Convert.ToInt32(data.ToString()) + "'" ;
        
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtId.Text = reader[0].ToString();
                    txtCelular.IsReadOnly = true;
                    txtNomeContato.Text = reader[1].ToString();
                    txtCelular.Text = reader[2].ToString();
                    txtEmpresa.Text = reader[3].ToString();
                    txtEmail.Text = reader[4].ToString();
                    txtResidencial.Text = reader[5].ToString();
                }
                else
                    MessageBox.Show("Nenhum registro encontrado com id informado");

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

         
        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {  
            txtNomeContato.IsEnabled = true;
            txtCelular.IsEnabled = true;
            txtEmpresa.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtResidencial.IsEnabled = true;
            txtId.IsEnabled = true;

       
        }


        private void Button_Save (Object sender, EventArgs e)
        {
            string sql = "UPDATE tbCONTATOS SET NOME = '" + txtNomeContato.Text + "', CELULAR = '" + txtCelular.Text + "', EMPRESA = '" + txtEmpresa.Text + "', EMAIL = '" + txtEmail.Text + "', RESIDENCIAL = '" + txtResidencial.Text + "' WHERE ID = '" + txtId.Text +"'";


            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
        
            con.Open();


            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Cadastro atualizado!");
                txtNomeContato.IsReadOnly = true;
                txtEmail.IsReadOnly = true;
                txtEmpresa.IsReadOnly = true;
                txtCelular.IsReadOnly = true;
                txtResidencial.IsReadOnly = true;
                



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
        
        private void Button_Edit(Object sender, EventArgs e)
        {
           
                txtNomeContato.IsReadOnly = false;
                txtEmail.IsReadOnly = false;
                txtEmpresa.IsReadOnly = false;
                txtCelular.IsReadOnly = false;
                txtResidencial.IsReadOnly = false;
            
        }

        private void Button_Delete (Object sender, EventArgs e)
        {

            

            string sql = "DELETE FROM tbCONTATOS WHERE ID = " + "'" + txtId.Text + "'";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
         
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Excluído");

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
