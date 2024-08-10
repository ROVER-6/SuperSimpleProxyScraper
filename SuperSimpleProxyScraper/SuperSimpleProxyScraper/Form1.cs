using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace SuperSimpleProxyScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = $"Welcome, {Environment.UserName}";

            label2.Text = $"Proxies: {listBox1.Items.Count}";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.proxyscrape.com/v2/?request=displayproxies&protocol=http&timeout=10000&country=all&ssl=all&anonymity=none");
            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string proxies = await response.Content.ReadAsStringAsync();
                foreach (var proxy in proxies.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
                {
                    listBox1.Items.Add(proxy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch proxies. Error: {ex.Message}");
            }

            label2.Text = $"Proxies: {listBox1.Items.Count}";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.proxyscrape.com/v2/?request=displayproxies&protocol=http&timeout=10000&country=all&ssl=all&anonymity=elite");
            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string proxies = await response.Content.ReadAsStringAsync();
                foreach (var proxy in proxies.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
                {
                    listBox1.Items.Add(proxy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch proxies. Error: {ex.Message}");
            }

            label2.Text = $"Proxies: {listBox1.Items.Count}";
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.proxyscrape.com/v2/?request=displayproxies&protocol=socks4&timeout=10000&country=all&ssl=all&anonymity=none");
            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string proxies = await response.Content.ReadAsStringAsync();
                foreach (var proxy in proxies.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
                {
                    listBox1.Items.Add(proxy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch proxies. Error: {ex.Message}");
            }

            label2.Text = $"Proxies: {listBox1.Items.Count}";
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.proxyscrape.com/v2/?request=displayproxies&protocol=socks4&timeout=10000&country=all&ssl=all&anonymity=elite");
            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string proxies = await response.Content.ReadAsStringAsync();
                foreach (var proxy in proxies.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
                {
                    listBox1.Items.Add(proxy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch proxies. Error: {ex.Message}");
            }

            label2.Text = $"Proxies: {listBox1.Items.Count}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            label2.Text = $"Proxies: {listBox1.Items.Count}";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                var allItems = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());
                Clipboard.SetText(allItems);
                MessageBox.Show("All items copied to clipboard.");
            }
            else
            {
                MessageBox.Show("The list box is empty.");
            }

            label2.Text = $"Proxies: {listBox1.Items.Count}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save ListBox Items";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = saveFileDialog.FileName;
                        var items = listBox1.Items.Cast<string>().ToList();
                        File.WriteAllLines(filePath, items);

                        MessageBox.Show("Items successfully saved to file.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save items. Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
