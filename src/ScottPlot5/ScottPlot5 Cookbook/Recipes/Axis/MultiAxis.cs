﻿namespace ScottPlotCookbook.Recipes.Axis;

public class MultiAxis : ICategory
{
    public string Chapter => "Axis";
    public string CategoryName => "Advanced Axis Features";
    public string CategoryDescription => "Tick mark customization and creation of multi-Axis plots";

    public class MultiAxisQuickstart : RecipeBase
    {
        public override string Name => "Multi-Axis";
        public override string Description => "Additional axes may be added to plots. " +
            "Plottables are displayed using the coordinate system of the primary axes by default, " +
            "but any plottable can be displayed using any X and Y axis.";

        [Test]
        public override void Execute()
        {
            // plottables use the standard X and Y axes by default
            var sig1 = myPlot.Add.Signal(ScottPlot.Generate.Sin(51, mult: 0.01));
            sig1.Axes.XAxis = myPlot.XAxis; // standard X axis
            sig1.Axes.YAxis = myPlot.YAxis; // standard Y axis
            myPlot.YAxis.Label.Text = "Primary Y Axis";

            // create a second axis and add it to the plot
            ScottPlot.AxisPanels.LeftAxis yAxis2 = new();
            myPlot.YAxes.Add(yAxis2);

            // add a new plottable and tell it to use the custom Y axis
            var sig2 = myPlot.Add.Signal(ScottPlot.Generate.Cos(51, mult: 100));
            sig2.Axes.XAxis = myPlot.XAxis; // standard X axis
            sig2.Axes.YAxis = yAxis2; // custom Y axis
            yAxis2.Label.Text = "Secondary Y Axis";
        }
    }
}
