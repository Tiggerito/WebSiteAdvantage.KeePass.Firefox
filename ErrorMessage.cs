using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WebSiteAdvantage.KeePass.Firefox
{
    public partial class ErrorMessage : Form
    {
        public ErrorMessage()
        {
            InitializeComponent();
        }

        public string Message {
            get
            {
            	return this.labelMessage.Text;
            }
            set {
                this.labelMessage.Text = value;
            }
        }

        public string Log
        {
            get
            {
                return this.textBoxLog.Text;
            }
            set
            {
                this.textBoxLog.Text = value;
            }
        }

        public static void ShowErrorMessage(string toolName, string message, Exception ex)
        {

            ErrorMessage dialog = new ErrorMessage();

            dialog.Message = message;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Message: " + message);
            sb.AppendLine("Program: " + toolName);
             sb.AppendLine("Version: " + KeePassUtilities.Version);

            
             sb.AppendLine("Assembly Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

             if (KeePassUtilities.Is64Bit)
                 sb.AppendLine("Processor: 64bit");
             else
                 sb.AppendLine("Processor: not 64bit");

             sb.AppendLine("Processor Architecture: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().ProcessorArchitecture.ToString());


            if (ex !=null)
            {
                sb.AppendLine();
                sb.AppendLine("Exception");
                sb.AppendLine(ex.Message);
                sb.AppendLine("Source: "+ex.Source);
                sb.AppendLine(ex.StackTrace);

                if (ex.InnerException!=null)
                {
                sb.AppendLine();

                sb.AppendLine("Inner Exception");
                sb.AppendLine(ex.InnerException.Message);
                sb.AppendLine("Source: "+ex.InnerException.Source);
                sb.AppendLine(ex.InnerException.StackTrace);
                }
            }
            dialog.Log = sb.ToString();

            dialog.ShowDialog();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:tony@websiteadvantage.com.au");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#heading-trouble");
        }
    }
}
