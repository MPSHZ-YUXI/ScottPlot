﻿using ScottPlot;

namespace WinForms_Demo.Demos;

public partial class SignalPerformance : Form, IDemoWindow
{
    public string Title => "Scatter Plot vs. Signal Plot";

    public string Description => "Demonstrates how Signal plots and " +
        "OpenGL-accelerated Scatter plots can display " +
        "millions of points interactively at high framerates";

    public SignalPerformance()
    {
        InitializeComponent();
        Replot();

        rbSignal.CheckedChanged += (s, e) => Replot();
        rbScatter.CheckedChanged += (s, e) => Replot();
    }

    private void Replot()
    {
        formsPlot1.Plot.Clear();
        label1.Text = "Generating random data...";
        Application.DoEvents();

        int pointCount = 1_000_000;
        double[] ys = ScottPlot.Generate.NoisySin(new Random(), pointCount);
        double[] xs = ScottPlot.Generate.Consecutive(pointCount);

        if (rbSignal.Checked)
        {
            formsPlot1.Plot.Add.Signal(ys);
            formsPlot1.Plot.TitlePanel.Label.Text = $"Signal Plot with {ys.Length:N0} Points";
            label1.Text = "Signal plots are very performant for large datasets";
        }
        else if (rbScatter.Checked)
        {
            var sp = formsPlot1.Plot.Add.Scatter(xs, ys);
            formsPlot1.Plot.TitlePanel.Label.Text = $"Scatter Plot with {ys.Length:N0} Points";
            sp.MarkerStyle = MarkerStyle.None;
            label1.Text = "Traditional Scatter plots are not performant for large datasets";
        }

        formsPlot1.Plot.AutoScale();
        formsPlot1.Refresh();
    }
}
