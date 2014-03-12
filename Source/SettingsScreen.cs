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

		//TODO: create MenuEntryInt and MenuEntryBool

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

			//// Create our menu entries.
			//buttnutsEntry = new MenuEntry(string.Empty);

			//SetMenuEntryText();

			//var backMenuEntry = new MenuEntry("Done");

			//// Hook up menu event handlers.
			//buttnutsEntry.Selected += ButtnutsEntrySelected;
			//backMenuEntry.Selected += OnCancel;

			//// Add entries to the menu.
			//MenuEntries.Add(buttnutsEntry);
			//MenuEntries.Add(backMenuEntry);
		}

		#endregion

		#region Handle Input

		/// <summary>
		/// Handler for when the user has cancelled the menu.
		/// </summary>
		protected override void OnCancel(PlayerIndex playerIndex)
		{
			//TODO: on menu exit, save settings

			base.OnCancel(playerIndex);
		}

		

		#endregion
	}
}