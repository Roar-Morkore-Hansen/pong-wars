using System;
using System.Collections.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace pong_wars {
    public class Scor {
        private int dayScor;
        private int nightScor;
        private Text scorText;
        private Dictionary<Color, int> scorDict;

        public Scor(int totalBlocks, Dictionary<Color, int> scorDict) {

            this.scorDict = scorDict;

            int numPlayers = scorDict.Count;
            int startScor = totalBlocks / numPlayers;

            foreach (var item in scorDict) {
                scorDict[item.Key] = startScor;
            }

            scorText = new Text("", new Vec2F(0.2f, 0.2f), new Vec2F(0.3f, 0.3f));
            UpdateScorText();
        }

        private void UpdateScorText() {
            string newScor = "";
            foreach (var item in scorDict) {
                newScor += $"{item.Value}:";
            }
            scorText.SetText(newScor);
        }

        public void UpdateScor(Color ballColor, Color blockColor) {
            
            scorDict[ballColor]++;
            scorDict[blockColor]--;

            UpdateScorText();
        }

        public void Render() {
            scorText.RenderText();
        }

        public void Update() {
        }
    }
}