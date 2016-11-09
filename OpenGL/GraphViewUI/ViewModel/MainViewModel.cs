using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GraphViewUI.ViewModel {

    public class MainViewModel : ViewModelBase {
        private readonly OpenGL.DataTable _dataTable;

        public MainViewModel() {
            _dataTable = new OpenGL.DataTable();
        }

        public PointCollection DrawLines() {
            var xValues = GenerateXValues();
            var yValues = _dataTable.GenerateDataTable(xValues);
            var points = new PointCollection();
        

            for (var i = 0; i < xValues.Length; i++) {
                var x = xValues[i];
                var y = yValues[i];
                var point = new Point(x, y);
                points.Add(point);
            }

            return points;
        }
        

        private static float[] GenerateXValues() {
            var xValues = new List<float>();

            for (float i = 0; i < 100; i++) {
                xValues.Add(i);
            }
            return xValues.ToArray();
        }
    }
}