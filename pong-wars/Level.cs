using System;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;
using DIKUArcade.Math;

namespace pong_wars{
    public class Level {
        private Color day;
        private Color night;
        private EntityContainer<Block> blocks;
        public Level(int num_blocks_x, int num_blocks_y, Color day, Color night) {
            this.day = day;
            this.night = night;
            blocks = CreateBlocks(num_blocks_x, num_blocks_y);
        }

        public EntityContainer<Block> GetBlocks() {
            return blocks;
        }

        private EntityContainer<Block> CreateBlocks(int num_blocks_x, int num_blocks_y) {
            if ((num_blocks_x % 2) != 0 && (num_blocks_y % 2) != 0) {
                Console.WriteLine("ERROR MUST BE LIGE TAL!");
            }

            EntityContainer<Block> new_blocks = new EntityContainer<Block>();
            float block_x = (float)1/num_blocks_x;
            float block_y = (float)1/num_blocks_y;

            Vec2F block_pos;
            Vec2F block_ext = new Vec2F(block_x, block_y);
            
            Shape block_shape;
            for (int y = 0; y < num_blocks_y; y++) {
                Color color = day;
                for (int x = 0; x < num_blocks_x; x++) {
                    //Devide Day and night half
                    if ((x == num_blocks_x/2) && (color == day)) {
                        color = night;
                    }

                    block_pos = new Vec2F(block_x * x, block_y * y);
                    block_shape = new StationaryShape(block_pos, block_ext);


                    new_blocks.AddEntity(new Block(color, block_shape));
                }
            }
            return new_blocks;
        }
    }
}