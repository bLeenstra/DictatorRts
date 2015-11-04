using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.Terrain
{
    public class TerrainChunk
    {
        public int X, Y;
        public const int ChunkSize = 16;
        public BaseTerrain[,] TerrainBlocks = new BaseTerrain[ChunkSize, ChunkSize];
    }
}
