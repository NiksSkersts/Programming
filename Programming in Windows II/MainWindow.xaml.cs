using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace wpf_db_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string cs =
            "Host=172.26.61.162;Database=llu;Username=postgres;Password=students;Persist Security Info=True";

        private static DataTable set = new();
        private static NpgsqlConnection con = new NpgsqlConnection(cs);
        private static NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private static void Init()
        {
            set.Clear();
            set.TableName = "masina";
            con.Open();
            var read = new NpgsqlCommand("select id,name,weight,seat,marka,model from masina ORDER BY id", con);
            dataAdapter.SelectCommand = read;
            dataAdapter.Fill(set);
            con.Close();
        }

        private static void Sync()
        {
            con.Open();
            a();
            u();
            d();
            dataAdapter.Update(set);
            con.Close();

            void a()
            {
                dataAdapter.InsertCommand =
                    new NpgsqlCommand(
                        "INSERT INTO masina(id,name,weight,seat,marka,model) VALUES(@id,@name,@weight,@seat,@marka,@model)",
                        con);
                dataAdapter.InsertCommand.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
                dataAdapter.InsertCommand.Parameters.Add("@weight", NpgsqlTypes.NpgsqlDbType.Integer, 255, "weight");
                dataAdapter.InsertCommand.Parameters.Add("@seat", NpgsqlTypes.NpgsqlDbType.Integer, 255, "seat");
                dataAdapter.InsertCommand.Parameters.Add("@model", NpgsqlTypes.NpgsqlDbType.Integer, 255, "model");
                dataAdapter.InsertCommand.Parameters.Add("@marka", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "marka");
                NpgsqlParameter param =
                    dataAdapter.InsertCommand.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id");
                param.SourceVersion = DataRowVersion.Original;
            }

            void u()
            {
                dataAdapter.UpdateCommand =
                    new NpgsqlCommand(
                        "Update masina SET name=@name,weight=@weight,seat=@seat,marka=@marka,model=@model where id = @id",
                        con);
                dataAdapter.UpdateCommand.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
                dataAdapter.UpdateCommand.Parameters.Add("@weight", NpgsqlTypes.NpgsqlDbType.Integer, 255, "weight");
                dataAdapter.UpdateCommand.Parameters.Add("@seat", NpgsqlTypes.NpgsqlDbType.Integer, 255, "seat");
                dataAdapter.UpdateCommand.Parameters.Add("@model", NpgsqlTypes.NpgsqlDbType.Integer, 255, "model");
                dataAdapter.UpdateCommand.Parameters.Add("@marka", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "marka");
                NpgsqlParameter param =
                    dataAdapter.UpdateCommand.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id");
                param.SourceVersion = DataRowVersion.Original;
            }

            void d()
            {
                dataAdapter.DeleteCommand = new NpgsqlCommand("Delete from masina where id = @id", con);
                NpgsqlParameter param =
                    dataAdapter.DeleteCommand.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id");
                param.SourceVersion = DataRowVersion.Original;
            }
        }

        private void DataGridView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dataAdapter.Fill(set);
        }
    }
}