using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OperatorSettingsBuddy
{
	/// <summary>
	/// The options screen is brought up over the top of the main menu
	/// screen, and gives the user a chance to configure the game in various hopefully useful ways.
	/// If you'd like to add more options to this screen, inherit from it and override SettingsComponent.CreateSettingsScreen 
	/// </summary>
	public class SettingsScreen : MenuScreen
	{
		#region Fields

		/// <summary>
		/// menu entry to change the difficulty
		/// </summary>
		private MenuEntryInt _difficulty;

		/// <summary>
		/// menu entry to change the num credits to play
		/// </summary>
		private MenuEntryInt _numCredits;

		/// <summary>
		/// menu entry to change the attract mode sound on/off
		/// </summary>
		private MenuEntryBool _attractModeSound;

		/// <summary>
		/// menu entry to change the attract mode music on/off
		/// </summary>
		private MenuEntryBool _attractModeMusic;

		private MenuEntry _doneMenuEntry;

		/// <summary>
		/// the settings file to manipulate
		/// </summary>
		private SettingsFile Settings { get; set; }

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public SettingsScreen()
			: base("Operator Settings")
		{
			IsPopup = true;
		}

		public void Init(SettingsFile settings)
		{
			Settings = settings;

			//Create our menu entries.
			_difficulty = new MenuEntryInt("Difficulty", SettingsFile.Difficulty)
			{
				Step = 1,
				Min = 1,
				Max = 10,
				SizeMultiplier = 0.6f
			};

			_numCredits = new MenuEntryInt("Credits Per Play", Settings.NumCredits)
			{
				Step = 1,
				Min = 0,
				Max = 20,
				SizeMultiplier = 0.6f
			};

			_attractModeSound = new MenuEntryBool("Attract Mode Sound", SettingsFile.AttractModeSound)
			{
				SizeMultiplier = 0.6f
			};
			
			_attractModeMusic = new MenuEntryBool("Attract Mode Music", SettingsFile.AttractModeMusic)
			{
				SizeMultiplier = 0.6f
			};

			_doneMenuEntry = new MenuEntry("Done")
			{
				SizeMultiplier = 0.6f
			};

			_doneMenuEntry.Selected += OnCancel;

			//Add entries to the menu.
			MenuEntries.Add(_difficulty);
			MenuEntries.Add(_numCredits);
			MenuEntries.Add(_attractModeSound);
			MenuEntries.Add(_attractModeMusic);
			MenuEntries.Add(_doneMenuEntry);
		}

		#endregion

		#region Handle Input

		/// <summary>
		/// Handler for when the user has cancelled the menu.
		/// </summary>
		protected override void OnCancel(PlayerIndex playerIndex)
		{
			//update settings object from menu entries
			SettingsFile.Difficulty = _difficulty.Value;
			Settings.NumCredits = _numCredits.Value;
			SettingsFile.AttractModeSound = _attractModeSound.Value;
			SettingsFile.AttractModeMusic = _attractModeMusic.Value;

			//save settings
			Settings.Save();

			base.OnCancel(playerIndex);
		}

		public override void Draw(GameTime gameTime)
		{
			//Draw on a black background
			ScreenManager.SpriteBatchBegin();
			ScreenManager.FadeBackBufferToBlack(TransitionAlpha * 2.0f / 3.0f);
			ScreenManager.SpriteBatchEnd();
			
			base.Draw(gameTime);
		}

		#endregion
	}
}