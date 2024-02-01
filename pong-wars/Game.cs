using System;
using System.IO;
using System.Collections.Generic;

using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;

namespace pong_wars {

    public class Game : DIKUGame {
        private Scor scor;
        private EntityContainer<Ball> balls;
        private EntityContainer<Block> blocks;

        public Game(WindowArgs windowArgs) : base(windowArgs) {

            int size = 30;

            Color night = new Color(Path.Combine("Assets", "Images", "green-ball.png"),
                                         Path.Combine("Assets", "Images", "blue-block.png"));

            Color day = new Color(Path.Combine("Assets", "Images", "blue-ball.png"),
                                       Path.Combine("Assets", "Images", "green-block.png"));


            balls = new EntityContainer<Ball>();
            Ball ball_day = new Ball(new Vec2F((float)1/4, (float)1/2), 
                                       new Vec2F(1.25f, -1.25f), day);
            Ball ball_night = new Ball(new Vec2F((float)1/4 * 3, (float)1/2), 
                                       new Vec2F(-1.25f, 1.25f), night);
            balls.AddEntity(ball_night);
            balls.AddEntity(ball_day);

            Level level = new Level(size, size, day, night);
            blocks = level.GetBlocks();
            
            Dictionary<Color, int> scorDict = new Dictionary<Color, int>(2);
            scorDict.Add(day, 0);
            scorDict.Add(night, 0);
            scor = new Scor(size*size, scorDict);
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
                        scor.UpdateScor(ball.color, block.color);
                        
                        ball.Collision(collisionData.CollisionDir);
                        block.Collection(ball.color);
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
