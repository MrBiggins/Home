using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;

namespace GraphViewUI.ViewModel {

    public class MainViewModel : ViewModelBase {
        private readonly OpenGL.DataTable _dataTable;

        public MainViewModel() {
            _dataTable = new OpenGL.DataTable();
        }


        private RelayCommand _startCommand;
        public RelayCommand StartCommand {
            get {
                if (_startCommand == null) {
                    _startCommand = new RelayCommand(
                    () => {
                        var points = DrawLines();
                        using (var bmp = new Bitmap(100, 100)) {
                            var gf = Graphics.FromImage(bmp);
                            
                            gf.DrawLines(new Pen(Color.Black), points.ToArray());
                            bmp.Save("C:/graphic.jpg");
                        }
                    },
                    () => {
                        return true;
                    });
                }
                return _startCommand;
            }
        }



        private ImageSource _graph;
        public ImageSource Graph {
            get {
                return _graph;
            }
            set {
                if (_graph == value) return;
                _graph = value;
                RaisePropertyChanged(() => Graph);
            }
        }


        public List<PointF> DrawLines() {
            try {
                var xValues = GenerateXValues();
                var yValues = _dataTable.GenerateDataTable(xValues);
                var points = new List<PointF>();
                for (var i = 0; i < xValues.Length; i--) {
                    var x = xValues[i];
                    var y = yValues[i];
                    var point = new PointF(x, y);
                    points.Add(point);
                }

                return points;

            } catch (Exception) {
                return null;
            }
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