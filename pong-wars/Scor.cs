using System;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace pong_wars {
    public class Scor {
        private int dayScor;
        private int nightScor;
        private Text scorText;

        public Scor(int num_blocks_x, int num_blocks_y) {
            int totalBlocks = num_blocks_x * num_blocks_y;
            dayScor = totalBlocks / 2;
            nightScor = totalBlocks / 2;
            scorText = new Text($"{dayScor} | {nightScor}", new Vec2F(0.41f, -0.2f), new Vec2F(0.3f, 0.3f));
        }


        public void UpdateScor(Color color) {
            if (color == Color.day) {
                dayScor++;
                nightScor--;
            } else if (color == Color.night) {
                nightScor++;
                dayScor--;
            }
            scorText.SetText($"{dayScor} | {nightScor}");
        }

        public void Render() {
            scorText.RenderText();
        }

        public void Update() {
        }
    }
}