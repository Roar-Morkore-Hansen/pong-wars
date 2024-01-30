using System;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using Microsoft.VisualBasic;

namespace pong_wars {
    public class Block : Entity {
        public Element element;
        public Block(Element element, Shape shape) : base(shape, ElementControl.GetBlockColor(element)) {
            this.element = element;
        }

        public void Collection(Element new_element) {
            element = new_element;
            Image = ElementControl.GetBlockColor(new_element);
        }

    }
}
