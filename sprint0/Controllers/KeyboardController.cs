using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace sprint0.Controllers;

public class KeyboardController : IController
{
    private IPlayer _player;

    public KeyboardController(IPlayer player)
    {
        _player = player;
    }
    public void Update(GameTime gameTime)
    {
        Vector2 move = Vector2.Zero;

        if (Core.Input.Keyboard.IsKeyDown(Keys.W) || Core.Input.Keyboard.IsKeyDown(Keys.Up))
        {
            move.Y -= 1;
        }
        else if (Core.Input.Keyboard.IsKeyDown(Keys.S) || Core.Input.Keyboard.IsKeyDown(Keys.Down))
        {
            move.Y += 1;
        }
        else if (Core.Input.Keyboard.IsKeyDown(Keys.A) || Core.Input.Keyboard.IsKeyDown(Keys.Left))
        {
            move.X -= 1;
        }
        else if (Core.Input.Keyboard.IsKeyDown(Keys.D) || Core.Input.Keyboard.IsKeyDown(Keys.Right))
        {
            move.X += 1;
        }

        if(move != Vector2.Zero)
        {
            _player.Move(move);
        }
        else
        {
            _player.Idle();
        }
    }
}
