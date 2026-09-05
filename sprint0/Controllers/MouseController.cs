using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Input;

namespace sprint0.Controllers;

public class MouseController : IController
{
    private IPlayer _player;

    public MouseController(IPlayer player)
    {
        _player = player;
    }
    public void Update(GameTime gameTime)
    {
        if (Core.Input.Mouse.WasButtonJustPressed(MouseButton.Left))
        {
            _player.Action();
        }
    }
}