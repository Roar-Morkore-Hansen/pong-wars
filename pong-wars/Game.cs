using System.IO;

using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using System;

namespace pong_wars {

    public class Game : DIKUGame {
        private Ball ball;
        private EntityContainer<Ball> balls;
        private Block block;
        private EntityContainer<Block> blocks;

        public Game(WindowArgs windowArgs) : base(windowArgs) {

            ball = new Ball(new Vec2F(0.4f, 0.4f), new Vec2F(0.08f, 0.1f), Element.day);
            balls = new EntityContainer<Ball>();
            balls.AddEntity(ball);

            Shape shape = new StationaryShape(new Vec2F(0.7f, 0.7f), new Vec2F(0.1f, 0.1f));

            block = new Block(Element.night, shape);
            blocks = new EntityContainer<Block>();
            blocks.AddEntity(block);
        }

        private void collision_detection() {
            //Iterate trough every ball
            balls.Iterate(ball => {
                //Iterate trough every block
                blocks.Iterate(block => {
                    CollisionData collisionData = CollisionDetection.Aabb(ball.Shape.AsDynamicShape(), block.Shape);
                    if (collisionData.Collision == true && ball.element != block.element) {
                        ball.Collision(collisionData.CollisionDir);
                        block.Collection(ball.element);
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
