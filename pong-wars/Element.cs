using System;
using System.IO;
using DIKUArcade.Graphics;

namespace pong_wars {
    public enum Color {
        day,
        night,
    }

    static public class ColorControl {
        static public IBaseImage GetBlockColor(Color elment) {
            switch(elment) {
                case Color.day:
                    return new Image(Path.Combine("Assets", "Images", "blue-block.png"));
                case Color.night:
                    return new Image(Path.Combine("Assets", "Images", "green-block.png"));
                default:
                    throw new ArgumentException("No match");
            }
        }
        static public IBaseImage GetBallColor(Color elment) {
            switch(elment) {
                case Color.day:
                    return new Image(Path.Combine("Assets", "Images", "green-ball.png"));
                case Color.night:
                    return new Image(Path.Combine("Assets", "Images", "blue-ball.png"));
                default:
                    throw new ArgumentException("No match");
            }
        }
    }

}