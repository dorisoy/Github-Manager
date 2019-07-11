using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.IO;

namespace github_management
{
    class FTPClient
    {
        string host;
        //string port;
        string username;
        string password;

        public FTPClient(string host, string username, string password)
        {
            this.host = host;
            //this.port = port;
            this.username = username;
            this.password = password;
        }

        public void UpdateFiles(GitHubCommit commit, DirectoryInfo temp_folder)
        {
            if(temp_folder.GetDirectories().Length == 0)
            {
                UpdateFiles(commit.Sha, temp_folder);
            }
            else
            {
                UpdateFiles(commit.Sha, temp_folder);
                DirectoryInfo[] folders = temp_folder.GetDirectories();
                for (int i = 0; i < folders.Length; i++)
                {
                    UpdateFiles(commit, folders[i]);
                }
            }
        }

        private void UpdateFiles(string sha, DirectoryInfo temp_folder)
        {
            FileInfo[] files = temp_folder.GetFiles();

            string ftp_path;
            int start_index = temp_folder.FullName.IndexOf(sha) + sha.Length + 1;

            if (start_index >= temp_folder.FullName.Length)
            {
                ftp_path = "";
            }
            else
            {
                ftp_path = temp_folder.FullName.Substring(start_index);
            }

            foreach (FileInfo file in files)
            {
                UpdateFile(temp_folder.FullName + "/" + file.Name, ftp_path);
            }
        }

        public void UpdateFile(string file_path, string ftp_path)
        {
            //FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + host + "/httpdocs/" + ftp_path);
            //ftpRequest.Credentials = new NetworkCredential(username, password);
            //ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            //byte[] fileContent;  //in this array you'll store the file's content

            //using (StreamReader sr = new StreamReader(file_path))  //file we want to upload
            //{
            //    fileContent = Encoding.UTF8.GetBytes(sr.ReadToEnd()); //getting the file's content, already transformed into a byte array
            //}

            //using (Stream sw = ftpRequest.GetRequestStream())
            //{
            //    sw.Write(fileContent, 0, fileContent.Length);  //sending the content to the FTP Server
            //}
        }
    }
}
