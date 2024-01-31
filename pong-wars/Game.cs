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
        private EntityContainer<Ball> balls;
        private EntityContainer<Block> blocks;

        public Game(WindowArgs windowArgs) : base(windowArgs) {

            balls = new EntityContainer<Ball>();
            Ball ball_night = new Ball(new Vec2F(0.8f, 0.8f), new Vec2F(0.08f, 0.1f), Element.night);
            Ball ball_day = new Ball(new Vec2F(0.2f, 0.2f), new Vec2F(0.08f, 0.1f), Element.day);
            balls.AddEntity(ball_night);
            balls.AddEntity(ball_day);

            Level level = new Level(22, 22);
            blocks = level.GetBlocks();
            
            blocks.Iterate(block => {
                Console.WriteLine($"{block.Shape.Position}");
            });
            
        }

        private void collision_detection() {
            //Iterate trough every ball
            balls.Iterate(ball => {
                //Iterate trough every block
                blocks.Iterate(block => {
                    CollisionData collisionData = CollisionDetection.Aabb(
                                                                        ball.Shape.AsDynamicShape(), 
                                                                        block.Shape);
                    if (collisionData.Collision == true && ball.element != block.element) {
                        ball.Collision(collisionData.CollisionDir);
                        block.Collection(ball.element);
                    }
                });
            });
        }

        private void BallsUpdate() {
            balls.Iterate(ball => {
                ball.Update();
            });
        }

        public override void Render() {
            blocks.RenderEntities();
            balls.RenderEntities();
        }

        public override void Update() {
            BallsUpdate();
            collision_detection();
        }
    }
}
