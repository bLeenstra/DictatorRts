using DictatorRTS.Entities.Terrain;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.Misc
{
    public class TerrainGenerator : RandomGenerator
    {
        BaseTerrain[,] _terrain;
        int _size;

        public const int MinIslandSize = 10;
        public const int MaxIslandSize = 45;

        public static Point[] NeighborNormals = new Point[] { 
            new Point(-1, 0),
            new Point(0 , -1), 
            new Point(1, 0),
            new Point(0, 1)};

        public void GenerateTerrain(int Size, out BaseTerrain[,] Terrain)
        {
            Terrain = new BaseTerrain[Size, Size];
            _terrain = Terrain;
            _size = Size;

            // bool Invalid = false;

            //BaseTerrain CurrentBlock;

            //Tuple<BaseTerrain, bool>[] Neighbors = new Tuple<BaseTerrain, bool>[3];

            //generate an Island!

            int StartingX = this.baseRandom.Next(0, _size);
            int StartingY = this.baseRandom.Next(0, _size);
            int IslandSize = this.baseRandom.Next(MinIslandSize, MaxIslandSize);

            while(true)
            {

            }
            
            for (int row = 0; row < _size; row++)
            {
                for (int column = 0; column < _size; column++)
                {

                    //bool AllNull = true;
                    //for(int i = 0; i < 4; i++)
                    //{
                    //    Point CurrentVector = NeighborNormals[i];
                    //    CurrentBlock =   GetTile(row  + CurrentVector.X, column + CurrentVector.Y, out Invalid);
                    //    if(!Invalid)
                    //    {
                    //        if (AllNull && CurrentBlock != null)
                    //            AllNull = false;
                    //        Neighbors[i] = new Tuple<BaseTerrain, bool>(CurrentBlock, true);
                    //    }
                    //    else
                    //    {
                    //        Neighbors[i] = new Tuple<BaseTerrain, bool>(null, false);
                    //    }
                    //}
                    
                    //if(AllNull)
                    //{

                    //}
                }
            }

            //for (int row = 0; row < TerrainChunk.ChunkSize; row++)
            //{
            //    for (int column = 0; column < TerrainChunk.ChunkSize; column++)
            //    {
            //        // what am i next to, we need to generate islands...
            //        // which is kind of hard without working the big picture.
            //        // we might need to have a very basic design or have it change a static map??
            //    }
            //}
            
            //return new TerrainChunk { X = x, Y = y };
        }

        public BaseTerrain GetTile(int x, int y, out bool Invalid)
        {
            if(x < 0 || y < 0 || x >= _size || y >= _size)
            {
                Invalid = true;
                return null;
            }

            Invalid = false;
             return _terrain[x, y];
        }
    }
}
