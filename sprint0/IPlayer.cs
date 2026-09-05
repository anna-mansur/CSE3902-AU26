using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0;

public interface IPlayer
{
    void Move(Vector2 movement);

    void Idle();

    void Action();

    void Update(GameTime gameTime);

    void Draw(SpriteBatch spriteBatch);
}