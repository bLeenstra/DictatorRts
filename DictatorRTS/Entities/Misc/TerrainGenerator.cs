using DictatorRTS.Entities.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.Misc
{
    public class TerrainGenerator
    {
        public TerrainChunk GenerateTerrainChunk(int x, int y)
        {
            for (int row = 0; row < TerrainChunk.ChunkSize; row++)
            {
                for (int column = 0; column < TerrainChunk.ChunkSize; column++)
                {
                    // what am i next to, we need to generate islands...
                    // which is kind of hard without working the big picture.
                    // we might need to have a very basic design or have it change a static map??
                }
            }

            return new TerrainChunk { X = x, Y = y };
        }
    }
}
