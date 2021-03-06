﻿using System;
using Microsoft.SharePoint.Client;

namespace Sherpa.Installer
{
    public class AuthenticationHandler
    {
        public SharePointOnlineCredentials GetCredentialsForSharePointOnline(string userName, Uri urlToSite)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your password for {0}: ", userName);
                var password = PasswordReader.GetConsoleSecurePassword();
                Console.ResetColor();
                Console.WriteLine();

                if (password != null && password.Length > 0)
                {
                    var credentials = new SharePointOnlineCredentials(userName, password);
                    if (AuthenticateUser(credentials, urlToSite))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Account successfully authenticated!");
                        Console.ResetColor();

                        return credentials;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Couldn't authenticate user. Try again.");
                    Console.ResetColor();
                }
                else
                {
                    return GetCredentialsForSharePointOnline(userName, urlToSite);
                }
            }
        }

        private bool AuthenticateUser(SharePointOnlineCredentials credentials, Uri urlToSite)
        {
            try
            {
                credentials.GetAuthenticationCookie(urlToSite);
                return true;
            }
            catch (IdcrlException)
            {
                return false;
            }
        }
    }
}
