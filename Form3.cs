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
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Matching_cs
{
   
    public partial class Form3 : Form
    {
        String shiftstart;
        String shiftend;
        String halfstart;
        String halfend;
        List<String> names = new List<String>();
        List<int> shiftts = new List<int>();

        List<int> nameid = new List<int>();
        List<int> list = new List<int>();
        List<int> empid = new List<int>();
        List<String> fingerone = new List<String>();
        List<String> finger2 = new List<String>();
        List<String> Shiftid = new List<String>();
        List<String> Shiftempid = new List<String>();
        List<String> Shiftfrom = new List<String>();
        List<String> Shiftto = new List<String>();
        List<String> Shifthalf1 = new List<String>();
        List<String> Shifthalf2 = new List<String>();
        private SGFingerPrintManager m_FPM;
        private bool m_LedOn = false;
        private Int32 m_ImageWidth;
        private Int32 m_ImageHeight;
        private Byte[] m_RegMin1;
        private Byte[] m_RegMin2;
        private Byte[] m_VrfMin;
        private SGFPMDeviceList[] m_DevList;
        String isuerreg;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          //  this.TopMost = true;
            // this.FormBorderStyle = FormBorderStyle.None;
           // this.WindowState = FormWindowState.Maximized;
            m_LedOn = false;
            m_RegMin1 = new Byte[400];
            m_RegMin2 = new Byte[400];
            m_VrfMin = new Byte[400];
            m_FPM = new SGFingerPrintManager();
        
            rest();
            shifts();
            Console.WriteLine(Shiftfrom.ElementAt(0));
            userinfo("https://dashboards.tk/api.php/mytable", "?columns=name,shift&filter[]=userid,eq," + Global.userid);

        }
        void checkiflog(int id,int shif) {
            String date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            String url = "https://dashboards.tk/api.php/emp_attend";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            // List data response.
            HttpResponseMessage response = client.GetAsync("?filter[]=userid,eq,"+Global.userid+"&filter[]=date,eq,"+date+"&filter[]=emp_id,eq,"+id).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    // Parse the response body.
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    var objects = JObject.Parse(dataObjects);
                    JObject j = (JObject)objects["emp_attend"];
                    JArray ja = (JArray)j["records"];

                    if (ja.Count > 0)
                    {
                        for (int i = 0; i < ja.Count(); i++)
                        {
                            JArray je = (JArray)ja[i];
                            int attendid = (int)je[0];
                            int idss = (int)je[1];
                            String checkouts = (String)je[3];
                       
                            String checkin = (String)je[2];
                        //    DateTime subch = Convert.ToDateTime(subcheckins);
                          //  DateTime subcho = Convert.ToDateTime(subcheckout);
                         //   TimeSpan start = new TimeSpan(23, 59, 0); //10 o'clock

                            if (checkouts.Equals("0000-00-00 00:00:00")) {
                                try
                                {
                                    checkout(attendid, checkin);
                                }
                                catch (Exception e) {
                                    System.Windows.Forms.MessageBox.Show("ERROR WHILE CHECKOUT"+e);
                                }
                            } else {
                                try { 
                               subcheckinss(attendid, checkin,checkouts,idss);
                                }
                                catch (Exception e)
                                {
                                    System.Windows.Forms.MessageBox.Show("ERROR WHILE SUB CHECK IN"+e);
                                }

                            }

                        }
                    }
                    else
                    {
                        int shift= 0;
                        for (int k = 0; k < Shiftempid.Count(); k++)
                        {
                            int x = Int32.Parse(Shiftempid.ElementAt(k));
                            if (x == shif)
                            {
                                shift = k;
                            }
                        }
                        if ( shif == 0)
                        {
                            label2.Text = "Shift Not Intitizalized";
                            StatusBar.Text = "unsccuessfull !";
                        }
                        else {
                         
                           
                            TimeSpan start = TimeSpan.Parse(Shiftfrom.ElementAt(shift)); //10 o'clock
                            TimeSpan end = TimeSpan.Parse(Shiftto.ElementAt(shift)); //12 o'clock
                            TimeSpan halfone = TimeSpan.Parse(Shifthalf1.ElementAt(shift)); //12 o'clock
                            TimeSpan halftwo = TimeSpan.Parse(Shifthalf2.ElementAt(shift)); //12 o'clock
                            TimeSpan now = DateTime.Now.TimeOfDay;
                            String status = "";
                            String dates = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                            String datestime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

                            if ((now < start) && (now > end))
                            {
                                status = "present";
                            }
                            else if ((now < start) && (now < end))
                            {
                                status = "present";
                            }
                            else if ((now > start) && (now < halfone))
                            {
                                status = "late";
                            }
                            else 
                            {
                                status = "halfday";
                            }
                            try
                            {
                                Attend(id, dates, datestime, status);
                            }
                            catch (Exception e)
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR WHILE FIRST ATTENDENCE" + e);
                            }
                        }
                     

                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e);
                }
            }
        }
        void checkout(int id,String date) {
            String url = "https://dashboards.tk/api.php/emp_attend/"+id;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            String datestime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            DateTime dt1 = DateTime.Parse(datestime);
            DateTime dt2 = DateTime.Parse(date);

            System.TimeSpan diff1 = dt1.Subtract(dt2);
            String dadif = diff1.ToString();
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {

                    checkout = datestime,
                    totalhours = dadif

                });

                streamWriter.Write(json);
                
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result + "This is the result");
            }
        }

        void subcheckinss(int id,String checkin,String checkouts,int ids) {
            String date = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

            String url = "https://dashboards.tk/api.php/subcheckin";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            // List data response.
            HttpResponseMessage response = client.GetAsync("?filter[]=userid,eq," + Global.userid+"&filter[]=date,eq," + date + "&filter[]=empid,eq," + ids).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                try {
                    // Parse the response body.
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    var objects = JObject.Parse(dataObjects);
                    JObject j = (JObject)objects["subcheckin"];
                    JArray ja = (JArray)j["records"];

                    if (ja.Count > 0)
                    {
                        List<int> subids = new List<int>();
                        List<String> checcin = new List<String>();
                        for (int i = 0; i < ja.Count(); i++)
                        {
                            JArray je = (JArray)ja[i];
                            String checko = (String)je[4];
                            String checin = (String)je[3];
                            int subid = (int)je[0];
                            if (checko.Equals("0000-00-00 00:00:00"))
                            {
                                subids.Add(subid);
                                checcin.Add(checin);

        

                            }
                          

                        }
                        Console.WriteLine(subids.Count);
                        if (subids.Count == 0)
                        {
                            subcheckin(id, checkin, checkouts, ids);
                        }
                        else {
                            updatesub(subids[0], checcin[0], checkouts, id, checkin);
                        }
                    }
                    else {
                        subcheckin(id, checkin, checkouts,ids);
                    }

                        }
                catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
        }
            }
        void subcheckin(int id, String date,String checkout,int ids)
        {
            String url = "https://dashboards.tk/api.php/subcheckin/";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            String datestime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            DateTime dt1 = DateTime.Parse(datestime);
            DateTime dt2 = DateTime.Parse(date);
            System.TimeSpan diff1 = dt1.Subtract(dt2);
            String dadif = diff1.ToString();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    checkin = checkout,
                    date = datestime,
                    empid = ids,
                    attendid = id,
                    userid = Global.userid
                });

                streamWriter.Write(json);
                updatecheckout(id, date, checkout);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result + "This is the result");
            }
        }
        void updatesub(int id, String date, String checkout,int ids,String checkin)
        {
            String url = "https://dashboards.tk/api.php/subcheckin/" + id;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            String datestime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            DateTime dt1 = DateTime.Parse(checkout);
            DateTime dt2 = DateTime.Parse(date);
            System.TimeSpan diff1 = dt1.Subtract(dt2);
            String dadif = diff1.ToString();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    checkout = checkout,
                    totaltime = dadif,
                    userid = Global.userid
                });

                streamWriter.Write(json);
                updatecheckout(ids, checkin , checkout);

            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result + "This is the result");
            }
        }
        void updatecheckout(int id, String date, String checkout)
        {
            String url = "https://dashboards.tk/api.php/emp_attend/" + id;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            String datestime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            DateTime dt1 = DateTime.Parse(datestime);
            DateTime dt2 = DateTime.Parse(date);
            System.TimeSpan diff1 = dt1.Subtract(dt2);
            String dadif = diff1.ToString();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    checkout = datestime,
                    totalhours = dadif,
                    userid = Global.userid
                });

                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result + "This is the result");
            }
        }
        void subcheckinn(int id, String date, String checkout)
        {
            String url = "https://dashboards.tk/api.php/emp_attend/" + id;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            String datestime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            DateTime dt1 = DateTime.Parse(datestime);
            DateTime dt2 = DateTime.Parse(date);
            System.TimeSpan diff1 = dt1.Subtract(dt2);
            String dadif = diff1.ToString();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    checkout = datestime,
                    subcheckin = checkout,
                    totalhours = dadif,
                    userid = Global.userid
                });

                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result + "This is the result");
            }
        }

        void subcheckouts(int id, String date, String checkout,String subcheckin,String subcheckouts)
        {
            String url = "https://dashboards.tk/api.php/emp_attend/" + id;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            String datestime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            DateTime dt1 = DateTime.Parse(datestime);
            DateTime dt2 = DateTime.Parse(date);
            DateTime dt4 = DateTime.Parse(subcheckin);
            DateTime dt5 = DateTime.Parse(checkout);
            System.TimeSpan diff4 = dt5.Subtract(dt4);
            System.TimeSpan diff1 = dt1.Subtract(dt2);
            String dadif = diff1.ToString();
            String dadif1 = diff4.ToString();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    checkout = datestime,
                    subcheckout = checkout,
                    totalhours = dadif,
                    totalbreaktime = dadif1,
                    userid = Global.userid

                });

                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result + "This is the result");
            }
        }

        void Attend(int id, String dates,String datetime,String statuss) {
            String url = "https://dashboards.tk/api.php/emp_attend";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {


                string json = new JavaScriptSerializer().Serialize(new
                {
                    date = dates,
                    checkin = datetime,
                    emp_id = id,
                    status = statuss,
                    userid = Global.userid
                    
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                try {
                    //LivefingerAsync();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem with LIVE FINGER "+e);
                }

                Console.Write(result + "This is the result");
            }
        }
       void LivefingerAsync() {
            try
            {
                Int32 iError;
                Int32 timeout;
                Int32 quality;
                Byte[] fp_image;
                Int32 elap_time;
                bool matched1 = false;
                bool matched2 = false;
                SGFPMSecurityLevel secu_level; //
                int secu = 4;
                secu_level = (SGFPMSecurityLevel)secu;

                timeout = 18000000;
                quality = 50;
                fp_image = new Byte[m_ImageWidth * m_ImageHeight];
                elap_time = Environment.TickCount;

                iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBox1.Handle.ToInt32(), quality);

                if (iError == 0)
                {
                    iError = m_FPM.CreateTemplate(fp_image, m_VrfMin);
                    int j = 1;
                    for (int i = 0; i < fingerone.Count; i++)
                    {
                        String str = fingerone.ElementAt(i);
                        String str1 = finger2.ElementAt(i);
                        Console.WriteLine(str);
                        m_RegMin1 = Encoding.Default.GetBytes(str);
                        m_RegMin2 = Encoding.Default.GetBytes(str1);

                        iError = m_FPM.MatchTemplate(m_RegMin1, m_VrfMin, secu_level, ref matched1);
                        iError = m_FPM.MatchTemplate(m_RegMin2, m_VrfMin, secu_level, ref matched2);
                        if (matched1 || matched2)
                        {
                            label2.Text = names.ElementAt((int)empid.ElementAt(i) - 1);

                            StatusBar.Text = "Sccuessfull !";


                            checkiflog((int)empid.ElementAt(i), (int)shiftts.ElementAt((int)empid.ElementAt(i) - 1));
                            Refresh();
                            try
                            {
                              

                               //  Delay(10000);
                           LivefingerAsync();
                                 Delay(10000);


                            }
                            catch (Exception e)
                            {

                            }

                            break;
                        }
                        else
                        {

                            if (j == fingerone.Count()) {
                                label2.Text = "Couldnt Recognized ! not valid";
                                StatusBar.Text = "unsccuessfull !";
                                Refresh();
                                LivefingerAsync();
                            }
                            j++;


                        }

                    }

                    elap_time = Environment.TickCount - elap_time;
                    //    StatusBar.Text = "Capture Time : " + elap_time + "millisec";
                }

                else
                    DisplayError("GetLiveImageEx()", iError);
            }
            catch (Exception e) {

            }
        }

        public static Task Delay(double milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += (obj, args) =>
            {
                tcs.TrySetResult(true);
            };
            timer.Interval = milliseconds;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
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

               StatusBar.Text = "Ready for Finger Print";
               
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == "")
            {
            }
            else
            {
                LivefingerAsync();
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

                    var objects = JObject.Parse(dataObjects);

                    JObject j = (JObject)objects["mytable"];

                    JArray ja = (JArray)j["records"];

                    for (int i = 0; i < ja.Count; i++)
                        {
                           JArray jaa = (JArray)ja[i];
                        names.Add((String)jaa[0]);
                        shiftts.Add((int)jaa[1]);
                        }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e);


                }
              //  System.Windows.Forms.MessageBox.Show("GOT THE RECORDS" + names.Count);

            }
        }
       
        void rest() {
            String url = "http://dashboards.tk/api.php/finger";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("Procceding");
            // List data response.
            HttpResponseMessage response = client.GetAsync("?filter[]=userid,eq," + Global.userid).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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
                        for (int i = 0; i < ja.Count(); i++)
                        {
                            JArray je = (JArray)ja[i];
                            String js = (String)je[1];
                            String jss = (String)je[2];
                            int id = (int)je[3];
                            finger2.Add(jss);
                            fingerone.Add(js);
                            empid.Add(id);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records Found");
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e);
                }
            }
        }
        void shifts()
        {
            String url = "http://dashboards.tk/api.php/shift";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("Procceding");
            // List data response.
            HttpResponseMessage response = client.GetAsync("?filter[]=userid,eq," + Global.userid).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    // Parse the response body.
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    var objects = JObject.Parse(dataObjects);
                    JObject j = (JObject)objects["shift"];
                    JArray ja = (JArray)j["records"];
                    Console.WriteLine(ja.ToString());
                    if (ja.Count > 0)
                    {
                        for ( int i = 0; i < ja.Count(); i++)
                        {
                            JArray je = (JArray)ja[i];
                            String from = (String)je[1];
                            String to = (String)je[2];
                            String halffrom = (String)je[3];
                            String halfto = (String)je[4];
                            Console.WriteLine(from.ToString());
                            Shiftempid.Add((String)je[0]);
                            Shiftfrom.Add(from);
                            Shiftto.Add(to);
                            Shifthalf1.Add(halffrom);
                            Shifthalf2.Add(halfto);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records Found");
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e);
                }
            }
        }
        delegate void CloseMethod(Form form);
        static private void CloseForm(Form form)
        {
            if (!form.IsDisposed)
            {
                if (form.InvokeRequired)
                {
                    CloseMethod method = new CloseMethod(CloseForm);
                    form.Invoke(method, new object[] { form });
                }
                else
                {
                    form.Close();
                }
            }
        }
    }
  
}
public static class Extensions
{
    public static void Invoke<TControlType>(this TControlType control, Action<TControlType> del)
        where TControlType : Control
    {
        if (control.InvokeRequired)
            control.Invoke(new Action(() => del(control)));
        else
            del(control);
    }
}