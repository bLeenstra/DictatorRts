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
        public List<TerrainChunk> TerrainChunks = new List<TerrainChunk>();

        public TerrainChunk LoadChunk(int x, int y)
        {




            return null;
        }

        public void UnloadChunk(int x, int y)
        {
            for (int i = 0; i < TerrainChunks.Count; i++)
            {
                if (TerrainChunks[i].X == x && TerrainChunks[i].Y == y)
                {
                    TerrainChunks.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
