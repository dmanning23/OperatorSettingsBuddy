using MenuBuddy;
using InsertCoinBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace OperatorSettingsBuddy
{
	/// <summary>
	/// This item is a game component that sits and calculates the average FPS
	/// </summary>
	public class SettingsComponent<T> : DrawableGameComponent where T : SettingsScreen, new()
	{
		#region Members

		/// <summary>
		/// The folder to save settings to 
		/// </summary>
		private string Folder { get; set; }

		/// <summary>
		/// the settings object
		/// </summary>
		public SettingsFile Settings { get; private set; }

		/// <summary>
		/// the screen manager, used to pop up the settings screen
		/// </summary>
		protected ScreenManager ScreenManager { get; private set; }

		/// <summary>
		/// the key to press to bring up the menu screen
		/// </summary>
		protected Keys MenuKey { get; set; }

		/// <summary>
		/// the button to press to bring up the menu screen
		/// </summary>
		protected Buttons MenuButton { get; set; }

		/// <summary>
		/// The name of the settings screen, used to check if one is already displayed
		/// </summary>
		private string SettingsScreenName { get; set; }

		#endregion //Members

		#region Methods

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="game"></param>
		/// <param name="screenManager"></param>
		/// <param name="folder">location to store the settings file</param>
		/// <param name="menuKey">the key to press to bring up the menu screen</param>
		public SettingsComponent(Game game, 
			ScreenManager screenManager, 
			string folder, 
			Keys menuKey,
			Buttons menuButton)
			: base(game)
		{
			this.Folder = folder;
			ScreenManager = screenManager;
			MenuKey = menuKey;
			MenuButton = menuButton;

			Settings = CreateSettings(Folder);
		}

		/// <summary>
		/// load all the content required for this dude
		/// </summary>
		public override void Initialize()
		{
			//load settingsfile
			Settings.Initialize(Game);

			//get teh screen name
			var screen = CreateSettingsScreen();
			SettingsScreenName = screen.ScreenName;

			base.Initialize();
		}

		protected override void LoadContent()
		{
			Settings.Load();
			base.LoadContent();
		}

		/// <summary>
		/// Called every frame to update the FPS
		/// </summary>
		/// <param name="gameTime"></param>
		public override void Update(GameTime gameTime)
		{
			//check for magic button press to load settingsscreen
			if (ScreenRequest())
			{
				//check if the menu is already being displayed
				GameScreen screen = ScreenManager.FindScreen(SettingsScreenName);
				if (null == screen)
				{
					//add a settings screen and display it
					screen = CreateSettingsScreen();
					ScreenManager.AddScreen(screen, null);
				}
			}
		}

		/// <summary>
		/// Check if the player tried to pop up the operator screen
		/// </summary>
		/// <returns></returns>
		private bool ScreenRequest()
		{
			return (Keyboard.GetState().IsKeyDown(MenuKey) ||
				GamePad.GetState(PlayerIndex.One).IsButtonDown(MenuButton));
		}

		/// <summary>
		/// factory method to create the correct settings screen
		/// </summary>
		/// <returns></returns>
		private SettingsScreen CreateSettingsScreen()
		{
			var screen = new T();
			screen.Init(Settings);
			return screen;
		}

		/// <summary>
		/// factory method to create correct settings file
		/// </summary>
		/// <param name="folder"></param>
		/// <returns></returns>
		private SettingsFile CreateSettings(string folder)
		{
			return new SettingsFile(folder, (ICreditsManager)Game.Services.GetService(typeof(ICreditsManager)));
		}

		#endregion //Methods
	}
}