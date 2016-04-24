using Microsoft.Xna.Framework;
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

        Level level; //create a level object 
        Player player; // Creates a new player object
        Texture2D bgTexture; //creates a texture for the background
        Texture2D playerTexture; // makes a texture to hold the texture for the player
        Texture2D bulletTexture; // makes a texture for the bullets in the game
        Texture2D enemyTexture;
        Texture2D menuImg;
        Texture2D button1;
        Texture2D controls;
        SpriteFont buttonWord;
        SpriteFont controlScreen;

        GameState gameState;
        enum GameState { Menu, Game, Controls, Gameover };
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 600;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;
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
            enemyTexture = Content.Load<Texture2D>("Images/Level1/Senpai"); 
            

            //menuImg = Content.Load<Texture2D>("Images/Menu/menu"); // image for menu, will be stretched across screen

            button1 = Content.Load<Texture2D>("unfinishedButton");//image for the button
            buttonWord = Content.Load<SpriteFont>("mainFont");//font for the button

            controlScreen = Content.Load<SpriteFont>("mainFont");//font for the controls
            controls = Content.Load<Texture2D>("Controls");//image for the controls

            playerTexture = Content.Load<Texture2D>("Images/Level1/AyumiDraft2_OnlySprite"); // loads the player texture
            

            bulletTexture = Content.Load<Texture2D>("Bullet"); //loads in bullet texture
            player = new Player(playerTexture, bulletTexture, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height); // constructs the player with the texture
            
            //gameObjects.Add(level); //adds a level object to the array of things to be drawn
            //gameObjects.Add(player); // adds the player to the lits of things that will be drawn
            level = new Level(bgTexture, enemyTexture, bulletTexture, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height, player); //construct level object with the textue loaded





            //TESTING
            ExternalReader exRead = new ExternalReader();
            exRead.Read("images.dat");
            exRead.Test();
            //TESTING
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
                Exit(); // allows escape and back on the controller to update the game

            if (gameState == GameState.Menu) // first state of finite state machine
            {
                MouseState ms = Mouse.GetState();

                if (ms.LeftButton == ButtonState.Pressed)//tests if its on the start button
                {
                    if (ms.Position.X >= (this.GraphicsDevice.Viewport.Width / 2) - 100 && ms.Position.X <= ((this.GraphicsDevice.Viewport.Width / 2) - 100) + 200)
                    {
                        if (ms.Position.Y >= (this.GraphicsDevice.Viewport.Height / 2) - 100 && ms.Position.Y <= ((this.GraphicsDevice.Viewport.Height / 2) - 100) + 50)
                        {
                            player.Lives = 100;
                            player.Score = 0;
                            gameState = GameState.Game;
                        }
                    }
                }


                if (ms.LeftButton == ButtonState.Pressed)//tests if its on the controls button
                {
                    if (ms.Position.X >= (this.GraphicsDevice.Viewport.Width / 2) - 100 && ms.Position.X <= ((this.GraphicsDevice.Viewport.Width / 2) - 100) + 200)
                    {
                        if (ms.Position.Y >= (this.GraphicsDevice.Viewport.Height / 2) && ms.Position.Y <= ((this.GraphicsDevice.Viewport.Height / 2)) + 50)
                        {
                            gameState = GameState.Controls;
                        }
                    }
                }
                if (ms.LeftButton == ButtonState.Pressed)//tests if its on the quit button
                {
                    if (ms.Position.X >= (this.GraphicsDevice.Viewport.Width / 2) - 100 && ms.Position.X <= ((this.GraphicsDevice.Viewport.Width / 2) - 100) + 200)
                    {
                        if (ms.Position.Y >= (this.GraphicsDevice.Viewport.Height / 2) + 100 && ms.Position.Y <= ((this.GraphicsDevice.Viewport.Height / 2) + 100) + 50)
                        {
                            System.Environment.Exit(0);
                        }
                    }
                }


            }
                if (gameState == GameState.Game) // second state of finite state machine
                {
                    for (int i = 0; i < gameObjects.Count; i++)
                    {
                        gameObjects[i].Update(gameTime.ElapsedGameTime); //update all of the default gameobjects

                    }
                    player.Update(Keyboard.GetState(), gameTime.ElapsedGameTime, level);
                    level.Update(gameTime.ElapsedGameTime);
                    if (player.Lives <= 0)
                    {
                        gameState = GameState.Gameover;
                    }
                }
                if (gameState == GameState.Controls)//third state of the finite state machine
                {

                    MouseState mouseState = Mouse.GetState();

                    if (mouseState.LeftButton == ButtonState.Pressed)//tests if its on the back button
                    {
                        if (mouseState.Position.X >= (this.GraphicsDevice.Viewport.Width / 2) + 200 && mouseState.Position.X <= ((this.GraphicsDevice.Viewport.Width / 2) + 200) + 200)
                        {
                            if (mouseState.Position.Y >= (this.GraphicsDevice.Viewport.Height / 2 - 200) && mouseState.Position.Y <= ((this.GraphicsDevice.Viewport.Height / 2 - 200) + 50))
                            {
                                gameState = GameState.Menu;
                            }
                        }
                    }
                }
                if (gameState == GameState.Gameover)
                {
                    MouseState ms = Mouse.GetState();

                    if (ms.LeftButton == ButtonState.Pressed)//tests if its on the restart button
                    {
                        if (ms.Position.X >= (this.GraphicsDevice.Viewport.Width / 2) - 100 && ms.Position.X <= ((this.GraphicsDevice.Viewport.Width / 2) - 100) + 200)
                        {
                            if (ms.Position.Y >= (this.GraphicsDevice.Viewport.Height / 2) - 100 && ms.Position.Y <= ((this.GraphicsDevice.Viewport.Height / 2) - 100) + 50)
                            {
                                player.Reset();
                                level.Enemies = new List<Enemy>();
                                
                                gameState = GameState.Game;
                            }
                        }
                    }


                    if (ms.LeftButton == ButtonState.Pressed)//tests if its on the mainmenu button
                    {
                        if (ms.Position.X >= (this.GraphicsDevice.Viewport.Width / 2) - 100 && ms.Position.X <= ((this.GraphicsDevice.Viewport.Width / 2) - 100) + 200)
                        {
                            if (ms.Position.Y >= (this.GraphicsDevice.Viewport.Height / 2) && ms.Position.Y <= ((this.GraphicsDevice.Viewport.Height / 2)) + 50)
                            {
                                
                                
                                player.Reset();
                                gameState = GameState.Menu;
                            }
                        }
                    }
                    if (ms.LeftButton == ButtonState.Pressed)//tests if its on the quit button
                    {
                        if (ms.Position.X >= (this.GraphicsDevice.Viewport.Width / 2) - 100 && ms.Position.X <= ((this.GraphicsDevice.Viewport.Width / 2) - 100) + 200)
                        {
                            if (ms.Position.Y >= (this.GraphicsDevice.Viewport.Height / 2) + 100 && ms.Position.Y <= ((this.GraphicsDevice.Viewport.Height / 2) + 100) + 50)
                            {
                                System.Environment.Exit(0);
                            }
                        }
                    }

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

            spriteBatch.Begin(); // begin the spritebatch
            if (gameState == GameState.Menu) // if in the menu, just draw the menu
            {
                this.IsMouseVisible = true;
                //spriteBatch.Draw(menuImg, new Rectangle(0, 0, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height), Color.White);
                Button startButton = new Button((this.GraphicsDevice.Viewport.Width / 2) - 100, (this.GraphicsDevice.Viewport.Height / 2) - 100 , 200, 50, button1, buttonWord);//start button
                Button controlsButton = new Button((this.GraphicsDevice.Viewport.Width / 2) - 100, this.GraphicsDevice.Viewport.Height/2, 200, 50, button1, buttonWord);//controls button
                Button quitButton = new Button((this.GraphicsDevice.Viewport.Width / 2) - 100, (this.GraphicsDevice.Viewport.Height / 2) + 100, 200, 50, button1, buttonWord);//quit button
                startButton.Drawbutton(spriteBatch, "Start");
                controlsButton.Drawbutton(spriteBatch, "Controls");
                quitButton.Drawbutton(spriteBatch, "Quit");

                spriteBatch.DrawString(controlScreen, "LOVE IS WAR", new Vector2((this.GraphicsDevice.Viewport.Width / 2) - 100, 50), Color.Black);
                
            }
            if(gameState == GameState.Controls)
            {
                spriteBatch.DrawString(controlScreen, "Arrow keys to move", new Vector2(50, 50), Color.Black);
                spriteBatch.DrawString(controlScreen, "Space bar to shoot", new Vector2(50, 80), Color.Black);
                spriteBatch.Draw(controls, new Vector2(100, 100), Color.White);

                Button backButton = new Button((this.GraphicsDevice.Viewport.Width / 2) + 200, this.GraphicsDevice.Viewport.Height / 2 -200, 200, 50, button1, buttonWord);//controls button
                backButton.Drawbutton(spriteBatch, "Back");
            }
            if (gameState == GameState.Game) //if in the gamestate
            {
                this.IsMouseVisible = false;

                level.Draw(spriteBatch); // draw the level
                for (int i = 0; i < gameObjects.Count; i++) // this for loop goes through the list of everything that should be drawn
                {
                    //spriteBatch.Draw(gameObjects[i].texture, gameObjects[i].location, Color.White);
                    gameObjects[i].Draw(spriteBatch);
                }
                player.Draw(spriteBatch); // draw the player


                //----------------------------------------------
                //All UI drawing goes after this line
                
                spriteBatch.DrawString(controlScreen, "Score: "+player.Score , new Vector2(0, 0), Color.Black);
                spriteBatch.DrawString(controlScreen, "Health: " + player.Lives, new Vector2(0,50), Color.Black);

            }
            if (gameState == GameState.Gameover) // if in the menu, just draw the menu
            {
                this.IsMouseVisible = true;
                //spriteBatch.Draw(menuImg, new Rectangle(0, 0, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height), Color.White);
                Button startButton = new Button((this.GraphicsDevice.Viewport.Width / 2) - 100, (this.GraphicsDevice.Viewport.Height / 2) - 100, 200, 50, button1, buttonWord);//restart button
                Button mainButton = new Button((this.GraphicsDevice.Viewport.Width / 2) - 100, this.GraphicsDevice.Viewport.Height / 2, 200, 50, button1, buttonWord);//mainmenu button
                Button quitButton = new Button((this.GraphicsDevice.Viewport.Width / 2) - 100, (this.GraphicsDevice.Viewport.Height / 2) + 100, 200, 50, button1, buttonWord);//quit button
                startButton.Drawbutton(spriteBatch, "Restart");
                mainButton.Drawbutton(spriteBatch, "MainMenu");
                quitButton.Drawbutton(spriteBatch, "Quit");

                spriteBatch.DrawString(controlScreen, "LOVE IS WAR", new Vector2((this.GraphicsDevice.Viewport.Width / 2) - 100, 50), Color.Black);
                spriteBatch.DrawString(controlScreen, "Score: "+ player.Score, new Vector2((this.GraphicsDevice.Viewport.Width / 2) - 100, 100), Color.Black);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
