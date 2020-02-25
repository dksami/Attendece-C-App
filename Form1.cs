using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace Matching_cs
{
    public partial class Form1 : Form
    {
        public static int id = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  this.TopMost = true;
           // this.FormBorderStyle = FormBorderStyle.None;
           // this.WindowState = FormWindowState.Maximized;
            panel4.BackColor = Color.FromArgb(81, 255, 255, 255);

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            String username = user.Text;
            String password = pw.Text;
            String url = "http://dashboards.tk/api.php/users";
            String parms = "?filter[]=password,eq,"+password+"&filter[]=username,eq,"+username;
            rest(url, parms);
            Console.WriteLine(url+parms);
        }
         void rest(String URL,String paramss) 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(paramss).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    // Parse the response body.
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(dataObjects);
                    var objects = JObject.Parse(dataObjects);
                    JObject j = (JObject)objects["users"];
                    JArray ja = (JArray)j["records"];
                    if (ja.Count > 0) {
                        JArray je = (JArray)ja[0];
                        int js = (int)je[3];
                        Global.userid = js;
                        Console.WriteLine(js);
                        this.Hide();
                        id = js;
                        Form2 frm2 = new Form2();
                        frm2.Show();
                    } else {
                        System.Windows.Forms.MessageBox.Show("NO USER FOUND ");
                    }

                }
                catch (Exception e) {
                    Console.WriteLine("Error"+e);
                }
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
      
    }
}
