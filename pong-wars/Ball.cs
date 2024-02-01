using System;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;
using DIKUArcade.Math;

namespace pong_wars{
    public class Ball : Entity {
        public Color color;
        private const float SIZE = 0.04f;
        private const float MOVEMENT_SPEED = 0.04f;

        public Ball(Vec2F pos, Vec2F dir, Color color) : base(
                                new DynamicShape(pos, new Vec2F(SIZE, SIZE), 
                                                 Vec2F.Normalize(dir) * MOVEMENT_SPEED),
                                                 color.GetBallColor()) {
            this.color = color;
        }
        public void UpdateDirection(Vec2F newDir) {
            Vec2F newDirNorm = Vec2F.Normalize(newDir);
            Shape.AsDynamicShape().ChangeDirection(newDirNorm * MOVEMENT_SPEED);
        }
        public void Collision(CollisionDirection collisionDirection) {
            //Mirror the vector with the collision direction
            //Vertical (X, Y) = (-X, Y)
            //Horizontal (X, Y) = (X, -Y)

            Vec2F newDir = Shape.AsDynamicShape().Direction;

            if (collisionDirection == CollisionDirection.CollisionDirDown || 
                collisionDirection == CollisionDirection.CollisionDirUp) {
                newDir.Y = -newDir.Y;
            } 
            else if (collisionDirection == CollisionDirection.CollisionDirLeft || 
                     collisionDirection == CollisionDirection.CollisionDirRight) {
                newDir.X = -newDir.X;
            }
            UpdateDirection(newDir);
        }
        
        private void Move() {
            Shape.Move();
        }

        public void BoarderCheck() {
            if (Shape.Position.X <= 0) {
                Shape.Position.X = 0;
                Collision(CollisionDirection.CollisionDirLeft);
            }
            else if (Shape.Position.X + Shape.Extent.X >= 1) {
                Shape.Position.X = 1 - Shape.Extent.X;
                Collision(CollisionDirection.CollisionDirRight);
            }
            else if (Shape.Position.Y + Shape.Extent.Y >= 1) {
                Shape.Position.Y = 1 - Shape.Extent.Y;
                Collision(CollisionDirection.CollisionDirUp);
            }
            else if (Shape.Position.Y <= 0) {
                Shape.Position.Y = 0;                
                Collision(CollisionDirection.CollisionDirDown);
            }
        }

        public void Render() {
           RenderEntity();
        }

        public void Update() {
            Move();
            BoarderCheck();
        }
    }
}