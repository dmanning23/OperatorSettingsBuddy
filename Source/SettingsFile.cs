using Microsoft.Xna.Framework;
using EasyStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using FileBuddyLib;

namespace OperatorSettingsBuddy
{
	/// <summary>
	/// This is a class to hold the operator settings for a game, and save/load them from a file.
	/// </summary>
	public class SettingsFile : FileBuddy
	{
		#region Member Variables

		public int Difficulty { get; set; }

		public int NumCredits { get; set; }

		public bool AttractModeSound { get; set; }

		#endregion //Member Variables

		#region Methods

		/// <summary>
		/// hello standard constructor!
		/// </summary>
		public SettingsFile(string folderLocation)
			: base(folderLocation, "OperatorSettings.xml")
		{
			SaveMethod = WriteHighScores;
			LoadMethod = ReadHighScores;
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
			//TODO: save settings

			////write the high score table element
			//rFile.WriteStartElement("highscoretable");

			////write out all the lists
			//foreach (KeyValuePair<string, HighScoreList> entry in HighScoreLists)
			//{
			//	// do something with entry.Value or entry.Key
			//	entry.Value.WriteToXML(rFile);
			//}

			//rFile.WriteEndElement();
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
			//TODO: load settings

			//make sure is correct type of node
			Debug.Assert("highscoretable" == rootNode.Name);

			//read high score lists
			if (rootNode.HasChildNodes)
			{
				XmlNode childNode = rootNode.FirstChild;
				while (childNode != null)
				{
					//get the name of this list
					string ListName = "";
					XmlNamedNodeMap mapAttributes = childNode.Attributes;
					for (int i = 0; i < mapAttributes.Count; i++)
					{
						//will only have the name attribute
						string strName = mapAttributes.Item(i).Name;
						string strValue = mapAttributes.Item(i).Value;
						if ("ListName" == strName)
						{
							ListName = strValue;
						}
						else
						{
							//unknwon attribute in the xml file!!!
							Debug.Assert(false);
						}
					}

					////find the list from the xml file
					//Debug.Assert(!String.IsNullOrEmpty(ListName));
					//HighScoreList rHighScoreList = HighScoreLists[ListName];
					//Debug.Assert(null != rHighScoreList);

					////create, read, and store a new high score list from this xml node
					//rHighScoreList.ReadFromXML(childNode);
					//HighScoreLists[rHighScoreList.Name] = rHighScoreList;

					//next node!
					childNode = childNode.NextSibling;
				}
			}
		}

		#endregion //XML Methods
	}
}