using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Annotations;


namespace ElectrakHD
{
    public partial class SimplePlot : Form
    {
        public SimplePlot()
        {
            InitializeComponent();
            var myModel = new PlotModel { Title = "" };
            this.PlotView.Model = myModel;
            MainPlotModel = myModel;


        }

        bool PlotIsDirty = false;

        public PlotModel MainPlotModel;

        public void Dirty()
        {
            PlotIsDirty = true;
        }

        public void ResetPlot()
        {
            if (this.PlotView.Model != null)
            {
                this.PlotView.Model.Annotations.Clear();
                foreach (object SSS in this.PlotView.Model.Series)
                {
                    if (SSS.GetType() == typeof(LineSeries))
                    {
                        LineSeries S = (LineSeries)SSS;
                        S.Points.Clear();
                    }
                    if (SSS.GetType() == typeof(ScatterSeries))
                    {
                        ScatterSeries S = (ScatterSeries)SSS;
                        S.Points.Clear();
                    }
                }
                Dirty();
            }
        }

        private void resetChartToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ResetPlot();
        }

        private void PlotUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (PlotIsDirty == true)
            {
                this.PlotView.InvalidatePlot(true);
                PlotIsDirty = false;    
            }
        }

        private void SimplePlot_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void PlotView_Click(object sender, EventArgs e)
        {

        }

        private void autoScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PlotView.ActualModel.ResetAllAxes();
            this.PlotView.InvalidatePlot(true);
        }

        private void RightClickMenu_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
