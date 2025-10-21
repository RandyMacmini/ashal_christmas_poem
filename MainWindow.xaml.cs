using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChristmasPoemApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] poemLines = new[]
        {
            "Missing you this Christmas time,",
            "While on vacation, far away,",
            "Though miles apart, you're in my heart,",
            "Each moment, every single day.",
            "",
            "The twinkling lights and falling snow,",
            "Remind me of your loving smile,",
            "And though we're separated now,",
            "I'll hold you close in just a while.",
            "",
            "So here's a message from my soul,",
            "Wrapped in festive cheer so bright,",
            "Merry Christmas, dear one true,",
            "May your holidays be filled with light!",
            "",
            "With all my love,",
            "- Santa's Quill"
        };

        private int currentCharIndex = 0;
        private int currentLineIndex = 0;
        private readonly DispatcherTimer typingTimer;
        private readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            // Initialize typing timer
            typingTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50) // Typing speed
            };
            typingTimer.Tick += TypingTimer_Tick;

            // Start animations when loaded
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Add snowflakes
            CreateSnowflakes();

            // Start the quill animation after a brief delay
            var startDelay = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            startDelay.Tick += (s, args) =>
            {
                startDelay.Stop();
                typingTimer.Start();
                AnimateQuillEntry();
            };
            startDelay.Start();
        }

        private void AnimateQuillEntry()
        {
            // Animate the quill entering from the top
            var quillStartAnimation = new DoubleAnimation
            {
                From = -100,
                To = 0,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            QuillCanvas.RenderTransform = new TranslateTransform();
            QuillCanvas.RenderTransform.BeginAnimation(TranslateTransform.YProperty, quillStartAnimation);

            // Add gentle floating animation
            StartQuillFloatingAnimation();
        }

        private void StartQuillFloatingAnimation()
        {
            // Create a subtle floating effect
            var floatAnimation = new DoubleAnimation
            {
                From = 0,
                To = -5,
                Duration = TimeSpan.FromSeconds(1.5),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            var rotateAnimation = new DoubleAnimation
            {
                From = -2,
                To = 2,
                Duration = TimeSpan.FromSeconds(2),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            var transformGroup = new TransformGroup();
            var translateTransform = new TranslateTransform();
            var rotateTransform = new RotateTransform { CenterX = 20, CenterY = 15 };
            
            transformGroup.Children.Add(translateTransform);
            transformGroup.Children.Add(rotateTransform);
            QuillCanvas.RenderTransform = transformGroup;

            translateTransform.BeginAnimation(TranslateTransform.YProperty, floatAnimation);
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }

        private void TypingTimer_Tick(object? sender, EventArgs e)
        {
            if (currentLineIndex >= poemLines.Length)
            {
                typingTimer.Stop();
                AnimateQuillExit();
                return;
            }

            string currentLine = poemLines[currentLineIndex];

            if (currentCharIndex < currentLine.Length)
            {
                // Add next character
                UpdatePoemText();
                currentCharIndex++;

                // Animate ink sparkle
                AnimateInkSparkle();

                // Move quill to next position
                MoveQuillToCurrentPosition();
            }
            else
            {
                // Move to next line
                currentLineIndex++;
                currentCharIndex = 0;

                if (currentLineIndex < poemLines.Length)
                {
                    UpdatePoemText();
                }
            }
        }

        private void UpdatePoemText()
        {
            string displayText = "";
            
            for (int i = 0; i < currentLineIndex; i++)
            {
                displayText += poemLines[i] + "\n";
            }

            if (currentLineIndex < poemLines.Length)
            {
                displayText += poemLines[currentLineIndex].Substring(0, currentCharIndex);
            }

            PoemText.Text = displayText;
        }

        private void MoveQuillToCurrentPosition()
        {
            // Calculate approximate position based on text
            var formattedText = new FormattedText(
                PoemText.Text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(PoemText.FontFamily, PoemText.FontStyle, PoemText.FontWeight, PoemText.FontStretch),
                PoemText.FontSize,
                Brushes.Black,
                VisualTreeHelper.GetDpi(this).PixelsPerDip);

            double textWidth = formattedText.Width;
            double textHeight = formattedText.Height;

            // Position quill at the end of the text
            Canvas.SetLeft(QuillCanvas, Math.Min(textWidth + 5, PoemCanvas.ActualWidth - 40));
            Canvas.SetTop(QuillCanvas, textHeight - 25);
        }

        private void AnimateInkSparkle()
        {
            // Create sparkle effect at quill tip
            var scaleTransform = new ScaleTransform(1, 1, 4, 4);
            InkSparkle.RenderTransform = scaleTransform;

            var scaleAnimation = new DoubleAnimation
            {
                From = 1.5,
                To = 0.5,
                Duration = TimeSpan.FromMilliseconds(200),
                AutoReverse = true
            };

            var opacityAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0.3,
                Duration = TimeSpan.FromMilliseconds(200),
                AutoReverse = true
            };

            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
            InkSparkle.BeginAnimation(OpacityProperty, opacityAnimation);
        }

        private void AnimateQuillExit()
        {
            // Animate the quill exiting upward
            var transformGroup = QuillCanvas.RenderTransform as TransformGroup;
            if (transformGroup == null)
            {
                transformGroup = new TransformGroup();
                transformGroup.Children.Add(new TranslateTransform());
                QuillCanvas.RenderTransform = transformGroup;
            }

            var translateTransform = transformGroup.Children[0] as TranslateTransform;
            if (translateTransform == null)
            {
                translateTransform = new TranslateTransform();
                transformGroup.Children.Insert(0, translateTransform);
            }

            var exitAnimation = new DoubleAnimation
            {
                To = -200,
                Duration = TimeSpan.FromSeconds(2),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn }
            };

            translateTransform.BeginAnimation(TranslateTransform.YProperty, exitAnimation);
        }

        private void CreateSnowflakes()
        {
            // Add animated snowflakes
            for (int i = 0; i < 30; i++)
            {
                var snowflake = new Ellipse
                {
                    Width = random.Next(3, 8),
                    Height = random.Next(3, 8),
                    Fill = Brushes.White,
                    Opacity = random.NextDouble() * 0.5 + 0.3
                };

                Canvas.SetLeft(snowflake, random.Next(0, (int)Width));
                Canvas.SetTop(snowflake, random.Next(-50, (int)Height));

                SnowflakeCanvas.Children.Add(snowflake);

                // Animate snowflake falling
                AnimateSnowflake(snowflake);
            }
        }

        private void AnimateSnowflake(Ellipse snowflake)
        {
            var duration = random.Next(5, 15);
            var fallAnimation = new DoubleAnimation
            {
                From = Canvas.GetTop(snowflake),
                To = Height + 50,
                Duration = TimeSpan.FromSeconds(duration),
                RepeatBehavior = RepeatBehavior.Forever
            };

            var swayAnimation = new DoubleAnimation
            {
                From = Canvas.GetLeft(snowflake),
                To = Canvas.GetLeft(snowflake) + random.Next(-30, 30),
                Duration = TimeSpan.FromSeconds(duration / 2),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            snowflake.BeginAnimation(Canvas.TopProperty, fallAnimation);
            snowflake.BeginAnimation(Canvas.LeftProperty, swayAnimation);
        }
    }
}
