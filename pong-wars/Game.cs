using System.IO;

using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using System;

namespace pong_wars
{
    public class Game : DIKUGame
    {
        private Ball ball;
        private EntityContainer<Ball> balls;
        private Block block;
        private EntityContainer<Block> blocks;

        public Game(WindowArgs windowArgs) : base(windowArgs) {
            ball = new Ball();
            balls = new EntityContainer<Ball>();
            balls.AddEntity(ball);

            Shape shape = new StationaryShape(new Vec2F(0.5f, 0.5f), new Vec2F(0.1f, 0.1f));
            IBaseImage image = new Image(Path.Combine("Assets", "Images", "white-square.png"));

            block = new Block(shape, image);
            blocks = new EntityContainer<Block>();
            blocks.AddEntity(block);
        }

        private void collision_detection() {
            //Iterate trough every ball
            balls.Iterate(ball => {
                //Iterate trough every block
                blocks.Iterate(block => {
                    CollisionData collisionData = CollisionDetection.Aabb(ball.Shape.AsDynamicShape(), block.Shape);
                    if (collisionData.Collision == true) {
                        ball.Collision(collisionData.CollisionDir);
                    }
                });
            });
        }

        public override void Render() {
            ball.Render();
            blocks.RenderEntities();
        }

        public override void Update() {
            ball.Update();
            collision_detection();
        }
    }
}
