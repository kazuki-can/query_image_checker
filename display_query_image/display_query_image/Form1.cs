using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace display_query_image
{
    public partial class Form1 : Form
    {
        public string root_path;
        public List<List<string>> query_image_list = new List<List<string>>();
        public Form1()
        {
            InitializeComponent();
        }

        private void query_num_label_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
 
        private void set_root(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                
                dialog.SelectedPath = @"C:/Users/orixs";
                dialog.Description = "クエリのルートフォルダー指定";

                dialog.ShowNewFolderButton = true;

                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.root_path = dialog.SelectedPath;
                    MessageBox.Show(string.Format("{0} is selected.", this.root_path));
                }
                else{}
            }
            string[] person_dirs = Directory.GetDirectories(this.root_path);
            for(int i = 0; i < person_dirs.Length; i++)
            {
                string[] tracking_dirs = Directory.GetDirectories(person_dirs[i]);
                this.query_image_list.Add(new List<string>());
                foreach (string tracking_dir in tracking_dirs)
                {
                    string[] query_image_paths = Directory.GetFiles(tracking_dir, "*.png");
                    foreach(string query_image_path in query_image_paths)
                    {
                        this.query_image_list[i].Add(query_image_path);
                    }
                }
                
            }
        }

        private void display_selected_query(object sender, EventArgs e)
        {
            int selected_id = Int32.Parse(person_id.Text);
            int selected_q_num = Int32.Parse(query_num.Text);
            if (12 < selected_id)
            {
                MessageBox.Show("The selected person is not registerd");
                return;
            }
            if(this.query_image_list[selected_id].Count < selected_q_num)
            {
                MessageBox.Show(string.Format("The query number is not valid. It must be less than {0}.", this.query_image_list[selected_id].Count));
                return;
            }
            selected_query.SizeMode = PictureBoxSizeMode.StretchImage;
            selected_query.ImageLocation = this.query_image_list[selected_id][selected_q_num];
            selected_gallery.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (selected_id)
            {
                case 0:
                    selected_gallery.Image = gallery00.Image;
                    break;
                case 1:
                    selected_gallery.Image = gallery01.Image;
                    break;
                case 2:
                    selected_gallery.Image = gallery02.Image;
                    break;
                case 3:
                    selected_gallery.Image = gallery03.Image;
                    break;
                case 4:
                    selected_gallery.Image = gallery04.Image;
                    break;
                case 5:
                    selected_gallery.Image = gallery05.Image;
                    break;
                case 6:
                    selected_gallery.Image = gallery06.Image;
                    break;
                case 7:
                    selected_gallery.Image = gallery07.Image;
                    break;
                case 8:
                    selected_gallery.Image = gallery08.Image;
                    break;
                case 9:
                    selected_gallery.Image = gallery09.Image;
                    break;
                case 10:
                    selected_gallery.Image = gallery10.Image;
                    break;
                case 11:
                    selected_gallery.Image = gallery11.Image;
                    break;
                case 12:
                    selected_gallery.Image = gallery12.Image;
                    break;
            }
            selected_gallery_label.Text = string.Format("Person{0}", selected_id);
            selected_query_label.Text = string.Format("Person{0}", selected_id);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
