using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    class Graph
    {
        public string test = "<html style='background-color: Gray;'><head><script src='https://cdn.plot.ly/plotly-latest.min.js'></script><script src = 'https://code.jquery.com/jquery-3.2.1.min.js' integrity = 'sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=' crossorigin = 'anonymous'></script></head><body style='margin: 0;'><div id='my-graph' style='width:100%; height: 200px;'></div><script>$(document).ready(function() { Plotly.plot('my-graph', [{ x: [1,2,3,4,5], y: [1,2,4,8,16] }], { margin: {t:50, b:50, l: 25, r: 25, pad: 0}, showLegend: false, autosize: true, plot_bgcolor: '#808080', paper_bgcolor: '#808080' }, {scrollZoom: true, displayModeBar: false}); });</script></body></html>";
    }
}
