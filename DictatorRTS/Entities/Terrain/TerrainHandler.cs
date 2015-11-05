using DictatorRTS.Entities.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.Terrain
{
    /// <summary>
    /// Terrain is loaded into chunks...
    /// This handles everything to do with what is on the terrain...
    /// </summary>
    public class TerrainHandler
    {
        public BaseTerrain[,] TerrainBlocks;
        public const int DefaultSize = 1024;
        public TerrainGenerator Generator;

        public enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 4
        }

        public TerrainHandler(Difficulty diff)
        {            
            Generator = new TerrainGenerator();
            Generator.GenerateTerrain((int)diff * DefaultSize, out TerrainBlocks);
        }

        public object LoadChunk(int x, int y)
        {            
            return null;
        }

        public void UnloadChunk(int x, int y)
        {
            //for (int i = 0; i < TerrainChunks.Count; i++)
            //{
            //    if (TerrainChunks[i].X == x && TerrainChunks[i].Y == y)
            //    {
            //        TerrainChunks.RemoveAt(i);
            //        return;
            //    }
            //}
        }
    }
}
