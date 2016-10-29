using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL {
    public class DataTable : IGraph {

        public float[] GenerateDataTable(float[] xValues) {
            var yValues = new List<float>();
            for (var i = 0; i < xValues.Length; i++) {
                var y = 0.25 * xValues[i] + 3 * Math.Cos(100 * xValues[i]) * Math.Sin(xValues[i]);
                
                yValues.Add(Convert.ToSingle(y));
            }

            return yValues.ToArray();
        }
    }
}
