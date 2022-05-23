using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match_Finder
{
    public partial class Main : Form
    {
        // initializator, ignore this
        public Main() { InitializeComponent(); }

        // values read from form on the form
        string formApiKey = "";
        string[] formPlayers;
        string formRoomName = "";
        int formRoomId = 0;

        // filters used to determine checks
        string playersFilter = "";
        string roomNameFilter = "";

        // how many matches checked in one search
        int checkedMatches = 0;

        // information file names, these are files that store all
        // kind of information and are saved in software default folder in variable below
        // all those files will have "INF" at the end so you know these
        public static string lastMpINF = "lastMp";

        // path where all INF files are stored
        string configFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
            "\\fl-wer\\Match Finder\\";

        // ran when loading form
        private void Main_Load(object sender, EventArgs e)
        {
            // changing some settings for the program
            webQueue1.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;

            // if software folder doesn't exist = make it
            if (!Directory.Exists(configFilesPath))
                Directory.CreateDirectory(configFilesPath);

            // read last mp link and apply to form if exists
            if (File.Exists(configFilesPath + lastMpINF))
            {
                int mpLink = 0;
                if (int.TryParse(File.ReadAllText(configFilesPath + lastMpINF), out mpLink))
                    startFromRoomIdNumeric.Value = mpLink;
            }

            // apply default dropdown settings
            playersDropdown.SelectedIndex = 0;
            roomNameDropdown.SelectedIndex = 0;
        }

        // start searching queue
        private void searchStopButton_Click(object sender, EventArgs e)
        {
            if (searchStopButton.Text == "Search")
            {
                // checks if enough information was provided onm the form for search
                // if so then runs all the background web calling queues
                string parseStatus = parseFormInfo();

                // checking if no error as parse status will hold error
                if (parseStatus == "")
                {
                    // cleaning checked matches counter
                    checkedMatches = 0;

                    // save last used mp link, adding blank string as without it
                    // windows dumb defender thinks it's bitcoin miner rofl
                    File.WriteAllText(Path.Combine(configFilesPath, lastMpINF), startFromRoomIdNumeric.Value + "");

                    // running queue
                    webQueue1.RunWorkerAsync();

                    // checking button name to Stop for identification
                    searchStopButton.Text = "Stop";
                }
                else showError(parseStatus);
            }
            // Text == "Stop, stopping queue on next iteration
            else webQueue1.CancelAsync();
        }

        // parse info from the form and assign to global variables
        // returns error message in string
        private string parseFormInfo()
        {
            // get api key from masked text box
            formApiKey = apiKeyMaskedTextBox.Text;

            // sanitized players textbox
            string sanitizedPlayersTextBox = playersTextBox.Text;

            // remove spaces from player list if someone decides
            // to add spaces after comma
            while (sanitizedPlayersTextBox.Contains(", "))
                sanitizedPlayersTextBox = sanitizedPlayersTextBox.Replace(", ", ",");

            // split players into an array by comma
            formPlayers = playersTextBox.Text.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries);

            // read room name
            formRoomName = roomNameTextBox.Text;

            // get first room id to start with removes one as every
            // iteration adds one number so it goes forward
            // but we don't want to miss the first room id
            formRoomId = (int)(startFromRoomIdNumeric.Value - 1);

            // read player filter
            // single means at least one player has to be in the room
            // all means all players should be in the room
            if (playersDropdown.SelectedIndex == 0) playersFilter = "All";
            else playersFilter = "Single";

            // read room name filter
            // equals means room name has to be exactly like in the box
            // contains means the room name has to contain the text in the box
            if (roomNameDropdown.SelectedIndex == 0) roomNameFilter = "Equals";
            else roomNameFilter = "Contains";

            // decide if information is correct and usable for search
            if (formApiKey != "" && (formPlayers.Length != 0 || formRoomName != "")) return "";
            else return "More information on the form required.";
        }

        // parses and returns match object
        private Match parseApiResponse(string response)
        {
            // creating new object for return, will use it to assign values below
            Match match = new Match();

            // parsing match id
            response = response.Remove(0, 22);
            match.id = response.Remove(response.IndexOf(",") - 1);

            // parsin match name
            response = response.Remove(0, response.IndexOf("name\"") + 7);
            match.name = response.Remove(response.IndexOf(",") - 1);

            // parsing users, it will hold all of the players in big array
            // and then be moved to the one with correct size
            string[] tempPlayersHolder = new string[1000];

            // used for inserting players into temp array above, 1 will be added
            // if user id didn't repeat
            int currentIndex = 0;

            // making sure there's no users left
            while (response.IndexOf("user_id\"") != -1)
            {
                // parsing response text
                response = response.Remove(0, response.IndexOf("user_id\"") + 10);
                string extractedPlayer = response.Remove(response.IndexOf(",") - 1);

                // go through already saved players and see if found one is already there
                bool repeating = false;
                foreach (string player in tempPlayersHolder)
                    if (player == extractedPlayer) repeating = true;

                // if user not saved yet -> save it
                if (!repeating)
                {
                    tempPlayersHolder[currentIndex] = extractedPlayer;
                    currentIndex += 1;
                }

                // creating correctly sized array, current index will have
                // count of non-repeated players in match
                match.players = new string[currentIndex];

                // transfer players from temp array to match object
                for (int i = 0; i < match.players.Length; i++)
                    match.players[i] = tempPlayersHolder[i];
            }

            // returning object with filled out details
            return match;
        }

        // show custom message box with warning or error icon
        public static void showError(string message) { MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        public static void showInfo(string message) { MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        // threads calling osu api
        private void webQueue1_DoWork(object sender, DoWorkEventArgs e)
        {
            // web client used for sending requests, in our case api requests to osu api
            WebClient webClient = new WebClient();

            // checking if user wants to stop this madness, if not then continues
            while (!webQueue1.CancellationPending)
            {
                // adding one to current room id so it uses next one
                // this removes possibility of queues using same id
                formRoomId += 1;

                // holds osu api response with all match info
                string apiReponse = "";

                // sending request to osu api
                try
                {
                    apiReponse = webClient.DownloadString("https://osu.ppy.sh/api/get_match?k=" + formApiKey +
                    "&mp=" + formRoomId.ToString());
                }
                catch { }

                // check if connected to osu api
                if (apiReponse != null && apiReponse != "")
                {
                    // making sure response is correct, if it is the 20th character will be :
                    if (apiReponse[20] == ':')
                    {
                        // parsing response into a match object
                        Match match = parseApiResponse(apiReponse);

                        // if at least one check won't pass it will change this var to false
                        bool checksPassed = true;

                        // players check
                        if (formPlayers.Length != 0)
                        {
                            // match playerrs will not be assigned if no players found in api response
                            if (match.players != null)
                            {
                                // found player matches in response
                                int matches = 0;

                                // go through both arrays and check how many players matching
                                foreach (string formPlayer in formPlayers)
                                    foreach (string responsePlayer in match.players)
                                        if (formPlayer == responsePlayer) matches += 1;

                                // if found less matches than players count then didn't pass check
                                if (playersFilter == "All" && matches < formPlayers.Length) checksPassed = false;
                                else if (matches < 1) checksPassed = false;
                            }
                            else checksPassed = false;
                        }

                        // room name check
                        if (formRoomName != "")
                        {
                            // check name based on used filtering
                            if (roomNameFilter == "Equals" && formRoomName != match.name) checksPassed = false;
                            else if (!match.name.Contains(formRoomName)) checksPassed = false;
                        }

                        // checks passed meaning we found room players was looking for
                        if (checksPassed)
                        {
                            // show info about the result
                            showInfo("Found match!");

                            // opens web browser with the mp room
                            Process.Start("https://osu.ppy.sh/community/matches/" + match.id);

                            // set background worker to stop
                            webQueue1.CancelAsync();
                        }
                    }

                    // add room to counter
                    checkedMatches += 1;

                    // change form title with checked matches
                    Text = "Match Finder | Checked: " + checkedMatches;
                }
            }
            // closing queue background worker and setting some details back
            searchStopButton.Text = "Search";
            Text = "Match Finder";
        }
    }
}
