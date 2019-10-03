using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using static QzoneSpider.QzonePhoto;
using static System.Collections.Generic.Dictionary<QzoneSpider.AlbumListModeSort, QzoneSpider.QzonePhoto.Photo[]>;

namespace QzoneSpider
{
    class PhotoDownload
    {
        private Dictionary<AlbumListModeSort, Photo[]> Dictionary = new Dictionary<AlbumListModeSort, Photo[]>();
        private AlbumListModeSort[] Albums;
        private MainForm MainForm;

        public PhotoDownload(MainForm mainForm)
        {
            MainForm = mainForm;
        }

        public void Start(AlbumListModeSort[] albums)
        {
            Albums = albums;
            ThreadStart thStart = new ThreadStart(Download);//threadStart委托 
            Thread thread = new Thread(thStart);
            thread.Priority = ThreadPriority.Highest;
            thread.IsBackground = true; //关闭窗体继续执行
            thread.Start();
        }

        private void Download()
        {
            Dictionary.Clear();

            TipsPhotoDownloadDelegate f = new TipsPhotoDownloadDelegate(MainForm.TipsPhotoDownload);
            MainForm.Invoke(f, new object[] { "正在采集相册数据..." });
            foreach (AlbumListModeSort Album in Albums)
            {
                string url = Constants.QZONE_PHOTO_LIST;
                url = url.Replace("${G_TK}", Constants.GTk + "");
                url = url.Replace("${UIN}", Constants.Uin);
                url = url.Replace("${HOST_UIN}", Constants.HostUin);
                url = url.Replace("${PAGE_NUM}", Constants.PageNum.ToString());
                url = url.Replace("${TOPIC_ID}", Album.id);
                url = url.Replace("${TIME}", GetTimeStamp());
                int pageStart = 0;
                List<Photo> list = new List<Photo>();
                while (true)
                {
                    Photo[] photoList = null;
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

                            System.Net.HttpWebResponse response;
                            response = (System.Net.HttpWebResponse)request.GetResponse();
                            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            string responseText = myreader.ReadToEnd();
                            myreader.Close();

                            JavaScriptSerializer js = new JavaScriptSerializer();//实例化一个能够序列化数据的类
                            QzonePhoto qzonePhoto = js.Deserialize<QzonePhoto>(responseText); //将json数据转化为对象类型并赋值给list
                            photoList = qzonePhoto.data.photoList;
                            if (photoList != null)
                            {
                                list.AddRange(photoList);
                            }
                            break;
                        }
                        catch (Exception E)
                        {
                            i++;
                            Console.WriteLine(E.StackTrace);
                        }
                    } while (i < 5);

                    Thread.Sleep(1000);
                    if (photoList == null || photoList.Length < Constants.PageNum)
                    {
                        break;
                    }
                    else
                    {
                        pageStart += Constants.PageNum;
                    }
                }
                Dictionary.Add(Album, list.ToArray());
            }
            TipsPhotoDownloadDelegate ff = new TipsPhotoDownloadDelegate(MainForm.TipsPhotoDownload);
            MainForm.Invoke(ff, new object[] { "相册数据采集完毕，即将开始下载相片..." });
            DownloadDitionary();
        }

        private void DownloadDitionary()
        {
            Dictionary<AlbumListModeSort, Photo[]>.KeyCollection albums = Dictionary.Keys;
            foreach (AlbumListModeSort album in albums)
            {
                string photoPath = Constants.Path + "\\" + replaceInvalidChar(album.name) + "\\";
                DirectoryInfo di = new DirectoryInfo(photoPath);
                di.Create();
                //开始下载
                Photo[] photos = Dictionary[album];
                int count = photos.Length;
                int i = 1;
                foreach (Photo photo in photos)
                {
                    //整理地址
                    string pUrl;
                    if (photo.origin_url != "")
                    {
                        pUrl = photo.origin_url;
                    }
                    else if (photo.raw != "")
                    {
                        pUrl = photo.raw;
                    }
                    else
                    {
                        pUrl = photo.url;
                    }

                    string filePath = photoPath + i + ".jpg";
                    if (!System.IO.File.Exists(filePath))
                    {
                        //判断文件是否存在
                        HttpDownloadFile(pUrl, filePath);
                    }

                    TipsPhotoDownloadDelegate pdd = new TipsPhotoDownloadDelegate(MainForm.TipsPhotoDownload);
                    if (i == count)
                    {
                        MainForm.Invoke(pdd, new object[] { album.name + "下载完成" } );
                    }
                    else
                    {
                        MainForm.Invoke(pdd, new object[] { "正在下载《" + album.name + "》，当前进度：" + i + "/" + count } );
                    }
                    i++;
                }
            }

            TipsPhotoDownloadDelegate ff = new TipsPhotoDownloadDelegate(MainForm.TipsPhotoDownload);
            MainForm.Invoke(ff, new object[] { "相册批量下载完成" });
        }

        private static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private delegate void TipsPhotoDownloadDelegate(string tips);

        private string replaceInvalidChar(string illegal)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            foreach (char c in invalid)
            {
                illegal = illegal.Replace(c.ToString(), "");
            }
            return illegal;
        }

        private void HttpDownloadFile(string url, string path)
        {
            int i = 0;
            do
            {
                try
                {
                    // 设置参数
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    request.Headers.Add(System.Net.HttpRequestHeader.Cookie, Constants.Cookie);
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                    request.Headers.Add("Accept-Language: zh-CN,zh;q=0.9");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
                    request.Headers.Add("Cache-Control: max-age=0");
                    //发送请求并获取相应回应数据
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    //直到request.GetResponse()程序才开始向目标网页发送Post请求
                    Stream responseStream = response.GetResponseStream();
                    //创建本地文件写入流
                    Stream stream = new FileStream(path, FileMode.Create);
                    byte[] bArr = new byte[8 * 1024 * 1024];
                    int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    while (size > 0)
                    {
                        stream.Write(bArr, 0, size);
                        size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    }
                    stream.Close();
                    responseStream.Close();
                    break;
                }
                catch(Exception E)
                {
                    i++;
                    Console.WriteLine(E.StackTrace);
                }
            } while (i < 5);
        }
    }
}
