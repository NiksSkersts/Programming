using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataset
{
    public partial class Form1 : Form
    {
        #region(DECLARE)

        public static string cs =
            "Host=172.26.57.229;Database=llu;Username=it19055;Password=students;Persist Security Info=True";

        public static DataSet set = new();
        private static NpgsqlConnection con = new NpgsqlConnection(cs);

        private static NpgsqlDataAdapter sync_students =
            new NpgsqlDataAdapter("select id,name,surname,sex,birthdate,id_sp from students order by id", con);

        private static NpgsqlDataAdapter sync_faculty =
            new NpgsqlDataAdapter("select id_f,name,short from faculty order by id_f", con);

        private static NpgsqlDataAdapter sync_study =
            new NpgsqlDataAdapter("select id_sp,name,id_f from study order by id_sp", con);

        private BindingSource bstudent = new BindingSource();
        private BindingSource bstudy = new BindingSource();
        private BindingSource bfaculty = new BindingSource();

        #endregion

        #region(Commands)

        private static NpgsqlCommand update_study =
            new NpgsqlCommand("update study set name=:name,id_f=:id_f where id_sp=:id_sp", con);

        private static NpgsqlCommand update_students = new NpgsqlCommand(
            "update students set name=:name,surname=:surname,sex=:sex,birthdate=:birthdate,id_sp=:id_sp where id=:id",
            con);

        private static NpgsqlCommand update_faculty =
            new NpgsqlCommand("update faculty set name=:name,short=:short where id_f=:id_f", con);

        private static NpgsqlCommand delete_study = new NpgsqlCommand("delete from study where id_sp=:id_sp", con);
        private static NpgsqlCommand delete_faculty = new NpgsqlCommand("delete from faculty where id_f=:id_f", con);
        private static NpgsqlCommand delete_students = new NpgsqlCommand("delete from students where id=:id", con);

        private static NpgsqlCommand insert_study =
            new NpgsqlCommand("insert into study(id_sp,name,id_f) values(:id_sp,:name,:id_f)", con);

        private static NpgsqlCommand insert_faculty =
            new NpgsqlCommand("insert into faculty(id_f,name,short) values(:id_f,:name,:short)", con);

        private static NpgsqlCommand insert_students = new NpgsqlCommand(
            "insert into students(id,name,surname,sex,birthdate,id_sp) values (:id,:name,:surname,:sex,:birthdate,:id_sp)",
            con);

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void GetTS_Click(object sender, EventArgs e)
        {
            try
            {
                Sub_Clear();
                Sub_Init_DB();
                Sub_Init_DS_RL();
                Sub_Init_DGV();
            }
            catch (Exception)
            {
                throw;
            }

            void Sub_Clear()
            {
                set.Clear();
                set.Reset();
            }

            void Sub_Init_DB()
            {
                set.DataSetName = "llu";
                con.Open();
                set.Tables.Add("faculty");
                set.Tables.Add("students");
                set.Tables.Add("study");
                sync_faculty.Fill(set, "faculty");
                sync_study.Fill(set, "study");
                sync_students.Fill(set, "students");
                con.Close();
            }

            void Sub_Init_DS_RL()
            {
                faculty.AutoGenerateColumns = false;
                study.AutoGenerateColumns = false;
                full.AutoGenerateColumns = false;
                bstudent.DataSource = set.Tables["students"];
                bstudy.DataSource = set.Tables["study"];
                bfaculty.DataSource = set.Tables["faculty"];
                set.Relations.Add(new DataRelation("rel_sp_stu", set.Tables["study"].Columns["id_sp"],
                    set.Tables["students"].Columns["id_sp"], true));
                set.Relations.Add(new DataRelation("rel_stu_f", set.Tables["faculty"].Columns["id_f"],
                    set.Tables["study"].Columns["id_f"], true));
                set.Tables["study"].Columns["id_sp"].AutoIncrement = true;
                set.Tables["study"].Columns["id_sp"].AutoIncrementStep = 1;
                set.Tables["study"].Columns["id_sp"].AutoIncrementSeed = set.Tables["study"].Rows.Count + 1;
                set.Tables["faculty"].Columns["id_f"].AutoIncrement = true;
                set.Tables["faculty"].Columns["id_f"].AutoIncrementStep = 1;
                set.Tables["faculty"].Columns["id_f"].AutoIncrementSeed = set.Tables["faculty"].Rows.Count + 1;
                set.Tables["students"].Columns["id"].AutoIncrement = true;
                set.Tables["students"].Columns["id"].AutoIncrementStep = 1;
                set.Tables["students"].Columns["id"].AutoIncrementSeed = set.Tables["students"].Rows.Count + 1;
            }

            void Sub_Init_DGV()
            {
                study.DataSource = bstudy;
                faculty.DataSource = bfaculty;

                full.AutoGenerateColumns = false;
                full.DataSource = bstudent;
                Col_SP.DataSource = bstudy;
                Col_SP.DisplayMember = "name";
                Col_SP.ValueMember = "id_sp";
                Col_SP_F.DataPropertyName = "id_f";
                Col_SP_F.DataSource = bfaculty;
                Col_SP_F.DisplayMember = "name";
                Col_SP_F.ValueMember = "id_f";
            }
        }

        private void SetTS_Click(object sender, EventArgs e)
        {
            con.Open();
            commands();
            insert();
            update();
            delete();
            sync_faculty.Update(set, "faculty");
            sync_study.Update(set, "study");
            sync_students.Update(set, "students");
            con.Close();
            GetTS_Click(sender, e);

            void commands()
            {
                sync_faculty.InsertCommand = insert_faculty;
                sync_students.InsertCommand = insert_students;
                sync_study.InsertCommand = insert_study;

                sync_faculty.UpdateCommand = update_faculty;
                sync_students.UpdateCommand = update_students;
                sync_study.UpdateCommand = update_study;

                sync_faculty.DeleteCommand = delete_faculty;
                sync_students.DeleteCommand = delete_students;
                sync_study.DeleteCommand = delete_study;
            }

            void insert()
            {
                sync_faculty.InsertCommand.Parameters.Add(":id_f", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_f");
                sync_faculty.InsertCommand.Parameters.Add(":name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
                sync_faculty.InsertCommand.Parameters.Add(":short", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "short");
                sync_study.InsertCommand.Parameters.Add(":id_sp", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_sp");
                sync_study.InsertCommand.Parameters.Add(":name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
                sync_study.InsertCommand.Parameters.Add(":id_f", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_f");
                sync_students.InsertCommand.Parameters.Add(":name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
                sync_students.InsertCommand.Parameters.Add(":surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255,
                    "surname");
                sync_students.InsertCommand.Parameters.Add(":sex", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "sex");
                sync_students.InsertCommand.Parameters.Add(":birthdate", NpgsqlTypes.NpgsqlDbType.Timestamp, 255,
                    "birthdate");
                sync_students.InsertCommand.Parameters.Add(":id_sp", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_sp");
                sync_students.InsertCommand.Parameters.Add(":id", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id");
            }

            void update()
            {
                sync_faculty.UpdateCommand.Parameters.Add(":name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
                sync_faculty.UpdateCommand.Parameters.Add(":short", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "short");
                NpgsqlParameter param1 =
                    sync_faculty.UpdateCommand.Parameters.Add(":id_f", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_f");
                param1.SourceVersion = DataRowVersion.Original;
                sync_study.UpdateCommand.Parameters.Add(":name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
                sync_study.UpdateCommand.Parameters.Add(":id_f", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_f");
                NpgsqlParameter param2 =
                    sync_study.UpdateCommand.Parameters.Add(":id_sp", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_sp");
                param2.SourceVersion = DataRowVersion.Original;
                sync_students.UpdateCommand.Parameters.Add(":name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
                sync_students.UpdateCommand.Parameters.Add(":surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255,
                    "surname");
                sync_students.UpdateCommand.Parameters.Add(":sex", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "sex");
                sync_students.UpdateCommand.Parameters.Add(":birthdate", NpgsqlTypes.NpgsqlDbType.Timestamp, 255,
                    "birthdate");
                sync_students.UpdateCommand.Parameters.Add(":id_sp", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_sp");
                NpgsqlParameter param3 =
                    sync_students.UpdateCommand.Parameters.Add(":id", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id");
                param3.SourceVersion = DataRowVersion.Original;
            }

            void delete()
            {
                NpgsqlParameter param1 =
                    sync_faculty.DeleteCommand.Parameters.Add(":id_f", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_f");
                NpgsqlParameter param2 =
                    sync_study.DeleteCommand.Parameters.Add(":id_sp", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id_sp");
                NpgsqlParameter param3 =
                    sync_students.DeleteCommand.Parameters.Add(":id", NpgsqlTypes.NpgsqlDbType.Integer, 255, "id");
                param1.SourceVersion = DataRowVersion.Original;
                param2.SourceVersion = DataRowVersion.Original;
                param3.SourceVersion = DataRowVersion.Original;
            }
        }

        private void full_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;
            SetTS_Click(sender, e);

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var builder = "Students: " + senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString() + " " +
                              senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                MessageBox.Show(builder);
            }
        }
    }
}