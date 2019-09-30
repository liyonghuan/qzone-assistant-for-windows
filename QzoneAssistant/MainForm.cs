using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace QzoneSpider
{
    public partial class MainForm : Form
    {
        private List<AlbumListModeSort> list = new List<AlbumListModeSort>();
        private string pathTips;
        private bool isLoading = false;
        
        public MainForm()
        {
            InitializeComponent();

        }

        private void MenuItemFileSetting_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsFormClose);
            sf.Show();
        }

        private void MenuItemFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SettingsFormClose(object sender, EventArgs e)
        {
            RequestAlbum();
        }

        private void RequestAlbum()
        {
            list.Clear();
            flowLayoutPanel1.Controls.Clear();
            isLoading = true;

            Constants.Path = Constants.BasePath + "\\" + Constants.HostUin;
            pathTips = "默认路径：" + Constants.Path;
            StatusLabelSavePath.Text = pathTips;
    
            statusStrip1.Items[0].Text = "相册信息加载中...";
            ThreadStart thStart = new ThreadStart(Download);//threadStart委托 
            Thread thread = new Thread(thStart);
            thread.Priority = ThreadPriority.Highest;
            thread.IsBackground = true; //关闭窗体继续执行
            thread.Start();
        }

        public void Download()
        {
            string url = Constants.QZONE_ALBUM_LIST;
            url = url.Replace("${G_TK}", Constants.GTk + "");
            url = url.Replace("${UIN}", Constants.Uin);
            url = url.Replace("${HOST_UIN}", Constants.HostUin);
            url = url.Replace("${PAGE_NUM}", Constants.PageNum.ToString());
            url = url.Replace("${TIME}", GetTimeStamp());
            int pageStart = 0;
            List<AlbumListModeSort> list = new List<AlbumListModeSort>();
            while(true)
            {
                AlbumListModeSort[] albumList = null;
                int i = 0;
                do
                {
                    try
                    {
                        string tmbUrl = url.Replace("${PAGE_START}", pageStart.ToString());
                        System.Net.HttpWebRequest request;
                        // 创建一个HTTP请求
                        request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(tmbUrl);
                        request.Method = "get";
                        request.Timeout = 5000;
                        request.Headers.Add(System.Net.HttpRequestHeader.Cookie, Constants.Cookie);
                        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                        request.Headers.Add("accept-Language: zh-CN,zh;q=0.9");
                        request.Headers.Add("upgrade-insecure-requests: 1");
                        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
                        request.Headers.Add("cache-control: max-age=0");
                        //request.Headers.Add("accept-encoding: gzip, deflate, br");
                        //request.Referer = "referer: https://user.qzone.qq.com/proxy/domain/qzs.qq.com/qzone/photo/v7/page/photo.html?init=photo.v7/module/albumList/index&navBar=1&g_iframeUser=1&g_iframedescend=1";

                        System.Net.HttpWebResponse response;
                        response = (System.Net.HttpWebResponse)request.GetResponse();
                        System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        string responseText = myreader.ReadToEnd();
                        myreader.Close();

                        JavaScriptSerializer js = new JavaScriptSerializer();//实例化一个能够序列化数据的类
                        QzoneAlbum qzoneAlbum = js.Deserialize<QzoneAlbum>(responseText); //将json数据转化为对象类型并赋值给list
                        albumList = qzoneAlbum.data.albumList;
                        if (albumList != null)
                        {
                            list.AddRange(albumList);
                        }
                        break;
                    }
                    catch (Exception E)
                    {
                        i++;
                        Console.WriteLine(E.StackTrace);
                    }
                } while (i < 5);
                
                if (albumList == null || albumList.Length < Constants.PageNum)
                {
                    break;
                } else
                {
                    pageStart += Constants.PageNum;
                }
            }

            isLoading = false;
            CallBackDelegate callBackDelegate = new CallBackDelegate(RequestAlbumSuccess);
            Invoke(callBackDelegate, new object[] { list.ToArray() });
        }

        private void RequestAlbumSuccess(AlbumListModeSort[] albumList)
        {
            if (albumList != null && albumList.Length > 0)
            {
                list.AddRange(albumList);
                foreach (AlbumListModeSort al in albumList)
                {
                    UserControl1 userControl1 = new UserControl1();
                    userControl1.MouseEnter += UserControl1_MouseEnter;
                    userControl1.MouseLeave += UserControl1_MouseLeave;
                    AlbumMouseDown amd = new AlbumMouseDown(al, OnMouseRightDown);
                    userControl1.MouseDown += new MouseEventHandler(amd.UserControl1_MouseDown);
                    userControl1.LoadAsync(al.pre);
                    userControl1.SetText(al.name);
                    flowLayoutPanel1.Controls.Add(userControl1);
                }
                flowLayoutPanel1.AutoScroll = true;
            }
            StatusLabelSavePath.Text = pathTips;
        }

        public delegate void CallBackDelegate(AlbumListModeSort[] albumList);

        public class AlbumMouseDown
        {
            private OnMouseRightDownDelegate onMouseRightDownDelegate;
            private AlbumListModeSort albumListModeSort;

            public AlbumMouseDown(AlbumListModeSort albumListModeSort, OnMouseRightDownDelegate onMouseRightDownDelegate)
            {
                this.onMouseRightDownDelegate = onMouseRightDownDelegate;
                this.albumListModeSort = albumListModeSort;
            }
            
            public void UserControl1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    onMouseRightDownDelegate(albumListModeSort);
                }
            }
        }

        public delegate void OnMouseRightDownDelegate(AlbumListModeSort albumListModeSort);

        public void OnMouseRightDown(AlbumListModeSort albumListModeSort)
        {
            contextMenuStrip1.Tag = albumListModeSort;
            contextMenuStrip1.Show(MousePosition);
        }

        private void UserControl1_MouseLeave(object sender, EventArgs e)
        {
            UserControl1 userControl1 = sender as UserControl1;
            userControl1.BackColor = System.Drawing.Color.White;
        }

        private void UserControl1_MouseEnter(object sender, EventArgs e)
        {
            UserControl1 userControl1 = sender as UserControl1;
            userControl1.BackColor = System.Drawing.Color.Gray;
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //获取Configuration对象
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //根据Key读取<add>元素的Value
            Constants.Uin = config.AppSettings.Settings["uin"].Value;
            Constants.HostUin = config.AppSettings.Settings["host_uin"].Value;
            Constants.Cookie = config.AppSettings.Settings["cookie"].Value;
            Constants.GTk = int.Parse(config.AppSettings.Settings["g_tk"].Value);
            Constants.Path = Constants.BasePath + "\\" + Constants.HostUin;

            pathTips = "默认路径：" + Constants.Path;
            StatusLabelSavePath.Text = pathTips;

            RequestAlbum();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //获取Configuration对象
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //写入<add>元素的Value
            config.AppSettings.Settings["uin"].Value = Constants.Uin;
            config.AppSettings.Settings["host_uin"].Value = Constants.HostUin;
            config.AppSettings.Settings["cookie"].Value = Constants.Cookie;
            config.AppSettings.Settings["g_tk"].Value = Constants.GTk.ToString();
            //增加<add>元素
            //config.AppSettings.Settings.Add("url", "http://www.fx163.net");
            //删除<add>元素
            //config.AppSettings.Settings.Remove("name");
            //一定要记得保存，写不带参数的config.Save()也可以
            config.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void MenuItemDownload_Click(object sender, EventArgs e)
        {
            AlbumListModeSort albumListModeSort = contextMenuStrip1.Tag as AlbumListModeSort;
            PhotoDownload pd = new PhotoDownload(this);
            pd.Start(new AlbumListModeSort[] { albumListModeSort });
        }

        public void TipsPhotoDownload(string tips)
        {
            StatusLabelDownload.Text = tips;
        }

        private void MenuItemAllDownload_Click(object sender, EventArgs e)
        {
            if (isLoading)
            {
                MessageBox.Show("相册信息正在加载中，请稍后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhotoDownload pd = new PhotoDownload(this);
            pd.Start(list.ToArray());
        }
    }
}
