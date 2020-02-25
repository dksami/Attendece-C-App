using Newtonsoft.Json.Linq;
using SecuGen.FDxSDKPro.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Web.Script.Serialization;


namespace Matching_cs
{
    public partial class Form2 : Form
    {
        List<int> list = new List<int>();
        private SGFingerPrintManager m_FPM;
        private bool m_LedOn = false;
        private Int32 m_ImageWidth;
        private Int32 m_ImageHeight;
        private Byte[] m_RegMin1;
        private Byte[] m_RegMin2;
        private Byte[] m_VrfMin;
        private SGFPMDeviceList[] m_DevList;
        String isuerreg;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Global.userid + "");

            bunifuImageButton1.Enabled = false;
            bunifuImageButton2.Enabled = false;
            bunifuFlatButton3.Enabled = false;
            m_LedOn = false;
            m_RegMin1 = new Byte[400];
            m_RegMin2 = new Byte[400];
            m_VrfMin = new Byte[400];
            m_FPM = new SGFingerPrintManager();
            //this.TopMost = true;
            // this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            String url = "http://dashboards.tk/api.php/mytable";
            String paramss = "?filter[]=userid,eq," + Global.userid + "&columns=name,id";
            rest(url, paramss);
        }


        void rest(String URL, String paramss)
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
                    var objects = JObject.Parse(dataObjects);
                    JObject j = (JObject)objects["mytable"];
                    JArray ja = (JArray)j["records"];
                    if (ja.Count > 0)
                    {
                        for (int i = 0; i < ja.Count(); i++) {
                            JArray je = (JArray)ja[i];
                            String js = (String)je[1];
                            int jss = (int)je[0];
                            list.Add(jss);
                            bunifuDropdown1.AddItem(js);
                        }


                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("NO USER FOUND ");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e);
                }
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
        void DisplayError(string funcName, int iError)
        {
            string text = "";

            switch (iError)
            {
                case 0:                             //SGFDX_ERROR_NONE				= 0,
                    text = "Error none";
                    break;

                case 1:                             //SGFDX_ERROR_CREATION_FAILED	= 1,
                    text = "Can not create object";
                    break;

                case 2:                             //   SGFDX_ERROR_FUNCTION_FAILED	= 2,
                    text = "Function Failed";
                    break;

                case 3:                             //   SGFDX_ERROR_INVALID_PARAM	= 3,
                    text = "Invalid Parameter";
                    break;

                case 4:                          //   SGFDX_ERROR_NOT_USED			= 4,
                    text = "Not used function";
                    break;

                case 5:                                //SGFDX_ERROR_DLLLOAD_FAILED	= 5,
                    text = "Can not create object";
                    break;

                case 6:                                //SGFDX_ERROR_DLLLOAD_FAILED_DRV	= 6,
                    text = "Can not load device driver";
                    break;
                case 7:                                //SGFDX_ERROR_DLLLOAD_FAILED_ALGO = 7,
                    text = "Can not load sgfpamx.dll";
                    break;

                case 51:                //SGFDX_ERROR_SYSLOAD_FAILED	   = 51,	// system file load fail
                    text = "Can not load driver kernel file";
                    break;

                case 52:                //SGFDX_ERROR_INITIALIZE_FAILED  = 52,   // chip initialize fail
                    text = "Failed to initialize the device";
                    break;

                case 53:                //SGFDX_ERROR_LINE_DROPPED		   = 53,   // image data drop
                    text = "Data transmission is not good";
                    break;

                case 54:                //SGFDX_ERROR_TIME_OUT			   = 54,   // getliveimage timeout error
                    text = "Time out";
                    break;

                case 55:                //SGFDX_ERROR_DEVICE_NOT_FOUND	= 55,   // device not found
                    text = "Device not found";
                    break;

                case 56:                //SGFDX_ERROR_DRVLOAD_FAILED	   = 56,   // dll file load fail
                    text = "Can not load driver file";
                    break;

                case 57:                //SGFDX_ERROR_WRONG_IMAGE		   = 57,   // wrong image
                    text = "Wrong Image";
                    break;

                case 58:                //SGFDX_ERROR_LACK_OF_BANDWIDTH  = 58,   // USB Bandwith Lack Error
                    text = "Lack of USB Bandwith";
                    break;

                case 59:                //SGFDX_ERROR_DEV_ALREADY_OPEN	= 59,   // Device Exclusive access Error
                    text = "Device is already opened";
                    break;

                case 60:                //SGFDX_ERROR_GETSN_FAILED		   = 60,   // Fail to get Device Serial Number
                    text = "Device serial number error";
                    break;

                case 61:                //SGFDX_ERROR_UNSUPPORTED_DEV		   = 61,   // Unsupported device
                    text = "Unsupported device";
                    break;

                // Extract & Verification error
                case 101:                //SGFDX_ERROR_FEAT_NUMBER		= 101, // utoo small number of minutiae
                    text = "The number of minutiae is too small";
                    break;

                case 102:                //SGFDX_ERROR_INVALID_TEMPLATE_TYPE		= 102, // wrong template type
                    text = "Template is invalid";
                    break;

                case 103:                //SGFDX_ERROR_INVALID_TEMPLATE1		= 103, // wrong template type
                    text = "1st template is invalid";
                    break;

                case 104:                //SGFDX_ERROR_INVALID_TEMPLATE2		= 104, // vwrong template type
                    text = "2nd template is invalid";
                    break;

                case 105:                //SGFDX_ERROR_EXTRACT_FAIL		= 105, // extraction fail
                    text = "Minutiae extraction failed";
                    break;

                case 106:                //SGFDX_ERROR_MATCH_FAIL		= 106, // matching  fail
                    text = "Matching failed";
                    break;

            }

            text = funcName + " Error # " + iError + " :" + text;
            Console.WriteLine(text);
            StatusBar.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 iError;
            string enum_device;

            comboBoxDeviceName.Items.Clear();

            // Enumerate Device
            iError = m_FPM.EnumerateDevice();

            // Get enumeration info into SGFPMDeviceList
            m_DevList = new SGFPMDeviceList[m_FPM.NumberOfDevice];

            for (int i = 0; i < m_FPM.NumberOfDevice; i++)
            {
                m_DevList[i] = new SGFPMDeviceList();
                m_FPM.GetEnumDeviceInfo(i, m_DevList[i]);
                enum_device = m_DevList[i].DevName.ToString() + " : " + m_DevList[i].DevID;
                comboBoxDeviceName.Items.Add(enum_device);
            }

            if (comboBoxDeviceName.Items.Count > 0)
            {
                // Add Auto Selection
                enum_device = "Auto Selection";
                comboBoxDeviceName.Items.Add(enum_device);

                comboBoxDeviceName.SelectedIndex = 0;  //First selected one
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_FPM.NumberOfDevice == 0)
                return;

            Int32 iError;
            SGFPMDeviceName device_name;
            Int32 device_id;

            Int32 numberOfDevices = comboBoxDeviceName.Items.Count;
            Int32 deviceSelected = comboBoxDeviceName.SelectedIndex;
            Boolean autoSelection = (deviceSelected == (numberOfDevices - 1));  // Last index

            if (autoSelection)
            {
                // Order of search: Hamster IV(HFDU04) -> Plus(HFDU03) -> III (HFDU02)
                device_name = SGFPMDeviceName.DEV_AUTO;

                device_id = (Int32)(SGFPMPortAddr.USB_AUTO_DETECT);
            }
            else
            {
                device_name = m_DevList[deviceSelected].DevName;
                device_id = m_DevList[deviceSelected].DevID;
            }

            iError = m_FPM.Init(device_name);
            iError = m_FPM.OpenDevice(device_id);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                GetBtn_Click(sender, e);

                StatusBar.Text = "Initialization Success";
                bunifuImageButton1.Enabled = true;
                bunifuImageButton2.Enabled = true;

                // FDU03, FDU04 only
                if ((device_name == SGFPMDeviceName.DEV_FDU03) || (device_name == SGFPMDeviceName.DEV_FDU04)) { }
            }
            else
                DisplayError("OpenDevice()", iError);
        }
        private void GetBtn_Click(object sender, System.EventArgs e)
        {
            SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
            Int32 iError = m_FPM.GetDeviceInfo(pInfo);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                m_ImageWidth = pInfo.ImageWidth;
                m_ImageHeight = pInfo.ImageHeight;


            }
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 iError;
                Byte[] fp_image;
                Int32 img_qlty;

                fp_image = new Byte[m_ImageWidth * m_ImageHeight];
                img_qlty = 0;

                iError = m_FPM.GetImage(fp_image);

                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
                p1.Value = img_qlty;

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    DrawImage(fp_image, pictureBox1);
                    iError = m_FPM.CreateTemplate(fp_image, m_RegMin1);

                    if (iError == (Int32)SGFPMError.ERROR_NONE)
                        StatusBar.Text = "First image is captured";
                    else
                        DisplayError("CreateTemplate()", iError);
                }
                else
                    DisplayError("GetImage()", iError);
            }
            catch (Exception es) {
                Console.Write(es);
            }
        }
        private void LedBtn_Click(object sender, System.EventArgs e)
        {
            m_LedOn = !m_LedOn;
            m_FPM.SetLedOn(m_LedOn);
        }
        private void ConfigBtn_Click(object sender, System.EventArgs e)
        {
            m_FPM.Configure((int)this.Handle);
        }
        private void DrawImage(Byte[] imgData, PictureBox picBox)
        {
            int colorval;
            Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
            picBox.Image = (Image)bmp;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorval = (int)imgData[(j * m_ImageWidth) + i];
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                }
            }
            picBox.Refresh();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 iError;
                Byte[] fp_image;
                Int32 img_qlty;

                fp_image = new Byte[m_ImageWidth * m_ImageHeight];
                img_qlty = 0;

                iError = m_FPM.GetImage(fp_image);

                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
                p2.Value = img_qlty;
                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    DrawImage(fp_image, pictureBox2);
                    iError = m_FPM.CreateTemplate(fp_image, m_RegMin2);

                    if (iError == (Int32)SGFPMError.ERROR_NONE)
                        StatusBar.Text = "Second image is captured";
                    else
                        DisplayError("CreateTemplate()", iError);
                }
                else
                    DisplayError("GetImage()", iError);
            }
            catch (Exception es)
            {
                Console.Write(es);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Int32 iError;
            bool matched = false;
            Int32 match_score = 0;
            SGFPMSecurityLevel secu_level; //
            int secu = 4;
            secu_level = (SGFPMSecurityLevel)secu;

            iError = m_FPM.MatchTemplate(m_RegMin1, m_RegMin2, secu_level, ref matched);
            iError = m_FPM.GetMatchingScore(m_RegMin1, m_RegMin2, ref match_score);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                if (matched)
                {
                    StatusBar.Text = "Registration Success, Matching Score: " + match_score;
                    bunifuFlatButton3.Enabled = true;
                }
                else
                {
                    StatusBar.Text = "Registration Failed";
                }
            }
            else
                DisplayError("GetMatchingScore()", iError);

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (isuerreg.Equals("true"))
            {
                updatefinger("Updated Finger !");
            }
            else
            {
                Registeraton("Finger Registered");
            }
        }
        void userinfo(String URL, String paramss)
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
                    JObject jb = JObject.Parse(dataObjects);

                    name.Text = (String)jb["name"];
                    FATHERN.Text = (String)jb["fn"];
                    CONTACT.Text = (String)jb["textinput"];

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e);
                }
            }
        }
        public void Registeraton(String mesage)  {
            String str = System.Text.Encoding.Default.GetString(m_RegMin1);
            String str1 = System.Text.Encoding.Default.GetString(m_RegMin2);
            int indexz = bunifuDropdown1.selectedIndex;
            String url = "https://dashboards.tk/api.php/finger";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    finger = str.Replace("\n", Environment.NewLine),
                    finger2 = str.Replace("\n", Environment.NewLine),
                    emp = list.ElementAt(indexz),
                    userid = Global.userid
                });
                System.Windows.Forms.MessageBox.Show(mesage);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result + "This is the result");
            }
        }

        public void updatefinger(String mesage)
        {
            String str = System.Text.Encoding.Default.GetString(m_RegMin1);
            String str1 = System.Text.Encoding.Default.GetString(m_RegMin2);
            int indexz = bunifuDropdown1.selectedIndex;
            String url = "https://dashboards.tk/api.php/finger/"+ list.ElementAt(indexz);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    finger = str.Replace("\n", Environment.NewLine),
                    finger2 = str.Replace("\n", Environment.NewLine),
                    emp = list.ElementAt(indexz),
                    userid = Global.userid
                });

                streamWriter.Write(json);
                System.Windows.Forms.MessageBox.Show(mesage);

            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result + "This is the result");
            }
        }

        void checkuser(String url,String paramss) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

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
                    var objects = JObject.Parse(dataObjects);
                    JObject j = (JObject)objects["finger"];
                    JArray ja = (JArray)j["records"];
                    if (ja.Count > 0)
                    {
                        label10.Text = "Finger Register : True";
                        isuerreg = "true";

                    }
                    else
                    {
                        label10.Text = "Finger Register : False";
                        isuerreg = "false";
                    }
                  

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e);
                }
            }
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            var fa = new Form3();
            fa.Show();
            this.Hide();
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            int indexz = bunifuDropdown1.selectedIndex;
            Console.WriteLine(list.ElementAt(indexz));
            String url = "https://dashboards.tk/api.php/mytable/" + list.ElementAt(indexz);
            String param = "?columns=name,fn,textinput&filter[]=userid,eq," + Global.userid;
            userinfo(url, param);
            String urls = "https://dashboards.tk/api.php/finger?filter[]=userid,eq,"+Global.userid+"&filter[]=emp,eq," + list.ElementAt(indexz); ;
            String par = "";
            checkuser(urls, par);
                

        }
    }
}
