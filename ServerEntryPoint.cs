using MediaBrowser.Controller.Configuration;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Plugins;
using MediaBrowser.Controller.Session;
using MediaBrowser.Model.Dto;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Session;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace GenericPlugin
{
    public class ServerEntryPoint : IServerEntryPoint
    {
        private ISessionManager SessionManager { get; set; }

        private IUserManager UserManager { get; set; }

        private IServerConfigurationManager ConfigManager { get; set; }

        private ILogger Log { get; set; }

        private string Locale = string.Empty;

        public ServerEntryPoint(ISessionManager sessionManager, IUserManager userManager, ILogManager logManager, IServerConfigurationManager configManager)
        {
            SessionManager = sessionManager;
            UserManager = userManager;
            ConfigManager = configManager;
            Log = logManager.GetLogger(Plugin.Instance.Name);
        }


        public void Dispose()
        {
            SessionManager.PlaybackStart -= PlaybackStart;
            SessionManager.PlaybackStopped -= PlaybackStopped;
            SessionManager.PlaybackProgress -= PlaybackProgress;
        }

        public void Run()
        {
            SessionManager.PlaybackStart += PlaybackStart;
            SessionManager.PlaybackStopped += PlaybackStopped;
            SessionManager.PlaybackProgress += PlaybackProgress;

            Plugin.Instance.UpdateConfiguration(Plugin.Instance.Configuration);
        }

        /// <summary>
        /// Executed on a playback started Emby event. Read the EDL file and add to commercialList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaybackStart(object sender, PlaybackProgressEventArgs e)
        {

        }

        /// <summary>
        /// Executed on a playback prorgress Emby event. See if it is in a identified commercial and skip if it is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaybackProgress(object sender, PlaybackProgressEventArgs e)
        {
 
        }

        /// <summary>
        /// Executed on a playback stopped Emby event. Remove the commercialList entries for the session.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaybackStopped(object sender, PlaybackStopEventArgs e)
        {

        }
 
    }
}
