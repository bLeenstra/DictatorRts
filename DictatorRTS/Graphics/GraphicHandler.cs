using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DictatorRTS.Graphics
{
    public class GraphicHandler
    {
        Client Game;
        SpriteBatch spriteBatch;
        Texture2D ActiveTexture;
        SpriteFont Font;

        // we are going to handle scale

        public float xScale = 1.0f;
        public float yscale = 1.0f;

        public GraphicHandler(Client _game)
        {
            this.Game = _game;
            this.spriteBatch = this.Game.spriteBatch;
            this.Font = this.Game.Content.Load<SpriteFont>("DefaultFont");
        }

        /// <summary>
        /// List of Textures we have loaded.
        /// </summary>
        public List<Texture2D> Textures = new List<Texture2D>();
        public Texture2D LoadImage(string source)
        {
            // so we don't load more then one texture.
            for (int i = 0; i < Textures.Count; i++)
                if (string.CompareOrdinal(source, Textures[i].Name) == 0)
                    return Textures[i];

            Texture2D temp = this.Game.Content.Load<Texture2D>(source);
            Textures.Add(temp);
            return temp;
        }

        /// <summary>
        /// Dispose and unload all textures.
        /// </summary>
        public void UnloadAll()
        {
            for (int i = 0; i < Textures.Count; i++)
                Textures[i].Dispose();
            Textures.Clear();
        }

        /// <summary>
        ///  unload and dispose by name, might not do anything, if the object is not there.
        /// </summary>
        /// <param name="source"></param>
        public bool Unload(string source)
        {
            for (int i = 0; i < Textures.Count; i++)
            {
                if (string.CompareOrdinal(source, Textures[i].Name) == 0)
                {
                    Textures[i].Dispose();
                    Textures.RemoveAt(i);

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Unload and dispose by object.
        /// </summary>
        /// <param name="source"></param>
        public void Unload(Texture2D source)
        {
            Textures.Remove(source);
            source.Dispose();            
        }

        public void SetActiveTexture(Texture2D source)
        {
            this.ActiveTexture = source;
        }

        public void DrawActiveTexture(int x, int y, int width, int height)
        {
            this.spriteBatch.Draw(this.ActiveTexture, new Rectangle((int)(x * xScale), (int)(y * yscale), (int)(width * xScale), (int)(height * yscale)), Color.White);
        }
        public void DrawTexture(Texture2D source, int x, int y, int width, int height)
        {
            this.spriteBatch.Draw(source, new Rectangle((int)(x * xScale), (int)(y * yscale), (int)(width * xScale), (int)(height * yscale)), Color.White);
        }

        public void Begin()
        {
            this.spriteBatch.Begin();
        }

        public void End()
        {
            this.spriteBatch.End();
        }
    }
}
