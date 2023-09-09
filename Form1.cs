using System.Data;

namespace NoteTakingApp
{
    public partial class Form1 : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");
            previousNotes.DataSource = notes;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not a valid note");
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            noteBox.Text = "";
            editing = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtTitle.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && noteBox.Text != "")
            {
                if (editing)
                {
                    notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = txtTitle.Text;
                    notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = noteBox.Text;
                }
                else
                {
                    notes.Rows.Add(txtTitle.Text, noteBox.Text);
                }
            }
            
            txtTitle.Text = "";
            noteBox.Text = "";
            editing = false;

        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTitle.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}