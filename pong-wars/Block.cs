using System;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using Microsoft.VisualBasic;

namespace pong_wars {
    public class Block : Entity {
        public Color color;
        public Block(Color color, Shape shape) : base(shape, ColorControl.GetBlockColor(color)) {
            this.color = color;
        }

        public void Collection(Color new_color) {
            color = new_color;
            Image = ColorControl.GetBlockColor(new_color);
        }

    }
}
