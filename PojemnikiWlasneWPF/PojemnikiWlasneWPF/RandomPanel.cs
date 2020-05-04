using System;
using System.Windows;
using System.Windows.Controls;

namespace PojemnikiWlasneWPF
{
    class RandomPanel : Panel
    {
        public Size ContentSize { get; set; } = new Size(300, 200);
        public Size MinimalChildSize { get; set; } = new Size(100, 25);

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
            }
            return ContentSize;
        }

        private Random random = new Random();

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                double x = ContentSize.Width * random.NextDouble();
                double y = ContentSize.Height * random.NextDouble();
                Size childSize = child.DesiredSize;
                if (childSize.Width < MinimalChildSize.Width)
                    childSize.Width = MinimalChildSize.Width;
                if (childSize.Height < MinimalChildSize.Height)
                    childSize.Height = MinimalChildSize.Height;
                child.Arrange(new Rect(new Point(x, y), childSize));
            }
            return finalSize;
        }
    }
}
