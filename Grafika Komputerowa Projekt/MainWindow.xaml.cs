using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Grafika_Komputerowa_Projekt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            onStart();
        }

        // ==================================================
        // ================ GLOBAL VARIABLES ================
        // ==================================================

        Point startPoint;
        Point currentPoint;
        UIElement selectedObject;
        List<List<UIElement>> layersElements = new List<List<UIElement>>();
        List<double> layersOpacity = new List<double>();
        String currentTool;
        Color currentColor;
        int currentThickness;
        int currentLayer;
        bool isDragging = false;
        bool isFinalized = true;

        // ==================================================
        // ================ CANVAS FUNCTIONS ================
        // ==================================================

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // LEFT BUTTON PRESSED
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isDragging = true;
                startPoint = e.GetPosition(paintSurface);

                if (currentTool == "pen")
                {
                    createObject<Polyline>();
                    Polyline newPenStroke = (Polyline)layersElements[currentLayer].Last();
                    newPenStroke.Points.Add(startPoint);
                }

                else if (currentTool == "rectangle")
                {
                    createObject<Rectangle>();
                }

                else if (currentTool == "triangle")
                {
                    createObject<Polygon>();
                }

                else if (currentTool == "circle")
                {
                    createObject<System.Windows.Shapes.Ellipse>();
                }

                else if (currentTool == "addLine")
                {
                    createObject<Line>();
                    layersElements[currentLayer].Last().MouseDown += Line_MouseDown;
                }

                else if (currentTool == "path")
                {
                    // Create a new path
                    if (isFinalized == true)
                    {
                        createNewPath();
                    }
                    // Add a new segment to the existing path
                    else if (layersElements[currentLayer].LastOrDefault() is System.Windows.Shapes.Path lastPath)
                    {
                        drawPath((PathFigure)lastPath.Tag); 
                    }
                }

                else if (currentTool == "polygon")
                {
                    // create a new polygon
                    if (isFinalized == true)
                    {
                        createObject<Polygon>();
                        Polygon newPolygon = (Polygon)layersElements[currentLayer].Last();
                        newPolygon.Points.Add(currentPoint); // Add the first point
                        newPolygon.Points.Add(currentPoint); // Add a second point for preview
                        isFinalized = false;
                    }
                    // add a point to an existing polygon
                    else if (layersElements[currentLayer].LastOrDefault() is Polygon lastPolygon)
                    {
                        lastPolygon.Points.Add(currentPoint);
                    }
                }
            }

            // RIGHT BUTTON PRESSED
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                // Set the flag to finalize the path
                isFinalized = true;
                if (layersElements[currentLayer].LastOrDefault() is System.Windows.Shapes.Path lastPath && lastPath.Tag is PathFigure pathFigure)
                {
                    // Remove the preview segment if it exists
                    if (pathFigure.Segments.LastOrDefault() is LineSegment lastSegment)
                    {
                        pathFigure.Segments.Remove(lastSegment);
                    }
                }
            }
        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            currentPoint = e.GetPosition(paintSurface);
            // IS DRAGGING
            if (e.LeftButton == MouseButtonState.Pressed && isDragging == true)
            {
                if (currentTool == "pen")
                {
                    Polyline currentPolyline = (Polyline)layersElements[currentLayer].Last();
                    Point lastPoint = currentPolyline.Points.LastOrDefault();
                    if ((Math.Abs(currentPoint.X - lastPoint.X) > 2 || Math.Abs(currentPoint.Y - lastPoint.Y) > 2))
                    {
                        drawPenStroke(currentPoint, currentPolyline);
                    }
                }

                else if (currentTool == "rectangle")
                {
                    drawRectangle(startPoint, currentPoint, (Rectangle)layersElements[currentLayer].Last());
                }

                else if (currentTool == "triangle")
                {
                    drawTriangle(startPoint, currentPoint, (Polygon)layersElements[currentLayer].Last());
                }

                else if (currentTool == "circle")
                {
                    drawCircle(startPoint, currentPoint, (System.Windows.Shapes.Ellipse)layersElements[currentLayer].Last());
                }

                else if (currentTool == "addLine")
                {
                    drawLine(startPoint, currentPoint, (Line)layersElements[currentLayer].Last());
                }
            }
            // IS NOT DRAGGING
            else
            {
                // add preview of a new path segment
                if (currentTool == "path" && layersElements[currentLayer].LastOrDefault() is System.Windows.Shapes.Path lastPath && lastPath.Tag is PathFigure pathFigure && isFinalized == false)
                {
                    if (pathFigure.Segments.LastOrDefault() is LineSegment lastSegment)
                    {
                        lastSegment.Point = currentPoint;
                    }
                    else
                    {
                        LineSegment previewSegment = new LineSegment(currentPoint, true);
                        pathFigure.Segments.Add(previewSegment);
                    }
                }
                // add preview of a new polygon point
                else if (currentTool == "polygon" && layersElements[currentLayer].LastOrDefault() is Polygon lastPolygon && isFinalized == false)
                {
                    lastPolygon.Points.RemoveAt(lastPolygon.Points.Count - 1);
                    lastPolygon.Points.Add(currentPoint);
                }
            }
        }

        private void Canvas_MouseUp_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDragging = false;
            Mouse.Capture(null);
        }

        // ==================================================
        // ============== TOOLS FUNCTIONALITY ===============
        // ==================================================

        void drawPenStroke(Point currentPoint, Polyline polyline)
        {
            polyline.Points.Add(currentPoint);
        }

        void drawRectangle(Point startPoint, Point currentPoint, Rectangle rect)
        {
            double x = Math.Min(startPoint.X, currentPoint.X);
            double y = Math.Min(startPoint.Y, currentPoint.Y);

            double width = Math.Abs(currentPoint.X - startPoint.X);
            double height = Math.Abs(currentPoint.Y - startPoint.Y);
            rect.Width = width;
            rect.Height = height;

            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
        }

        void drawTriangle(Point startPoint, Point currentPoint, Polygon triangle)
        {
            // Ensure p1 is the bottom-left and p2 is the bottom-right
            Point bottomLeft = new Point(Math.Min(startPoint.X, currentPoint.X), Math.Max(startPoint.Y, currentPoint.Y));
            Point bottomRight = new Point(Math.Max(startPoint.X, currentPoint.X), Math.Max(startPoint.Y, currentPoint.Y));
            Point middlePoint = new Point((startPoint.X + currentPoint.X) / 2, Math.Min(startPoint.Y, currentPoint.Y));

            triangle.Points.Clear();
            triangle.Points.Add(bottomLeft); // Bottom-left vertex
            triangle.Points.Add(bottomRight); // Bottom-right vertex
            triangle.Points.Add(middlePoint); // Top vertex
        }

        void drawCircle(Point startPoint, Point currentPoint, System.Windows.Shapes.Ellipse circle)
        {
            double radius = Math.Sqrt(Math.Pow(currentPoint.X - startPoint.X, 2) + Math.Pow(currentPoint.Y - startPoint.Y, 2)) / 2;
            Point center = new Point((startPoint.X + currentPoint.X) / 2, (startPoint.Y + currentPoint.Y) / 2);

            circle.Width = radius * 2;
            circle.Height = radius * 2;
            Canvas.SetLeft(circle, center.X - radius);
            Canvas.SetTop(circle, center.Y - radius);
        }

        void drawLine(Point startPoint, Point currentPoint, Line line)
        {
            line.X1 = startPoint.X;
            line.Y1 = startPoint.Y;
            line.X2 = currentPoint.X;
            line.Y2 = currentPoint.Y;
        }

        void Line_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentTool == "editLine")
            {
                Line line = sender as Line;

                if (line != null)
                {
                    // If different line has been selected previously, delete it's edit points
                    if ((Line)selectedObject != line && selectedObject != null)
                    {
                        removeLastCanvasElement();
                        removeLastCanvasElement();
                    }

                    selectedObject = line;

                    CreateDraggablePoint(line.X1, line.Y1, line, true);
                    CreateDraggablePoint(line.X2, line.Y2, line, false);
                }
            }
        }

        void CreateDraggablePoint(double x, double y, Line line, bool isStartPoint)
        {
            System.Windows.Shapes.Ellipse point = new System.Windows.Shapes.Ellipse
            {
                Stroke = SystemColors.WindowFrameBrush,
                Fill = SystemColors.WindowFrameBrush,
                StrokeThickness = 2,
                Height = 10,
                Width = 10,
            };
            Canvas.SetLeft(point, x - point.Width / 2);
            Canvas.SetTop(point, y - point.Height / 2);

            point.MouseMove += (s, e) => Edit_Point(s, e, line, isStartPoint);

            paintSurface.Children.Add(point);
            layersElements[currentLayer].Add(point);
        }

        void Edit_Point(object sender, MouseEventArgs e, Line line, bool isStartPoint)
        {
            System.Windows.Shapes.Ellipse editPoint = sender as System.Windows.Shapes.Ellipse;
            if (isDragging == true)
            {
                Mouse.Capture(editPoint);

                Point currentPosition = e.GetPosition(paintSurface);

                Canvas.SetLeft(editPoint, currentPosition.X - editPoint.Width / 2);
                Canvas.SetTop(editPoint, currentPosition.Y - editPoint.Width / 2);

                if (isStartPoint)
                {
                    line.X1 = currentPosition.X;
                    line.Y1 = currentPosition.Y;
                }
                else
                {
                    line.X2 = currentPosition.X;
                    line.Y2 = currentPosition.Y;
                }
            }
        }

        void createNewPath()
        {
            createObject<System.Windows.Shapes.Path>();
            PathFigure newPathFigure = new PathFigure { StartPoint = startPoint };
            PathGeometry newPathGeometry = new PathGeometry();
            newPathGeometry.Figures.Add(newPathFigure);
            System.Windows.Shapes.Path newPath = (System.Windows.Shapes.Path)layersElements[currentLayer].Last();
            newPath.Data = newPathGeometry;
            newPath.Tag = newPathFigure;
            isFinalized = false;
        }

        void drawPath(PathFigure pathFigure)
        {
            LineSegment lineSegment = new LineSegment(startPoint, true);
            pathFigure.Segments.Add(lineSegment);
        }

        // ==================================================
        // =============== UTILITY FUNCTIONS ================
        // ==================================================
        void onStart()
        {
            // Add first layer
            addLayer();

            // Set current layer
            currentLayer = 0;

            // Set default thickness
            currentThickness = 2;

            // Set default tool
            currentTool = "pen";

            // Set default color
            currentColor = Colors.Black;
        }

        void removeLastCanvasElement()
        {
            paintSurface.Children.Remove(layersElements[currentLayer][layersElements[currentLayer].Count - 1]);
            layersElements[currentLayer].RemoveAt(layersElements[currentLayer].Count - 1);
        }

        void changeTool(String newToolName)
        {
            if (currentTool == "editLine" && newToolName != "editLine")
            {
                removeLastCanvasElement();
                removeLastCanvasElement();
            }

            currentTool = newToolName;
        }

        void createObject<T>() where T : Shape, new()
        {
            T shapeObject = new T
            {
                Stroke = new SolidColorBrush(currentColor),
                StrokeThickness = currentThickness,
            };

            paintSurface.Children.Add(shapeObject);
            layersElements[currentLayer].Add(shapeObject);
        }

        void onColorSelected(Color color)
        {
            currentColor = color;
        }

        void displayImageWithFilter(string imagePath, int filter)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(imagePath);
            if (filter == 1)
            {
                Image<Gray, byte> img_final = img.Convert<Gray, byte>();
                CvInvoke.Imshow("Image", img_final);
            }
            else if (filter == 2)
            {
                Image<Gray, Single> img_final = (img.Convert<Gray, byte>().Sobel(1, 0, 5));
                CvInvoke.Imshow("Image", img_final);
            }
            CvInvoke.WaitKey(0);
        }

        void displayImage(string path)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(path);
            CvInvoke.Imshow("Image", img);
            CvInvoke.WaitKey(0);
        }

        void addLayer()
        {
            // Horizontal StackPanel that will contain layer functionality
            StackPanel layerFunctionalityPanel = new StackPanel();
            layerFunctionalityPanel.Orientation = Orientation.Horizontal;

            // Button to switch to selected layer
            Button newLayerButton = new Button();
            int layerNumber = layersPanel.Children.Count;
            newLayerButton.Name = $"layer{layerNumber}Button";
            newLayerButton.Content = $"Layer {layerNumber}";
            newLayerButton.FontSize = 30;
            newLayerButton.Margin = new Thickness(2);
            if (layerNumber != 0)
            {
                newLayerButton.Foreground = Brushes.LawnGreen;
                newLayerButton.Background = Brushes.Black;
            }
            else
            {
                newLayerButton.Foreground = Brushes.Black;
                newLayerButton.Background = Brushes.LawnGreen;
            }
            newLayerButton.Click += (sender, e) => switchToLayer(sender, e, newLayerButton, layerNumber);

            // Check box to make layer visible or not
            CheckBox layerCheckBox = new CheckBox();
            layerCheckBox.Margin = new Thickness(5, 0, 0, 0);
            layerCheckBox.LayoutTransform = new ScaleTransform(2.0, 2.0);
            layerCheckBox.VerticalAlignment = VerticalAlignment.Center;
            layerCheckBox.HorizontalAlignment = HorizontalAlignment.Center;
            layerCheckBox.IsChecked = true;
            layerCheckBox.Checked += (sender, e) => changeLayerState(sender, e, layerCheckBox, layerNumber);
            layerCheckBox.Unchecked += (sender, e) => changeLayerState(sender, e, layerCheckBox, layerNumber);

            // Add everything
            layerFunctionalityPanel.Children.Add(newLayerButton);
            layerFunctionalityPanel.Children.Add(layerCheckBox);
            layersPanel.Children.Add(layerFunctionalityPanel);
            layersElements.Add(new List<UIElement>());
            layersOpacity.Add(1.0);
        }

        void switchToLayer(object sender, RoutedEventArgs e, Button currentLayerButton, int layerNumber)
        {
            // Disable selection of previous layer button
            foreach (var child in layersPanel.Children)
            {
                if (child is StackPanel panel && panel.Children[0] is Button button && button.Background == Brushes.LawnGreen)
                {
                    button.Background = Brushes.Black;
                    button.Foreground = Brushes.LawnGreen;
                }
            }

            // Change layer
            currentLayer = layerNumber;

            // Enable selection of a new layer button
            currentLayerButton.Background = Brushes.LawnGreen;
            currentLayerButton.Foreground = Brushes.Black;

            // Set correct opacity slider value
            opacitySlider.Value = layersOpacity[currentLayer];
        }

        private void changeLayerState(object sender, RoutedEventArgs e, CheckBox layerCheckBoxName, int layerNumber)
        {
            if (layerCheckBoxName.IsChecked == false)
            {
                foreach (UIElement element in layersElements[layerNumber])
                {
                    element.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                foreach (UIElement element in layersElements[layerNumber])
                {
                    element.Visibility = Visibility.Visible;
                }
            }
        }

        void changeOpacity(double opacityValue)
        {
            if (layersElements.Count != 0)
            {
                foreach (UIElement element in layersElements[currentLayer])
                {
                    element.Opacity = opacityValue;
                }

                layersOpacity[currentLayer] = opacityValue;
            }
        }

        void setThickness(int thickness)
        {
            currentThickness = thickness;
        }

        void undoLastAction()
        {
            paintSurface.Children.RemoveAt(paintSurface.Children.Count - 1);
            layersElements[currentLayer].RemoveAt(layersElements[currentLayer].Count - 1);
        }

        // ==================================================
        // ============ UI BUTTONS FUNCTIONALITY ============
        // ==================================================

        private void onPenButtonPressed(object sender, RoutedEventArgs e)
        {
            changeTool("pen");
        }
        private void onRectangleButtonPressed(object sender, RoutedEventArgs e)
        {
            changeTool("rectangle");
        }
        private void onTriangleButtonPressed(object sender, RoutedEventArgs e)
        {
            changeTool("triangle");
        }
        private void onCircleButtonPressed(object sender, RoutedEventArgs e)
        {
            changeTool("circle");
        }
        private void onPolygonButtonPressed(object sender, RoutedEventArgs e)
        {
            currentTool = "polygon";
        }
        private void onAddLineButtonPressed(object sender, RoutedEventArgs e)
        {
            changeTool("addLine");
        }
        private void onEditLineButtonPressed(object sender, RoutedEventArgs e)
        {
            changeTool("editLine");
        }
        private void onPathButtonPressed(object sender, RoutedEventArgs e)
        {
            changeTool("path");
        }
        private void onColorButtonPressed(object sender, RoutedEventArgs e)
        {
            ColorPickerWindow colorPickerWindow = new();
            colorPickerWindow.ColorSelected += onColorSelected;
            colorPickerWindow.Show();
        }
        private void onShowImageButtonPressed(object sender, RoutedEventArgs e)
        {
            displayImage("test.jpg");
        }
        private void onShowImageWithFilter1ButtonPressed(object sender, RoutedEventArgs e)
        {
            displayImageWithFilter("test.jpg", 1);
        }
        private void onShowImageWithFilter2ButtonPressed(object sender, RoutedEventArgs e)
        {
            displayImageWithFilter("test.jpg", 2);
        }
        private void onAddLayerButtonPressed(object sender, RoutedEventArgs e)
        {
            addLayer();
        }
        private void onOpacitySliderChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changeOpacity(opacitySlider.Value);
        }
        private void onThickness2ButtonPressed(object sender, RoutedEventArgs e)
        {
            setThickness(2);
        }
        private void onThickness4ButtonPressed(object sender, RoutedEventArgs e)
        {
            setThickness(4);
        }
        private void onThickness8ButtonPressed(object sender, RoutedEventArgs e)
        {
            setThickness(8);
        }
        private void onThickness16ButtonPressed(object sender, RoutedEventArgs e)
        {
            setThickness(16);
        }
        private void onThickness32ButtonPressed(object sender, RoutedEventArgs e)
        {
            setThickness(32);
        }
        private void onUndoButtonPressed(object sender, RoutedEventArgs e)
        {
            undoLastAction();
        }
    }
}