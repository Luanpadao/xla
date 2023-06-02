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
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.Reg;
using Emgu.CV.Dai;
using ZBar;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;
using Emgu.CV.CvEnum;
using System.Threading;

namespace comPLC
{
    public partial class IPSHala : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        Bitmap frame;
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
            // Sử dụng thư viện ZBar để phát hiện mã QR ---------------------------------
            //ZBar.ImageScanner scanner = new ZBar.ImageScanner();
            //scanner.SetConfiguration(ZBar.SymbolType.None, ZBar.Config.Enable, 0);
            //scanner.SetConfiguration(ZBar.SymbolType.QRCODE, ZBar.Config.Enable, 1);
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
            if (FinalFrame.IsRunning != true)
            {
                FinalFrame.Start();
            }
        }

        private void FinalFrame_NewFrame(Object sender,NewFrameEventArgs eventArgs)
        {
            frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame;
        }

        private void IPSHala_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FinalFrame.IsRunning == true) FinalFrame.Stop();
            tm_readdata.Stop();
            tm_now.Stop();
        }

        private void tm_scan_Tick(object sender, EventArgs e) //timer scan QR
        {
            Bitmap RGBPic = new Bitmap(frame);
            int Threshold = trbar_threshold.Value;

            //Noise filter
            Bitmap BinaryPic = new Bitmap(frame.Width, frame.Height);
            for(int x = 0; x< frame.Width;x++)
            {
                for (int y = 0; y < frame.Height; y++)
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
            if (frame != null)
                {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)frame);
                if(result != null)
                {
                    tb_qr.Text = result.ToString();                   
                }
            } 
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            Bitmap RGBPic = new Bitmap(frame);
            int Threshold = trbar_threshold.Value;

            //Noise filter - lọc nhiễu
            Console.WriteLine("1");
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
                }
            }
            Console.WriteLine("2");
            pictureBox4.Image = BinaryPic;
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
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
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
                //plc.Write(DataType.DataBlock, 73, 50, values.ToArray());
                plc.Write(DataType.DataBlock, 1, 80, values.ToArray());
                plc.Close();
            }
            else
            {
                MessageBox.Show("Can't send data to PLC.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tm_write_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("tm_write");
            Bitmap RGBPic = new Bitmap(frame);
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
                        //plc.Write(DataType.DataBlock, 73, 50, values.ToArray());
                        plc.Write(DataType.DataBlock, 1, 80, values.ToArray());
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
                //var dataRead = plc.Read(DataType.DataBlock, 73, 52, VarType.String, 7);
                var dataRead = plc.Read(DataType.DataBlock, 1, 50, VarType.String, 7);
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
            Bitmap RGBPic = new Bitmap(frame);
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
            Console.WriteLine("tm_delay");
            byte[] sensor = new byte[10];

            Plc plc = new Plc(CpuType.S71200, txt_ip.Text, 0, 0);
            if (plc.Open() == ErrorCode.NoError)
            {
                sensor = plc.ReadBytes(DataType.DataBlock, 1, 16, 3);
                //sensor = plc.ReadBytes(DataType.DataBlock, 73, 32, 8);
                if (frame != null && sensor[0].SelectBit(4) == true)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        ///HÀM BỔ XUNG-----------------------------------------------------------------
        private Bitmap CutOutQRCode(Bitmap frame)
        {
            // Chuyển đổi khung hình sang ảnh xám
            Bitmap grayFrame = ConvertToGrayscale(frame);

            // Tạo bộ lọc QR code
            BarcodeReader barcodeReader = new BarcodeReader();
            barcodeReader.Options.TryHarder = true;

            // Nhận dạng mã QR code từ ảnh xám
            ZXing.Result result = barcodeReader.Decode(grayFrame);

            if (result != null)
            {
                // Lấy vùng chứa mã QR code
                ZXing.ResultPoint[] resultPoints = result.ResultPoints;
                Rectangle qrCodeRect = GetBoundingBox(resultPoints);

                // Cắt phần ảnh chứa mã QR code
                Bitmap qrCodeImage = frame.Clone(qrCodeRect, frame.PixelFormat);
                return qrCodeImage;
            }

            return null;
        }

        private Bitmap ConvertToGrayscale(Bitmap image)
        {
            Bitmap grayscaleImage = new Bitmap(image.Width, image.Height, PixelFormat.Format8bppIndexed);

            using (Graphics g = Graphics.FromImage(grayscaleImage))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
                    });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }

            return grayscaleImage;
        }

        private Rectangle GetBoundingBox(ZXing.ResultPoint[] resultPoints)
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;

            foreach (ZXing.ResultPoint point in resultPoints)
            {
                int x = (int)point.X;
                int y = (int)point.Y;

                if (x < minX)
                    minX = x;
                if (y < minY)
                    minY = y;
                if (x > maxX)
                    maxX = x;
                if (y > maxY)
                    maxY = y;
            }

            return Rectangle.FromLTRB(minX, minY, maxX, maxY);
        }

        private void ProcessQRCode(Bitmap qrCodeImage)
        {
            if (qrCodeImage != null)
            {
                // Thực hiện xử lý mã QR code ở đây
                // ...
                // Ví dụ: Hiển thị mã QR code lên giao diện
                frame = qrCodeImage;
            }
        }
        // Giảm độ phân giải ảnh
        private Bitmap ResizeImage(Bitmap hinhanh, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);

            bool isImageLocked = false;
            try
            {
                Monitor.Enter(hinhanh, ref isImageLocked);
                using (Bitmap clonedImage = (Bitmap)hinhanh.Clone())
                {
                    using (Graphics graphics = Graphics.FromImage(resizedImage))
                    {
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.DrawImage(clonedImage, 0, 0, width, height);
                    }
                }
            }
            finally
            {
                if (isImageLocked)
                {
                    Monitor.Exit(hinhanh);
                }
            }

            return resizedImage;
        }
    }
}
    
