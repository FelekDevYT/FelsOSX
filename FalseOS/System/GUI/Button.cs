using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.GUI
{
    public class Button
    {
        private readonly Canvas _canvas;
        private readonly int _x;
        private readonly int _y;
        private readonly int _width;
        private readonly int _height;
        private readonly Color color;
        private readonly Image _image;
        private readonly String _text;

        public Button(Canvas canvas, int x, int y, int width, int height, Color pen)
        {
            _canvas = canvas;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            color = pen;
        }

        public Button(Canvas canvas, int x, int y, Image image)
        {
            _canvas = canvas;
            _x = x;
            _y = y;
            _image = image;
        }

        public Button(Canvas canvas, int x, int y, Color color, String text)
        {
            _canvas=canvas;
            _x = x;
            _y = y;
            this.color = color;
            _text = text;
            _width = text.Length * 7;
            _height = 15;
        }

        public bool IsPressed(int mouseX, int mouseY)
        {
            if (_text != null)
            {
                if (mouseX >= _x && mouseX <= _x + _image.Width &&
                    mouseY >= _y && mouseY <= _y + _image.Height &&
                    MouseManager.MouseState == MouseState.Left)
                {
                    _canvas.DrawFilledRectangle(color, _x, _y, _width, _height);
                    _canvas.DrawString(_text, Cosmos.System.Graphics.Fonts.PCScreenFont.Default, Color.Black, _x + 2, _y + 2);
                    return true;
                }
                else
                {
                    return false;
                }
            } else if (_image != null)
            {
                if (mouseX >= _x && mouseX <= _x + _image.Width &&
                    mouseY >= _y && mouseY <= _y + _image.Height &&
                    MouseManager.MouseState == MouseState.Left)
                {
                    _canvas.DrawImageAlpha(_image, _x, _y);
                    return true;
                }

                _canvas.DrawImageAlpha(_image, _x, _y);
                return false;
            }
            else
            {
                if (mouseX >= _x && mouseX <= _x + _width &&
                    mouseY >= _y && mouseY <= _y + _height &&
                    MouseManager.LastMouseState == MouseState.Left)
                {
                    _canvas.DrawFilledRectangle(color, _x, _y, _width, _height);
                    return true;
                }

                _canvas.DrawFilledRectangle(color, _x, _y, _width, _height);
                return false;
            }
        }

    }
}
