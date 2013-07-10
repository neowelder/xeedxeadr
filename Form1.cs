using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;
namespace xeedxead
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
//            string url = "http://evilnapsis.blogspot.com/feeds/posts/default";
        }

        public SyndicationFeed loadurl(string url) {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            return feed;
        }
        
        public void getfeed(SyndicationFeed feed) {
            foreach (SyndicationItem item in feed.Items)
            {
                if (titulo != null) {
                    TreeNode post = new TreeNode();
                    TreeNode summary = new TreeNode();
                    post.Text = item.Title.Text;
                    summary.Text = item.Content.ToString();
                    post.Nodes.Add(summary);
                    titulo.Nodes.Add(post);

                }
            }
        }

        TreeNode titulo;
        private void button1_Click(object sender, EventArgs e)
        {
            if(urlbox.Text!=""){
                SyndicationFeed feed = loadurl(urlbox.Text);
                if (feed != null) {
                    titulo = new TreeNode();
                    titulo.Text = feed.Title.Text;
                    articulos.Nodes.Add(titulo);
                    getfeed(feed);
                }
            }
        }
    }
}
