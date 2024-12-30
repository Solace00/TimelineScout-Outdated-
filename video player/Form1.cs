using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        private VlcControl vlcControl;
        private VlcMediaPlayer vlcPlayer;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // You can leave this empty or add custom drawing if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure vlcPlayer is not null before checking if it's playing
            if (vlcPlayer != null)
            {
                // Toggle between Play and Pause
                if (vlcPlayer.IsPlaying())  // Corrected: Invoke IsPlaying() method
                {
                    // Pause the video if it is currently playing
                    vlcPlayer.Pause();
                    button1.Text = "Play";  // Change button text to "Play"
                }
                else
                {
                    // Play the video if it is currently paused or stopped
                    vlcPlayer.Play();
                    button1.Text = "Pause";  // Change button text to "Pause"
                }
            }
            else
            {
                MessageBox.Show("VLC Player is not initialized.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize VLC control
                vlcControl = new VlcControl();
                vlcControl.Dock = DockStyle.Fill;  // Make the VLC control fill the panel
                this.panel1.Controls.Add(vlcControl);  // Add VLC control to the panel

                // Set the VLC library directory
                vlcControl.VlcLibDirectory = new System.IO.DirectoryInfo(@"C:\Program Files\VideoLAN\VLC");

                // Ensure the VLC control is initialized
                vlcControl.EndInit();

                // Get the VLC media player instance
                vlcPlayer = vlcControl.VlcMediaPlayer;

                if (vlcPlayer == null)
                {
                    MessageBox.Show("VLC Media Player could not be initialized.");
                }
                else
                {
                    MessageBox.Show("VLC Player initialized successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing VLC: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if vlcPlayer is initialized
            if (vlcPlayer != null)
            {
                // Open a file dialog to select a video file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.mov";  // Supported video formats
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Play the selected file
                    vlcPlayer.Play(new Uri(openFileDialog.FileName));
                }
            }
            else
            {
                MessageBox.Show("VLC Player is not initialized.");
            }
        }
    }
}
