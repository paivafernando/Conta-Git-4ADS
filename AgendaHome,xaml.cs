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
    /// Interação lógica para AgendaHome.xam
    /// </summary>
    /// 

    public partial class AgendaHome : Page
    {


        string connectionString = @"SERVER = .\;Database=bdCadastro;Trusted_Connection=True;";
       

        public AgendaHome()
        {
            InitializeComponent();
            CarregaListBox();
        
        }

        
        private void CarregaListBox()
        {
            string sql = "SELECT ID, NOME ID FROM tbCONTATOS ORDER BY NOME";
            

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();

            try
            {

               
                
                while (reader.Read())
                {

                      
                    this.listaDeContatos.Items.Add(string.Format("{0}-{1}",reader[0].ToString().PadLeft(5,'0'),reader[1]));
                }             
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {    
                //fecha conexão 
                con.Close();
            }

        }
    
        private void Button_View(object sender, EventArgs e)
    {

            var idSelecionado = this.listaDeContatos.SelectedItem.ToString().Split('-');

            ContatosSalvos contatosSalvos = new ContatosSalvos(idSelecionado[0]);
                
                this.NavigationService.Navigate(contatosSalvos);
            

    }

        private void Button_Add(object sender, EventArgs e)
    {

        Adicionar add = new Adicionar();
        this.NavigationService.Navigate(add);
    }

        private void listaDeContatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

