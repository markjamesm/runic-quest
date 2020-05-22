using System.Collections.Generic;
using SadConsole;
using System;
using Microsoft.Xna.Framework;

namespace RunicQuest
{
    //A scrollable window that displays messages
    //using a FIFO (first-in-first-out) Queue data structure
    public class MessageLogWindow : Window
    {
        //max number of lines to store in message log
        private static readonly int _maxLines = 50;

        // a Queue works using a FIFO structure, where the first line added
        // is the first line removed when we exceed the max number of lines
        private readonly Queue<string> _lines;

        // the messageConsole displays the active messages
        private SadConsole.ScrollingConsole _messageConsole;

        // Create a new window with the title centered
        // the window is draggable by default
        public MessageLogWindow(int width, int height, string title) : base(width, height)
        {
            // Ensure that the window background is the correct colour
        //    Theme.WindowTheme.FillStyle.Background = DefaultBackground;
            _lines = new Queue<string>();
            CanDrag = true;
            Title = title.Align(HorizontalAlignment.Center, Width);

            // add the message console, reposition, and add it to the window
            _messageConsole = new SadConsole.ScrollingConsole(width - 1, height - 1);
            _messageConsole.Position = new Point(1, 1);
            Children.Add(_messageConsole);
        }

        //Remember to draw the window!
        public override void Draw(TimeSpan drawTime)
        {
            base.Draw(drawTime);
        }

        //add a line to the queue of messages
        public void Add(string message)
        {
            _lines.Enqueue(message);
            // when exceeding the max number of lines remove the oldest one
            if (_lines.Count > _maxLines)
            {
                _lines.Dequeue();
            }
            // Move the cursor to the last line and print the message.
            _messageConsole.Cursor.Position = new Point(1, _lines.Count);
            _messageConsole.Cursor.Print(message + "\n");
        }
    }
}
