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
		private readonly MenuEntry _difficulty;
		public int Difficulty { get; set; }

		/// <summary>
		/// menu entry to change the num credits to play
		/// </summary>
		private readonly MenuEntry _numCredits;
		public int NumCredits { get; set; }

		/// <summary>
		/// menu entry to change the attract mode sound on/off
		/// </summary>
		private readonly MenuEntry _attractModeSound;
		public int AttractModeSound { get; set; }

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public SettingsScreen()
			: base("Operator Settings")
		{
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

		/// <summary>
		/// Fills in the latest values for the options screen menu text.
		/// </summary>
		private void SetMenuEntryText()
		{
			//buttnutsEntry.Text = string.Format("buttnuts: {0}", currentButtnuts.ToString());
		}

		#endregion

		#region Handle Input

		/// <summary>
		/// Event handler for when the buttnuts selection menu entry is selected.
		/// </summary>
		private void ButtnutsEntrySelected(object sender, PlayerIndexEventArgs e)
		{
			////increment the mic
			//currentButtnuts++;

			//SetMenuEntryText();
		}

		//TODO: on menu exit, save settings

		#endregion
	}
}