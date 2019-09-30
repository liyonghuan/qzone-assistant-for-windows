using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QzoneSpider.QzonePhoto;

namespace QzoneSpider
{
    class Constants
    {
        public const string QZONE_ALBUM_LIST = "https://h5.qzone.qq.com/proxy/domain/photo.qzone.qq.com/fcgi-bin/fcg_list_album_v3?g_tk=${G_TK}&callback=shine4_Callback&t=542028743&hostUin=${HOST_UIN}&uin=${UIN}&appid=4&inCharset=utf-8&outCharset=utf-8&source=qzone&plat=qzone&format=json&notice=0&filter=1&handset=4&pageNumModeSort=40&pageNumModeClass=15&needUserInfo=1&idcNum=4&mode=2&sortOrder=2&pageStart=${PAGE_START}&pageNum=${PAGE_NUM}&callbackFun=shine4&_=${TIME}";
        public const string QZONE_PHOTO_LIST = "https://user.qzone.qq.com/proxy/domain/photo.qzone.qq.com/fcgi-bin/cgi_list_photo?g_tk=${G_TK}&callback=shine7_Callback&t=207649744&mode=0&idcNum=4&hostUin=${HOST_UIN}&topicId=${TOPIC_ID}&noTopic=0&uin=${UIN}&pageStart=${PAGE_START}&pageNum=${PAGE_NUM}&skipCmtCount=0&singleurl=1&batchId=&notice=0&appid=4&inCharset=utf-8&outCharset=utf-8&source=qzone&plat=qzone&outstyle=json&format=json&json_esc=1&callbackFun=shine7&_=${TIME}";

        public static string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\QzoneSpider";

        public static string Path;
        public static string Cookie;
        public static int PageNum = 100;
        public static int GTk;
        public static string HostUin;
        public static string Uin;
    }
}
