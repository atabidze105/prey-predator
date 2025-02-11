using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predator_prey_tab
{
    public class DiagramData
    {
        private static double _alpha;
        private static double _beta;
        private static double _epsilon;
        private static double _omega;
        private static double _preyQuantity1;
        private static double _predatorQuantity1;
        private static double _preyQuantity2;
        private static double _predatorQuantity2;
        private static double _preyQuantity3;
        private static double _predatorQuantity3;
        private  List<ObservablePoint> _points = new();
        private static List<double> _valuePrey = new();
        private static List<double> _valuePredator = new();

        public double Alpha => _alpha;
        public double Beta => _beta;
        public double Epsilon => _epsilon;
        public double Omega => _omega;
        public double PreyQuantity1 => _preyQuantity1;        
        public double PredatorQuantity1 => _predatorQuantity1;
        public double PreyQuantity2 => _preyQuantity2;        
        public double PredatorQuantity2 => _predatorQuantity2;
        public double PreyQuantity3 => _preyQuantity3;        
        public double PredatorQuantity3 => _predatorQuantity3;

        public DiagramData(double alpha, double beta, double epsilon, double omega,
                           double preyQuantity1, double predatorQuantity1, double preyQuantity2, double predatorQuantity2, double preyQuantity3, double predatorQuantity3)
        {
            _alpha = alpha;
            _beta = beta;
            _epsilon = epsilon;
            _omega = omega;
            _preyQuantity1 = preyQuantity1;
            _predatorQuantity1 = predatorQuantity1;
            _preyQuantity2 = preyQuantity2;
            _predatorQuantity2 = predatorQuantity2;
            _preyQuantity3 = preyQuantity3;
            _predatorQuantity3 = predatorQuantity3;

            PhasePoints = [
                new LineSeries<ObservablePoint>
                {
                    Values = InitializePhazePortreit(),
                    Stroke = new SolidColorPaint(new SKColor(33, 150, 243), 4),
                    Fill = null,
                    GeometrySize = 0
                }
            ];


            InitializeGraph();

            GraphPoints = [
                new LineSeries<double> { Values = _valuePrey },
                new LineSeries<double> { Values = _valuePredator }
            ];
        }

        public ISeries[] PhasePoints { get; set; } =
            [
                new LineSeries<ObservablePoint>
                {
                }
            ];
        public ISeries[] GraphPoints { get; set; } =
            [
                new LineSeries<ObservablePoint>
                {
                }
            ];

        private  void PointsInserting(double preyQuantity, double predatorQuantity)
        {
            List<ObservablePoint> generation = new();
            generation.Add(new ObservablePoint()
            {
                X = preyQuantity,
                Y = predatorQuantity
            });

            for (int i = 0; i < 150; i++)
            {
                double preyQuantity1 = Math.Round((double)((_epsilon - _alpha * generation[i].Y) * generation[i].X + generation[i].X), 2);
                generation.Add(new ObservablePoint()
                {
                    X = preyQuantity1,
                    Y = Math.Round((double)((_omega * preyQuantity1 - _beta) * generation[i].Y + generation[i].Y), 2)
                });
            }
            _points.AddRange(generation);
        }

        private  List<ObservablePoint> InitializePhazePortreit()
        {
            PointsInserting(_preyQuantity1, _predatorQuantity1);
            PointsInserting(_preyQuantity2, _predatorQuantity2);
            PointsInserting(_preyQuantity3, _predatorQuantity3);
            return _points;
        }

        private void InitializeGraph()
        {

            foreach (ObservablePoint point in _points)
            {
                _valuePrey.Add((double)point.X);
                _valuePredator.Add((double)point.Y);
            }
        }
    }
}
