using Microsoft.Xna.Framework;
using MenuBuddy;

namespace OperatorSettingsBuddy
{
	/// <summary>
	/// This item is a game component that sits and calculates the average FPS
	/// </summary>
	public class SettingsComponent<T> : GameComponent where T : MenuScreen
	{
		#region Members

		#endregion //Members

		#region Methods

		public SettingsComponent(Game game, ScreenManager screenManager)
			: base(game)
		{
		}

		/// <summary>
		/// load all the content required for this dude
		/// </summary>
		public override void Initialize()
		{
			//TODO: load settingsfile
		}

		/// <summary>
		/// Called every frame to update the FPS
		/// </summary>
		/// <param name="gameTime"></param>
		public override void Update(GameTime gameTime)
		{
			//TODO: check for magic button press to load settingsscreen
		}

		//TODO: factory method to create the correct settings screen

		//TODO: factory method to create correct settings file

		#endregion //Methods
	}
}