using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;

namespace pong_wars
{
    public class Game : DIKUGame
    {
        private Ball ball;
        public Game(WindowArgs windowArgs) : base(windowArgs) {
            ball = new Ball();
        }

        public override void Render() {
            ball.Render();
        }

        public override void Update() {
            ball.Update();
        }
    }
}
