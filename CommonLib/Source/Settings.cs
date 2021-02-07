using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ris;

namespace MyNamespace
{
    //**************************************************************************
    //**************************************************************************
    //**************************************************************************
    // This class provides an encapsulation of a tta factory test record.

    public class Settings
    {
        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Constants

        public const string cFilePath = @"Settings.json";

        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Members.

        public string CommPort{ get; set; }
        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Constructor.

        public Settings()
        {
            reset();
        }

        public void reset()
        {
            // Amp A.
            CommPort = "COM12";
        }

        public void Show()
        {
            // Amp A.
            Prn.print(0, " Factory Test Settings************************************");
            Prn.print(0, "CommPort                 {0}", CommPort);
        }

    }

    //**************************************************************************
    //**************************************************************************
    //**************************************************************************
    // Write records to json files or csv strings.

    public class SettingsWriter
    {
        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Write a record to a json file.

        public static void WriteSettingsToJsonFile(Settings aSettings)
        {
            // Serialize the record into a string and write the string
            // to the file.
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string tJsonString = JsonSerializer.Serialize(aSettings, options);
            File.WriteAllText(Settings.cFilePath, tJsonString);
        }

        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Get a json string from the string values of a record.

        public static string GetJsonStringFromSettings(Settings aSettings)
        {
            // Serialize the list into a json string return it.
            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
            };
            string tJsonString = JsonSerializer.Serialize(aSettings, options);
            return tJsonString;
        }

    }

    //**************************************************************************
    //**************************************************************************
    //**************************************************************************
    // Read from json file. 

    public class SettingsReader
    {
        public static Settings ReadSettingsFromJsonFile()
        {
            // Create a record.
            Settings tSettings = new Settings();
          
            // If the file doesn't exist, then set defaults, write to the
            // file, and exit.
            if (!File.Exists(Settings.cFilePath))
            {
                SettingsWriter.WriteSettingsToJsonFile(tSettings);
                return tSettings;
            }

            // Read the file into a string and deserialize the stting
            // into the record.
            string tJsonString = File.ReadAllText(Settings.cFilePath);
            tSettings = JsonSerializer.Deserialize<Settings>(tJsonString);

            // Return the record.
            return tSettings;
        }

        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Read a record from a json string.

        public static Settings ReadSettingsFromJsonString(string aJsonString)
        {
            // Create a record.
            Settings tSettings = new Settings();

            // Read the file into a string and deserialize the stting
            // into the record.
            tSettings = JsonSerializer.Deserialize<Settings>(aJsonString);

            // Return the record.
            return tSettings;
        }

    }

    //******************************************************************************
    //******************************************************************************
    //******************************************************************************
}//namespace

