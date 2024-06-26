﻿using CheckersProject.View;
using CheckersProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckersProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            InitializeMediaPlayer();
        }

        private void InitializeMediaPlayer()
        {
            mediaPlayer.Open(new Uri("C:\\Users\\Filip\\Desktop\\facultate\\musicTwixt.mp3", UriKind.Relative));
            mediaPlayer.Volume = 0.0; // Setează volumul inițial
            mediaPlayer.Play();
        }

        public void SetMediaPlayerVolume(double volume)
        {
            mediaPlayer.Volume = volume;
        }
    }

}
