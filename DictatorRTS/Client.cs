using DictatorRTS.Graphics;
using DictatorRTS.LifeCycle;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DictatorRTS
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Client : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public InteractionPlane interaction = new InteractionPlane(10, 0, 30);

        public GraphicHandler graphicHandler;

        public Client()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here            
            base.Initialize();
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphicHandler = new GraphicHandler(this); // needs to be set after sprite batch.
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 10.0f);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        KeyboardState Prev;
        KeyboardState Curr;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Curr = Keyboard.GetState();

            if (Curr.IsKeyDown(Keys.Up) && Prev.IsKeyUp(Keys.Up) && interaction.TaxPercent < 100m)
            {
                interaction.TaxPercent += 1m;
            }
            else if (Curr.IsKeyDown(Keys.Down) && Prev.IsKeyUp(Keys.Down) && interaction.TaxPercent > 0m)
            {
                interaction.TaxPercent -= 1m;
            }
            if (Curr.IsKeyDown(Keys.Space) && Prev.IsKeyUp(Keys.Space))
            {
                interaction.CentreLinkEnabled = !interaction.CentreLinkEnabled;
            }
            Prev = Curr;

            interaction.Interact();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            graphicHandler.
                Begin().
                DrawString(string.Format("{0}%", Math.Round( interaction.PopGrowthPercetange, 2)), 20, 20, interaction.PopGrowthPercetange == 0m ? Color.Black : interaction.PopGrowthPercetange > 0m ? Color.Green : Color.Red).
                    DrawString(interaction.ToString(), 20, 40, Color.Black).
                End();            

            base.Draw(gameTime);
        }
    }
}
