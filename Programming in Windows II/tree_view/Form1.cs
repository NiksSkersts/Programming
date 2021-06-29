using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree_view
{
    public partial class Form1 : Form
    {
        public static NpgsqlConnection con =
            new NpgsqlConnection(
                "Host=172.26.56.92;Database=llu;Username=it19055;Password=students;Persist Security Info=True");

        public static NpgsqlDataAdapter katAdapter =
            new NpgsqlDataAdapter("select id,cat_name,cat_desc,cat_id from netstore.cat", con);

        public static NpgsqlDataAdapter stockAdapter =
            new NpgsqlDataAdapter("select id,stock_name,stock_desc,cat_id from netstore.stock", con);

        public int rowIndex;
        private DataSet store = new("store");
        public int curr_node;

        public Form1()
        {
            InitializeComponent();

            #region(setupSet)

            store.Tables.Add("cat");
            store.Tables.Add("cat_two");
            store.Tables.Add("stock");
            store.Tables["cat"].Columns.Add("id", typeof(int));
            store.Tables["cat"].Columns.Add("cat_name", typeof(string));
            store.Tables["cat"].Columns.Add("cat_desc", typeof(string));
            store.Tables["cat"].Columns.Add("cat_id", typeof(int));
            store.Tables["stock"].Columns.Add("id", typeof(int));
            store.Tables["stock"].Columns.Add("stock_name", typeof(string));
            store.Tables["stock"].Columns.Add("stock_desc", typeof(string));
            store.Tables["stock"].Columns.Add("cat_id", typeof(int));
            store.Relations.Add(new DataRelation("fk_cat_stock", store.Tables["cat"].Columns["id"],
                store.Tables["stock"].Columns["cat_id"]));

            #endregion

            treeView1.LabelEdit = true;
            con.Open();
            katAdapter.Fill(store, "cat");
            stockAdapter.Fill(store, "stock");
            SubLevel(0, null);
        }

        public void SubLevel(int parentid, TreeNode parentNode)
        {
            NpgsqlCommand select_lvl =
                new NpgsqlCommand("SELECT id , cat_name as name FROM netstore.cat WHERE cat_id = :parentid", con);
            select_lvl.Parameters.Add(":parentid", NpgsqlTypes.NpgsqlDbType.Integer).Value = parentid;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(select_lvl);
            var dt = new DataTable();
            da.Fill(dt);
            if (parentid == 0)
                CreateNodes(dt, treeView1.Nodes);
            else
                CreateNodes(dt, parentNode.Nodes);
        }

        public void CreateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr1 in dt.Rows)
            {
                TreeNode tn = new TreeNode
                {
                    Text = dr1["name"].ToString(),
                    Name = dr1["id"].ToString()
                };
                nodes.Add(tn);
                SubLevel(Convert.ToInt32(tn.Name), tn);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name != "")
            {
                TreeNode tn = new TreeNode();
                tn.Text = "new";
                e.Node.Nodes.Add(tn);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var y = 0;
            if (e.Node.Name != "")
                y = Convert.ToInt32(e.Node.Name);
            dgv_select(y);
        }

        public void dgv_select(int a)
        {
            NpgsqlDataAdapter dp_adapt = new NpgsqlDataAdapter();
            store.Tables["stock"].Clear();
            NpgsqlCommand sel =
                new NpgsqlCommand("select id,stock_name,stock_desc,cat_id from netstore.stock where (cat_id=:a)", con);
            sel.Parameters.Add(":a", NpgsqlTypes.NpgsqlDbType.Integer).Value = a;
            dp_adapt.SelectCommand = sel;
            dp_adapt.Fill(store, "stock");
            con.Close();
            dataGridView1.DataSource = store.Tables["stock"];
            NpgsqlCommand select_desc =
                new NpgsqlCommand("Select id,cat_desc from netstore.cat where NOT(cat_desc IS NULL)", con);
            con.Open();
            NpgsqlDataReader datareaderapraksts = select_desc.ExecuteReader();
            var s = "";
            while (datareaderapraksts.Read())
                if (a.ToString() != "" && datareaderapraksts.GetInt32(0) == a)

                    s = datareaderapraksts.GetString(1);
            con.Close();
            label.Text = s;
            curr_node = a;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var rc = dataGridView1.Rows.Count - 1;
            if (rc > 0)
                dataGridView1.Rows[rc].Cells[3].Value = curr_node;
            else
                dataGridView1.Rows[0].Cells[3].Value = curr_node;
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
                e.Node.Text = e.Label;

            #region(Commands)

            //izveidot NpgsqlCommand comandas: select, insert, delete un update.
            NpgsqlCommand select = new NpgsqlCommand("SELECT * FROM netstore.cat", con);
            NpgsqlCommand insert =
                new NpgsqlCommand("insert into netstore.cat(id,cat_name,cat_desc,cat_id) values (:a,:b,:c,:d)", con);
            NpgsqlCommand delete = new NpgsqlCommand("delete from netstore.cat where id=:delid", con);
            NpgsqlCommand update =
                new NpgsqlCommand("update netstore.cat set id=:id,cat_name=:cn,cat_desc=:cd,cat_id=:ci where id=:id",
                    con);
            insert.Parameters.Add(":a", NpgsqlTypes.NpgsqlDbType.Integer, 256, "id");
            insert.Parameters.Add(":b", NpgsqlTypes.NpgsqlDbType.Varchar, 256, "cat_name");
            insert.Parameters.Add(":c", NpgsqlTypes.NpgsqlDbType.Varchar, 256, "cat_desc");
            insert.Parameters.Add(":d", NpgsqlTypes.NpgsqlDbType.Integer, 256, "cat_id");
            delete.Parameters.Add(":delid", NpgsqlTypes.NpgsqlDbType.Integer, 256, "id");
            update.Parameters.Add(":id", NpgsqlTypes.NpgsqlDbType.Integer, 256, "id");
            update.Parameters.Add(":cn", NpgsqlTypes.NpgsqlDbType.Varchar, 256, "cat_name");
            update.Parameters.Add(":cd", NpgsqlTypes.NpgsqlDbType.Varchar, 256, "cat_desc");
            update.Parameters.Add(":ci", NpgsqlTypes.NpgsqlDbType.Integer, 256, "cat_id");

            #endregion

            store.Tables["cat_two"].Clear();
            katAdapter.Fill(store, "cat_two");
            katAdapter.SelectCommand = select;
            katAdapter.DeleteCommand = delete;
            katAdapter.UpdateCommand = update;
            katAdapter.InsertCommand = insert;
            var i = 0;
            var t = -1;
            foreach (DataRow dr in store.Tables["cat_two"].Rows)
            {
                if (dr[0].ToString() == e.Node.Name) t = i;
                i++;
            }

            if (t != -1)
            {
                store.Tables["cat_two"].Rows[t]["cat_name"] = e.Node.Text.ToString();
                store.Tables["cat_two"].Rows[t]["cat_desc"] = textBox1.Text.ToString();
            }
            else
            {
                var dr1 = store.Tables["cat_two"].NewRow();
                dr1["ID"] = store.Tables["cat_two"].Rows.Count + 1;
                dr1["cat_name"] = e.Node.Text.ToString();
                dr1["cat_desc"] = textBox1.Text.ToString();
                dr1["cat_id"] = Convert.ToInt32(e.Node.Parent.Name);
                store.Tables["cat_two"].Rows.Add(dr1);
            }

            katAdapter.Update(store.Tables["cat_two"]);
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //set up adapt
            NpgsqlDataAdapter dp_adapt = new NpgsqlDataAdapter();
            NpgsqlCommand insert =
                new NpgsqlCommand("insert into netstore.stock(id,stock_name,stock_desc,cat_id) values (:a,:b,:c,:d)",
                    con);
            NpgsqlCommand delete = new NpgsqlCommand("delete from netstore.stock where id=:delid", con);
            NpgsqlCommand update =
                new NpgsqlCommand(
                    "update netstore.stock set id=:id,stock_name=:cn,stock_desc=:cd,cat_id=:ci where id=:id", con);
            insert.Parameters.Add(":a", NpgsqlTypes.NpgsqlDbType.Integer, 256, "id");
            insert.Parameters.Add(":b", NpgsqlTypes.NpgsqlDbType.Varchar, 256, "stock_name");
            insert.Parameters.Add(":c", NpgsqlTypes.NpgsqlDbType.Varchar, 256, "stock_desc");
            insert.Parameters.Add(":d", NpgsqlTypes.NpgsqlDbType.Integer, 256, "cat_id");
            delete.Parameters.Add(":delid", NpgsqlTypes.NpgsqlDbType.Integer, 256, "id");
            //delete.Parameters.Add(":catid", NpgsqlTypes.NpgsqlDbType.Integer, 256, "cat_id");
            update.Parameters.Add(":id", NpgsqlTypes.NpgsqlDbType.Integer, 256, "id");
            //update.Parameters.Add(":catid", NpgsqlTypes.NpgsqlDbType.Integer, 256, "cat_id");
            update.Parameters.Add(":cn", NpgsqlTypes.NpgsqlDbType.Varchar, 256, "stock_name");
            update.Parameters.Add(":cd", NpgsqlTypes.NpgsqlDbType.Varchar, 256, "stock_desc");
            update.Parameters.Add(":ci", NpgsqlTypes.NpgsqlDbType.Integer, 256, "cat_id");
            //adapter
            dp_adapt.DeleteCommand = delete;
            dp_adapt.UpdateCommand = update;
            dp_adapt.InsertCommand = insert;
            dp_adapt.Update(store.Tables["stock"]);
        }
    }
}