using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace HDCLUB_Stat
{
   public partial class OpenSiteForm : Form
   {
      public OpenSiteForm()
      {
         InitializeComponent();
      }

      bool loginComplete = true;

      private void loadForm(object sender, EventArgs e)
      {
         hdclubWebBrowser.ScriptErrorsSuppressed = true;
         richTextBox1.Text += "hdclubWebBrowser.ScriptErrorsSuppressed = true;";
         hdclubWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(checkLogin);
         richTextBox1.Text += "\nhdclubWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(checkLogin);";
         hdclubWebBrowser.Navigate(@"http://www.hdclub.org");
         richTextBox1.Text += "\nhdclubWebBrowser.Navigate(\"http://www.hdclub.org\");";
      }

      private void checkLogin(object sender, WebBrowserDocumentCompletedEventArgs e)
      {
         string url = e.Url.ToString();
         if (!(url.StartsWith("http://") || url.StartsWith("https://")))
         {
            // in AJAX
            return;
         }

         if (e.Url.AbsolutePath != this.hdclubWebBrowser.Url.AbsolutePath)
         {
            // IFRAME 
            return;
         }
         WebBrowser webBrowser = (WebBrowser)sender;
         foreach (HtmlElement htmlEl in webBrowser.Document.GetElementsByTagName("a"))
         {
            if (htmlEl.GetAttribute("href") == "login.php")
               loginComplete = false;
         }
         hdclubWebBrowser.DocumentCompleted -= checkLogin;
         richTextBox1.Text += "\nhdclubWebBrowser.DocumentCompleted -= checkLogin;";
         if (!loginComplete)
            loginSite();


         hdclubWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(showCurrentTorrents);
         richTextBox1.Text += "\nhdclubWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(showAllTorrents);";
         hdclubWebBrowser.Navigate(@"http://www.hdclub.org/userdetails.php?id=110353");
         richTextBox1.Text += "\nhdclubWebBrowser.Navigate(\"http://www.hdclub.org/userdetails.php?id=110353\");";
      }

      private void showCurrentTorrents(object sender, WebBrowserDocumentCompletedEventArgs e)
      {
         string url = e.Url.ToString();
         if (!(url.StartsWith("http://") || url.StartsWith("https://")))
         {
            // in AJAX
            return;
         }

         if (e.Url.AbsolutePath != this.hdclubWebBrowser.Url.AbsolutePath)
         {
            // IFRAME
            return;
         }
         WebBrowser webBrowser = (WebBrowser)sender;
         HtmlElementCollection collection = webBrowser.Document.GetElementsByTagName("span");
         foreach (HtmlElement htmlEl in webBrowser.Document.GetElementsByTagName("span"))
         {
            HtmlElementCollection imgCollection = htmlEl.GetElementsByTagName("img");
            //pics2 - current
            //pics4 - all
            if (imgCollection.Count > 0 && imgCollection[0].GetAttribute("id") == "pics4")
            {
               hdclubWebBrowser.DocumentCompleted -= showCurrentTorrents;
               richTextBox1.Text += "\nhdclubWebBrowser.DocumentCompleted -= showAllTorrents;";
               htmlEl.InvokeMember("click");
               richTextBox1.Text += "\nhtmlEl.InvokeMember(\"click\");";
               readInformation(hdclubWebBrowser);
               richTextBox1.Text += "\nreadInformation(hdclubWebBrowser);";
            }
         }
         //ALERT не должны дойти
      }

      private void readInformation(WebBrowser webBrowser)
      {
         StreamReader streamReader = new StreamReader(webBrowser.DocumentStream, Encoding.GetEncoding("windows-1251"));
         string log = "";
         BaseOfTorrents baseOfTorrents = HTMLParser.AnalyzeHTMLByStreamReader(streamReader, @"D:\HDCLUB_Base.xml", ref log);
         richTextBox1.Text += log;
         if (baseOfTorrents == null)
            richTextBox1.Text = "EXCEPTION";
      }

      private void loginSite()
      {
      }
   }
}
