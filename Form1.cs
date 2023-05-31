using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using S7.Net.Types;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.Reg;
using ZBar;

namespace comPLC
{
    public partial class IPSHala : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        public IPSHala()
        {
            InitializeComponent();
        }
        private void btn_check_Click(object sender, EventArgs e)
        {
            //Test connection PLC
            Plc plc = new Plc(CpuType.S71200, txt_ip.Text, 0, 0);
            if (plc.Open() == ErrorCode.NoError)
            {
                MessageBox.Show("Connect to PLC succesfully.", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tm_readdata.Start();
                plc.Close();
            }
            else
                MessageBox.Show("Can't connect to PLC.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void IPSHala_Load(object sender, EventArgs e)
        {
            tb_threshold.Text = trbar_threshold.Value.ToString();
            btn_scan.Enabled = false;
            btn_send.Enabled = false;
            tm_now.Start();

            //Initialization camera
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            cbb_devices.Items.Add(Device.Name);

            cbb_devices.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }

        private void btn_oncam_Click(object sender, EventArgs e)
        {
            btn_oncam.Enabled = false;

            //Turn on camera
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cbb_devices.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            if (FinalFrame.IsRunning != true) FinalFrame.Start();
        }

        private void FinalFrame_NewFrame(Object sender,NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void IPSHala_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FinalFrame.IsRunning == true) FinalFrame.Stop();
            tm_readdata.Stop();
            tm_now.Stop();
        }

        private void tm_scan_Tick(object sender, EventArgs e) //timer scan QR
        {
            Bitmap RGBPic = new Bitmap(pictureBox1.Image);
            int Threshold = trbar_threshold.Value;

            //Noise filter
            Bitmap BinaryPic = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for(int x = 0; x<pictureBox1.Width;x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    Color pixel = RGBPic.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte Gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);
                    if (Gray > Threshold) Gray = 255;
                    else Gray = 0;

                    BinaryPic.SetPixel(x, y, Color.FromArgb(Gray));
                    pictureBox4.Image = BinaryPic;
                }    
            }    

            //Scan QR
            if (pictureBox1.Image != null)
                {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)pictureBox1.Image);
                if(result != null)
                {
                    tb_qr.Text = result.ToString();                   
                }
            } 
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            Bitmap RGBPic = new Bitmap(pictureBox1.Image);
            int Threshold = trbar_threshold.Value;

            //Noise filter
            Bitmap BinaryPic = new Bitmap(RGBPic.Width, RGBPic.Height);
            for (int x = 0; x < RGBPic.Width; x++)
            {
                for (int y = 0; y < RGBPic.Height; y++)
                {
                    Color pixel = RGBPic.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte Gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);
                    if (Gray > Threshold) Gray = 255;
                    else Gray = 0;

                    BinaryPic.SetPixel(x, y, Color.FromArgb(Gray, Gray, Gray));
                    pictureBox4.Image = BinaryPic;
                }
            }

            //Move data to textbox
            if (BinaryPic != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)pictureBox4.Image);
                if (result != null)
                {
                    tb_qr.Text = result.ToString();
                }
            }
        }

        private void btn_stop_Click(object sender, EventArgs e) 
        {
            tb_qr.Clear();

            btn_auto.Enabled = true;
            btn_man.Enabled = true;
            btn_oncam.Enabled = true;
            btn_scan.Enabled = false;
            btn_send.Enabled = false;

            tm_scan.Stop();
            tm_write.Stop();
            if (FinalFrame.IsRunning == true) FinalFrame.Stop();
        }

        private void btn_man_Click(object sender, EventArgs e)
        {
            btn_auto.Enabled = false;
            btn_man.Enabled = false;
            btn_oncam.Enabled = true;
            btn_scan.Enabled = true;
            btn_send.Enabled = true;

            tm_write.Stop();
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            btn_auto.Enabled = false;
            btn_man.Enabled = false;
            btn_oncam.Enabled = false;
            btn_scan.Enabled = false;
            btn_send.Enabled = false;
            tm_delay.Start();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //String processing
            string dataSend = tb_qr.Text;
            byte[] dataBytes = S7.Net.Types.String.ToByteArray(dataSend);

            List<byte> values = new List<byte>();
            byte maxlength = (byte)dataSend.Length;
            byte actuallength = (byte)dataSend.Length;
            values.Add(maxlength);
            values.Add(actuallength);
            values.AddRange(dataBytes);

            //Send data to PLC
            Plc plc = new Plc(CpuType.S71200, txt_ip.Text, 0, 0);
            if (plc.Open() == ErrorCode.NoError && tb_qr != tb_readPLC)
            {
                byte[] bitSend = new byte[10];
                bitSend[0] |= 0x01;
                plc.WriteBytes(DataType.Memory, 0, 0, bitSend); 
                bitSend[0] &= 0xfe;
                plc.WriteBytes(DataType.Memory, 0, 0, bitSend);
                plc.Write(DataType.DataBlock, 73, 50, values.ToArray());
                plc.Close();
            }
            else
            {
                MessageBox.Show("Can't send data to PLC.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tm_write_Tick(object sender, EventArgs e)
        {
            Bitmap RGBPic = new Bitmap(pictureBox1.Image);
            int threshold = trbar_threshold.Value;
            /*
            byte[] sensor = new byte[10];

            Plc plc = new Plc(CpuType.S71200, txt_ip.Text, 0, 0);
            if (plc.Open() == ErrorCode.NoError)
            {
                sensor = plc.ReadBytes(DataType.DataBlock, 73, 32, 8);
                if (sensor[0].SelectBit(4) == true) radioButton1.Checked = true;
                //tb_readPLC.Text = sensor.ToString();
                plc.Close();
            }
            */
            if (RGBPic != null)
            {
                //Noise filter
              
                Bitmap BinaryPic = new Bitmap(RGBPic.Width, RGBPic.Height);
                for (int x = 0; x < RGBPic.Width; x++)
                {
                    for (int y = 0; y < RGBPic.Height; y++)
                    {
                        Color pixel = RGBPic.GetPixel(x, y);
                        byte R = pixel.R;
                        byte G = pixel.G;
                        byte B = pixel.B;
                        byte Gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);
                        if (Gray > threshold) Gray = 255;
                        else Gray = 0;

                        BinaryPic.SetPixel(x, y, Color.FromArgb(Gray, Gray, Gray));
                        pictureBox4.Image = BinaryPic;
                    }
                }

                //Scan QR
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)BinaryPic);
                if (result != null)
                {
                    tb_qr.Text = result.ToString();

                    //String processing
                    string dataSend = tb_qr.Text;
                    byte[] dataBytes = S7.Net.Types.String.ToByteArray(dataSend);

                    List<byte> values = new List<byte>();
                    byte maxlength = (byte)dataSend.Length;
                    byte actuallength = (byte)dataSend.Length;
                    values.Add(maxlength);
                    values.Add(actuallength);
                    values.AddRange(dataBytes);

                    //Send data to PLC
                    Plc plc = new Plc(CpuType.S71200, txt_ip.Text, 0, 0);
                    if (plc.Open() == ErrorCode.NoError && tb_qr != tb_readPLC)
                    {
                        byte[] bitSend = new byte[10];
                        bitSend[0] |= 0x01;
                        plc.WriteBytes(DataType.Memory, 0, 0, bitSend);
                        bitSend[0] &= 0xfe;
                        plc.WriteBytes(DataType.Memory, 0, 0, bitSend);
                        plc.Write(DataType.DataBlock, 73, 50, values.ToArray());
                        plc.Close();
                    }
                    else
                    {
                        tm_write.Stop();
                        MessageBox.Show("Can't send data to PLC.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            tm_delay.Interval = 100;
            tm_delay.Start();
            tm_write.Stop();

        }

        private void tm_readdata_Tick(object sender, EventArgs e)
        {
            //Read data from PLC
            Plc plc = new Plc(CpuType.S71200, txt_ip.Text, 0, 0);
            if (plc.Open() == ErrorCode.NoError)
            {
                var dataRead = plc.Read(DataType.DataBlock, 73, 52, VarType.String, 7);
                tb_readPLC.Text = dataRead.ToString();
                plc.Close();
            }
            else
            {
                tm_readdata.Stop();
                MessageBox.Show("Can't read data from PLC.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tm_now_Tick(object sender, EventArgs e)
        {
            lb_now.Text = DateTime.Now.ToString();
        }

        private void btn_gray_Click(object sender, EventArgs e)
        {
            Bitmap RGBPic = new Bitmap(pictureBox1.Image);
            int Threshold = trbar_threshold.Value;

            //Noise filter
            Bitmap BinaryPic = new Bitmap(RGBPic.Width, RGBPic.Height);
            for (int x = 0; x < RGBPic.Width; x++)
            {
                for (int y = 0; y < RGBPic.Height; y++)
                {
                    Color pixel = RGBPic.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte Gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);
                    if (Gray > Threshold) Gray = 255;
                    else Gray = 0;

                    BinaryPic.SetPixel(x, y, Color.FromArgb(Gray, Gray, Gray));
                    pictureBox4.Image = BinaryPic;
                }
            }

            //Move data to textbox
            if (BinaryPic != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)BinaryPic);
                if (result != null)
                {
                    tb_qr.Text = result.ToString();
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int threshold = trbar_threshold.Value;
            tb_threshold.Text = trbar_threshold.Value.ToString();
        }

        private void tb_threshold_TextChanged(object sender, EventArgs e)
        {
              
        }

        private void tm_delay_Tick(object sender, EventArgs e)
        {
            byte[] sensor = new byte[10];

            Plc plc = new Plc(CpuType.S71200, txt_ip.Text, 0, 0);
            if (plc.Open() == ErrorCode.NoError)
            {
                sensor = plc.ReadBytes(DataType.DataBlock, 73, 32, 8);
                if (pictureBox1.Image != null && sensor[0].SelectBit(4) == true)
                { 
                    radioButton1.Checked = true;
                    tm_delay.Interval = 1000;
                    tm_delay.Stop();
                    tm_write.Start();
                }
                else
                {
                    pictureBox4.Image = null;
                    radioButton1.Checked = false;
                    tm_delay.Interval = 100;
                }
                plc.Close();
            }
        }
    }
}
    
