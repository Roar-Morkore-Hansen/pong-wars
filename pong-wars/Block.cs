using System;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using Microsoft.VisualBasic;

namespace pong_wars {
    public class Block : Entity {
        public Color color;
        public Block(Color color, Shape shape) : base(shape, color.GetBlockColor()) {
            this.color = color;
        }

        public void Collection(Color new_color) {
            color = new_color;
            Image = new_color.GetBlockColor();
        }

    }
}
