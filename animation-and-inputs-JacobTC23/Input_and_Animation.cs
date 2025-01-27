using Microsoft.Xna.Framework;
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
    private CelAnimationSequence _flag, _guy;
    private CelAnimationPlayer _animation1, _Animation2;

    private CelAnimationSequenceMultiRow bird1;
    private CelAnimationPlayerMultiRow birdFlying1;
    private int birdRow;
    private float _guyX;
    private float _guyY;
    private float _birdX;
    //private float _birdY;
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
        birdRow = 0;

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

         Texture2D spriteSheet3 = Content.Load<Texture2D>("Walking_guy");
        // the flag still shakes in place but thats just because it was not made the best I assume.
         _guy = new CelAnimationSequence(spriteSheet3, 375, 1 / 4f);
         _Animation2 = new CelAnimationPlayer();
         _Animation2.Play(_guy);

         Texture2D spriteSheet2 = Content.Load<Texture2D>("blue_bird");
         bird1 = new CelAnimationSequenceMultiRow(spriteSheet2, 350, 350, 1/4f, birdRow);
         birdFlying1 = new CelAnimationPlayerMultiRow();
         birdFlying1.Play(bird1);

        // TODO: use this.Content to load your game content here
    }


    protected override void Update(GameTime gameTime)
    {
        _animation1.Update(gameTime);
        _Animation2.Update(gameTime);
        birdFlying1.Update(gameTime);
        // TODO: Add your update logic here
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.L))
        {
            
            _birdX++;
            
        }
           
            
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.K))
        {
            
            _birdX--;
            
        }
            
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.L) && birdRow == 0)
        {
            Texture2D spriteSheet2 = Content.Load<Texture2D>("blue_bird");
            bird1 = new CelAnimationSequenceMultiRow(spriteSheet2, 350, 350, 1/4f, birdRow);
            birdFlying1 = new CelAnimationPlayerMultiRow();
            birdFlying1.Play(bird1);
            birdRow = 1;
        }    
            
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.K) && birdRow == 1)
        {
            
            Texture2D spriteSheet2 = Content.Load<Texture2D>("blue_bird");
            bird1 = new CelAnimationSequenceMultiRow(spriteSheet2, 350, 350, 1/4f, birdRow);
            birdFlying1 = new CelAnimationPlayerMultiRow();
            birdFlying1.Play(bird1);
            birdRow = 0;
            
        }

         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            _guyX++;
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            _guyX--;
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            _guyY--;
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            _guyY++;
        }
            
           

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
        _spriteBatch.Draw(_balloon, new Vector2(1000, 0), Color.White);
        _animation1.Draw(_spriteBatch, new Vector2(500, 550), SpriteEffects.None);
        _Animation2.Draw(_spriteBatch, new Vector2(_guyX, _guyY), SpriteEffects.None);
        birdFlying1.Draw(_spriteBatch, new Vector2(_birdX, 0), SpriteEffects.None);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
