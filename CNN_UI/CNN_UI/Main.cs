using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CNN_UI
{
    public partial class Main : Form
    {
        // 폼의 드래그 이동에 활용될 전역변수
        int TogMove;
        int MvalX;
        int MvalY;

        public Main()
        {
            InitializeComponent();
            this.img_pbx.AllowDrop = true; // 픽쳐 박스의 드래그 앤 드롭 기능 활성화

            try
            {
                // 이미지 다운로드 기능의 재사용을 위해 폴더 삭제
                string image_path = @"C:\C#\NP\downloads";
                string[] temp_files = Directory.GetFiles(image_path, "*", SearchOption.AllDirectories);
                foreach (string file in temp_files)
                {
                    File.Delete(file);
                }
                Directory.Delete(image_path, true);
            }
            catch { }
        }

        private void img_pbx_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop); // 드래그 앤 드롭으로 가져온 파일들을 배열에 저장
            string file_path = files[0]; // 하나의 파일만 검사할 것이므로, 배열의 첫번째 파일의 경로를 가져옴
            string file_ext = Path.GetExtension(file_path); // 확장자만 추출함 ex) .jpg or .jpeg 
            if (file_ext == ".jpeg" || file_ext == ".jpg") // 이미지 확장자인 경우에만 계속 진행
            {
                try
                {
                    // 재사용을 위한 초기화
                    image_lvw.Items.Clear();
                    while (image_lvw.Items.Count > 0)
                    {
                        var item = image_lvw.Items[image_lvw.Items.Count - 1];
                        image_lvw.Items.RemoveAt(image_lvw.Items.Count - 1);
                        if (item is IDisposable)
                        {
                            ((IDisposable)item).Dispose();
                        }
                    }
                    image_list.Images.Clear();
                    image_list.Dispose();
                }
                catch { }

                try
                {
                    string image_path = @"C:\C#\NP\downloads";
                    string[] temp_files = Directory.GetFiles(image_path, "*", SearchOption.AllDirectories);
                    foreach (string file in temp_files)
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(image_path, true);
                }
                catch{}

                img_pbx.Load(file_path); // 사용자가 업로드한 이미지를 화면(픽쳐 박스)에 표시
                info_lbl.Visible = false; // 드래그 앤 드롭을 유도하는 라벨을 비활성화하여 안보이도록 함  
            }
            else MessageBox.Show("jpg 형식의 이미지만 업로드 가능합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void img_pbx_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private bool Image_Searching()
        {
            CheckForIllegalCrossThreadCalls = false; // 크로스 쓰레드 문제점 해결을 위한 예외처리

            string file_path = img_pbx.ImageLocation; // 이미지 경로를 가져옴
            string file_name = Path.GetFileName(file_path); // 파일명만 추출

            string temp_image_path = @"C:\C#\NP\image";
            string temp_file_path = temp_image_path + @"\" + file_name;

            // 폴더가 존재하지 않는다면, 생성
            if (!Directory.Exists(temp_image_path))
                Directory.CreateDirectory(temp_image_path);
            else
            {
                // 재사용을 위해 임시 이미지를 깔끔하게 삭제함
                string[] files = Directory.GetFiles(temp_image_path);
                foreach (string file in files)
                {
                    string f_name = Path.GetFileName(file);
                    string f_path = temp_image_path + @"\" + f_name;
                    File.Delete(f_path);
                }

            }

            // 파일을 임시폴더로 복사
            if (File.Exists(file_path))
                File.Copy(file_path, temp_file_path);

            // 스크립트를 실행하여, python과 연계하는 부분
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.CreateNoWindow = true;
            psi.Arguments = @"/C C:\C#\NP\client.bat";
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;

            Process proc = Process.Start(psi);

            // ML으로 파일을 보낸 결과를 받아옴
            string cmd_result = proc.StandardOutput.ReadToEnd();
            string[] cmd_result_split = cmd_result.Split();

            string[] prediction_result = cmd_result_split[10].Split(',');
            string cartegory = prediction_result[0];
            string percent = prediction_result[1];

            // 화면에 추론 결과를 표시
            result_tbx.Text = cartegory + "(" + percent + ")";

            return true;
        }

        bool isSearching = false;
        private async void img_search_btn_Click(object sender, EventArgs e)
        {
            if (img_pbx.ImageLocation != null) // 사용자가 이미지를 먼저 드래그앤 드롭을 한 경우에만 진행
            {
                if (!isSearching)
                {
                    loading_pbx.Visible = true;
                    isSearching = true;
                    // 비동기식 처리를 통해 이미지 서칭 진행
                    var result = Task.Run(() => Image_Searching());
                    if (await result)
                    {
                        result.Dispose();
                        loading_pbx.Visible = false;
                        isSearching = false;
                    }
                }
            }
            else MessageBox.Show("이미지를 먼저 선택하여 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private bool Image_View()
        {
            CheckForIllegalCrossThreadCalls = false; // 크로스 쓰레드 문제점 해결을 위한 예외처리
            string image_path = @"C:\C#\NP\downloads";
            if (!Directory.Exists(image_path)) Directory.CreateDirectory(image_path);
             
            while (true)
            {
                string[] files = Directory.GetFiles(image_path, "*.*", SearchOption.AllDirectories);

                if (files.Count() >= 6)
                {
                    foreach (string file_path in files)
                    {
                        string file_ext = Path.GetExtension(file_path); // 확장자만 추출함 ex) .jpg or .jpeg 
                        if (file_ext == ".jpeg" || file_ext == ".jpg") // 이미지 확장자인 경우에만 계속 진행
                        {
                            try
                            {
                                StreamReader sr = new StreamReader(file_path);
                                Image img = Image.FromStream(sr.BaseStream);
                                image_list.Images.Add(img);
                                sr.Dispose();
                            }
                            catch {continue;}
                        }
                    }
                    image_list.ImageSize = new Size(160, 160);
                    image_lvw.LargeImageList = image_list;
                    for (int j = 0; j < this.image_list.Images.Count; j++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = j;
                        this.image_lvw.Items.Add(item);
                    }
                    break;
                }
                Thread.Sleep(2000);
            }
            return true;
        }


        private bool Image_Download()
        {
            // 스크립트를 실행하여, python과 연계하는 부분
            string command = @"""C:\Users\JUNG\Anaconda3\envs\tf\python.exe"" ""C:\C#\NP\image_download.py""";
            string argv = result_tbx.Text.Substring(0, result_tbx.Text.IndexOf('('));

            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            Process cmd = new Process();
            cmd.StartInfo = psi;
            cmd.Start();
            cmd.StandardInput.Write(@"cd ""C:\C#\NP""" + Environment.NewLine);
            cmd.StandardInput.Write(@"" + command + " " + argv + Environment.NewLine);

            return true;
        }

        bool isRunning = false;
        private async void img_download_btn_Click(object sender, EventArgs e)
        {
            if (img_pbx.ImageLocation != null) // 사용자가 이미지를 먼저 드래그앤 드롭을 한 경우에만 진행
            {
                if (result_tbx.Text != "미동작 (0%)")
                {
                    if (!isRunning)
                    {
                        isRunning = true;
                        loading_pbx.Visible = true;

                        // 비동기식 처리를 통해 이미지 서칭 진행
                        var download_result = Task.Run(() => Image_Download());
                        if (await download_result)
                        {
                            download_result.Dispose();
                        }

                        var listing_result = Task.Run(() => Image_View());
                        if (await listing_result)
                        {
                            listing_result.Dispose();
                            isRunning = false;
                            loading_pbx.Visible = false;
                        }
                    }
                    else MessageBox.Show("이미지 다운로드가 이미 진행중입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else MessageBox.Show("이미지 분석을 먼저 진행하여 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else MessageBox.Show("이미지를 먼저 선택하여 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MvalX = e.X;
            MvalY = e.Y;
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MvalY);
            }
        }

        private void close_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
