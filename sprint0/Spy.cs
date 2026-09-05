using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;

namespace sprint0;

public class Spy : IPlayer
{
    private AnimatedSprite _sprite;
    private TextureAtlas _atlas;

    private const float MOVEMENT_SPEED = 5.0f;
    private string _currentAnimation = "white-spy-down";
    private string _currentIdleAnimation = "white-spy-down-idle";
    private bool _colorWhite = true; 

    public Vector2 Position { get; set; }

    public Spy(TextureAtlas atlas)
    {
        _atlas = atlas;

        _sprite = _atlas.CreateAnimatedSprite("white-spy-down");
        _sprite.Scale = new Vector2(4.0f, 4.0f);
        _sprite.CenterOrigin();

        Position = new Vector2(640, 360);
    }

    public void Move(Vector2 movement)
    {
        Position += movement * MOVEMENT_SPEED;

        if (movement.Y < 0)
        {
            if (_colorWhite)
            {
                SetAnimation("white-spy-up");
                _currentIdleAnimation = "white-spy-up-idle";
            } 
            else
            {
                SetAnimation("black-spy-up");
                _currentIdleAnimation = "black-spy-up-idle";
            }
        }
        else if (movement.Y > 0)
        {
            if (_colorWhite)
            {
                SetAnimation("white-spy-down");
                _currentIdleAnimation = "white-spy-down-idle";
            } 
            else
            {
                SetAnimation("black-spy-down");
                _currentIdleAnimation = "black-spy-down-idle";
            }
        }
        else if (movement.X < 0)
        {
            if (_colorWhite)
            {
                SetAnimation("white-spy-left");
                _currentIdleAnimation = "white-spy-left-idle";
            } 
            else
            {
                SetAnimation("black-spy-left");
                _currentIdleAnimation = "black-spy-left-idle";
            }
        }
        else if (movement.X > 0)
        {
            if (_colorWhite)
            {
                SetAnimation("white-spy-right");
                _currentIdleAnimation = "white-spy-right-idle";
            } 
            else
            {
                SetAnimation("black-spy-right");
                _currentIdleAnimation = "black-spy-right-idle";
            }
        }
    }

    public void Action()
    {
        if (_colorWhite)
        {
            _colorWhite = false;
        }
        else
        {
            _colorWhite = true;
        }
    }

    public void Idle()
    {
        SetAnimation(_currentIdleAnimation);
    }

    public void Update(GameTime gameTime)
    {
        _sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch, Position);
    }

    private void SetAnimation(string animationName)
    {
        if (_currentAnimation != animationName)
        {
            _currentAnimation = animationName;
            _sprite.Animation = _atlas.GetAnimation(animationName);
        }
    }

}