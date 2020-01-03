//-----------------------------------------------------------------------
// <copyright file="PoeKeyboardHelper.cs" company="Wohs">
//     Missing Copyright information from a valid stylecop.json file.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Linq;
using System.Reflection;

namespace Lurker.UI.Helpers
{
    public class MessagesHelper
    {
        #region Fields
        private static readonly string WaitMessage_Key = "WAIT_MESSAGE";
        private readonly string _waitMessage = "I'm busy right now I'll send you a party invite asap.";
        private static readonly string ThxMessage_Key = "THX_MESSAGE";
        private readonly string _thxMessage = "Thanks Exile, conquer the world with this awesome item.";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagesHelper"/> class.
        /// </summary>
        public MessagesHelper()
        {
            if (!File.Exists(BasePath() + "\\custom_messages.txt"))
            {
                File.Copy(BasePath() + "\\Resources\\base_messages.txt", BasePath() + "\\custom_messages.txt");
            }

            string[] lines = System.IO.File.ReadAllLines(BasePath() + "\\custom_messages.txt");
            var pairs = lines.Select(l => new { Line = l, Pos = l.IndexOf("=") });
            var dictionary = pairs.ToDictionary(p => p.Line.Substring(0, p.Pos).Trim(), p => p.Line.Substring(p.Pos + 1).Trim());

            if (dictionary[WaitMessage_Key] != null)
            {
                this._waitMessage = dictionary[WaitMessage_Key];
            }

            if (dictionary[ThxMessage_Key] != null)
            {
                this._thxMessage = dictionary[ThxMessage_Key];
            }
        }
        #endregion

        #region Methods
        public string WaitMessage()
        {
            return _waitMessage;
        }

        public string ThxMessage()
        {
            return _thxMessage;
        }


         private string BasePath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        #endregion
    }
}
