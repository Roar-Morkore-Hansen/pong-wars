using System;
using System.IO;
using DIKUArcade.Graphics;

namespace pong_wars {

    public class Color {
        
        private IBaseImage ballImage;
        private IBaseImage blockImage;

        public Color(string ballPath, string blockPath) {
            ballImage = new Image(ballPath);
            blockImage = new Image(blockPath);
        }

        public IBaseImage GetBallColor() {
            return ballImage;
        }
        
        public IBaseImage GetBlockColor() {
            return blockImage;
        }
        
    }
}