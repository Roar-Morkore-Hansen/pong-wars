using System;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;
using DIKUArcade.Math;

namespace pong_wars{
    public class Ball : Entity {
        public Element element;
        public int Damage { get; private set; }
        private const float SIZE = 0.04f;
        private const float MOVEMENT_SPEED = 0.08f;
        public Vec2F DirectionVec;

        public Ball(Vec2F pos, Vec2F dir, Element element) : base(
                                new DynamicShape(pos, new Vec2F(SIZE, SIZE)), 
                                ElementControl.GetBallColor(element)) {
            UpdateDirection(dir);
            this.element = element;
        }
        public void UpdateDirection(Vec2F newDir) {
            DirectionVec = newDir;
            Shape.AsDynamicShape().ChangeDirection(newDir * MOVEMENT_SPEED);
        }
        public void Collision(CollisionDirection collisionDirection) {
            //Mirror the vector with the collision direction
            //Vertical (X, Y) = (-X, Y)
            //Horizontal (X, Y) = (X, -Y)
            if (collisionDirection == CollisionDirection.CollisionDirDown || 
                collisionDirection == CollisionDirection.CollisionDirUp) {
                DirectionVec.Y = -DirectionVec.Y;
            } 
            else if (collisionDirection == CollisionDirection.CollisionDirLeft || 
                     collisionDirection == CollisionDirection.CollisionDirRight) {
                DirectionVec.X = -DirectionVec.X;
            } 
            UpdateDirection(DirectionVec);
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