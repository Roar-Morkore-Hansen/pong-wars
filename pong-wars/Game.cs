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
        private Scor scor;
        private EntityContainer<Ball> balls;
        private EntityContainer<Block> blocks;

        public Game(WindowArgs windowArgs) : base(windowArgs) {

            int size = 30;

            balls = new EntityContainer<Ball>();
            Ball ball_day = new Ball(new Vec2F((float)1/4, (float)1/2), 
                                       new Vec2F(1.25f, -1.25f), Color.day);
            Ball ball_night = new Ball(new Vec2F((float)1/4 * 3, (float)1/2), 
                                       new Vec2F(-1.25f, 1.25f), Color.night);
            balls.AddEntity(ball_night);
            balls.AddEntity(ball_day);

            Level level = new Level(size, size);
            blocks = level.GetBlocks();
            
            blocks.Iterate(block => {
            });
            
            scor = new Scor(size, size);
        }

        private void collision_detection() {
            //Iterate trough every ball
            balls.Iterate(ball => {
                //Iterate trough every block
                blocks.Iterate(block => {
                    CollisionData collisionData = CollisionDetection.Aabb(
                                                                        ball.Shape.AsDynamicShape(), 
                                                                        block.Shape);
                    if (collisionData.Collision == true && ball.color != block.color) {
                        ball.Collision(collisionData.CollisionDir);
                        block.Collection(ball.color);
                        scor.UpdateScor(ball.color);
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
            scor.Render();
        }

        public override void Update() {
            BallsUpdate();
            collision_detection();
        }
    }
}
