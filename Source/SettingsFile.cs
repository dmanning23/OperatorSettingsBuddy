using Microsoft.Xna.Framework;
using EasyStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using FileBuddyLib;
using InsertCoinBuddy;

namespace OperatorSettingsBuddy
{
	/// <summary>
	/// This is a class to hold the operator settings for a game, and save/load them from a file.
	/// </summary>
	public class SettingsFile : FileBuddy
	{
		#region Member Variables

		int _numCredits = 0;

		#endregion //Member Variables

		#region Properties

		public int Difficulty { get; set; }

		public int NumCredits 
		{
			get
			{
				return _numCredits;
			}
			set
			{
				_numCredits = value;
				if (null != Credits)
				{
					Credits.CoinsPerCredit = value;
				}
			}
		}

		public bool AttractModeSound { get; set; }

		private ICreditsManager Credits { get; set; }

		#endregion //Properties

		#region Methods

		/// <summary>
		/// hello standard constructor!
		/// </summary>
		public SettingsFile(string folderLocation, ICreditsManager creditManager)
			: base(folderLocation, "OperatorSettings.xml")
		{
			SaveMethod = WriteHighScores;
			LoadMethod = ReadHighScores;
			Credits = creditManager;
		}

		#endregion //Methods

		#region XML Methods

		/// <summary>
		/// do the actual writing out to disk
		/// </summary>
		/// <param name="myFileStream">My file stream.</param>
		private void WriteHighScores(Stream myFileStream)
		{
			try
			{
				//open the file, create it if it doesnt exist yet
				XmlTextWriter rFile = new XmlTextWriter(myFileStream, null);
				rFile.Formatting = Formatting.Indented;
				rFile.Indentation = 1;
				rFile.IndentChar = '\t';

				//save all the high scores!
				rFile.WriteStartDocument();

				//save settings
				SaveSettings(rFile);

				rFile.WriteEndDocument();

				// Close the file.
				rFile.Flush();
				rFile.Close();
			}
			catch (Exception ex)
			{
				// just write some debug output for our verification
				Debug.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// If you add more settings, override this method to save them
		/// </summary>
		/// <param name="rFile"></param>
		public virtual void SaveSettings(XmlTextWriter rFile)
		{
			//write the settings element
			rFile.WriteStartElement("Settings");

			//write the difficulty
			rFile.WriteStartElement("Difficulty");
			rFile.WriteString(Difficulty.ToString());
			rFile.WriteEndElement();

			//write the num credits
			rFile.WriteStartElement("NumCredits");
			rFile.WriteString(NumCredits.ToString());
			rFile.WriteEndElement();

			//write the attract mode sound
			rFile.WriteStartElement("AttractModeSound");
			rFile.WriteString(AttractModeSound.ToString());
			rFile.WriteEndElement();

			rFile.WriteEndElement();
		}

		/// <summary>
		/// to the actual reading in from disk
		/// </summary>
		/// <param name="myFileStream">My file stream.</param>
		private void ReadHighScores(Stream myFileStream)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(myFileStream);
			XmlNode rootNode = xmlDoc.DocumentElement;

			//make sure it is actually an xml node
			if (rootNode.NodeType == XmlNodeType.Element)
			{
				//load settings
				LoadSettings(rootNode);
			}
			else
			{
				//should be an xml node!!!
				Debug.Assert(false);
			}
		}

		/// <summary>
		/// If you add more settings, override this method to load them
		/// </summary>
		/// <param name="rootNode"></param>
		public virtual void LoadSettings(XmlNode rootNode)
		{
			//make sure is correct type of node
			Debug.Assert("Settings" == rootNode.Name);

			//Read in child nodes
			if (rootNode.HasChildNodes)
			{
				for (XmlNode childNode = rootNode.FirstChild;
				null != childNode;
				childNode = childNode.NextSibling)
				{
					//what is in this node?
					string strName = childNode.Name;
					string strValue = childNode.InnerText;

					if (strName == "Difficulty")
					{
						Difficulty = Convert.ToInt32(strValue);
					}
					else if (strName == "NumCredits")
					{
						NumCredits = Convert.ToInt32(strValue);
					}
					else if (strName == "AttractModeSound")
					{
						AttractModeSound = Convert.ToBoolean(strValue);
					}
				}
			}
		}

		#endregion //XML Methods
	}
}