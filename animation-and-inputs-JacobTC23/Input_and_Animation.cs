﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace assignment01_animation_and_inputs;

public class Input_and_Animation : Game
{
    private const int _WindowWidth = 1280;
    private const int _WindowHeight = 1280;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background, _balloon;
    private CelAnimationSequence _flag; //_bird;
    private CelAnimationPlayer _animation1;//, _Animation2;

    private CelAnimationSequenceMultiRow bird1;//, bird2, bird3;
    private CelAnimationPlayerMultiRow birdFlying1;//, birdFlying2, birldFlying3;
    private int birdRow;
    //private float _BalloonX;
    //private float _BalloonY;
    public Input_and_Animation()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
         _graphics.PreferredBackBufferWidth = _WindowWidth;
        _graphics.PreferredBackBufferHeight = _WindowHeight;
        
        _graphics.ApplyChanges();
        

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _background = Content.Load<Texture2D>("Houses");
        _balloon = Content.Load<Texture2D>("Balloon");

        Texture2D spriteSheet = Content.Load<Texture2D>("flag_animation");
        // the flag still shakes in place but thats just because it was not made the best I assume.
         _flag = new CelAnimationSequence(spriteSheet, 60, 1 / 4f);
         _animation1 = new CelAnimationPlayer();
         _animation1.Play(_flag);

         Texture2D spriteSheet2 = Content.Load<Texture2D>("blue_bird");
         bird1 = new CelAnimationSequenceMultiRow(spriteSheet2, 350, 350, 1/4f, birdRow);
         birdFlying1 = new CelAnimationPlayerMultiRow();
         birdFlying1.Play(bird1);

        // TODO: use this.Content to load your game content here
    }

    protected void ChangeBirdAnimation()
    {
        Texture2D spriteSheet2 = Content.Load<Texture2D>("blue_bird");
         bird1 = new CelAnimationSequenceMultiRow(spriteSheet2, 350, 350, 1/4f, birdRow);
         birdFlying1 = new CelAnimationPlayerMultiRow();
         birdFlying1.Play(bird1);
    }

    protected override void Update(GameTime gameTime)
    {
        _animation1.Update(gameTime);
        birdFlying1.Update(gameTime);
        // TODO: Add your update logic here
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Q))
        {
            birdRow = 0;
            ChangeBirdAnimation();
        }
           
            
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
        {
            birdRow = 1;
           ChangeBirdAnimation();
        }
            
            
            
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.E))
        {
            birdRow = 2;
            ChangeBirdAnimation();
        }
            
           

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
        _spriteBatch.Draw(_balloon, new Vector2(0, 0), Color.White);
        _animation1.Draw(_spriteBatch, new Vector2(500, 550), SpriteEffects.None);
        birdFlying1.Draw(_spriteBatch, new Vector2(100, 100), SpriteEffects.None);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
