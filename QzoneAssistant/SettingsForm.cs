using System;
using System.Windows.Forms;

namespace QzoneSpider
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Constants.Uin = textBoxUin.Text;
            Constants.HostUin = textBoxHostUin.Text;
            Constants.Cookie = textBoxCookie.Text;
            Constants.GTk = new SecretToken(Constants.Cookie).GetAntiCsrfToken();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBoxUin.Text = Constants.Uin;
            textBoxHostUin.Text = Constants.HostUin;
            textBoxCookie.Text = Constants.Cookie;
        }
    }
}
