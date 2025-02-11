using Avalonia.Controls;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace predator_prey_tab
{
    public partial class MainWindow : Window
    {
        private static DiagramData _DiagramData = new DiagramData(0.022, 0.05, 0.5,0.00001, 100, 30, 100, 20, 100, 10);

        public MainWindow()
        {
            InitializeComponent();
            grid_main.DataContext = _DiagramData;
        }

        private void TextBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            try
            {
                DiagramData dia = new DiagramData(Convert.ToDouble(tbox_alpha.Text), Convert.ToDouble(tbox_beta.Text), Convert.ToDouble(tbox_epsilon.Text), Convert.ToDouble(tbox_omega.Text),
                    Convert.ToDouble(tbox_generationPrey.Text), Convert.ToDouble(tbox_generationPredator.Text),
                    Convert.ToDouble(tbox_generationPrey2.Text), Convert.ToDouble(tbox_generationPredator2.Text),
                    Convert.ToDouble(tbox_generationPrey3.Text), Convert.ToDouble(tbox_generationPredator3.Text));
                grid_main.DataContext = dia;
               
            }
            catch { }
        }
    }
}