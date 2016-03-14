﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LoveIsWar
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<GameObject> gameObjects; // This list should contain everything that needs to be drawn on screen, with the exception of UI

        Level bg; //create a level object 
        Player player; // Creates a new player object
        Texture2D bgTexture; //creates a texture for the background
        Texture2D playerTexture; // makes a texture to hold the texture for the player
        Texture2D bulletTexture; // makes a texture for the bullets in the game
        Texture2D menuImg;

        GameState gameState;
        enum GameState { Menu, Game };
        public Game1()
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

            gameObjects = new List<GameObject>(); // inits the list

            gameState = GameState.Menu;

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

            bgTexture = Content.Load<Texture2D>("Images/Level1/Background_Draft1");//load in background texture
            bg = new Level(bgTexture, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height); //construct level object with the textue loaded

            menuImg = Content.Load<Texture2D>("Images/Menu/menu");

            playerTexture = Content.Load<Texture2D>("Images/Level1/AyumiDraft2_SpriteOnly"); // loads the player texture
            

            bulletTexture = Content.Load<Texture2D>("Bullet"); //loads in bullet texture
            player = new Player(playerTexture, bulletTexture); // constructs the player with the texture

            gameObjects.Add(bg); //adds a level object to the array of things to be drawn
            gameObjects.Add(player); // adds the player to the lits of things that will be drawn




        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (gameState == GameState.Menu)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.Game;
                }
                    
            }
            if (gameState == GameState.Game)
            {
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    gameObjects[i].Update();
                    
                }
                player.Update(Keyboard.GetState(), this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (gameState == GameState.Menu)
            {
                spriteBatch.Draw(menuImg, new Rectangle(0, 0, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height), Color.White);
            }
            if (gameState == GameState.Game)
            {
                for (int i = 0; i < gameObjects.Count; i++) // this for loop goes through the list of everything that should be drawn
                {
                    //spriteBatch.Draw(gameObjects[i].texture, gameObjects[i].location, Color.White);
                    gameObjects[i].Draw(spriteBatch);
                }
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
