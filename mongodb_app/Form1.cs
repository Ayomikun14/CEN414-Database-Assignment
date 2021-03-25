using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mongodb_app
{
    public partial class Form1 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("local");
        static IMongoCollection<Unemployment_2019> collection = db.GetCollection<Unemployment_2019>("Unemployment_2019");

        public void ReadAllDocuments()
        {
            List<Unemployment_2019> list = collection.AsQueryable().ToList<Unemployment_2019>();
            DataGridView1.DataSource = list;
            Id_txt.Text = DataGridView1.Rows[0].Cells[0].Value.ToString();
            State_txt.Text = DataGridView1.Rows[0].Cells[1].Value.ToString();
            Unemployed_txt.Text = DataGridView1.Rows[0].Cells[2].Value.ToString();
            Unemployment_txt.Text = DataGridView1.Rows[0].Cells[3].Value.ToString();
        }

        public Form1()
        {

            InitializeComponent();
            ReadAllDocuments();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Id_txt.Text = DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            State_txt.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Unemployed_txt.Text = DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Unemployment_txt.Text = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void Insert_btn_Click(object sender, EventArgs e)
        {
            Unemployment_2019 U = new Unemployment_2019(State_txt.Text, Unemployed_txt.Text, Double.Parse(Unemployment_txt.Text));
            collection.InsertOne(U);
            ReadAllDocuments();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            var updateDef = Builders<Unemployment_2019>.Update.Set("state", State_txt.Text).Set("Total Unemployed", Unemployed_txt.Text).Set("unemployment_rate", Unemployment_txt.Text);
            collection.UpdateOne(U => U.Id == ObjectId.Parse(Id_txt.Text), updateDef);
            ReadAllDocuments();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(U => U.Id == ObjectId.Parse(Id_txt.Text));
            ReadAllDocuments();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
