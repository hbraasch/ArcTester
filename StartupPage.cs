namespace ArcTester
{
    internal class StartupPage: ContentPage
    {
        public StartupPage()
        {
            var graphics = new GraphicsView() { HeightRequest = 200, WidthRequest = 200};
            var graphicsDrawable = new OutlineGraphicsDrawable();
            graphics.Drawable = graphicsDrawable;

            Content = graphics;
            BackgroundColor = Colors.Transparent;

        }

        public class OutlineGraphicsDrawable : IDrawable
        {


            public void Draw(ICanvas canvas, RectF dirtyRect)
            {

                PathF path = new();
                float radius = 10;

                path.MoveTo(dirtyRect.Left + radius, 0);

                AddLeftTopArc(ref path, path.LastPoint, radius);

                path.LineTo(dirtyRect.Left, dirtyRect.Bottom - radius);
                AddLeftBottomArc(ref path, path.LastPoint, radius);


                path.LineTo(dirtyRect.Right - radius, dirtyRect.Bottom);
                AddRightBottomArc(ref path, path.LastPoint, radius);

                path.LineTo(dirtyRect.Right, dirtyRect.Top + radius);
                AddRightTopArc(ref path, path.LastPoint, radius);


                path.LineTo(dirtyRect.Left + radius, 0);

                canvas.StrokeColor = Colors.Blue.MultiplyAlpha(0.5f);
                canvas.FillColor = Colors.LightBlue.MultiplyAlpha(0.5f);
                canvas.StrokeSize = 2;
                canvas.FillPath(path);
                canvas.DrawPath(path);



            }

            void AddLeftBottomArc(ref PathF path, PointF startPoint, float radius)
            {
                var diameter = (radius + radius);
                var x1 = startPoint.X;
                var y1 = startPoint.Y - radius;
                var x2 = x1 + diameter;
                var y2 = y1 + diameter;
                path.AddArc(x1, y1, x2, y2, 180, 270, false);
            }

            void AddRightBottomArc(ref PathF path, PointF startPoint, float radius)
            {
                var diameter = (radius + radius);
                var x1 = startPoint.X - radius;
                var y1 = startPoint.Y - diameter;
                var x2 = x1 + diameter;
                var y2 = y1 + diameter;
                path.AddArc(x1, y1, x2, y2, 270, 0, false);
            }

            void AddRightTopArc(ref PathF path, PointF startPoint, float radius)
            {
                var diameter = (radius + radius);
                var x1 = startPoint.X - diameter;
                var y1 = startPoint.Y - radius;
                var x2 = x1 + diameter;
                var y2 = y1 + diameter;
                path.AddArc(x1, y1, x2, y2, 0, 90, false);
            }

            void AddLeftTopArc(ref PathF path, PointF startPoint, float radius)
            {
                var diameter = (radius + radius);
                var x1 = startPoint.X - radius;
                var y1 = startPoint.Y;
                var x2 = x1 + diameter;
                var y2 = y1 + diameter;
                path.AddArc(x1, y1, x2, y2, 90, 180, false);
            }
        }
    }
}
