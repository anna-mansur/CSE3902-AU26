using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using sprint0.Controllers;

namespace sprint0;

public class Game1 : Core
{
    private IPlayer _spy;
    private List<IController> _controllers;
    private TextureAtlas _atlas;
    private SpriteFont _font;
    private string _credits = "Credits\nProgram Made By: Anna Mansur\nSprites from: https://www.spriters-resource.com/nes/spyvsspy/asset/40724/";

    public Game1() : base ("Spy", 1280, 720, false)
    {
        
    }
    protected override void Initialize()
    {
        _controllers = new List<IController>();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _atlas = TextureAtlas.FromFile(Content, "images/spy-definition.xml");

        _font = Content.Load<SpriteFont>("Info");

        _spy = new Spy(_atlas);

        _controllers.Add(new KeyboardController(_spy));
        _controllers.Add(new MouseController(_spy));

    }

    protected override void Update(GameTime gameTime)
    {

        base.Update(gameTime);

        foreach (IController controller in _controllers)
        {
            controller.Update(gameTime);
        }

        _spy.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);

        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _spy.Draw(SpriteBatch);

        SpriteBatch.DrawString(_font, _credits, new Vector2(50, 600), Color.Black);

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
