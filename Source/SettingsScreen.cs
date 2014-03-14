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
		private readonly MenuEntryInt _difficulty;

		/// <summary>
		/// menu entry to change the num credits to play
		/// </summary>
		private readonly MenuEntryInt _numCredits;

		/// <summary>
		/// menu entry to change the attract mode sound on/off
		/// </summary>
		private readonly MenuEntryBool _attractModeSound;

		private readonly MenuEntry _doneMenuEntry;

		/// <summary>
		/// the settings file to manipulate
		/// </summary>
		private SettingsFile Settings { get; set; }

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public SettingsScreen(SettingsFile settings)
			: base("Operator Settings")
		{
			Settings = settings;

			//Create our menu entries.
			_difficulty = new MenuEntryInt("Difficulty", Settings.Difficulty)
			{
				Step = 1,
				Min = 1,
				Max = 10
			};

			_numCredits = new MenuEntryInt("Credits Per Play", Settings.NumCredits)
			{
				Step = 1,
				Min = 0,
				Max = 20
			};

			_attractModeSound = new MenuEntryBool("Attract Mode Sound", Settings.AttractModeSound);
			_doneMenuEntry = new MenuEntry("Done");

			_doneMenuEntry.Selected += OnCancel;

			//Add entries to the menu.
			MenuEntries.Add(_difficulty);
			MenuEntries.Add(_numCredits);
			MenuEntries.Add(_attractModeSound);
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
			Settings.Difficulty = _difficulty.Value;
			Settings.NumCredits = _numCredits.Value;
			Settings.AttractModeSound = _attractModeSound.Value;

			//save settings
			Settings.Save();

			base.OnCancel(playerIndex);
		}

		

		#endregion
	}
}