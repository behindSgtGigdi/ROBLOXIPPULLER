using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GigdiPuller;
using System.Collections.Specialized;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GigdiPuller
{
    public partial class instancepullercreator : Form
    {


        public instancepullercreator()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Script_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To start. Join the roblox game and complete the steps. Invite a friend an have them do the steps. Lookup their display name in this menu to pull the IP");
        }

        private void OpenYouTubeChannel_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Process.Start("http://discord.gg/7cyrKZcj8W");
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void OpenYouTubeChannel_Click_1(object sender, EventArgs e)
        {
            Process.Start("http://discord.gg/7cyrKZcj8W");
        }
        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            string displayName = txtRobloxDisplay.Text;  // Get display name from textbox

            // Create an instance of HttpClientHandler to include cookies
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                // Use a handler to include the cookies from the current session
                handler.CookieContainer = CookieHelper.CookieContainer; // Use the cookies stored in the shared container

                using (HttpClient client = new HttpClient(handler))
                {
                    try
                    {
                        // Construct the lookup URL with the display name
                        string url = $"https://vrchatapi.onrender.com/roblox/api/v1/lookup-ip?displayName={displayName}";

                        // Send GET request to the lookup API with cookies
                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        // Deserialize the JSON response
                        string result = await response.Content.ReadAsStringAsync();
                        dynamic apiResponse = JsonConvert.DeserializeObject(result);

                        // Check if the response is successful
                        if (apiResponse.success == true)
                        {
                            // Extract the Display Name and IP Address fields
                            string fetchedDisplayName = apiResponse.displayName;
                            string ipAddress = apiResponse.ipAddress;

                            // Display the Display Name and IP Address in the respective labels
                            lblDisplay.Text = $"User Display Name: {fetchedDisplayName}";
                            lblIP.Text = $"User IP: {ipAddress}";
                        }
                        else
                        {
                            MessageBox.Show("No data found for the given display name.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions (e.g., network issues, invalid display name, etc.)
                        MessageBox.Show($"Error: {ex.Message}", "Lookup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("After purchasing license key it will be sent to your email and after you need to link it by going to our website and redeeming");
            Process.Start("https://vrchatapi.onrender.com");
            Process.Start("https://gigdipullers.mozellosite.com/home");
        }
    }
}