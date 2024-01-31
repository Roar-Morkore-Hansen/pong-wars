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
            Ball ball_day = new Ball(new Vec2F((float)1/4, (float)1/2), 
                                       new Vec2F(1.25f, -1.25f), Element.day);
            Ball ball_night = new Ball(new Vec2F((float)1/4 * 3, (float)1/2), 
                                       new Vec2F(-1.25f, 1.25f), Element.night);
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
