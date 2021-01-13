using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhlDownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum HeaderTableColumnInfo
        {
            WatchList,
            Player,
            Owner,
            GamesPlayed,
            FanPoints,
            PreSeasonRanking,
            CurrentRanking,
            OwnedPercentage,
            Stat1,
            Stat2,
            Stat3,
            Stat4,
            Stat5,
            Stat6,
            Stat7,
            Stat8,
            Stat9,
            Stat10
        }
        enum PlayerTableColumnInfo
        {
            WatchList,
            Player,
            AddDropTrade,
            Opponent,
            Owner,
            GamesPlayed,
            FanPoints,
            PreSeasonRanking,
            CurrentRanking,
            OwnedPercentage,
            TimeOnIce,
            Stat1,
            Stat2,
            Stat3,
            Stat4,
            Stat5,
            Stat6,
            Stat7,
            Stat8,
            Stat9,
            Stat10
        }

        string[] Positions = new string[] { "C", "R", "L", "D" };

        private void button1_Click(object sender, EventArgs e)
        {
            int leagueNumber = 0;
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Style = ProgressBarStyle.Marquee;
            labelStatus.Text = "Downloading ...";
            labelStatus.Visible = true;
            button1.Enabled = false;
            
            if (int.TryParse(textBoxLeagueNumber.Text, out leagueNumber))
            {
                if (leagueNumber <= 0) return;
            }
            else
            {
                return;
            }
            string endurl;
            if (radioButton1.Checked)
            {
                String Scoring = "/players?&sort=AR&sdir=1&status=ALL&pos=P&stat1=S_PSR&jsenabled=1";
                endurl = Scoring;
            }
            else if (radioButton2.Checked)
            {
                String Scoring = "/players?&sort=AR&sdir=1&status=ALL&pos=P&stat1=S_S_2019&jsenabled=1";
                endurl = Scoring;
            }
            else if (radioButton3.Checked)
            {
                String Scoring = "/players?&sort=AR&sdir=1&status=ALL&pos=P&stat1=S_S_2020&jsenabled=1";
                endurl = Scoring;
            }
            else
            {
                String Scoring = "/players?sort=OR&sdir=1&status=ALL&pos=P&stat1=S_S_2019&jsenabled=1";
                endurl = Scoring;
            }
                try
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("NHLP" + leagueNumber.ToString() + ".csv"))
                {
                    for (int pages = 0; pages < 30; pages++) //30 * 25 players per page = top 625 players
                    {
                        //String baseUrl = "https://hockey.fantasysports.yahoo.com/hockey/" + leagueNumber.ToString() + "/players?status=ALL&pos=P&cut_type=33&stat1=S_S_2017&myteam=0&sort=AR&sdir=1";
                        String baseUrl = "https://hockey.fantasysports.yahoo.com/hockey/" + leagueNumber.ToString() + endurl;
                        String pageUrl;
                        if (pages == 0)
                        {
                            pageUrl = baseUrl;
                        }
                        else
                        {
                            pageUrl = baseUrl + "&count=" + (pages * 25);
                        }

                        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageUrl);
                        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                        HtmlAgilityPack.HtmlWeb getHtmlWeb = new HtmlAgilityPack.HtmlWeb();
                        HtmlAgilityPack.HtmlDocument document = getHtmlWeb.Load(pageUrl);
                        if (document.ParsedText.Contains("Request denied"))
                        {
                            System.Threading.Thread.Sleep(180000);
                            getHtmlWeb = new HtmlAgilityPack.HtmlWeb();
                            document = getHtmlWeb.Load(pageUrl);
                        }
                        // Page is loaded, go through the stats for each player
                       // var headers = document.DocumentNode.SelectNodes("//div[@id='players-table']//div[@class='players']//table//thead//tr[@class='Alt Last']");
                        //file.Write("PlayerName,Position,Owner");
                       /* foreach (HtmlAgilityPack.HtmlNode Header in headers)
                        {
                            var items = Header.Descendants("th");
                            int headerTableColumnCounter = 0;
                            string value;
                            foreach (HtmlAgilityPack.HtmlNode item in items)
                            {
                                switch ((HeaderTableColumnInfo)headerTableColumnCounter)
                                {
                                    case HeaderTableColumnInfo.WatchList:
                                        break;
                                    case HeaderTableColumnInfo.Player:
                                        file.Write("PlayerName,Position");
                                        break;
                                   case HeaderTableColumnInfo.Owner:
                                        file.Write("Owner");
                                        break;
                                    *//*   case PlayerTableColumnInfo.TimeOnIce:
                                           value = item.SelectSingleNode(".//div").InnerText;
                                           if (checkBoxPointsLeague.Checked)
                                           {
                                               if (value.Equals("-"))
                                                   file.Write(",00:00:00");
                                               else
                                                   file.Write(",00:" + value);
                                           }
                                           else
                                           {
                                               if (value.Equals("-"))
                                                   file.Write(",0");
                                               else
                                                   file.Write("," + value);
                                               break;
                                           }
                                           break;

                                      case PlayerTableColumnInfo.OwnedPercentage:
                                           value = item.SelectSingleNode(".//div").InnerText;
                                           if (!checkBoxPointsLeague.Checked)
                                           {
                                               if (value.Equals("-"))
                                                   file.Write(",00:00:00");
                                               else
                                                   file.Write(",00:" + value);
                                           }
                                           else
                                           {
                                               if (value.Equals("-"))
                                                   file.Write(",0");
                                               else
                                                   file.Write("," + value);
                                               break;
                                           }
                                           break;
                                           *//*
                                    default:
                                        value = item.SelectSingleNode(".//div").InnerText;
                                        if (value.Equals("-"))
                                            file.Write(",0");
                                        else
                                            file.Write("," + value);
                                        break;
                                }
                                headerTableColumnCounter++;
                            }
                            file.WriteLine("");
                        }*/
                        
                        var players = document.DocumentNode.SelectNodes("//div[@id='players-table']//div[@class='players']//table//tbody//tr");
                        //Debug.WriteLine("Players found =" + players.Count());
                        

                        foreach (HtmlAgilityPack.HtmlNode player in players)
                        {
                            var items = player.Descendants("td");
                            int playerTableColumnCounter = 0;
                            string value;
                            foreach (HtmlAgilityPack.HtmlNode item in items)
                            {
                                switch ((PlayerTableColumnInfo)playerTableColumnCounter)
                                {
                                    case PlayerTableColumnInfo.WatchList:
                                    case PlayerTableColumnInfo.AddDropTrade:
                                    case PlayerTableColumnInfo.Opponent:
                                        //    string adtRaw = item.SelectSingleNode(".//a").Attributes["title"].Value;
                                        //    string[] adt = adtRaw.Split(' ');
                                        //    Debug.Write("," + adt[0].Trim());
                                        break;

                                    case PlayerTableColumnInfo.Player:
                                        string playerName = item.SelectSingleNode(".//a[@class='Nowrap name F-link']").InnerText;
                                        string teamPosition = item.SelectSingleNode(".//span[@class='Fz-xxs']").InnerText;
                                       string[] tm = teamPosition.Split('-');
                                        string team = tm[0].Trim();
                                        file.Write(playerName);
                                        string position = tm[1].Replace(",", "/").Trim();
                                        //position = position.Replace("W", "");
                                        file.Write("," + position);
                                        //for (int p = 0; p < Positions.Length; p++)
                                        //{
                                        //    if (position.Contains(Positions[p]))
                                        //        file.Write("," + Positions[p]);
                                        //    else
                                        //        file.Write(",");
                                        //}
                                        break;

                                 /*   case PlayerTableColumnInfo.TimeOnIce:
                                        value = item.SelectSingleNode(".//div").InnerText;
                                        if (checkBoxPointsLeague.Checked)
                                        {
                                            if (value.Equals("-"))
                                                file.Write(",00:00:00");
                                            else
                                                file.Write(",00:" + value);
                                        }
                                        else
                                        {
                                            if (value.Equals("-"))
                                                file.Write(",0");
                                            else
                                                file.Write("," + value);
                                            break;
                                        }
                                        break;

                                   case PlayerTableColumnInfo.OwnedPercentage:
                                        value = item.SelectSingleNode(".//div").InnerText;
                                        if (!checkBoxPointsLeague.Checked)
                                        {
                                            if (value.Equals("-"))
                                                file.Write(",00:00:00");
                                            else
                                                file.Write(",00:" + value);
                                        }
                                        else
                                        {
                                            if (value.Equals("-"))
                                                file.Write(",0");
                                            else
                                                file.Write("," + value);
                                            break;
                                        }
                                        break;
                                        */
                                    default:
                                        value = item.SelectSingleNode(".//div").InnerText;
                                        if (value.Equals("-"))
                                            file.Write(",0");
                                        else
                                            file.Write("," + value);
                                        break;
                                }
                                playerTableColumnCounter++;
                            }
                            file.WriteLine("");
                        }
                    }
                    progressBar1.MarqueeAnimationSpeed = 0;
                    labelStatus.Text = "Downloaded to " + "NHLP" + leagueNumber.ToString() + ".csv !";
                    labelStatus.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception=" + ex.Message);
                labelStatus.Text = "Failed download!";
                labelStatus.Visible = true;
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelStatus.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int leagueNumber = 0;
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Style = ProgressBarStyle.Marquee;
            labelStatus.Text = "Downloading ...";
            labelStatus.Visible = true;
            button2.Enabled = false;
            if (int.TryParse(textBoxLeagueNumber.Text, out leagueNumber))
            {
                if (leagueNumber <= 0) return;
            }
            else
            {
                return;
            }
            string endurl;
            if (radioButton1.Checked)
            {
                String Scoring = "/players?&sort=AR&sdir=1&status=ALL&pos=G&stat1=S_PSR&jsenabled=1";
                endurl = Scoring;
            }
            else if(radioButton2.Checked)
            {
                String Scoring = "/players?sort=OR&sdir=1&status=ALL&pos=G&stat1=S_S_2019&jsenabled=1";
                endurl = Scoring;
            }
            else if (radioButton3.Checked)
            {
                String Scoring = "/players?sort=OR&sdir=1&status=ALL&pos=G&stat1=S_S_2020&jsenabled=1";
                endurl = Scoring;
            }
            else
            {
                String Scoring = "/players?sort=OR&sdir=1&status=ALL&pos=G&stat1=S_S_2020&jsenabled=1";
                endurl = Scoring;
            }

            try
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("NHLG" + leagueNumber.ToString() + ".csv"))
                {
                    for (int pages = 0; pages < 5; pages++) //5 * 25 players per page = top 125 players
                    {
                        //String baseUrl = "https://hockey.fantasysports.yahoo.com/hockey/" + leagueNumber.ToString() + "/players?status=ALL&pos=P&cut_type=33&stat1=S_S_2017&myteam=0&sort=AR&sdir=1";
                        String baseUrl = "https://hockey.fantasysports.yahoo.com/hockey/" + leagueNumber.ToString() + endurl;
                        String pageUrl;
                        if (pages == 0)
                        {
                            pageUrl = baseUrl;
                        }
                        else
                        {
                            pageUrl = baseUrl + "&count=" + (pages * 25);
                        }

                        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageUrl);
                        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                        HtmlAgilityPack.HtmlWeb getHtmlWeb = new HtmlAgilityPack.HtmlWeb();
                        HtmlAgilityPack.HtmlDocument document = getHtmlWeb.Load(pageUrl);

                        // Page is loaded, go through the stats for each player
                        var players = document.DocumentNode.SelectNodes("//div[@id='players-table']//div[@class='players']//table//tbody//tr");
                        Debug.WriteLine("Players found =" + players.Count());

                        foreach (HtmlAgilityPack.HtmlNode player in players)
                        {
                            var items = player.Descendants("td");
                            int playerTableColumnCounter = 0;
                            string value;
                            foreach (HtmlAgilityPack.HtmlNode item in items)
                            {
                                switch ((PlayerTableColumnInfo)playerTableColumnCounter)
                                {
                                    case PlayerTableColumnInfo.WatchList:
                                    case PlayerTableColumnInfo.AddDropTrade:
                                    case PlayerTableColumnInfo.Opponent:
                                        //    string adtRaw = item.SelectSingleNode(".//a").Attributes["title"].Value;
                                        //    string[] adt = adtRaw.Split(' ');
                                        //    Debug.Write("," + adt[0].Trim());
                                        break;

                                    case PlayerTableColumnInfo.Player:
                                        string playerName = item.SelectSingleNode(".//a[@class='Nowrap name F-link']").InnerText;
                                       string teamPosition = item.SelectSingleNode(".//span[@class='Fz-xxs']").InnerText;
                                      string[] tm = teamPosition.Split('-');
                                       string team = tm[0].Trim();
                                        file.Write(playerName);
                                        string position = tm[1].Replace(",", "").Trim();
                                       position = position.Replace("W", "");
                                        file.Write("," + position);
                                        for (int p = 0; p < Positions.Length; p++)
                                       {
                                            if (position.Contains(Positions[p]))
                                                file.Write("," + Positions[p]);
                                            else
                                                file.Write(",");
                                        }
                                        break;

                                   /* case PlayerTableColumnInfo.TimeOnIce:
                                        value = item.SelectSingleNode(".//div").InnerText;
                                        if (checkBoxPointsLeague.Checked)
                                        {
                                            if (value.Equals("-"))
                                                file.Write(",00:00:00");
                                            else
                                                file.Write(",00:" + value);
                                        }
                                        else
                                        {
                                            if (value.Equals("-"))
                                                file.Write(",0");
                                            else
                                                file.Write("," + value);
                                            break;
                                        }
                                        break;

                                    case PlayerTableColumnInfo.OwnedPercentage:
                                        value = item.SelectSingleNode(".//div").InnerText;
                                        if (!checkBoxPointsLeague.Checked)
                                        {
                                            if (value.Equals("-"))
                                                file.Write(",00:00:00");
                                            else
                                                file.Write(",00:" + value);
                                        }
                                        else
                                        {
                                            if (value.Equals("-"))
                                                file.Write(",0");
                                            else
                                                file.Write("," + value);
                                            break;
                                        }
                                        break;*/

                                    default:
                                        value = item.SelectSingleNode(".//div").InnerText;
                                        if (value.Equals("-"))
                                            file.Write(",0");
                                        else
                                            file.Write("," + value);
                                        break;
                                }
                                playerTableColumnCounter++;
                            }
                            file.WriteLine("");
                        }
                    }
                    progressBar1.MarqueeAnimationSpeed = 0;
                    labelStatus.Text = "Downloaded to " + "NHLG" + leagueNumber.ToString() + ".csv !";
                    labelStatus.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception=" + ex.Message);
                labelStatus.Text = "Failed download!";
                labelStatus.Visible = true;
            }
            finally
            {
                button2.Enabled = true;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
