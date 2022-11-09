using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace Dashboard
{
    public partial class Main : Form
    {
        public static bool fileValid;
        private Random rnd = new Random();
        public static bool fileRun;
        private Bitmap planeMarker = (Bitmap)Image.FromFile("img/plane.png");
        public string selectedMapProvider = "Bing";
        private GMapOverlay markers = new GMapOverlay("markers");
        private GMapOverlay allMarkers = new GMapOverlay("allMarkers");
        private List<PointLatLng> points = new List<PointLatLng>();
        private List<PointLatLng> pointsA = new List<PointLatLng>();
        private List<PointLatLng> pointsB = new List<PointLatLng>();
        private List<PointLatLng> pointsTotSel = new List<PointLatLng>();
        private List<PointLatLng> pointsIni = new List<PointLatLng>();
        public bool visibleTop = true;
        public bool clickedMap = false;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
            (int nleftRect, int nTopRect, int nRightRect, int nBottomRectn,
            int nWidthEllipse, int nHeightEllipse);
        public Main()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            pnlNav.Left = btnMenu.Left;
            btnMenu.BackColor = Color.FromArgb(46, 51, 73);
            btnMenu.ForeColor = System.Drawing.Color.Orange;
            btnMessages.ForeColor = System.Drawing.Color.DarkGray;
            btnTable.ForeColor = System.Drawing.Color.DarkGray;
            btnMap.ForeColor = System.Drawing.Color.DarkGray;
            btnSearch.ForeColor = System.Drawing.Color.DarkGray;
            btnSettings.ForeColor = System.Drawing.Color.DarkGray;
            HomeDark.Visible = false;
            MsgDark.Visible = true;
            TableDark.Visible = true;
            mapDark.Visible = true;
            searchDark.Visible = true;
            settingsDark.Visible = true;

            fileRun = false;
            fileValid = false;
        }
        public void Main_Load(object sender, EventArgs e)
        {

        }
        public void btnMenu_Click(object sender, EventArgs e)
        {
            btnMenu.BackColor = Color.FromArgb(46, 51, 73);
            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            pnlNav.Left = btnMenu.Left;
            btnMessages.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
            btnMap.BackColor = Color.FromArgb(24, 30, 54);
            btnTable.BackColor = Color.FromArgb(24, 30, 54);
            btnSearch.BackColor = Color.FromArgb(24, 30, 54);
            btnMenu.ForeColor = System.Drawing.Color.Orange;
            btnMessages.ForeColor = System.Drawing.Color.DarkGray;
            btnTable.ForeColor = System.Drawing.Color.DarkGray;
            btnMap.ForeColor = System.Drawing.Color.DarkGray;
            btnSearch.ForeColor = System.Drawing.Color.DarkGray;
            btnSettings.ForeColor = System.Drawing.Color.DarkGray;
            HomeDark.Visible = false;
            MsgDark.Visible = true;
            TableDark.Visible = true;
            mapDark.Visible = true;
            searchDark.Visible = true;
            settingsDark.Visible = true;
            searchFile.Text = "Click to select a File";

            //if (fileRun == false)
            //{
            //    lblTitle.Text = "Menu";
            //    this.pnlFormLoader.Controls.Clear();
            //    this.pnlFormLoader.Controls.Add(searchFile);
            //    this.pnlFormLoader.Controls.Add(searchOK);
            //    this.pnlFormLoader.Controls.Add(Warning);
            //    this.pnlFormLoader.Controls.Add(OpenFile);
            //    this.pnlFormLoader.Controls.Add(lblBits);
            //    this.pnlFormLoader.Controls.Add(lblBytes);
            //    this.pnlFormLoader.Controls.Add(lblDBlocks);
            //    this.pnlFormLoader.Controls.Add(Warning2);
            //    this.pnlFormLoader.Controls.Add(lblDItems);
            //    this.pnlFormLoader.Controls.Add(lblDItime0);
            //    this.pnlFormLoader.Controls.Add(lblDItimefin);
            //    searchFile.Visible = true;
            //    searchOK.Visible = true;
            //    Warning.Visible = false;
            //    OpenFile.Visible = true;
            //}
            //else
            //{
            this.pnlFormLoader.Controls.Clear();
            this.pnlFormLoader.Controls.Add(searchFile);
            this.pnlFormLoader.Controls.Add(searchOK);
            this.pnlFormLoader.Controls.Add(Warning);
            this.pnlFormLoader.Controls.Add(OpenFile);
            this.pnlFormLoader.Controls.Add(lblBits);
            this.pnlFormLoader.Controls.Add(lblBytes);
            this.pnlFormLoader.Controls.Add(lblDBlocks);
            this.pnlFormLoader.Controls.Add(numDataItems);
            this.pnlFormLoader.Controls.Add(decode);
            this.pnlFormLoader.Controls.Add(Warning2);
            this.pnlFormLoader.Controls.Add(lblDItems);
            this.pnlFormLoader.Controls.Add(lblDItime0);
            this.pnlFormLoader.Controls.Add(lblDItimefin);
            this.pnlFormLoader.Controls.Add(decodeAll);

            lblTitle.Text = "Menu";
            searchFile.Visible = true;
            searchOK.Visible = true;
            lblBits.Visible = true;
            lblBytes.Visible = true;
            lblDBlocks.Visible = true;
            textBox1.Visible = false;
            listBox.Visible = false;
            listBoxDB.Visible = false;
            listBoxDI.Visible = false;
            infoBox.Visible = false;
            infoPic.Visible = false;
            titleLB.Visible = false;
            titleDB.Visible = false;
            titleDI.Visible = false;
            btnClear.Visible = false;
            Warning.Visible = true;
            OpenFile.Visible = true;
            dataGrid.Visible = false;
            infoTable.Visible = false;
            listSearch.Visible = false;
            btnSearchBy.Visible = false;
            listBoxID.Visible = false;
            dataGridS.Visible = false;
            timeFinal.Visible = false;
            timeInitial.Visible = false;
            lblTimeInitial.Visible = false;
            lblTimeInitialValue.Visible = false;
            lblFinalTime.Visible = false;
            lblFinalTimeValue.Visible = false;
            gMap.Visible = false;
            btnTimeConsole.Visible = false;
            btnPlay.Visible = false;
            btnPause.Visible = false;
            btnBack.Visible = false;
            btnFirst.Visible = false;
            btnLast.Visible = false;
            btnForward.Visible = false;
            btnClearTraces.Visible = false;
            btnRoutesID.Visible = false;
            btnRoutesTrack.Visible = false;
            btnRoutesMode3A.Visible = false;
            btnBackMap.Visible = false;
            timeBar.Visible = false;
            lblcurrentTime.Visible = false;
            lblBarInitial.Visible = false;
            lblBarFinal.Visible = false;
            pnlMedia.Visible = false;
            lblDBlocks.Visible = false;
            lblBits.Visible = false;
            lblBytes.Visible = false;
            decodeAll.Visible = false;
            pnlSettings.Visible = false;
            if (visibleTop == true)
            {
                lblFile.Visible = true;
            }
            //}

        }
        public void btnMessages_Click(object sender, EventArgs e)
        {
            btnMessages.BackColor = Color.FromArgb(46, 51, 73);
            pnlNav.Height = btnMessages.Height;
            pnlNav.Top = btnMessages.Top;
            pnlNav.Left = btnMessages.Left;
            btnMenu.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
            btnMap.BackColor = Color.FromArgb(24, 30, 54);
            btnSearch.BackColor = Color.FromArgb(24, 30, 54);
            btnTable.BackColor = Color.FromArgb(24, 30, 54);
            btnMessages.ForeColor = System.Drawing.Color.Orange;
            btnMenu.ForeColor = System.Drawing.Color.DarkGray;
            btnTable.ForeColor = System.Drawing.Color.DarkGray;
            btnMap.ForeColor = System.Drawing.Color.DarkGray;
            btnSearch.ForeColor = System.Drawing.Color.DarkGray;
            btnSettings.ForeColor = System.Drawing.Color.DarkGray;
            HomeDark.Visible = true;
            MsgDark.Visible = false;
            TableDark.Visible = true;
            mapDark.Visible = true;
            searchDark.Visible = true;
            settingsDark.Visible = true;

            if (fileRun == false)
            {
                lblTitle.Text = "Messages";
                this.pnlFormLoader.Controls.Clear();
                NoFile noFileMsgs = new NoFile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                noFileMsgs.FormBorderStyle = FormBorderStyle.None;
                this.pnlFormLoader.Controls.Add(noFileMsgs);
                noFileMsgs.Show();
                lblFile.Text = "";
            }
            else
            {
                this.pnlFormLoader.Controls.Add(textBox1);
                this.pnlFormLoader.Controls.Add(listBox);
                this.pnlFormLoader.Controls.Add(listBoxDB);
                this.pnlFormLoader.Controls.Add(listBoxDI);
                this.pnlFormLoader.Controls.Add(infoBox);
                this.pnlFormLoader.Controls.Add(infoPic);
                this.pnlFormLoader.Controls.Add(titleLB);
                this.pnlFormLoader.Controls.Add(titleDB);
                this.pnlFormLoader.Controls.Add(titleDI);
                this.pnlFormLoader.Controls.Add(btnClear);

                if (visibleTop == true)
                {
                    lblFile.Visible = true;
                    lblFile.Text = file;
                }

                lblTitle.Text = "Messages";
                searchFile.Visible = false;
                searchOK.Visible = false;
                lblBits.Visible = false;
                lblBytes.Visible = false;
                lblDBlocks.Visible = false;
                textBox1.Visible = true;
                listBox.Visible = true;
                listBoxDB.Visible = false;
                listBoxDI.Visible = false;
                infoBox.Visible = false;
                infoPic.Visible = false;
                titleLB.Visible = true;
                titleDB.Visible = false;
                titleDI.Visible = false;
                btnClear.Visible = true;
                Warning.Visible = false;
                OpenFile.Visible = false;
                dataGrid.Visible = false;
                infoTable.Visible = false;
                listSearch.Visible = false;
                btnSearchBy.Visible = false;
                listBoxID.Visible = false;
                dataGridS.Visible = false;
                timeFinal.Visible = false;
                timeInitial.Visible = false;
                lblTimeInitial.Visible = false;
                lblTimeInitialValue.Visible = false;
                lblFinalTime.Visible = false;
                lblFinalTimeValue.Visible = false;
                gMap.Visible = false;
                btnTimeConsole.Visible = false;
                btnPlay.Visible = false;
                btnPause.Visible = false;
                btnBack.Visible = false;
                btnFirst.Visible = false;
                btnLast.Visible = false;
                btnForward.Visible = false;
                btnClearTraces.Visible = false;
                btnRoutesID.Visible = false;
                btnRoutesTrack.Visible = false;
                btnRoutesMode3A.Visible = false;
                btnBackMap.Visible = false;
                timeBar.Visible = false;
                lblcurrentTime.Visible = false;
                lblBarInitial.Visible = false;
                lblBarFinal.Visible = false;
                pnlMedia.Visible = false;
                numDataItems.Visible = false;
                decode.Visible = false;
                lblDItems.Visible = false;
                lblDItime0.Visible = false;
                lblDItimefin.Visible = false;
                Warning2.Visible = false;
                decodeAll.Visible = false;
                pnlSettings.Visible = false;
            }
        }
        public void btnTable_Click(object sender, EventArgs e)
        {
            btnTable.BackColor = Color.FromArgb(46, 51, 73);
            pnlNav.Height = btnTable.Height;
            pnlNav.Top = btnTable.Top;
            pnlNav.Left = btnTable.Left;
            btnMenu.BackColor = Color.FromArgb(24, 30, 54);
            btnMessages.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
            btnSearch.BackColor = Color.FromArgb(24, 30, 54);
            btnMap.BackColor = Color.FromArgb(24, 30, 54);
            btnTable.ForeColor = System.Drawing.Color.Orange;
            btnMessages.ForeColor = System.Drawing.Color.DarkGray;
            btnMenu.ForeColor = System.Drawing.Color.DarkGray;
            btnMap.ForeColor = System.Drawing.Color.DarkGray;
            btnSearch.ForeColor = System.Drawing.Color.DarkGray;
            btnSettings.ForeColor = System.Drawing.Color.DarkGray;
            HomeDark.Visible = true;
            MsgDark.Visible = true;
            TableDark.Visible = false;
            mapDark.Visible = true;
            searchDark.Visible = true;
            settingsDark.Visible = true;

            if (fileRun == false)
            {
                lblTitle.Text = "Table of Data";
                this.pnlFormLoader.Controls.Clear();
                NoFile noFileMap = new NoFile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                noFileMap.FormBorderStyle = FormBorderStyle.None;
                this.pnlFormLoader.Controls.Add(noFileMap);
                noFileMap.Show();
                lblFile.Text = "";
            }
            else
            {
                if (visibleTop == true)
                {
                    lblFile.Visible = true;
                    lblFile.Text = file;
                }
                this.pnlFormLoader.Controls.Add(dataGrid);
                lblTitle.Text = "Table of Data";
                searchFile.Visible = false;
                searchOK.Visible = false;
                lblBits.Visible = false;
                lblBytes.Visible = false;
                lblDBlocks.Visible = false;
                textBox1.Visible = false;
                listBox.Visible = false;
                listBoxDB.Visible = false;
                listBoxDI.Visible = false;
                infoBox.Visible = false;
                infoPic.Visible = false;
                titleLB.Visible = false;
                titleDB.Visible = false;
                titleDI.Visible = false;
                btnClear.Visible = false;
                Warning.Visible = false;
                OpenFile.Visible = false;
                dataGrid.Visible = true;
                infoTable.Visible = true;
                listSearch.Visible = false;
                btnSearchBy.Visible = false;
                listBoxID.Visible = false;
                dataGridS.Visible = false;
                timeFinal.Visible = false;
                timeInitial.Visible = false;
                lblTimeInitial.Visible = false;
                lblTimeInitialValue.Visible = false;
                lblFinalTime.Visible = false;
                lblFinalTimeValue.Visible = false;
                gMap.Visible = false;
                btnTimeConsole.Visible = false;
                btnPlay.Visible = false;
                btnPause.Visible = false;
                btnBack.Visible = false;
                btnFirst.Visible = false;
                btnLast.Visible = false;
                btnForward.Visible = false;
                btnClearTraces.Visible = false;
                btnRoutesID.Visible = false;
                btnRoutesTrack.Visible = false;
                btnRoutesMode3A.Visible = false;
                btnBackMap.Visible = false;
                timeBar.Visible = false;
                lblcurrentTime.Visible = false;
                lblBarInitial.Visible = false;
                lblBarFinal.Visible = false;
                pnlMedia.Visible = false;
                numDataItems.Visible = false;
                decode.Visible = false;
                infoTable.Text = "Keep cursor over column headers to get more info";
                lblDItems.Visible = false;
                lblDItime0.Visible = false;
                lblDItimefin.Visible = false;
                Warning2.Visible = false;
                decodeAll.Visible = false;
                pnlSettings.Visible = false;
            }
        }
        public void btnMap_Click(object sender, EventArgs e)
        {
            btnMap.BackColor = Color.FromArgb(46, 51, 73);
            pnlNav.Height = btnMap.Height;
            pnlNav.Top = btnMap.Top;
            pnlNav.Left = btnMap.Left;
            btnMenu.BackColor = Color.FromArgb(24, 30, 54);
            btnMessages.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
            btnSearch.BackColor = Color.FromArgb(24, 30, 54);
            btnTable.BackColor = Color.FromArgb(24, 30, 54);
            btnMap.ForeColor = System.Drawing.Color.Orange;
            btnMessages.ForeColor = System.Drawing.Color.DarkGray;
            btnTable.ForeColor = System.Drawing.Color.DarkGray;
            btnMenu.ForeColor = System.Drawing.Color.DarkGray;
            btnSearch.ForeColor = System.Drawing.Color.DarkGray;
            btnSettings.ForeColor = System.Drawing.Color.DarkGray;
            HomeDark.Visible = true;
            MsgDark.Visible = true;
            TableDark.Visible = true;
            mapDark.Visible = false;
            searchDark.Visible = true;
            settingsDark.Visible = true;

            if (fileRun == false)
            {
                lblTitle.Text = "Map";
                this.pnlFormLoader.Controls.Clear();
                NoFile noFileMap = new NoFile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                noFileMap.FormBorderStyle = FormBorderStyle.None;
                this.pnlFormLoader.Controls.Add(noFileMap);
                noFileMap.Show();
                lblFile.Text = "";
            }
            else
            {
                if (visibleTop == true)
                {
                    lblFile.Visible = true;
                    lblFile.Text = file;
                }
                this.pnlFormLoader.Controls.Clear();
                this.pnlFormLoader.Controls.Add(gMap);
                this.gMap.Controls.Add(btnClearTraces);
                this.gMap.Controls.Add(listSearch);
                this.gMap.Controls.Add(btnSearchBy);
                this.gMap.Controls.Add(btnTimeConsole);
                this.gMap.Controls.Add(listBoxID);
                this.gMap.Controls.Add(timeInitial);
                this.gMap.Controls.Add(timeFinal);
                this.gMap.Controls.Add(lblFinalTime);
                this.gMap.Controls.Add(lblFinalTimeValue);
                this.gMap.Controls.Add(lblTimeInitial);
                this.gMap.Controls.Add(lblTimeInitialValue);
                this.gMap.Controls.Add(pnlMedia);
                this.pnlMedia.Controls.Add(btnPlay);
                this.pnlMedia.Controls.Add(btnPause);
                this.pnlMedia.Controls.Add(btnBack);
                this.pnlMedia.Controls.Add(btnFirst);
                this.pnlMedia.Controls.Add(btnForward);
                this.pnlMedia.Controls.Add(btnLast);
                this.gMap.Controls.Add(lblcurrentTime);
                this.gMap.Controls.Add(btnRoutesID);
                this.gMap.Controls.Add(btnRoutesTrack);
                this.gMap.Controls.Add(btnRoutesMode3A);
                this.gMap.Controls.Add(btnBackMap);
                this.gMap.Controls.Add(timeBar);
                this.gMap.Controls.Add(lblBarInitial);
                this.gMap.Controls.Add(lblBarFinal);
                this.gMap.Controls.Add(pnlPlaneInfo);
                this.gMap.Controls.Add(pnlForFast);
                this.gMap.Controls.Add(pnlBackFast);

                //// Create map overlay



                gMap.Visible = true;
                btnClearTraces.Visible = true;

                // map settings
                gMap.ShowCenter = true;
                gMap.DragButton = MouseButtons.Left;
                if (selectedMapProvider == "Bing")
                {
                    gMap.MapProvider = GMapProviders.BingMap;
                }
                else if (selectedMapProvider == "Google Maps")
                {
                    gMap.MapProvider = GMapProviders.GoogleMap;
                }
                else if (selectedMapProvider == "Google Satellite Map")
                {
                    gMap.MapProvider = GMapProviders.GoogleSatelliteMap;
                }
                else if (selectedMapProvider == "Google Terrain Map")
                {
                    gMap.MapProvider = GMapProviders.GoogleSatelliteMap;
                }
                gMap.MinZoom = 5;
                gMap.MaxZoom = 100;
                gMap.Zoom = 8;

                lblTitle.Text = "Map";
                searchFile.Visible = false;
                searchOK.Visible = false;
                lblBits.Visible = false;
                lblBytes.Visible = false;
                lblDBlocks.Visible = false;
                textBox1.Visible = false;
                listBox.Visible = false;
                listBoxDB.Visible = false;
                listBoxDI.Visible = false;
                infoBox.Visible = false;
                infoPic.Visible = false;
                titleLB.Visible = false;
                titleDB.Visible = false;
                titleDI.Visible = false;
                btnClear.Visible = false;
                Warning.Visible = false;
                OpenFile.Visible = false;
                dataGrid.Visible = false;
                infoTable.Visible = false;
                listSearch.Visible = false;
                btnSearchBy.Visible = true;
                listBoxID.Visible = false;
                dataGridS.Visible = false;
                timeFinal.Visible = false;
                timeInitial.Visible = false;
                lblTimeInitial.Visible = false;
                lblTimeInitialValue.Visible = false;
                lblFinalTime.Visible = false;
                lblFinalTimeValue.Visible = false;
                btnTimeConsole.Visible = true;
                btnPlay.Visible = false;
                btnPause.Visible = false;
                btnBack.Visible = false;
                btnFirst.Visible = false;
                btnLast.Visible = false;
                btnForward.Visible = false;
                btnRoutesID.Visible = false;
                btnRoutesTrack.Visible = false;
                btnRoutesMode3A.Visible = false;
                btnBackMap.Visible = false;
                timeBar.Visible = false;
                lblcurrentTime.Visible = false;
                lblBarInitial.Visible = false;
                lblBarFinal.Visible = false;
                pnlMedia.Visible = false;

                RoutesIDOn = false;
                RoutesTrackOn = false;
                RoutesMode3AOn = false;
                btnRoutesID.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesID.ForeColor = System.Drawing.Color.DarkGray;
                listBoxID.Items.Clear();
                listBoxID.Visible = false;
                selectedRoute = false;
                numDataItems.Visible = false;
                decode.Visible = false;
                lblDItems.Visible = false;
                lblDItime0.Visible = false;
                lblDItimefin.Visible = false;
                Warning2.Visible = false;
                decodeAll.Visible = false;
                pnlSettings.Visible = false;
            }
        }
        public void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.FromArgb(46, 51, 73);
            pnlNav.Height = btnSearch.Height;
            pnlNav.Top = btnSearch.Top;
            pnlNav.Left = btnSearch.Left;
            btnMenu.BackColor = Color.FromArgb(24, 30, 54);
            btnMessages.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
            btnMap.BackColor = Color.FromArgb(24, 30, 54);
            btnTable.BackColor = Color.FromArgb(24, 30, 54);
            btnSearch.ForeColor = System.Drawing.Color.Orange;
            btnMessages.ForeColor = System.Drawing.Color.DarkGray;
            btnTable.ForeColor = System.Drawing.Color.DarkGray;
            btnMap.ForeColor = System.Drawing.Color.DarkGray;
            btnMenu.ForeColor = System.Drawing.Color.DarkGray;
            btnSettings.ForeColor = System.Drawing.Color.DarkGray;
            HomeDark.Visible = true;
            MsgDark.Visible = true;
            TableDark.Visible = true;
            mapDark.Visible = true;
            searchDark.Visible = false;
            settingsDark.Visible = true;


            if (fileRun == false)
            {
                lblTitle.Text = "Search by";
                this.pnlFormLoader.Controls.Clear();
                NoFile noFileSearch = new NoFile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                noFileSearch.FormBorderStyle = FormBorderStyle.None;
                this.pnlFormLoader.Controls.Add(noFileSearch);
                noFileSearch.Show();
                lblFile.Text = "";
            }
            else
            {
                this.pnlFormLoader.Controls.Clear();
                this.pnlFormLoader.Controls.Add(listSearch);
                this.pnlFormLoader.Controls.Add(btnSearchBy);
                this.pnlFormLoader.Controls.Add(listBoxID);
                this.pnlFormLoader.Controls.Add(dataGridS);
                this.pnlFormLoader.Controls.Add(timeInitial);
                this.pnlFormLoader.Controls.Add(timeFinal);
                this.pnlFormLoader.Controls.Add(lblFinalTime);
                this.pnlFormLoader.Controls.Add(lblFinalTimeValue);
                this.pnlFormLoader.Controls.Add(lblTimeInitial);
                this.pnlFormLoader.Controls.Add(lblTimeInitialValue);

                if (visibleTop == true)
                {
                    lblFile.Visible = true;
                    lblFile.Text = file;
                }
                lblTitle.Text = "Search by";
                searchFile.Visible = false;
                searchOK.Visible = false;
                lblBits.Visible = false;
                lblBytes.Visible = false;
                lblDBlocks.Visible = false;
                textBox1.Visible = false;
                listBox.Visible = false;
                listBoxDB.Visible = false;
                listBoxDI.Visible = false;
                infoBox.Visible = false;
                infoPic.Visible = false;
                titleLB.Visible = false;
                titleDB.Visible = false;
                titleDI.Visible = false;
                btnClear.Visible = false;
                Warning.Visible = false;
                OpenFile.Visible = false;
                dataGrid.Visible = false;
                infoTable.Visible = false;
                listSearch.Visible = false;
                btnSearchBy.Visible = true;
                listBoxID.Visible = false;
                timeFinal.Visible = false;
                timeInitial.Visible = false;
                lblTimeInitial.Visible = false;
                lblTimeInitialValue.Visible = false;
                lblFinalTime.Visible = false;
                lblFinalTimeValue.Visible = false;
                dataGridS.Visible = true;
                gMap.Visible = false;
                btnTimeConsole.Visible = false;
                btnPlay.Visible = false;
                btnPause.Visible = false;
                btnBack.Visible = false;
                btnFirst.Visible = false;
                btnLast.Visible = false;
                btnForward.Visible = false;
                btnClearTraces.Visible = false;
                btnRoutesID.Visible = false;
                btnRoutesTrack.Visible = false;
                btnRoutesMode3A.Visible = false;
                btnBackMap.Visible = false;
                timeBar.Visible = false;
                lblcurrentTime.Visible = false;
                lblBarInitial.Visible = false;
                lblBarFinal.Visible = false;
                pnlMedia.Visible = false;
                numDataItems.Visible = false;
                decode.Visible = false;
                lblDItems.Visible = false;
                lblDItime0.Visible = false;
                lblDItimefin.Visible = false;
                Warning2.Visible = false;
                decodeAll.Visible = false;
                pnlSettings.Visible = false;
            }
        }
        public void btnSettings_Click(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            pnlNav.Left = btnMessages.Left;
            btnMenu.BackColor = Color.FromArgb(24, 30, 54);
            btnMessages.BackColor = Color.FromArgb(24, 30, 54);
            btnMap.BackColor = Color.FromArgb(24, 30, 54);
            btnSearch.BackColor = Color.FromArgb(24, 30, 54);
            btnTable.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.ForeColor = System.Drawing.Color.Orange;
            btnMessages.ForeColor = System.Drawing.Color.DarkGray;
            btnTable.ForeColor = System.Drawing.Color.DarkGray;
            btnMap.ForeColor = System.Drawing.Color.DarkGray;
            btnSearch.ForeColor = System.Drawing.Color.DarkGray;
            btnMenu.ForeColor = System.Drawing.Color.DarkGray;
            HomeDark.Visible = true;
            MsgDark.Visible = true;
            TableDark.Visible = true;
            mapDark.Visible = true;
            searchDark.Visible = true;
            settingsDark.Visible = false;

            if (fileRun == false)
            {
                lblTitle.Text = "Settings";
                this.pnlFormLoader.Controls.Clear();
                NoFile noFileSearch = new NoFile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                noFileSearch.FormBorderStyle = FormBorderStyle.None;
                this.pnlFormLoader.Controls.Add(noFileSearch);
                noFileSearch.Show();
                lblFile.Text = "";
            }
            else
            {
                this.pnlFormLoader.Controls.Clear();
                this.pnlFormLoader.Controls.Add(pnlSettings);
                this.pnlSettings.Controls.Add(setMenu);
                if (visibleTop == true)
                {
                    lblFile.Visible = true;
                    lblFile.Text = file;
                }
                lblTitle.Text = "Settings";
                searchFile.Visible = false;
                searchOK.Visible = false;
                lblBits.Visible = false;
                lblBytes.Visible = false;
                lblDBlocks.Visible = false;
                textBox1.Visible = false;
                listBox.Visible = false;
                listBoxDB.Visible = false;
                listBoxDI.Visible = false;
                infoBox.Visible = false;
                infoPic.Visible = false;
                titleLB.Visible = false;
                titleDB.Visible = false;
                titleDI.Visible = false;
                btnClear.Visible = false;
                Warning.Visible = false;
                OpenFile.Visible = false;
                dataGrid.Visible = false;
                infoTable.Visible = false;
                listSearch.Visible = false;
                btnSearchBy.Visible = false;
                listBoxID.Visible = false;
                dataGridS.Visible = false;
                timeFinal.Visible = false;
                timeInitial.Visible = false;
                lblTimeInitial.Visible = false;
                lblTimeInitialValue.Visible = false;
                lblFinalTime.Visible = false;
                lblFinalTimeValue.Visible = false;
                gMap.Visible = false;
                btnTimeConsole.Visible = false;
                btnPlay.Visible = false;
                btnPause.Visible = false;
                btnBack.Visible = false;
                btnFirst.Visible = false;
                btnLast.Visible = false;
                btnForward.Visible = false;
                btnClearTraces.Visible = false;
                btnRoutesID.Visible = false;
                btnRoutesTrack.Visible = false;
                btnRoutesMode3A.Visible = false;
                btnBackMap.Visible = false;
                timeBar.Visible = false;
                lblcurrentTime.Visible = false;
                lblBarInitial.Visible = false;
                lblBarFinal.Visible = false;
                pnlMedia.Visible = false;
                numDataItems.Visible = false;
                decode.Visible = false;
                lblDItems.Visible = false;
                lblDItime0.Visible = false;
                lblDItimefin.Visible = false;
                Warning2.Visible = false;
                decodeAll.Visible = false;
                pnlSettings.Visible = true;
                setMenu.Visible = true;
                setMap.Visible = true;
                setInfo.Visible = true;
                setDiv1.Visible = true;
                setDiv2.Visible = true;
                setDiv3.Visible = true;
                lblRemoveFile.Visible = true;
                btnRemoveFile.Visible = true;
                lblCautionRemove.Visible = true;
                lblVisibleName.Visible = true;
                btnVisibleTop.Visible = true;
                lblExportCSV.Visible = true;
                btnExportCSV.Visible = true;
                lblExportFileKML.Visible = true;
                btnExportKML.Visible = true;
                lblMapProvider.Visible = true;
                listMapProviders.Visible = true;
                lblsetInterval.Visible = true;
                lbl1Step.Visible = true;
                btn1Step.Visible = true;
                lbl2Steps.Visible = true;
                btn2Steps.Visible = true;
                lblCaution2Steps.Visible = true;
                lblMoreInfo.Visible = true;
                btnInfoProgram.Visible = true;
                lblbottom.Visible = true;
                lblExportDBText.Visible = true;
                lblExportDIText.Visible = true;
                btnExportDBText.Visible = true;
                btnExportDIText.Visible = true;
                btnExportDBText.BackColor = Color.Gray;
                btnExportDIText.BackColor = Color.Gray;
                btnExportCSV.BackColor = Color.Gray;
                btnExportKML.BackColor = Color.Gray;
                listMapProviders.Items.Clear();
                listMapProviders.Items.Add(selectedMapProvider);
                btnRemoveFile.BackColor = Color.Gray;
                if (interval == 1)
                {
                    btn1Step.BackColor = Color.Orange;
                    btn2Steps.BackColor = Color.Gray;
                }
                else if (interval == 2)
                {
                    btn2Steps.BackColor = Color.Orange;
                    btn1Step.BackColor = Color.Gray;
                }

            }
        }
        public void btnLogout_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }



        public static List<DataBlock>? dataBlocks;
        public static List<DataItem>? dataItems;

        public static string messageString;

        public static int numBits;
        public static int numBytes;
        public static int numDataBlocks;

        public static string file;
        private void searchFile_Click(object sender, EventArgs e)
        {
            fileRun = false;
            fileValid = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files (*.*)|*.*|Asterix Files (*.ast)|*.ast|Asterix Files (*.asterix)|*.asterix|txt files (*.txt)|*.txt";
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                searchFile.Text = ofd.FileName;

                if (ofd.FileName.EndsWith(".txt") || ofd.FileName.EndsWith(".ast") || ofd.FileName.EndsWith(".asterix"))
                {
                    fileValid = true;
                    file = ofd.FileName;
                    OpenFile.Text = "Valid File. Press OK and wait";
                }
                else OpenFile.Text = "File not Valid";
            }
            else OpenFile.Text = "File not Valid";
        }
        public void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "PSST! try typing: \"Message X \"";
            titleDB.Visible = false;
            titleDI.Visible = false;
            listBoxDB.Visible = false;
            listBoxDI.Visible = false;
            listBox.Items.Clear();
            if (dataBlocks.Count < 65000)
            {
                foreach (var (dataitem, indexd) in dataItems.Select((value, i) => (value, i)))
                {
                    int index2 = indexd + 1;

                    listBox.Items.Add("Message " + index2);
                }
            }
        }
        public int tam;
        int index2;
        List<string> SavedID = new List<string>();
        List<string> SavedTrack = new List<string>();
        List<string> SavedMode3A = new List<string>();
        List<string> SavedOAir = new List<string>();
        List<string> SavedDAir = new List<string>();
        List<Double> SavedTimeDouble = new List<Double>();
        List<string> SavedTimestr = new List<string>();

        public int flagID;
        public int flagTrackNumber;
        public int flagOAir;
        public int flagDAir;
        public int interval = 1;

        public string target;

        string itemSB;
        List<string> uniqueID = new List<string>();
        List<string> uniqueTrackNumber = new List<string>();
        List<string> uniqueMode3A = new List<string>();
        List<string> uniqueOAir = new List<string>();
        List<string> uniqueDAir = new List<string>();
        List<string> uniqueTimestr = new List<string>();
        List<string> uniqueTimeLap = new List<string>();
        List<int> itemTimeLap = new List<int>();
        List<int> newTimeBegin = new List<int>();
        List<int> newTimeNumber = new List<int>();

        public Double chosenTimeI;
        public Double chosenTimeF;
        public Double timeBetweenMsg;
        public bool anticlockwise;

        public bool shot;
        public bool RoutesIDOn;
        public bool RoutesTrackOn;
        public bool RoutesMode3AOn;
        public bool selectedRoute;
        public int selectedRouteInitimeBar;
        public int selectedRouteFintimeBar;
        List<int> selectedTimes = new List<int>();
        List<int> selectedMSG = new List<int>();
        public int selectedMSGint;

        List<float> MHGPlane = new List<float>();
        List<Double> trackMFL = new List<Double>();
        List<int> trackMFLY = new List<int>();
        List<int> trackMFLX = new List<int>();
        public int k;
        public bool liveVert = false;


        public void searchOK_Click(object sender, EventArgs e)
        {

            Warning.Visible = true;
            Warning.Text = "Reading file... please wait";


            if (fileValid == true)
            {
                uniqueID.Clear();
                uniqueTrackNumber.Clear();
                uniqueOAir.Clear();
                uniqueDAir.Clear();
                uniqueTimestr.Clear();
                uniqueTimeLap.Clear();
                newTimeBegin.Clear();
                newTimeNumber.Clear();

                Decoder AsterixMessage = new Decoder(file);
                messageString = AsterixMessage.messageString;

                numBits = AsterixMessage.numBits;
                numBytes = AsterixMessage.numBytes;
                numDataBlocks = AsterixMessage.numDataBlocks;

                Warning.Text = "DONE";
                lblBits.Visible = true;
                lblBits.Text = "Number of bits: " + numBits;
                lblBytes.Visible = true;
                lblBytes.Text = "Number of bytes: " + numBytes;
                lblDBlocks.Visible = true;
                lblDBlocks.Text = "Number of DataBlocks: " + numDataBlocks;
                listBox.Items.Clear();
                listBoxAltern.Items.Clear();

                SavedID.Clear();
                SavedTrack.Clear();
                SavedDAir.Clear();
                SavedOAir.Clear();
                SavedTimestr.Clear();
                SavedMode3A.Clear();

                dataBlocks = AsterixMessage.getDataBlocks(messageString, numBytes);// Get DataBlocks List
                decode.Visible = true;
                decodeAll.Visible = true;
                numDataItems.Visible = true;

                MessageBox.Show("DataBlocks decoded" + Environment.NewLine + "Select number of DataBlocks to Decode and wait"
                    + Environment.NewLine + "HINT: program will be smoother with up to 60k DB" + Environment.NewLine + Environment.NewLine +
                    "OR, choose Decode All to select all dataBlocks" + Environment.NewLine + "This may slow down the program");
                //tam = dataBlocks.Count;// Set FRNs and Data Items ---------> dataBlocks.Count

                //dataGrid.Rows.Clear();
                //dataGridS.Rows.Clear();
                //dataGrid.Rows.Add(tam);
                //dataGridS.Rows.Add(tam);
                //var dataItems2 = new List<DataItem>();
                //flagID = 0;
                //flagTrackNumber = 0;
                //flagDAir = 0;
                //flagOAir = 0;

                //foreach (var (DataBlock, indexd) in dataBlocks.Select((value, i) => (value, i)))
                //{
                //    if (indexd < tam)
                //    {
                //        index2 = indexd + 1;
                //        listBoxAltern.Items.Add("Message " + index2);
                //        if (dataBlocks.Count < 65000)
                //        {
                //            listBox.Items.Add("Message " + index2);
                //            DataBlock.getFRNs(DataBlock.FSPEC);
                //            dataItems2.Add(new DataItem(dataBlocks[indexd].Data, dataBlocks[indexd].FRNs));
                //        }
                //        else
                //        {
                //            DataBlock.getFRNs(DataBlock.FSPEC);
                //            dataItems2.Add(new DataItem(dataBlocks[indexd].Data, dataBlocks[indexd].FRNs, ""));
                //        }
                //        dataItems = dataItems2;
                //        SavedTimestr.Add(dataItems[indexd].TimeOfTrackInfo);
                //        SavedTimeDouble.Add(dataItems[indexd].TimeSeconds);
                //        SavedMode3A.Add(dataItems[indexd].Mode3AReply);
                //        dataGrid[0, indexd].Value = index2.ToString();
                //        target = "";

                //        if (dataItems[indexd].TargetID != "")
                //        {
                //            target = dataItems[indexd].TargetID;
                //            SavedID.Add(target);
                //            flagID = 1;
                //        }
                //        else if (dataItems[indexd].ID != "")
                //        {
                //            target = dataItems[indexd].ID;
                //            SavedID.Add(target);
                //            flagID = 1;
                //        }
                //        else if (dataItems[indexd].Callsign != "")
                //        {
                //            target = dataItems[indexd].Callsign;
                //            SavedID.Add(target);
                //            flagID = 1;
                //        }
                //        else
                //        {
                //            SavedID.Add("");
                //        }
                //        dataGrid[1, indexd].Value = target;
                //        dataGrid[3, indexd].Value = dataItems[indexd].TimeOfTrackInfo;
                //        if (dataItems[indexd].TrackNumber != "")
                //        {
                //            SavedTrack.Add(dataItems[indexd].TrackNumber);
                //            dataGrid[2, indexd].Value = dataItems[indexd].TrackNumber;
                //            flagTrackNumber = 1;
                //        }
                //        else
                //        {
                //            SavedTrack.Add("");
                //        }
                //        if (dataItems[indexd].DestinationAirport != "")
                //        {
                //            SavedDAir.Add(dataItems[indexd].DestinationAirport);
                //            flagDAir = 1;
                //        }
                //        else
                //        {
                //            SavedDAir.Add("");
                //        }
                //        if (dataItems[indexd].DepartureAirport != "")
                //        {
                //            SavedOAir.Add(dataItems[indexd].DepartureAirport);
                //            flagOAir = 1;
                //        }
                //        else
                //        {
                //            SavedOAir.Add("");
                //        }
                //        dataGrid[4, indexd].Value = dataItems[indexd].LatWGS84str + ", " + dataItems[indexd].LonWGS84str;
                //        dataGrid[5, indexd].Value = dataItems[indexd].X + ", " + dataItems[indexd].Y;
                //        dataGrid[6, indexd].Value = dataItems[indexd].Vx + ", " + dataItems[indexd].Vy;
                //        dataGrid[7, indexd].Value = dataItems[indexd].ADR;
                //        dataGrid[8, indexd].Value = dataItems[indexd].Mode3AReply;
                //        dataGrid[9, indexd].Value = dataItems[indexd].DepartureAirport;
                //        dataGrid[10, indexd].Value = dataItems[indexd].DestinationAirport;
                //    }
                //}

                //fileRun = true;
                //MessageBox.Show("DONE");

                //}
            }
            else OpenFile.Text = "File not valid";

        }
        int itemIndex;
        string itemIndexFRN;
        public void numDataItems_Click(object sender, EventArgs e)
        {
            numDataItems.Text = "";
        }
        private void numDataItems_TextChanged(object sender, EventArgs e)
        {
            if (numDataItems.Text == "")
            {
                tam = 1000000;
            }
            else
            {
                bool isNumber = int.TryParse(numDataItems.Text, out int n); // returns true
                if (isNumber == true)
                {
                    tam = Convert.ToInt32(numDataItems.Text);
                }
                else
                {
                    tam = 1000000;
                }
            }

        }
        public void decode_Click(object sender, EventArgs e)
        {
            if ((tam >= 150) && (tam < dataBlocks.Count + 1))
            {


                dataGrid.Rows.Clear();
                dataGridS.Rows.Clear();
                dataGrid.Rows.Add(tam);
                dataGridS.Rows.Add(tam);
                var dataItems2 = new List<DataItem>();
                flagID = 0;
                flagTrackNumber = 0;
                flagDAir = 0;
                flagOAir = 0;

                foreach (var (DataBlock, indexd) in dataBlocks.Select((value, i) => (value, i)))
                {
                    if (indexd < tam)
                    {
                        index2 = indexd + 1;
                        listBoxAltern.Items.Add("Message " + index2);
                        if (dataBlocks.Count < 65000)
                        {
                            listBox.Items.Add("Message " + index2);
                            DataBlock.getFRNs(DataBlock.FSPEC);
                            dataItems2.Add(new DataItem(dataBlocks[indexd].Data, dataBlocks[indexd].FRNs));
                        }
                        else
                        {
                            DataBlock.getFRNs(DataBlock.FSPEC);
                            dataItems2.Add(new DataItem(dataBlocks[indexd].Data, dataBlocks[indexd].FRNs, ""));
                        }
                        dataItems = dataItems2;
                        SavedTimestr.Add(dataItems[indexd].TimeOfTrackInfo);
                        SavedTimeDouble.Add(dataItems[indexd].TimeSeconds);
                        SavedMode3A.Add(dataItems[indexd].Mode3AReply);
                        dataGrid[0, indexd].Value = index2.ToString();
                        target = "";

                        if (dataItems[indexd].TargetID != "")
                        {
                            target = dataItems[indexd].TargetID;
                            SavedID.Add(target);
                            flagID = 1;
                        }
                        else if (dataItems[indexd].ID != "")
                        {
                            target = dataItems[indexd].ID;
                            SavedID.Add(target);
                            flagID = 1;
                        }
                        else if (dataItems[indexd].Callsign != "")
                        {
                            target = dataItems[indexd].Callsign;
                            SavedID.Add(target);
                            flagID = 1;
                        }
                        else
                        {
                            SavedID.Add("");
                        }
                        dataGrid[1, indexd].Value = target;
                        dataGrid[3, indexd].Value = dataItems[indexd].TimeOfTrackInfo;
                        if (dataItems[indexd].TrackNumber != "")
                        {
                            SavedTrack.Add(dataItems[indexd].TrackNumber);
                            dataGrid[2, indexd].Value = dataItems[indexd].TrackNumber;
                            flagTrackNumber = 1;
                        }
                        else
                        {
                            SavedTrack.Add("");
                        }
                        if (dataItems[indexd].DestinationAirport != "")
                        {
                            SavedDAir.Add(dataItems[indexd].DestinationAirport);
                            flagDAir = 1;
                        }
                        else
                        {
                            SavedDAir.Add("");
                        }
                        if (dataItems[indexd].DepartureAirport != "")
                        {
                            SavedOAir.Add(dataItems[indexd].DepartureAirport);
                            flagOAir = 1;
                        }
                        else
                        {
                            SavedOAir.Add("");
                        }
                        dataGrid[4, indexd].Value = dataItems[indexd].LatWGS84str + ", " + dataItems[indexd].LonWGS84str;
                        dataGrid[5, indexd].Value = dataItems[indexd].X + ", " + dataItems[indexd].Y;
                        dataGrid[6, indexd].Value = dataItems[indexd].Vx + ", " + dataItems[indexd].Vy;
                        dataGrid[7, indexd].Value = dataItems[indexd].ADR;
                        dataGrid[8, indexd].Value = dataItems[indexd].Mode3AReply;
                        dataGrid[9, indexd].Value = dataItems[indexd].DepartureAirport;
                        dataGrid[10, indexd].Value = dataItems[indexd].DestinationAirport;
                    }
                }
                Warning2.Visible = true;
                Warning2.Text = "DONE";
                lblDItems.Visible = true;
                lblDItems.Text = "Number of DataBlocs Decoded: " + tam.ToString();
                lblDItime0.Visible = true;
                lblDItime0.Text = "Initial time: " + dataItems[0].TimeOfTrackInfo;
                lblDItimefin.Visible = true;
                lblDItimefin.Text = "Final time: " + dataItems[dataItems.Count - 1].TimeOfTrackInfo;
                fileRun = true;
                MessageBox.Show("DONE");
            }
            else
            {
                MessageBox.Show("Input not valid");
            }
        }
        public void decodeAll_Click(object sender, EventArgs e)
        {
            tam = dataBlocks.Count;
            if ((tam >= 150) && (tam < dataBlocks.Count + 1))
            {


                dataGrid.Rows.Clear();
                dataGridS.Rows.Clear();
                dataGrid.Rows.Add(tam);
                dataGridS.Rows.Add(tam);
                var dataItems2 = new List<DataItem>();
                flagID = 0;
                flagTrackNumber = 0;
                flagDAir = 0;
                flagOAir = 0;

                foreach (var (DataBlock, indexd) in dataBlocks.Select((value, i) => (value, i)))
                {
                    if (indexd < tam)
                    {
                        index2 = indexd + 1;
                        listBoxAltern.Items.Add("Message " + index2);
                        if (dataBlocks.Count < 65000)
                        {
                            listBox.Items.Add("Message " + index2);
                            DataBlock.getFRNs(DataBlock.FSPEC);
                            dataItems2.Add(new DataItem(dataBlocks[indexd].Data, dataBlocks[indexd].FRNs));
                        }
                        else
                        {
                            DataBlock.getFRNs(DataBlock.FSPEC);
                            dataItems2.Add(new DataItem(dataBlocks[indexd].Data, dataBlocks[indexd].FRNs, ""));
                        }
                        dataItems = dataItems2;
                        SavedTimestr.Add(dataItems[indexd].TimeOfTrackInfo);
                        SavedTimeDouble.Add(dataItems[indexd].TimeSeconds);
                        SavedMode3A.Add(dataItems[indexd].Mode3AReply);
                        dataGrid[0, indexd].Value = index2.ToString();
                        target = "";

                        if (dataItems[indexd].TargetID != "")
                        {
                            target = dataItems[indexd].TargetID;
                            SavedID.Add(target);
                            flagID = 1;
                        }
                        else if (dataItems[indexd].ID != "")
                        {
                            target = dataItems[indexd].ID;
                            SavedID.Add(target);
                            flagID = 1;
                        }
                        else if (dataItems[indexd].Callsign != "")
                        {
                            target = dataItems[indexd].Callsign;
                            SavedID.Add(target);
                            flagID = 1;
                        }
                        else
                        {
                            SavedID.Add("");
                        }
                        dataGrid[1, indexd].Value = target;
                        dataGrid[3, indexd].Value = dataItems[indexd].TimeOfTrackInfo;
                        if (dataItems[indexd].TrackNumber != "")
                        {
                            SavedTrack.Add(dataItems[indexd].TrackNumber);
                            dataGrid[2, indexd].Value = dataItems[indexd].TrackNumber;
                            flagTrackNumber = 1;
                        }
                        else
                        {
                            SavedTrack.Add("");
                        }
                        if (dataItems[indexd].DestinationAirport != "")
                        {
                            SavedDAir.Add(dataItems[indexd].DestinationAirport);
                            flagDAir = 1;
                        }
                        else
                        {
                            SavedDAir.Add("");
                        }
                        if (dataItems[indexd].DepartureAirport != "")
                        {
                            SavedOAir.Add(dataItems[indexd].DepartureAirport);
                            flagOAir = 1;
                        }
                        else
                        {
                            SavedOAir.Add("");
                        }
                        dataGrid[4, indexd].Value = dataItems[indexd].LatWGS84str + ", " + dataItems[indexd].LonWGS84str;
                        dataGrid[5, indexd].Value = dataItems[indexd].X + ", " + dataItems[indexd].Y;
                        dataGrid[6, indexd].Value = dataItems[indexd].Vx + ", " + dataItems[indexd].Vy;
                        dataGrid[7, indexd].Value = dataItems[indexd].ADR;
                        dataGrid[8, indexd].Value = dataItems[indexd].Mode3AReply;
                        dataGrid[9, indexd].Value = dataItems[indexd].DepartureAirport;
                        dataGrid[10, indexd].Value = dataItems[indexd].DestinationAirport;
                    }
                }
                Warning2.Visible = true;
                Warning2.Text = "DONE";
                lblDItems.Visible = true;
                lblDItems.Text = "Number of DataBlocks Decoded: " + tam.ToString();
                lblDItime0.Visible = true;
                lblDItime0.Text = "Initial time: " + dataItems[0].TimeOfTrackInfo;
                lblDItimefin.Visible = true;
                lblDItimefin.Text = "Final time: " + dataItems[dataItems.Count - 1].TimeOfTrackInfo;
                fileRun = true;
                MessageBox.Show("DONE");
            }
            else
            {
                MessageBox.Show("Input not valid");
            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            titleDB.Visible = false;
            titleDI.Visible = false;
            listBoxDB.Visible = false;
            listBoxDI.Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            listBox.Items.Clear();
            if (textBox1.Text == "")
            {

            }
            else
            {
                if (textBox1.Text.Length > 8)
                {
                    for (int i = 1; i < listBoxAltern.Items.Count + 1; i++)
                    {
                        string str = listBoxAltern.Items[i - 1] as string;
                        if (dataBlocks.Count > 65000) //limit of datablocks
                        {
                            if (str.Length == textBox1.Text.Length)
                            {
                                if (str.StartsWith(textBox1.Text))
                                {
                                    listBox.Items.Add(listBoxAltern.Items[i - 1]);
                                }
                            }
                            else if (textBox1.Text.Length > 10)
                            {
                                if (str.StartsWith(textBox1.Text))
                                {
                                    listBox.Items.Add(listBoxAltern.Items[i - 1]);
                                }
                            }
                        }
                        else if (str.StartsWith(textBox1.Text)) //no limit of datablocks
                        {
                            listBox.Items.Add(listBoxAltern.Items[i - 1]);
                        }
                    }
                }
            }


        }
        private void listBox_Click(object sender, EventArgs e)
        {
            infoPic.Visible = false;
            lblBits.Visible = false;
            lblBytes.Visible = false;
            lblDBlocks.Visible = false;
            Warning.Visible = false;
            listBoxDB.Items.Clear();
            infoBox.Visible = false;
            listBoxDI.Visible = false;
            titleDI.Visible = false;

            if (listBox.SelectedItem == null)
            {
            }
            else
            {
                string itemName = listBox.SelectedItem.ToString();
                string itemIndexstr = itemName.Substring(8, itemName.Length - 8);
                itemIndex = Int32.Parse(itemIndexstr) - 1;

                dataItems[itemIndex] = new DataItem(dataBlocks[itemIndex].Data, dataBlocks[itemIndex].FRNs);

                ListBox lb = sender as ListBox;
                listBoxDB.Visible = true;
                titleDB.Visible = true;
                int titleIndex = itemIndex + 1;
                titleDB.Text = "Message " + titleIndex;
                listBoxDB.Items.Add("CAT");
                listBoxDB.Items.Add("LEN");
                listBoxDB.Items.Add("Data");
                listBoxDB.Items.Add("FSPEC");

                foreach (var (datablockFRN, indexd) in dataBlocks[itemIndex].FRNs.Select((value, i) => (value, i)))
                {

                    listBoxDB.Items.Add("FRN" + dataBlocks[itemIndex].FRNs[indexd]);
                }
            }
        }
        private void listBoxDB_Click(object sender, EventArgs e)
        {
            if (listBoxDB.SelectedItem == null)
            {
            }
            else
            {
                itemIndexFRN = listBoxDB.SelectedItem.ToString();
                listBoxDI.Visible = true;
                titleDI.Visible = true;
                infoBox.Visible = false;
                infoPic.Visible = false;
                ListBox lb = sender as ListBox;

                if (itemIndexFRN == "CAT")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add(dataBlocks[itemIndex].CAT);
                    infoBox.Text = "Category :" + dataBlocks[itemIndex].CAT;

                }
                else if (itemIndexFRN == "LEN")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add(dataBlocks[itemIndex].LEN);
                    infoBox.Text = "Length: " + dataBlocks[itemIndex].LEN + " octets.";

                }
                else if (itemIndexFRN == "FSPEC")
                {
                    string messagePART = "";
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("FSPEC");
                    int lengthFSPEC = dataBlocks[itemIndex].FSPEC.Length;
                    int cont = 0;
                    for (int i = 0; i < lengthFSPEC / 8; i++)
                    {
                        messagePART += dataBlocks[itemIndex].FSPEC.Substring(cont + i * 8, 7) + " | " + dataBlocks[itemIndex].FSPEC.Substring(cont + i * 8 + 7, 1) + " | ";
                    }
                    infoBox.Text = "FSPEC: " + messagePART
                       + Environment.NewLine + "FRN 1: " + dataBlocks[itemIndex].FSPEC.Substring(0, 1)
                       + Environment.NewLine + "FRN 2: " + dataBlocks[itemIndex].FSPEC.Substring(1, 1)
                       + Environment.NewLine + "FRN 3: " + dataBlocks[itemIndex].FSPEC.Substring(2, 1)
                       + Environment.NewLine + "FRN 4: " + dataBlocks[itemIndex].FSPEC.Substring(3, 1)
                       + Environment.NewLine + "FRN 5: " + dataBlocks[itemIndex].FSPEC.Substring(4, 1)
                       + Environment.NewLine + "FRN 6: " + dataBlocks[itemIndex].FSPEC.Substring(5, 1)
                       + Environment.NewLine + "FRN 7: " + dataBlocks[itemIndex].FSPEC.Substring(6, 1)
                       + Environment.NewLine + "FX: " + dataBlocks[itemIndex].FSPEC.Substring(7, 1) + "- Extension Indicator";
                    if (lengthFSPEC > 8)
                    {
                        infoBox.Text += Environment.NewLine + "frn 8: " + dataBlocks[itemIndex].FSPEC.Substring(8, 1)
                           + Environment.NewLine + "FRN 9: " + dataBlocks[itemIndex].FSPEC.Substring(9, 1)
                           + Environment.NewLine + "FRN 10: " + dataBlocks[itemIndex].FSPEC.Substring(10, 1)
                           + Environment.NewLine + "FRN 11: " + dataBlocks[itemIndex].FSPEC.Substring(11, 1)
                           + Environment.NewLine + "FRN 12: " + dataBlocks[itemIndex].FSPEC.Substring(12, 1)
                           + Environment.NewLine + "FRN 13: " + dataBlocks[itemIndex].FSPEC.Substring(13, 1)
                           + Environment.NewLine + "FRN 14: " + dataBlocks[itemIndex].FSPEC.Substring(14, 1)
                           + Environment.NewLine + "FX: " + dataBlocks[itemIndex].FSPEC.Substring(15, 1) + "- Extension Indicator";
                        if (lengthFSPEC > 16)
                        {
                            infoBox.Text += Environment.NewLine + "FRN 15: " + dataBlocks[itemIndex].FSPEC.Substring(16, 1)
                            + Environment.NewLine + "FRN 16: " + dataBlocks[itemIndex].FSPEC.Substring(17, 1)
                            + Environment.NewLine + "FRN 17: " + dataBlocks[itemIndex].FSPEC.Substring(18, 1)
                            + Environment.NewLine + "FRN 18: " + dataBlocks[itemIndex].FSPEC.Substring(19, 1)
                            + Environment.NewLine + "FRN 19: " + dataBlocks[itemIndex].FSPEC.Substring(20, 1)
                            + Environment.NewLine + "FRN 20: " + dataBlocks[itemIndex].FSPEC.Substring(21, 1)
                            + Environment.NewLine + "FRN 21: " + dataBlocks[itemIndex].FSPEC.Substring(22, 1)
                            + Environment.NewLine + "FX: " + dataBlocks[itemIndex].FSPEC.Substring(23, 1) + "- Extension Indicator";
                            if (lengthFSPEC > 24)
                            {
                                infoBox.Text += Environment.NewLine + "FRN 22: " + dataBlocks[itemIndex].FSPEC.Substring(24, 1)
                                   + Environment.NewLine + "FRN 23: " + dataBlocks[itemIndex].FSPEC.Substring(25, 1)
                                   + Environment.NewLine + "FRN 24: " + dataBlocks[itemIndex].FSPEC.Substring(26, 1)
                                   + Environment.NewLine + "FRN 25: " + dataBlocks[itemIndex].FSPEC.Substring(27, 1)
                                   + Environment.NewLine + "FRN 26: " + dataBlocks[itemIndex].FSPEC.Substring(28, 1)
                                   + Environment.NewLine + "FRN 27: " + dataBlocks[itemIndex].FSPEC.Substring(29, 1)
                                   + Environment.NewLine + "FRN 28: " + dataBlocks[itemIndex].FSPEC.Substring(30, 1)
                                   + Environment.NewLine + "FX: " + dataBlocks[itemIndex].FSPEC.Substring(31, 1) + "- Extension Indicator";
                                if (lengthFSPEC > 32)
                                {
                                    infoBox.Text += Environment.NewLine + "FRN 29: " + dataBlocks[itemIndex].FSPEC.Substring(32, 1)
                                     + Environment.NewLine + "FRN 30: " + dataBlocks[itemIndex].FSPEC.Substring(33, 1)
                                     + Environment.NewLine + "FRN 31: " + dataBlocks[itemIndex].FSPEC.Substring(34, 1)
                                     + Environment.NewLine + "FRN 32: " + dataBlocks[itemIndex].FSPEC.Substring(35, 1)
                                     + Environment.NewLine + "FRN 33: " + dataBlocks[itemIndex].FSPEC.Substring(36, 1)
                                     + Environment.NewLine + "FRN 34: " + dataBlocks[itemIndex].FSPEC.Substring(37, 1)
                                     + Environment.NewLine + "FRN 35: " + dataBlocks[itemIndex].FSPEC.Substring(38, 1)
                                     + Environment.NewLine + "FX: " + dataBlocks[itemIndex].FSPEC.Substring(39, 1) + "- Extension Indicator";
                                }
                            }
                        }
                    }
                }
                else if (itemIndexFRN == "Data")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add(dataBlocks[itemIndex].Data);
                    infoBox.Text = "Data: " + dataBlocks[itemIndex].Data;
                }
                else if (itemIndexFRN == "FRN1")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/010 Data Source Identifier");
                    listBoxDI.Items.Add("SIC: " + dataItems[itemIndex].SIC);
                    listBoxDI.Items.Add("SAC: " + dataItems[itemIndex].SAC);
                    infoBox.Text = "SIC: " + dataItems[itemIndex].SIC + "- System Identification Code" + Environment.NewLine
                        + "SAC: " + dataItems[itemIndex].SAC + "- System Area Code"
                        + Environment.NewLine + "Format: Two - Octet fixed length data item";
                }
                else if (itemIndexFRN == "FRN3")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/015 Service Identification");
                    listBoxDI.Items.Add("Service ID: " + dataItems[itemIndex].ServiceID);
                    infoBox.Text = "Service ID: " + dataItems[itemIndex].ServiceID
                        + Environment.NewLine + "Format: One - Octet fixed length data item";

                }
                else if (itemIndexFRN == "FRN4")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/070 Time Of Track Information");
                    listBoxDI.Items.Add("Time: " + dataItems[itemIndex].TimeOfTrackInfo);
                    infoBox.Text = "Time of Track Information: " + dataItems[itemIndex].TimeOfTrackInfo
                        + Environment.NewLine + "Definition: Absolute time stamping of the information " +
                        "provided in the track message, in the form of elapsed time since last midnight, expressed as UTC"
                        + Environment.NewLine + "Format: Three - Octet fixed length data item";
                }
                else if (itemIndexFRN == "FRN5")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/015" + "Calculated Track Position (WGS84)");
                    listBoxDI.Items.Add("Latitude: " + dataItems[itemIndex].LatWGS84);
                    listBoxDI.Items.Add("Longitude: " + dataItems[itemIndex].LonWGS84);
                    infoBox.Text = "Latitude: " + dataItems[itemIndex].LatWGS84
                        + Environment.NewLine + "Longitude: " + dataItems[itemIndex].LonWGS84
                        + Environment.NewLine + "Definition: Calculated Position in WGS - 84 " +
                        "Co - ordinates with a resolution of 180 / 2^25.degrees" +
                        Environment.NewLine + "Format: Eight - octet fixed length Data Item";
                }
                else if (itemIndexFRN == "FRN6")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062 / 100 Calculated Track Position(Cartesian)");
                    listBoxDI.Items.Add("X: " + dataItems[itemIndex].X + "m");
                    listBoxDI.Items.Add("Y: " + dataItems[itemIndex].Y + "m");
                    infoBox.Text = "X: " + dataItems[itemIndex].X + "m"
                        + Environment.NewLine + "Y: " + dataItems[itemIndex].Y + "m"
                        + Environment.NewLine + "Definition: Calculated position in Cartesian co-ordinates " +
                        "with a resolution of 0.5m, in two’s complement form" +
                        Environment.NewLine + "Format: Six - octet fixed length Data Item";
                }
                else if (itemIndexFRN == "FRN7")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/185 Calculated Track Velocity (Cartesian)");
                    listBoxDI.Items.Add("Vx: " + dataItems[itemIndex].Vx + "m/s");
                    listBoxDI.Items.Add("Vy: " + dataItems[itemIndex].Vy + "m/s");
                    infoBox.Text = "Vx: " + dataItems[itemIndex].Vx + "m/s"
                        + Environment.NewLine + "Vy: " + dataItems[itemIndex].Vy + "m/s"
                        + Environment.NewLine + "Definition: Calculated track velocity in Cartesian co-ordinates, " +
                        "in two’s complement form" +
                        Environment.NewLine + "Format: Four - octet fixed length Data Item";
                }
                else if (itemIndexFRN == "FRN8")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/210 Calculated Acceleration (Cartesian)");
                    listBoxDI.Items.Add("Ax: " + dataItems[itemIndex].Ax + "m/s^2");
                    listBoxDI.Items.Add("Ay: " + dataItems[itemIndex].Ay + "m/s^2");
                    infoBox.Text = "Ax: " + dataItems[itemIndex].Ax + "m/s^2"
                        + Environment.NewLine + "Ay: " + dataItems[itemIndex].Ay + "m/s^2"
                        + Environment.NewLine + "Definition: Calculated Acceleration in Cartesian co-ordinates" +
                        ", in two’s complement form" +
                        Environment.NewLine + "Format: Two - octet fixed length Data Item";
                }
                else if (itemIndexFRN == "FRN9")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/060 Track Mode 3/A Code");
                    listBoxDI.Items.Add("Validated: " + dataItems[itemIndex].Validated);
                    listBoxDI.Items.Add("Garbled: " + dataItems[itemIndex].Garbled);
                    listBoxDI.Items.Add("Change in Mode: " + dataItems[itemIndex].ChangeInMode);
                    listBoxDI.Items.Add("Mode3AReply: " + dataItems[itemIndex].Mode3AReply);
                    infoBox.Text = "Validated: " + dataItems[itemIndex].Validated
                        + Environment.NewLine + "Garbled: " + dataItems[itemIndex].Garbled
                        + Environment.NewLine + "Change in Mode: " + dataItems[itemIndex].ChangeInMode
                        + Environment.NewLine + "Mode-3/A reply in octal representation: " + dataItems[itemIndex].Mode3AReply
                        + Environment.NewLine + "Definition: Mode-3/A code converted into octal representation" +
                        Environment.NewLine + "Format: Two - octet fixed length Data Item";
                }
                else if (itemIndexFRN == "FRN10")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/245 Target Identification");
                    listBoxDI.Items.Add("STI: " + dataItems[itemIndex].STI);
                    listBoxDI.Items.Add("Target ID: " + dataItems[itemIndex].TargetID);
                    infoBox.Text = "STI: " + dataItems[itemIndex].Validated
                       + Environment.NewLine + "Target ID: " + dataItems[itemIndex].Garbled
                       + Environment.NewLine + "Definition: Target (aircraft or vehicle) identification in 8 characters" +
                        Environment.NewLine + "Format: Seven-octet fixed length Data Item";
                }
                else if (itemIndexFRN == "FRN11")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/380 Aircraft Derived Data");
                    listBoxDI.Items.Add("Primary Field :" + dataItems[itemIndex].primary11);

                    infoBox.Text = "ADR: " + dataItems[itemIndex].primary11.Substring(0, 1) + "Presence of Subfield #1"
                       + Environment.NewLine + "ID: " + dataItems[itemIndex].primary11.Substring(1, 1) + "Presence of Subfield #2"
                       + Environment.NewLine + "MHG: " + dataItems[itemIndex].primary11.Substring(2, 1) + "Presence of Subfield #3"
                       + Environment.NewLine + "IAS: " + dataItems[itemIndex].primary11.Substring(3, 1) + "Presence of Subfield #4"
                       + Environment.NewLine + "TAS: " + dataItems[itemIndex].primary11.Substring(4, 1) + "Presence of Subfield #5"
                       + Environment.NewLine + "SAL: " + dataItems[itemIndex].primary11.Substring(5, 1) + "Presence of Subfield #6"
                       + Environment.NewLine + "FSS: " + dataItems[itemIndex].primary11.Substring(6, 1) + "Presence of Subfield #7"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary11.Substring(7, 1) + "- Extension Indicator";
                    if (dataItems[itemIndex].primary11.Length > 8)
                    {
                        infoBox.Text += Environment.NewLine + "TIS: " + dataItems[itemIndex].primary11.Substring(8, 1) + "Presence of Subfield #8"
                       + Environment.NewLine + "TID: " + dataItems[itemIndex].primary11.Substring(9, 1) + "Presence of Subfield #9"
                       + Environment.NewLine + "COM: " + dataItems[itemIndex].primary11.Substring(10, 1) + "Presence of Subfield #10"
                       + Environment.NewLine + "SAB: " + dataItems[itemIndex].primary11.Substring(11, 1) + "Presence of Subfield #11"
                       + Environment.NewLine + "ACS: " + dataItems[itemIndex].primary11.Substring(12, 1) + "Presence of Subfield #12"
                       + Environment.NewLine + "BVR: " + dataItems[itemIndex].primary11.Substring(13, 1) + "Presence of Subfield #13"
                       + Environment.NewLine + "GVR: " + dataItems[itemIndex].primary11.Substring(14, 1) + "Presence of Subfield #14"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary11.Substring(15, 1) + "- Extension Indicator";
                        if (dataItems[itemIndex].primary11.Length > 16)
                        {
                            infoBox.Text += Environment.NewLine + "RAN: " + dataItems[itemIndex].primary11.Substring(16, 1) + "Presence of Subfield #15"
                       + Environment.NewLine + "TAR: " + dataItems[itemIndex].primary11.Substring(17, 1) + "Presence of Subfield #16"
                       + Environment.NewLine + "TAN: " + dataItems[itemIndex].primary11.Substring(18, 1) + "Presence of Subfield #17"
                       + Environment.NewLine + "GSP: " + dataItems[itemIndex].primary11.Substring(19, 1) + "Presence of Subfield #18"
                       + Environment.NewLine + "VUN: " + dataItems[itemIndex].primary11.Substring(20, 1) + "Presence of Subfield #19"
                       + Environment.NewLine + "MET: " + dataItems[itemIndex].primary11.Substring(21, 1) + "Presence of Subfield #20"
                       + Environment.NewLine + "EMC: " + dataItems[itemIndex].primary11.Substring(22, 1) + "Presence of Subfield #21"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary11.Substring(23, 1) + "- Extension Indicator";
                            if (dataItems[itemIndex].primary11.Length > 24)
                            {
                                infoBox.Text += Environment.NewLine + "POS: " + dataItems[itemIndex].primary11.Substring(24, 1) + "Presence of Subfield #22"
                       + Environment.NewLine + "GAL: " + dataItems[itemIndex].primary11.Substring(25, 1) + "Presence of Subfield #23"
                       + Environment.NewLine + "PUN: " + dataItems[itemIndex].primary11.Substring(26, 1) + "Presence of Subfield #24"
                       + Environment.NewLine + "MB: " + dataItems[itemIndex].primary11.Substring(27, 1) + "Presence of Subfield #25"
                       + Environment.NewLine + "IAR: " + dataItems[itemIndex].primary11.Substring(28, 1) + "Presence of Subfield #26"
                       + Environment.NewLine + "MAC: " + dataItems[itemIndex].primary11.Substring(29, 1) + "Presence of Subfield #27"
                       + Environment.NewLine + "BPS: " + dataItems[itemIndex].primary11.Substring(30, 1) + "Presence of Subfield #28"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary11.Substring(31, 1) + "- Extension Indicator";
                            }
                        }
                    }

                    infoBox.Text += Environment.NewLine + "Definition: Data derived directly by the aircraft" +
                        Environment.NewLine + "Format: Compound Data Item, comprising a primary " +
                        "subfield of up to four octets, followed by the indicated subfields";
                    string primary11 = dataItems[itemIndex].primary11;
                    int numSubfield = 1;
                    foreach (char Bit in primary11)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1)
                            {
                                listBoxDI.Items.Add("#Subfield 1");
                                listBoxDI.Items.Add("ADR: " + dataItems[itemIndex].ADR);
                                infoBox.Text += Environment.NewLine + "#Subfield 1"
                                    + Environment.NewLine + "ADR: " + dataItems[itemIndex].ADR
                                    + Environment.NewLine + "Target Address"
                                    + Environment.NewLine + "Info: 24 bits Target Address, A23 to A0";
                            }
                            else if (numSubfield == 2)
                            {
                                listBoxDI.Items.Add("#Subfield 2");
                                listBoxDI.Items.Add("ID: " + dataItems[itemIndex].ID);
                                infoBox.Text += Environment.NewLine + "#Subfield 2"
                                   + Environment.NewLine + "ID: " + dataItems[itemIndex].ID
                                   + Environment.NewLine + "Target Identification"
                                   + Environment.NewLine + "Info: Characters 1-8 (coded on 6 bits each) " +
                                   "defining a target identification when flight plan is available or the " +
                                   "registration marking when no flight plan is available. Coding rules are " +
                                   "provided in [3] Section 3.1.2.9.1.2 and Table 3 - 9";
                            }
                            else if (numSubfield == 3)
                            {
                                listBoxDI.Items.Add("#Subfield 3");
                                listBoxDI.Items.Add("MHG: " + dataItems[itemIndex].MHG);
                                infoBox.Text += Environment.NewLine + "#Subfield 3"
                                  + Environment.NewLine + "MHG: " + dataItems[itemIndex].MHG + "degrees"
                                  + Environment.NewLine + "Magnetic Heading"
                                  + Environment.NewLine + "Info: (LSB) = 360° / 2^16 -> 0.0055°";
                            }
                            else if (numSubfield == 4)
                            {
                                listBoxDI.Items.Add("#Subfield 4");
                                listBoxDI.Items.Add("IM: " + dataItems[itemIndex].IM + "'0' IAS, '1' MACH");
                                if (dataItems[itemIndex].IM == "0")
                                {
                                    listBoxDI.Items.Add("IAS: " + dataItems[itemIndex].IAS);
                                    infoBox.Text += Environment.NewLine + "#Subfield 4"
                                      + Environment.NewLine + "IAS: " + dataItems[itemIndex].IAS + "NM/s"
                                      + Environment.NewLine + "Air Speed"
                                      + Environment.NewLine + "Info: (LSB) = 2^-14";
                                }
                                else
                                {
                                    listBoxDI.Items.Add("MACH: " + dataItems[itemIndex].MACH);
                                    infoBox.Text += Environment.NewLine + "#Subfield 4"
                                      + Environment.NewLine + "MACH: " + dataItems[itemIndex].IAS + "NM/s"
                                      + Environment.NewLine + "Mach (Dimensionless)"
                                      + Environment.NewLine + "Info: (LSB) = 0.001";
                                }

                            }
                            else if (numSubfield == 5)
                            {
                                listBoxDI.Items.Add("#Subfield 5");
                                listBoxDI.Items.Add("TAS: " + dataItems[itemIndex].TAS);
                                infoBox.Text += Environment.NewLine + "#Subfield 5"
                                      + Environment.NewLine + "TAS: " + dataItems[itemIndex].IAS + "knots"
                                      + Environment.NewLine + "True Air Speed"
                                      + Environment.NewLine + "Info: (LSB) = 1 knot";
                            }
                            else if (numSubfield == 6)
                            {
                                listBoxDI.Items.Add("#Subfield 6");
                                listBoxDI.Items.Add("SAS: " + dataItems[itemIndex].SAS);
                                listBoxDI.Items.Add("Source: " + dataItems[itemIndex].Source);
                                listBoxDI.Items.Add("SAL: " + dataItems[itemIndex].SAL);
                                infoBox.Text += Environment.NewLine + "#Subfield 6"
                                      + Environment.NewLine + "SAS: " + dataItems[itemIndex].SAS
                                      + Environment.NewLine + "Source: " + dataItems[itemIndex].Source
                                      + Environment.NewLine + "Altitude: " + dataItems[itemIndex].SAL
                                      + Environment.NewLine + "Info: Altitude in two’s complement form ,(LSB) = 25 ft";

                            }
                            else if (numSubfield == 7)
                            {
                                listBoxDI.Items.Add("#Subfield 7");
                                listBoxDI.Items.Add("MV: " + dataItems[itemIndex].MV);
                                listBoxDI.Items.Add("AH: " + dataItems[itemIndex].AH);
                                listBoxDI.Items.Add("AM: " + dataItems[itemIndex].AM);
                                listBoxDI.Items.Add("Altitude: " + dataItems[itemIndex].FSS);
                                infoBox.Text += Environment.NewLine + "#Subfield 7"
                                      + Environment.NewLine + "MV: " + dataItems[itemIndex].MV + "- Manage Vertical Mode"
                                      + Environment.NewLine + "AH: " + dataItems[itemIndex].AH + "- Altitude Hold"
                                      + Environment.NewLine + "AM: " + dataItems[itemIndex].AM + "- Approach Mode"
                                      + Environment.NewLine + "Altitude: " + dataItems[itemIndex].AM
                                      + Environment.NewLine + "Info: Altitude in two’s complement form ,(LSB) = 25 ft";
                            }
                            else if (numSubfield == 9)
                            {
                                listBoxDI.Items.Add("#Subfield 8");
                                listBoxDI.Items.Add("NAV: " + dataItems[itemIndex].NAV);
                                listBoxDI.Items.Add("NVB: " + dataItems[itemIndex].NVB);
                                infoBox.Text += Environment.NewLine + "#Subfield 8"
                                      + Environment.NewLine + "NAV: " + dataItems[itemIndex].NAV
                                      + Environment.NewLine + "NVB: " + dataItems[itemIndex].NVB;
                            }
                            else if (numSubfield == 10)
                            {
                                listBoxDI.Items.Add("#Subfield 9");
                                listBoxDI.Items.Add("REP: " + dataItems[itemIndex].REP);
                                listBoxDI.Items.Add("TCA: " + dataItems[itemIndex].TCA);
                                listBoxDI.Items.Add("NC: " + dataItems[itemIndex].NC);
                                listBoxDI.Items.Add("TCP Number: " + dataItems[itemIndex].TCPNumber);
                                listBoxDI.Items.Add("Altitude: " + dataItems[itemIndex].Altitude);
                                listBoxDI.Items.Add("Latitude: " + dataItems[itemIndex].Latitude);
                                listBoxDI.Items.Add("Longitude: " + dataItems[itemIndex].Longitude);
                                listBoxDI.Items.Add("PointType: " + dataItems[itemIndex].PointType);
                                listBoxDI.Items.Add("TD: " + dataItems[itemIndex].TD);
                                listBoxDI.Items.Add("TRA: " + dataItems[itemIndex].TRA);
                                listBoxDI.Items.Add("TOA: " + dataItems[itemIndex].TOA);
                                listBoxDI.Items.Add("TOV: " + dataItems[itemIndex].TOV);
                                listBoxDI.Items.Add("TTR: " + dataItems[itemIndex].TTR);
                                infoBox.Text += Environment.NewLine + "#Subfield 9"
                                      + Environment.NewLine + "REP: " + dataItems[itemIndex].REP + "- Repetition Factor"
                                      + Environment.NewLine + "TCA: " + dataItems[itemIndex].TCA
                                      + Environment.NewLine + "NC: " + dataItems[itemIndex].NC
                                      + Environment.NewLine + "TCP Number: " + dataItems[itemIndex].TCPNumber + "- Trajectory Change Point Number"
                                      + Environment.NewLine + "Altitude: " + dataItems[itemIndex].Altitude + "- Altitude in two’s complement. LSB = 10ft "
                                      + Environment.NewLine + "Latitude: " + dataItems[itemIndex].Latitude + "- In WGS84 in two’s complement. LSB = 180/2^23 degrees"
                                      + Environment.NewLine + "Longitude: " + dataItems[itemIndex].Longitude + "- In WGS84 in two’s complement. LSB = 180/2^23 degrees"
                                      + Environment.NewLine + "Point Type: " + dataItems[itemIndex].PointType
                                      + Environment.NewLine + "TD: " + dataItems[itemIndex].TD
                                      + Environment.NewLine + "TRA: " + dataItems[itemIndex].TRA + "- Turn Radius Availability"
                                      + Environment.NewLine + "TOA: " + dataItems[itemIndex].TOA
                                      + Environment.NewLine + "TOV: " + dataItems[itemIndex].TOV + "- Time Over Point"
                                      + Environment.NewLine + "TTR: " + dataItems[itemIndex].TTR + "- TCP Turn Radius. LSB = 0.01 NM";
                            }
                            else if (numSubfield == 11)
                            {
                                listBoxDI.Items.Add("#Subfield 10");
                                listBoxDI.Items.Add("COM: " + dataItems[itemIndex].COM);
                                listBoxDI.Items.Add("STAT: " + dataItems[itemIndex].STAT);
                                listBoxDI.Items.Add("SSC: " + dataItems[itemIndex].SSC);
                                listBoxDI.Items.Add("ARC: " + dataItems[itemIndex].ARC);
                                listBoxDI.Items.Add("AIC: " + dataItems[itemIndex].AIC);
                                listBoxDI.Items.Add("B1A: " + dataItems[itemIndex].B1A);
                                listBoxDI.Items.Add("B1B: " + dataItems[itemIndex].B1B);
                                infoBox.Text += Environment.NewLine + "#Subfield 10"
                                      + Environment.NewLine + "COM: " + dataItems[itemIndex].COM
                                      + Environment.NewLine + "STAT: " + dataItems[itemIndex].STAT
                                      + Environment.NewLine + "SSC: " + dataItems[itemIndex].SSC + "- Specific service capability"
                                      + Environment.NewLine + "ARC: " + dataItems[itemIndex].ARC + "- Altitude reporting capability"
                                      + Environment.NewLine + "AIC: " + dataItems[itemIndex].AIC + "- Aircraft identification capability"
                                      + Environment.NewLine + "B1A: " + dataItems[itemIndex].B1A + "- BDS 1,0 bit 16"
                                      + Environment.NewLine + "B1B: " + dataItems[itemIndex].B1B + "- BDS 1,0 bits 37/40";
                            }
                            else if (numSubfield == 12)
                            {
                                listBoxDI.Items.Add("#Subfield 11");
                                listBoxDI.Items.Add("AC: " + dataItems[itemIndex].AC);
                                listBoxDI.Items.Add("MN: " + dataItems[itemIndex].MN);
                                listBoxDI.Items.Add("DC: " + dataItems[itemIndex].DC);
                                listBoxDI.Items.Add("GBS: " + dataItems[itemIndex].GBS);
                                listBoxDI.Items.Add("STAT: " + dataItems[itemIndex].SAB);
                                infoBox.Text += Environment.NewLine + "#Subfield 11"
                                      + Environment.NewLine + "AC: " + dataItems[itemIndex].AC
                                      + Environment.NewLine + "MN: " + dataItems[itemIndex].MN
                                      + Environment.NewLine + "DC: " + dataItems[itemIndex].DC
                                      + Environment.NewLine + "GBS: " + dataItems[itemIndex].GBS
                                      + Environment.NewLine + "STAT: " + dataItems[itemIndex].SAB + "- Flight Status";
                            }
                            else if (numSubfield == 13)
                            {

                                listBoxDI.Items.Add("#Subfield 12");
                                listBoxDI.Items.Add("ACS: " + dataItems[itemIndex].ACS);
                                infoBox.Text += Environment.NewLine + "#Subfield 12"
                                      + Environment.NewLine + "ACS: " + dataItems[itemIndex].ACS + "- ACAS Resolution Advisory Report"
                                      + Environment.NewLine + "Definition: Currently active Resolution Advisory (RA), if any, generated by the ACAS" +
                                      " associated with the transponder transmitting the report and threat identity data. (MB Data)"
                                      + Environment.NewLine + "Format: Seven-octet fixed length Data Item";
                            }
                            else if (numSubfield == 14)
                            {
                                listBoxDI.Items.Add("#Subfield 13");
                                listBoxDI.Items.Add("BVR: " + dataItems[itemIndex].BVR);
                                infoBox.Text += Environment.NewLine + "#Subfield 13"
                                      + Environment.NewLine + "BVR: " + dataItems[itemIndex].BVR + "- Barometric Vertical Rate in two’s complement " +
                                      "form. (LSB) = 6.25 feet / minute";
                            }
                            else if (numSubfield == 15)
                            {
                                listBoxDI.Items.Add("#Subfield 14");
                                listBoxDI.Items.Add("GVR: " + dataItems[itemIndex].GVR);
                                infoBox.Text += Environment.NewLine + "#Subfield 14"
                                      + Environment.NewLine + "GVR: " + dataItems[itemIndex].GVR + "- Geometric Vertical Rate in two’s complement " +
                                      "form. (LSB) = 6.25 feet / minute";
                            }
                            else if (numSubfield == 17)
                            {
                                listBoxDI.Items.Add("#Subfield 15");
                                listBoxDI.Items.Add("RAN: " + dataItems[itemIndex].RAN);
                                infoBox.Text += Environment.NewLine + "#Subfield 15"
                                      + Environment.NewLine + "RAN: " + dataItems[itemIndex].RAN + "- Roll Angle in two’s complement " +
                                      "form. (LSB) = 0.01 degree";
                            }
                            else if (numSubfield == 18)
                            {
                                listBoxDI.Items.Add("#Subfield 16");
                                listBoxDI.Items.Add("TI: " + dataItems[itemIndex].TI);
                                listBoxDI.Items.Add("TAR: " + dataItems[itemIndex].TAR);
                                infoBox.Text += Environment.NewLine + "#Subfield 16"
                                      + Environment.NewLine + "TI: " + dataItems[itemIndex].TI
                                      + Environment.NewLine + "TAR: " + dataItems[itemIndex].TAR + "- Rate of Turn in two’s complement form. " +
                                      "(LSB) = 1/4 °/s";
                            }
                            else if (numSubfield == 19)
                            {
                                listBoxDI.Items.Add("#Subfield 17");
                                listBoxDI.Items.Add("TAN: " + dataItems[itemIndex].TAN);
                                infoBox.Text += Environment.NewLine + "#Subfield 17"
                                      + Environment.NewLine + "TAN: " + dataItems[itemIndex].TAN + "- Track Angle. (LSB) = 360°/2^16";
                            }
                            else if (numSubfield == 20)
                            {
                                listBoxDI.Items.Add("#Subfield 18");
                                listBoxDI.Items.Add("GSP: " + dataItems[itemIndex].GSP);
                                infoBox.Text += Environment.NewLine + "#Subfield 18"
                                      + Environment.NewLine + "GSP: " + dataItems[itemIndex].GSP + "- Ground Speed in two's complement" +
                                      " form referenced to WGS84. (LSB) = 2^-14 NM/s";
                            }
                            else if (numSubfield == 21)
                            {
                                listBoxDI.Items.Add("#Subfield 19");
                                listBoxDI.Items.Add("VUN: " + dataItems[itemIndex].VUN);
                                infoBox.Text += Environment.NewLine + "#Subfield 19"
                                      + Environment.NewLine + "VUN: " + dataItems[itemIndex].VUN + "- Velocity uncertainty category of " +
                                      "the least accurate velocity component";
                            }
                            else if (numSubfield == 22)
                            {
                                listBoxDI.Items.Add("#Subfield 20");
                                listBoxDI.Items.Add("WS: " + dataItems[itemIndex].WS);
                                listBoxDI.Items.Add("WD: " + dataItems[itemIndex].WD);
                                listBoxDI.Items.Add("TMP: " + dataItems[itemIndex].TMP);
                                listBoxDI.Items.Add("TRB: " + dataItems[itemIndex].TRB);
                                listBoxDI.Items.Add("Wind Speed: " + dataItems[itemIndex].WindSpeed);
                                listBoxDI.Items.Add("Wind Direction: " + dataItems[itemIndex].WindDirection);
                                listBoxDI.Items.Add("Temperature: " + dataItems[itemIndex].Temperature);
                                listBoxDI.Items.Add("Turbulence: " + dataItems[itemIndex].Turbulence);
                                infoBox.Text += Environment.NewLine + "#Subfield 20"
                                      + Environment.NewLine + "WS: " + dataItems[itemIndex].WS
                                      + Environment.NewLine + "WD: " + dataItems[itemIndex].WD
                                      + Environment.NewLine + "TMP: " + dataItems[itemIndex].TMP
                                      + Environment.NewLine + "TRB: " + dataItems[itemIndex].TRB
                                      + Environment.NewLine + "Wind Speed: " + dataItems[itemIndex].WindSpeed + "- Wind Speed. (LSB) = 1 knot"
                                      + Environment.NewLine + "Wind Direction: " + dataItems[itemIndex].WindDirection + "- Wind Direction. (LSB) = 1 degree"
                                      + Environment.NewLine + "Wind Temperature: " + dataItems[itemIndex].Temperature + "- Temperature in degrees celsius. (LSB) = 0.25 ºC"
                                      + Environment.NewLine + "Turbulence: " + dataItems[itemIndex].Turbulence + "- Integer between 0 and 15 inclusive"
                                      ;
                            }
                            else if (numSubfield == 23)
                            {
                                listBoxDI.Items.Add("#Subfield 21");
                                listBoxDI.Items.Add("ECAT: " + dataItems[itemIndex].EMC);
                                infoBox.Text += Environment.NewLine + "#Subfield 21"
                                     + Environment.NewLine + "ECAT: " + dataItems[itemIndex].EMC + "- Emitter Category";
                            }
                            else if (numSubfield == 25)
                            {
                                listBoxDI.Items.Add("#Subfield 22");
                                listBoxDI.Items.Add("LATWGS84: " + dataItems[itemIndex].POSLatWGS84);
                                listBoxDI.Items.Add("LONWGS84: " + dataItems[itemIndex].POSLonWGS84);
                                infoBox.Text += Environment.NewLine + "#Subfield 22"
                                     + Environment.NewLine + "Latitude: " + dataItems[itemIndex].POSLatWGS84 + "- In WGS.84 in two’s complement form. LSB = 180/2^23 degrees"
                                     + Environment.NewLine + "Longitude: " + dataItems[itemIndex].POSLonWGS84 + "- In WGS.84 in two’s complement form. LSB = 180/2^23 degrees";
                            }
                            else if (numSubfield == 26)
                            {
                                listBoxDI.Items.Add("#Subfield 23");
                                listBoxDI.Items.Add("Altitude: " + dataItems[itemIndex].GAL);
                                infoBox.Text += Environment.NewLine + "#Subfield 23"
                                    + Environment.NewLine + "Altitude: " + dataItems[itemIndex].GAL + "- Altitude in two’s complement form. LSB = 6.25 ft";
                            }
                            else if (numSubfield == 27)
                            {
                                listBoxDI.Items.Add("#Subfield 24");
                                listBoxDI.Items.Add("PUN: " + dataItems[itemIndex].PUN);
                                infoBox.Text += Environment.NewLine + "#Subfield 24"
                                    + Environment.NewLine + "PUN: " + dataItems[itemIndex].GAL + "- Position Uncertainty";
                            }
                            else if (numSubfield == 28)
                            {
                                listBoxDI.Items.Add("#Subfield 25");
                                listBoxDI.Items.Add("REP: " + dataItems[itemIndex].REP25);
                                listBoxDI.Items.Add("MB: " + dataItems[itemIndex].MB);
                                listBoxDI.Items.Add("BDS1: " + dataItems[itemIndex].BDS1);
                                listBoxDI.Items.Add("BDS2: " + dataItems[itemIndex].BDS2);
                                infoBox.Text += Environment.NewLine + "#Subfield 25"
                                    + Environment.NewLine + "REP: " + dataItems[itemIndex].REP25 + "- Repetition factor"
                                    + Environment.NewLine + "MB: " + dataItems[itemIndex].MB + "- 56 bit message conveying Mode S B message data"
                                    + Environment.NewLine + "BDS1: " + dataItems[itemIndex].BDS1 + "- Comm B data Buffer Store 1 Address"
                                    + Environment.NewLine + "BDS2: " + dataItems[itemIndex].BDS2 + "- Comm B data Buffer Store 2 Address";
                            }
                            else if (numSubfield == 29)
                            {
                                listBoxDI.Items.Add("#Subfield 26");
                                listBoxDI.Items.Add("IAR: " + dataItems[itemIndex].IAR);
                                infoBox.Text += Environment.NewLine + "#Subfield 26"
                                    + Environment.NewLine + "IAR: " + dataItems[itemIndex].IAR + "- Indicated Airspeed. LSB = 1 kt";
                            }
                            else if (numSubfield == 30)
                            {
                                listBoxDI.Items.Add("#Subfield 27");
                                listBoxDI.Items.Add("MAC: " + dataItems[itemIndex].MAC);
                                infoBox.Text += Environment.NewLine + "#Subfield 27"
                                    + Environment.NewLine + "Mach: " + dataItems[itemIndex].IAR + "- Mach Number. LSB = 0.008";
                            }
                            else if (numSubfield == 31)
                            {
                                listBoxDI.Items.Add("#Subfield 28");
                                listBoxDI.Items.Add("BPS: " + dataItems[itemIndex].BPS);
                                infoBox.Text += Environment.NewLine + "#Subfield 28"
                                    + Environment.NewLine + "BPS: " + dataItems[itemIndex].BPS + "- BPS is the barometric pressure setting of the aircraft minus 800 mb. LSB=0.1mb";
                            }
                        }
                        numSubfield++;
                    }


                }
                else if (itemIndexFRN == "FRN12")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/040 Track Number");
                    listBoxDI.Items.Add("Track Number: " + dataItems[itemIndex].TrackNumber);
                    infoBox.Text = "Track Number: " + dataItems[itemIndex].TrackNumber
                        + Environment.NewLine + "Definition: Identification of a track" +
                        Environment.NewLine + "Format: Two - octet fixed length Data Item";
                }
                else if (itemIndexFRN == "FRN13")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/080 Track Status");
                    listBoxDI.Items.Add("MON: " + dataItems[itemIndex].MON);
                    listBoxDI.Items.Add("SPI: " + dataItems[itemIndex].SPI);
                    listBoxDI.Items.Add("MRH: " + dataItems[itemIndex].MRH);
                    listBoxDI.Items.Add("SRC: " + dataItems[itemIndex].SRC);
                    listBoxDI.Items.Add("CNF: " + dataItems[itemIndex].CNF);
                    infoBox.Text = "MON: " + dataItems[itemIndex].MON
                        + Environment.NewLine + "SPI: " + dataItems[itemIndex].SPI
                        + Environment.NewLine + "MRH: " + dataItems[itemIndex].MRH + "- Most Reliable Height"
                        + Environment.NewLine + "SRC: " + dataItems[itemIndex].SRC + "- Source of calculated track altitude for I062 / 130"
                        + Environment.NewLine + "CNF: " + dataItems[itemIndex].CNF;
                    if (dataItems[itemIndex].primary13.Length > 8)
                    {
                        listBoxDI.Items.Add("First Extent");
                        listBoxDI.Items.Add("SIM: " + dataItems[itemIndex].SIM);
                        listBoxDI.Items.Add("TSE: " + dataItems[itemIndex].TSE);
                        listBoxDI.Items.Add("TSB: " + dataItems[itemIndex].TSB);
                        listBoxDI.Items.Add("FPC: " + dataItems[itemIndex].FPC);
                        listBoxDI.Items.Add("AFF: " + dataItems[itemIndex].AFF);
                        listBoxDI.Items.Add("STP: " + dataItems[itemIndex].STP);
                        listBoxDI.Items.Add("KOS: " + dataItems[itemIndex].KOS);
                        infoBox.Text += Environment.NewLine + "SIM: " + dataItems[itemIndex].SIM
                        + Environment.NewLine + "SPI: " + dataItems[itemIndex].SPI
                        + Environment.NewLine + "TSE: " + dataItems[itemIndex].TSE
                        + Environment.NewLine + "TSB: " + dataItems[itemIndex].TSB
                        + Environment.NewLine + "FPC: " + dataItems[itemIndex].FPC
                        + Environment.NewLine + "AFF: " + dataItems[itemIndex].AFF
                        + Environment.NewLine + "STP: " + dataItems[itemIndex].STP
                        + Environment.NewLine + "KOS: " + dataItems[itemIndex].KOS;
                        if (dataItems[itemIndex].primary13.Length > 16)
                        {
                            listBoxDI.Items.Add("Second Extent");
                            listBoxDI.Items.Add("AMA: " + dataItems[itemIndex].AMA);
                            listBoxDI.Items.Add("MD4: " + dataItems[itemIndex].MD4);
                            listBoxDI.Items.Add("ME: " + dataItems[itemIndex].ME);
                            listBoxDI.Items.Add("MI: " + dataItems[itemIndex].MI);
                            listBoxDI.Items.Add("MD5: " + dataItems[itemIndex].MD5);
                            infoBox.Text += Environment.NewLine + "AMA: " + dataItems[itemIndex].AMA
                            + Environment.NewLine + "MD4: " + dataItems[itemIndex].MD4
                            + Environment.NewLine + "ME: " + dataItems[itemIndex].ME
                            + Environment.NewLine + "MI: " + dataItems[itemIndex].MI
                            + Environment.NewLine + "MD5: " + dataItems[itemIndex].MD5;
                            if (dataItems[itemIndex].primary13.Length > 24)
                            {
                                listBoxDI.Items.Add("Third Extent");
                                listBoxDI.Items.Add("CST: " + dataItems[itemIndex].CST);
                                listBoxDI.Items.Add("PSR: " + dataItems[itemIndex].PSR);
                                listBoxDI.Items.Add("SSR: " + dataItems[itemIndex].SSR);
                                listBoxDI.Items.Add("MDS: " + dataItems[itemIndex].MDS);
                                listBoxDI.Items.Add("ADS: " + dataItems[itemIndex].ADS);
                                listBoxDI.Items.Add("SUC: " + dataItems[itemIndex].SUC);
                                listBoxDI.Items.Add("AAC: " + dataItems[itemIndex].AAC);
                                infoBox.Text += Environment.NewLine + "CST: " + dataItems[itemIndex].CST
                                + Environment.NewLine + "PSR: " + dataItems[itemIndex].PSR
                                + Environment.NewLine + "SSR: " + dataItems[itemIndex].SSR
                                + Environment.NewLine + "MDS: " + dataItems[itemIndex].MDS
                                + Environment.NewLine + "ADS: " + dataItems[itemIndex].ADS
                                + Environment.NewLine + "SUC: " + dataItems[itemIndex].SUC
                                + Environment.NewLine + "AAC: " + dataItems[itemIndex].AAC;
                                if (dataItems[itemIndex].primary13.Length > 32)
                                {
                                    listBoxDI.Items.Add("Fourth Extent");
                                    listBoxDI.Items.Add("SDS: " + dataItems[itemIndex].SDS);
                                    listBoxDI.Items.Add("EMS: " + dataItems[itemIndex].EMS);
                                    listBoxDI.Items.Add("PFT: " + dataItems[itemIndex].PFT);
                                    listBoxDI.Items.Add("FPLT: " + dataItems[itemIndex].FPLT);
                                    infoBox.Text += Environment.NewLine + "SDS: " + dataItems[itemIndex].SDS + "- Surveillance Data Status"
                                    + Environment.NewLine + "EMS: " + dataItems[itemIndex].EMS + "- Emergency Status Indication"
                                    + Environment.NewLine + "PFT: " + dataItems[itemIndex].PFT
                                    + Environment.NewLine + "FPLT: " + dataItems[itemIndex].FPLT;
                                    if (dataItems[itemIndex].primary13.Length > 40)
                                    {
                                        listBoxDI.Items.Add("Fifth Extent");
                                        listBoxDI.Items.Add("DUPT: " + dataItems[itemIndex].DUPT);
                                        listBoxDI.Items.Add("DUPF: " + dataItems[itemIndex].DUPF);
                                        listBoxDI.Items.Add("DUPM: " + dataItems[itemIndex].DUPM);
                                        listBoxDI.Items.Add("SFC: " + dataItems[itemIndex].SFC);
                                        listBoxDI.Items.Add("IDD: " + dataItems[itemIndex].IDD);
                                        listBoxDI.Items.Add("IEC: " + dataItems[itemIndex].IEC);
                                        infoBox.Text += Environment.NewLine + "DUPT: " + dataItems[itemIndex].DUPT
                                        + Environment.NewLine + "DUPF: " + dataItems[itemIndex].DUPF
                                        + Environment.NewLine + "DUPM: " + dataItems[itemIndex].DUPM
                                        + Environment.NewLine + "SFC: " + dataItems[itemIndex].SFC
                                        + Environment.NewLine + "IDD: " + dataItems[itemIndex].IDD
                                        + Environment.NewLine + "IEC: " + dataItems[itemIndex].IEC;
                                    }

                                }
                            }

                        }

                    }

                }
                else if (itemIndexFRN == "FRN14")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/290 System Track Update Ages");
                    listBoxDI.Items.Add("Primary Field: " + dataItems[itemIndex].primary14);
                    string primary14 = dataItems[itemIndex].primary14;

                    infoBox.Text = "TRK: " + dataItems[itemIndex].primary14.Substring(0, 1) + "Presence of Subfield #1"
                       + Environment.NewLine + "PSR: " + dataItems[itemIndex].primary14.Substring(1, 1) + "Presence of Subfield #2"
                       + Environment.NewLine + "SSR: " + dataItems[itemIndex].primary14.Substring(2, 1) + "Presence of Subfield #3"
                       + Environment.NewLine + "MDS: " + dataItems[itemIndex].primary14.Substring(3, 1) + "Presence of Subfield #4"
                       + Environment.NewLine + "ADS: " + dataItems[itemIndex].primary14.Substring(4, 1) + "Presence of Subfield #5"
                       + Environment.NewLine + "ES: " + dataItems[itemIndex].primary14.Substring(5, 1) + "Presence of Subfield #6"
                       + Environment.NewLine + "VDL: " + dataItems[itemIndex].primary14.Substring(6, 1) + "Presence of Subfield #7"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary14.Substring(7, 1) + "- Extension Indicator";
                    if (dataItems[itemIndex].primary14.Length > 8)
                    {
                        infoBox.Text += Environment.NewLine + "TIS: " + dataItems[itemIndex].primary14.Substring(8, 1) + "Presence of Subfield #8"
                       + Environment.NewLine + "UAT: " + dataItems[itemIndex].primary14.Substring(9, 1) + "Presence of Subfield #9"
                       + Environment.NewLine + "LOP: " + dataItems[itemIndex].primary14.Substring(10, 1) + "Presence of Subfield #10"
                       + Environment.NewLine + "MLT: " + dataItems[itemIndex].primary14.Substring(11, 1) + "Presence of Subfield #11";

                    }
                    int numSubfield = 1;
                    foreach (char Bit in primary14)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1)
                            {
                                listBoxDI.Items.Add("#Subfield 1");
                                listBoxDI.Items.Add("TRK: " + dataItems[itemIndex].TRK);
                                infoBox.Text += Environment.NewLine + "#Subfield 1"
                                    + Environment.NewLine + "TRK: " + dataItems[itemIndex].TRK + "- Actual track age since first " +
                                    "occurence. LSB = 1/4 s";
                            }
                            else if (numSubfield == 2)
                            {
                                listBoxDI.Items.Add("#Subfield 2");
                                listBoxDI.Items.Add("PSR: " + dataItems[itemIndex].PSR290);
                                infoBox.Text += Environment.NewLine + "#Subfield 2"
                                    + Environment.NewLine + "PSR: " + dataItems[itemIndex].PSR290 + "- Age of the last primary " +
                                    "detection used to update the track. LSB = 1/4 s";
                            }
                            else if (numSubfield == 3)
                            {
                                listBoxDI.Items.Add("#Subfield 3");
                                listBoxDI.Items.Add("SSR: " + dataItems[itemIndex].SSR290);
                                infoBox.Text += Environment.NewLine + "#Subfield 3"
                                    + Environment.NewLine + "SSR: " + dataItems[itemIndex].SSR290 + "- Age of the last secondary " +
                                    "detection used to update the track. LSB = 1/4 s";
                            }
                            else if (numSubfield == 4)
                            {
                                listBoxDI.Items.Add("#Subfield 4");
                                listBoxDI.Items.Add("MDS: " + dataItems[itemIndex].MDS290);
                                infoBox.Text += Environment.NewLine + "#Subfield 4"
                                    + Environment.NewLine + "MDS: " + dataItems[itemIndex].MDS290 + "- Age of the last Mode S " +
                                    "detection used to update the track. LSB = 1/4 s";
                            }
                            else if (numSubfield == 5)
                            {
                                listBoxDI.Items.Add("#Subfield 5");
                                listBoxDI.Items.Add("ADS: " + dataItems[itemIndex].ADS290);
                                infoBox.Text += Environment.NewLine + "#Subfield 5"
                                    + Environment.NewLine + "ADS: " + dataItems[itemIndex].ADS290 + "- Age of the last ADS-C " +
                                    "report used to update the track. LSB = 1/4 s";
                            }
                            else if (numSubfield == 6)
                            {
                                listBoxDI.Items.Add("#Subfield 6");
                                listBoxDI.Items.Add("ES: " + dataItems[itemIndex].ES);
                                infoBox.Text += Environment.NewLine + "#Subfield 6"
                                    + Environment.NewLine + "ES: " + dataItems[itemIndex].ES + "- Age of the last 1090 Extended " +
                                    "Squitter ADS-B report used to update the track. LSB = 1/4 s";
                            }
                            else if (numSubfield == 7)
                            {
                                listBoxDI.Items.Add("#Subfield 7");
                                listBoxDI.Items.Add("VDL: " + dataItems[itemIndex].VDL);
                                infoBox.Text += Environment.NewLine + "#Subfield 7"
                                    + Environment.NewLine + "VDL: " + dataItems[itemIndex].VDL + "- Age of the last VDL Mode 4 ADSB " +
                                    "report used to update the track. LSB = 1/4 s";
                            }
                            else if (numSubfield == 9)
                            {
                                listBoxDI.Items.Add("#Subfield 8");
                                listBoxDI.Items.Add("UAT: " + dataItems[itemIndex].UAT);
                                infoBox.Text += Environment.NewLine + "#Subfield 8"
                                    + Environment.NewLine + "UAT: " + dataItems[itemIndex].UAT + "- Age of the last UAT ADS-B report " +
                                    "used to update the track. LSB = 1/4 s";
                            }
                            else if (numSubfield == 10)
                            {
                                listBoxDI.Items.Add("#Subfield 9");
                                listBoxDI.Items.Add("LOP: " + dataItems[itemIndex].LOP);
                                infoBox.Text += Environment.NewLine + "#Subfield 9"
                                    + Environment.NewLine + "LOP: " + dataItems[itemIndex].LOP + "- Age of the last magnetic loop" +
                                    "detection. LSB = 1/4 s";
                            }
                            else if (numSubfield == 11)
                            {
                                listBoxDI.Items.Add("#Subfield 10");
                                listBoxDI.Items.Add("MLT: " + dataItems[itemIndex].MLT);
                                infoBox.Text += Environment.NewLine + "#Subfield 10"
                                    + Environment.NewLine + "MLT: " + dataItems[itemIndex].MLT + "- Age of the last MLT detection" +
                                    ". LSB = 1/4 s";
                            }
                        }
                        numSubfield++;
                    }
                }
                else if (itemIndexFRN == "FRN15")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/200 Calculated Track Velocity (Cartesian)");
                    listBoxDI.Items.Add("TRANS: " + dataItems[itemIndex].TRANS);
                    listBoxDI.Items.Add("LONG: " + dataItems[itemIndex].LONG);
                    listBoxDI.Items.Add("VERT: " + dataItems[itemIndex].VERT);
                    listBoxDI.Items.Add("ADF: " + dataItems[itemIndex].ADF);
                    infoBox.Text = "TRANS: " + dataItems[itemIndex].TRANS + "- Transversal Acceleration"
                                    + Environment.NewLine + "LONG: " + dataItems[itemIndex].LONG + "- Longitudinal Acceleration"
                                    + Environment.NewLine + "VERT: " + dataItems[itemIndex].VERT + "- Vertical Acceleration"
                                    + Environment.NewLine + "ADF: " + dataItems[itemIndex].ADF + "- Altitude Discrepancy Flag"
                                    + Environment.NewLine + "Definition: Calculated Mode of Movement of a target"
                                    + Environment.NewLine + "Format: One-Octet fixed length data item";
                }
                else if (itemIndexFRN == "FRN16")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/295 Track Data Ages");
                    listBoxDI.Items.Add("Primary Field: " + dataItems[itemIndex].primary16);
                    string primary16 = dataItems[itemIndex].primary16;

                    infoBox.Text = "MFL: " + dataItems[itemIndex].primary16.Substring(0, 1) + "Presence of Subfield #1"
                       + Environment.NewLine + "MD1: " + dataItems[itemIndex].primary16.Substring(1, 1) + "Presence of Subfield #2"
                       + Environment.NewLine + "MD2: " + dataItems[itemIndex].primary16.Substring(2, 1) + "Presence of Subfield #3"
                       + Environment.NewLine + "MDA: " + dataItems[itemIndex].primary16.Substring(3, 1) + "Presence of Subfield #4"
                       + Environment.NewLine + "MD4: " + dataItems[itemIndex].primary16.Substring(4, 1) + "Presence of Subfield #5"
                       + Environment.NewLine + "MD5: " + dataItems[itemIndex].primary16.Substring(5, 1) + "Presence of Subfield #6"
                       + Environment.NewLine + "MHG: " + dataItems[itemIndex].primary16.Substring(6, 1) + "Presence of Subfield #7"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary16.Substring(7, 1) + "- Extension Indicator";
                    if (dataItems[itemIndex].primary16.Length > 8)
                    {
                        infoBox.Text += Environment.NewLine + "IAS: " + dataItems[itemIndex].primary16.Substring(8, 1) + "Presence of Subfield #8"
                       + Environment.NewLine + "TAS: " + dataItems[itemIndex].primary16.Substring(9, 1) + "Presence of Subfield #9"
                       + Environment.NewLine + "SAL: " + dataItems[itemIndex].primary16.Substring(10, 1) + "Presence of Subfield #10"
                       + Environment.NewLine + "FSS: " + dataItems[itemIndex].primary16.Substring(11, 1) + "Presence of Subfield #11"
                       + Environment.NewLine + "TID: " + dataItems[itemIndex].primary16.Substring(12, 1) + "Presence of Subfield #12"
                       + Environment.NewLine + "COM: " + dataItems[itemIndex].primary16.Substring(13, 1) + "Presence of Subfield #13"
                       + Environment.NewLine + "SAB: " + dataItems[itemIndex].primary16.Substring(14, 1) + "Presence of Subfield #14"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary16.Substring(15, 1) + "- Extension Indicator";
                        if (dataItems[itemIndex].primary16.Length > 16)
                        {
                            infoBox.Text += Environment.NewLine + "ACS: " + dataItems[itemIndex].primary16.Substring(16, 1) + "Presence of Subfield #15"
                       + Environment.NewLine + "BVR: " + dataItems[itemIndex].primary16.Substring(17, 1) + "Presence of Subfield #16"
                       + Environment.NewLine + "GVR: " + dataItems[itemIndex].primary16.Substring(18, 1) + "Presence of Subfield #17"
                       + Environment.NewLine + "RAN: " + dataItems[itemIndex].primary16.Substring(19, 1) + "Presence of Subfield #18"
                       + Environment.NewLine + "TAR: " + dataItems[itemIndex].primary16.Substring(20, 1) + "Presence of Subfield #19"
                       + Environment.NewLine + "TAN: " + dataItems[itemIndex].primary16.Substring(21, 1) + "Presence of Subfield #20"
                       + Environment.NewLine + "GSP: " + dataItems[itemIndex].primary16.Substring(22, 1) + "Presence of Subfield #21"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary16.Substring(23, 1) + "- Extension Indicator";
                            if (dataItems[itemIndex].primary16.Length > 24)
                            {
                                infoBox.Text += Environment.NewLine + "VUN: " + dataItems[itemIndex].primary16.Substring(25, 1) + "Presence of Subfield #22"
                       + Environment.NewLine + "MET: " + dataItems[itemIndex].primary16.Substring(26, 1) + "Presence of Subfield #23"
                       + Environment.NewLine + "EMC: " + dataItems[itemIndex].primary16.Substring(27, 1) + "Presence of Subfield #24"
                       + Environment.NewLine + "POS: " + dataItems[itemIndex].primary16.Substring(28, 1) + "Presence of Subfield #25"
                       + Environment.NewLine + "GAL: " + dataItems[itemIndex].primary16.Substring(29, 1) + "Presence of Subfield #26"
                       + Environment.NewLine + "PUN: " + dataItems[itemIndex].primary16.Substring(30, 1) + "Presence of Subfield #27"
                       + Environment.NewLine + "MB: " + dataItems[itemIndex].primary16.Substring(30, 1) + "Presence of Subfield #28"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary16.Substring(31, 1) + "- Extension Indicator";
                                if (dataItems[itemIndex].primary16.Length > 24)
                                {
                                    infoBox.Text += Environment.NewLine + "IAR: " + dataItems[itemIndex].primary16.Substring(25, 1) + "Presence of Subfield #29"
                       + Environment.NewLine + "MAC: " + dataItems[itemIndex].primary16.Substring(26, 1) + "Presence of Subfield #30"
                       + Environment.NewLine + "BPS: " + dataItems[itemIndex].primary16.Substring(27, 1) + "Presence of Subfield #31"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary16.Substring(31, 1) + "- Extension Indicator";
                                }

                            }
                        }
                    }

                    infoBox.Text += Environment.NewLine + "Definition: Ages of the data provided" +
                        Environment.NewLine + "Format: Compound Data Item, comprising a primary " +
                        "subfield of up to five octets, followed by the indicated subfields";

                    int numSubfield = 1;
                    foreach (char Bit in primary16)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1)
                            {
                                listBoxDI.Items.Add("#Subfield 1");
                                listBoxDI.Items.Add("MFL: " + dataItems[itemIndex].MFL295);
                                infoBox.Text += Environment.NewLine + "#Subfield 1"
                                    + Environment.NewLine + "MFL: " + dataItems[itemIndex].MFL295 + "- Age of the last valid and " +
                                    "credible Mode C code or barometric altitude from ADS-B used to update the track(I062 / 136). LSB = 1/4 s";
                            }
                            else if (numSubfield == 2)
                            {
                                listBoxDI.Items.Add("#Subfield 2");
                                listBoxDI.Items.Add("MD1: " + dataItems[itemIndex].MD1295);
                                infoBox.Text += Environment.NewLine + "#Subfield 2"
                                    + Environment.NewLine + "MD1: " + dataItems[itemIndex].MD1295 + "- Age of the last valid and credible " +
                                    "Mode 1 code used to update the track(I062 / 110). LSB = 1/4 s";
                            }
                            else if (numSubfield == 3)
                            {
                                listBoxDI.Items.Add("#Subfield 3");
                                listBoxDI.Items.Add("MD2: " + dataItems[itemIndex].MD2295);
                                infoBox.Text += Environment.NewLine + "#Subfield 3"
                                    + Environment.NewLine + "MD2: " + dataItems[itemIndex].MD2295 + "- Age of the last valid and credible " +
                                    "Mode 2 code used to update the track(I062 / 120). LSB = 1/4 s";
                            }
                            else if (numSubfield == 4)
                            {
                                listBoxDI.Items.Add("#Subfield 4");
                                listBoxDI.Items.Add("MDA: " + dataItems[itemIndex].MDA295);
                                infoBox.Text += Environment.NewLine + "#Subfield 4"
                                    + Environment.NewLine + "MDA: " + dataItems[itemIndex].MDA295 + "- Age of the last valid and credible " +
                                    "Mode 3 / A code used to update the track(I062 / 060). LSB = 1/4 s";
                            }
                            else if (numSubfield == 5)
                            {
                                listBoxDI.Items.Add("#Subfield 5");
                                listBoxDI.Items.Add("MD4: " + dataItems[itemIndex].MD4295);
                                infoBox.Text += Environment.NewLine + "#Subfield 5"
                                    + Environment.NewLine + "MD4: " + dataItems[itemIndex].MD4295 + "- Age of the last valid and credible " +
                                    "Mode 4 code used to update the track. LSB = 1/4 s";

                            }
                            else if (numSubfield == 6)
                            {
                                listBoxDI.Items.Add("#Subfield 6");
                                listBoxDI.Items.Add("MD5: " + dataItems[itemIndex].MD5295);
                                infoBox.Text += Environment.NewLine + "#Subfield 6"
                                    + Environment.NewLine + "MD5: " + dataItems[itemIndex].MD5295 + "- Age of the last valid and credible " +
                                    "Mode 5 code used to update the track(I062/110). LSB = 1/4 s";
                            }
                            else if (numSubfield == 7)
                            {
                                listBoxDI.Items.Add("#Subfield 7");
                                listBoxDI.Items.Add("MHG: " + dataItems[itemIndex].MHG295);
                                infoBox.Text += Environment.NewLine + "#Subfield 7"
                                    + Environment.NewLine + "MHG: " + dataItems[itemIndex].MHG295 + "- Age of the DAP “Magnetic Heading” in " +
                                    "item 062 / 380(Subfield #3). LSB = 1/4 s";
                            }
                            else if (numSubfield == 9)
                            {
                                listBoxDI.Items.Add("#Subfield 8");
                                listBoxDI.Items.Add("IAS: " + dataItems[itemIndex].IAS295);
                                infoBox.Text += Environment.NewLine + "#Subfield 8"
                                    + Environment.NewLine + "IAS: " + dataItems[itemIndex].IAS295 + "- Age of the DAP “Indicated Airspeed / " +
                                    "Mach Number” in item 062 / 380 (Subfield #4). LSB = 1/4 s";
                            }
                            else if (numSubfield == 10)
                            {
                                listBoxDI.Items.Add("#Subfield 9");
                                listBoxDI.Items.Add("TAS: " + dataItems[itemIndex].TAS295);
                                infoBox.Text += Environment.NewLine + "#Subfield 9"
                                    + Environment.NewLine + "TAS: " + dataItems[itemIndex].TAS295 + "- Age of the DAP “True Airspeed" +
                                    " in item 062 / 380 (Subfield #5). LSB = 1/4 s";
                            }
                            else if (numSubfield == 11)
                            {
                                listBoxDI.Items.Add("#Subfield 10");
                                listBoxDI.Items.Add("SAL: " + dataItems[itemIndex].SAL295);
                                infoBox.Text += Environment.NewLine + "#Subfield 10"
                                    + Environment.NewLine + "SAL: " + dataItems[itemIndex].SAL295 + "- Age of the DAP “Selected Altitude” " +
                                    "in item 062 / 380 (Subfield #6). LSB = 1/4 s";
                            }
                            else if (numSubfield == 12)
                            {
                                listBoxDI.Items.Add("#Subfield 11");
                                listBoxDI.Items.Add("FSS: " + dataItems[itemIndex].FSS295);
                                infoBox.Text += Environment.NewLine + "#Subfield 11"
                                    + Environment.NewLine + "FSS: " + dataItems[itemIndex].FSS295 + "- Age of the DAP “Final State " +
                                    "Selected Altitude” in item 062 / 380 (Subfield #7). LSB = 1/4 s";
                            }
                            else if (numSubfield == 13)
                            {
                                listBoxDI.Items.Add("#Subfield 12");
                                listBoxDI.Items.Add("TID: " + dataItems[itemIndex].TID295);
                                infoBox.Text += Environment.NewLine + "#Subfield 12"
                                    + Environment.NewLine + "TID: " + dataItems[itemIndex].TID295 + "- Age of the DAP “Trajectory " +
                                    "Intent” in item 062 / 380 (Subfield #8). LSB = 1/4 s";
                            }
                            else if (numSubfield == 14)
                            {
                                listBoxDI.Items.Add("#Subfield 13");
                                listBoxDI.Items.Add("COM: " + dataItems[itemIndex].COM295);
                                infoBox.Text += Environment.NewLine + "#Subfield 13"
                                    + Environment.NewLine + "COM: " + dataItems[itemIndex].COM295 + "- Age of the DAP “Communication/ACAS " +
                                    "Capability and Flight Status” in item 062 / 380 (Subfield #10). LSB = 1/4 s";
                            }
                            else if (numSubfield == 15)
                            {
                                listBoxDI.Items.Add("#Subfield 14");
                                listBoxDI.Items.Add("SAB: " + dataItems[itemIndex].SAB295);
                                infoBox.Text += Environment.NewLine + "#Subfield 14"
                                    + Environment.NewLine + "SAB: " + dataItems[itemIndex].SAB295 + "- Age of the DAP “Status Reported " +
                                    "by ADS-B” in item 062 / 380 (Subfield #11). LSB = 1/4 s";
                            }
                            else if (numSubfield == 17)
                            {
                                listBoxDI.Items.Add("#Subfield 15");
                                listBoxDI.Items.Add("ACS: " + dataItems[itemIndex].ACS295);
                                infoBox.Text += Environment.NewLine + "#Subfield 15"
                                    + Environment.NewLine + "ACS: " + dataItems[itemIndex].ACS295 + "- Age of the DAP “ACAS Resolution " +
                                    "Advisory Report” in item 062 / 380 (Subfield #12). LSB = 1/4 s";
                            }
                            else if (numSubfield == 18)
                            {
                                listBoxDI.Items.Add("#Subfield 16");
                                listBoxDI.Items.Add("BVR: " + dataItems[itemIndex].BVR295);
                                infoBox.Text += Environment.NewLine + "#Subfield 16"
                                    + Environment.NewLine + "BVR: " + dataItems[itemIndex].BVR295 + "- Age of the DAP “Barometric Vertical " +
                                    "Rate” in item 062 / 380 (Subfield #13). LSB = 1/4 s";
                            }
                            else if (numSubfield == 19)
                            {
                                listBoxDI.Items.Add("#Subfield 17");
                                listBoxDI.Items.Add("GVR: " + dataItems[itemIndex].GVR295);
                                infoBox.Text += Environment.NewLine + "#Subfield 17"
                                    + Environment.NewLine + "GVR: " + dataItems[itemIndex].GVR295 + "- Age of the DAP “Geometric Vertical " +
                                    "Rate” in item 062 / 380 (Subfield #14). LSB = 1/4 s";
                            }
                            else if (numSubfield == 20)
                            {
                                listBoxDI.Items.Add("#Subfield 18");
                                listBoxDI.Items.Add("RAN: " + dataItems[itemIndex].RAN295);
                                infoBox.Text += Environment.NewLine + "#Subfield 18"
                                    + Environment.NewLine + "RAN: " + dataItems[itemIndex].RAN295 + "- Age of the DAP “Roll Angle" +
                                    "” in item 062 / 380 (Subfield #15). LSB = 1/4 s";
                            }
                            else if (numSubfield == 21)
                            {
                                listBoxDI.Items.Add("#Subfield 19");
                                listBoxDI.Items.Add("TAR: " + dataItems[itemIndex].TAR295);
                                infoBox.Text += Environment.NewLine + "#Subfield 19"
                                    + Environment.NewLine + "TAR: " + dataItems[itemIndex].TAR295 + "- Age of the DAP “Track Angle Rate" +
                                    "” in item 062 / 380 (Subfield #16). LSB = 1/4 s";
                            }
                            else if (numSubfield == 22)
                            {
                                listBoxDI.Items.Add("#Subfield 20");
                                listBoxDI.Items.Add("TAN: " + dataItems[itemIndex].TAN295);
                                infoBox.Text += Environment.NewLine + "#Subfield 20"
                                    + Environment.NewLine + "TAN: " + dataItems[itemIndex].TAN295 + "- Age of the DAP “Track Angle" +
                                    "” in item 062 / 380 (Subfield #17). LSB = 1/4 s";
                            }
                            else if (numSubfield == 23)
                            {
                                listBoxDI.Items.Add("#Subfield 21");
                                listBoxDI.Items.Add("GSP: " + dataItems[itemIndex].GSP295);
                                infoBox.Text += Environment.NewLine + "#Subfield 21"
                                    + Environment.NewLine + "GSP: " + dataItems[itemIndex].GSP295 + "- Age of the DAP “Ground Speed" +
                                    "” in item 062 / 380 (Subfield #18). LSB = 1/4 s";
                            }
                            else if (numSubfield == 25)
                            {
                                listBoxDI.Items.Add("#Subfield 22");
                                listBoxDI.Items.Add("VUN: " + dataItems[itemIndex].VUN295);
                                infoBox.Text += Environment.NewLine + "#Subfield 22"
                                    + Environment.NewLine + "VUN: " + dataItems[itemIndex].VUN295 + "- Age of the DAP “Velocity Unvertainty" +
                                    "” in item 062 / 380 (Subfield #19). LSB = 1/4 s";
                            }
                            else if (numSubfield == 26)
                            {
                                listBoxDI.Items.Add("#Subfield 23");
                                listBoxDI.Items.Add("MET: " + dataItems[itemIndex].MET295);
                                infoBox.Text += Environment.NewLine + "#Subfield 23"
                                    + Environment.NewLine + "MET: " + dataItems[itemIndex].MET295 + "- Age of the DAP “Meteorological Data" +
                                    "” in item 062 / 380 (Subfield #20). LSB = 1/4 s";
                            }
                            else if (numSubfield == 27)
                            {
                                listBoxDI.Items.Add("#Subfield 24");
                                listBoxDI.Items.Add("EMC: " + dataItems[itemIndex].EMC295);
                                infoBox.Text += Environment.NewLine + "#Subfield 24"
                                    + Environment.NewLine + "EMC: " + dataItems[itemIndex].EMC295 + "- Age of the DAP “Emitter Category" +
                                    "” in item 062 / 380 (Subfield #21). LSB = 1/4 s";
                            }
                            else if (numSubfield == 28)
                            {
                                listBoxDI.Items.Add("#Subfield 25");
                                listBoxDI.Items.Add("POS: " + dataItems[itemIndex].POS295);
                                infoBox.Text += Environment.NewLine + "#Subfield 25"
                                    + Environment.NewLine + "POS: " + dataItems[itemIndex].POS295 + "- Age of the DAP “Position" +
                                    "” in item 062 / 380 (Subfield #23). LSB = 1/4 s";
                            }
                            else if (numSubfield == 29)
                            {
                                listBoxDI.Items.Add("#Subfield 26");
                                listBoxDI.Items.Add("GAL: " + dataItems[itemIndex].GAL295);
                                infoBox.Text += Environment.NewLine + "#Subfield 26"
                                    + Environment.NewLine + "GAL: " + dataItems[itemIndex].RAN295 + "- Age of the DAP “Geometric Altitude" +
                                    "” in item 062 / 380 (Subfield #24). LSB = 1/4 s";
                            }
                            else if (numSubfield == 30)
                            {
                                listBoxDI.Items.Add("#Subfield 27");
                                listBoxDI.Items.Add("PUN: " + dataItems[itemIndex].PUN295);
                                infoBox.Text += Environment.NewLine + "#Subfield 27"
                                    + Environment.NewLine + "PUN: " + dataItems[itemIndex].PUN295 + "- Age of the DAP “Position Uncertainty" +
                                    "” in item 062 / 380 (Subfield #25). LSB = 1/4 s";
                            }
                            else if (numSubfield == 31)
                            {
                                listBoxDI.Items.Add("#Subfield 28");
                                listBoxDI.Items.Add("MB: " + dataItems[itemIndex].MB295);
                                infoBox.Text += Environment.NewLine + "#Subfield 28"
                                    + Environment.NewLine + "MB: " + dataItems[itemIndex].MB295 + "- Age of the DAP “Mode S MB Data" +
                                    "” in item 062 / 380 (Subfield #22). LSB = 1/4 s";
                            }
                            else if (numSubfield == 33)
                            {
                                listBoxDI.Items.Add("#Subfield 29");
                                listBoxDI.Items.Add("IAR: " + dataItems[itemIndex].IAR295);
                                infoBox.Text += Environment.NewLine + "#Subfield 29"
                                    + Environment.NewLine + "IAR: " + dataItems[itemIndex].IAR295 + "- Age of the DAP “Indicated Airspeed" +
                                    "” in item 062 / 380 (Subfield #26). LSB = 1/4 s";
                            }
                            else if (numSubfield == 34)
                            {
                                listBoxDI.Items.Add("#Subfield 30");
                                listBoxDI.Items.Add("MAC: " + dataItems[itemIndex].MAC295);
                                infoBox.Text += Environment.NewLine + "#Subfield 30"
                                    + Environment.NewLine + "MAC: " + dataItems[itemIndex].MAC295 + "- Age of the DAP “Mach Number" +
                                    "” in item 062 / 380 (Subfield #27). LSB = 1/4 s";
                            }
                            else if (numSubfield == 35)
                            {
                                listBoxDI.Items.Add("#Subfield 31");
                                listBoxDI.Items.Add("BPS: " + dataItems[itemIndex].BPS295);
                                infoBox.Text += Environment.NewLine + "#Subfield 31"
                                    + Environment.NewLine + "BPS: " + dataItems[itemIndex].BPS295 + "- Age of the DAP “Barometric Pressure Setting" +
                                    "” in item 062 / 380 (Subfield #28). LSB = 1/4 s";
                            }

                        }
                        numSubfield++;
                    }
                }
                else if (itemIndexFRN == "FRN17")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/136 Measured Flight Level");
                    listBoxDI.Items.Add("MFL: " + dataItems[itemIndex].MFL);
                    infoBox.Text = "MFL: " + dataItems[itemIndex].MFL + "- Measured Flight Level"
                                    + Environment.NewLine + "Definition: Last valid and credible flight level used to update the " +
                                    "track, in two’s complement form. (LSB) = 1/4 FL"
                                    + Environment.NewLine + "Format: Two-Octet fixed length data item";
                }
                else if (itemIndexFRN == "FRN18")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/130 Calculated Track Geometric Altitude");
                    listBoxDI.Items.Add("Altitude: " + dataItems[itemIndex].GeomAlt);
                    infoBox.Text = "Altitude: " + dataItems[itemIndex].GeomAlt + "- Geometric Altitude"
                                    + Environment.NewLine + "Definition: Vertical distance between the target and the projection " +
                                    "of its position on the earth’s ellipsoid, as defined by WGS84, in two’s complement form. (LSB) = 1/4 FL"
                                    + Environment.NewLine + "Format: Two-Octet fixed length data item";
                }
                else if (itemIndexFRN == "FRN19")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/135 Calculated Track Barometric Altitud");
                    listBoxDI.Items.Add("QNH: " + dataItems[itemIndex].QNH);
                    listBoxDI.Items.Add("Altitude: " + dataItems[itemIndex].BaromAlt);
                    infoBox.Text = "QNH: " + dataItems[itemIndex].QNH
                                    + Environment.NewLine + "Altitude: " + dataItems[itemIndex].GeomAlt + "- Barometric Altitude"
                                    + Environment.NewLine + "Definition: Calculated Barometric Altitude of the track, in two’s complement " +
                                    "form. (LSB) = 1/4 FL"
                                    + Environment.NewLine + "Format: Two-Octet fixed length data item";
                }
                else if (itemIndexFRN == "FRN20")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/220 Calculated Rate Of Climb/Descent");
                    listBoxDI.Items.Add("Rate Climb: " + dataItems[itemIndex].RateClimb);
                    infoBox.Text = "Rate of Climb/Descent: " + dataItems[itemIndex].RateClimb
                                    + Environment.NewLine + "Definition: Calculated rate of Climb/Descent of an aircraft in two’s complement " +
                                    "form. (LSB) = 1/4 FL"
                                    + Environment.NewLine + "Format: Two-Octet fixed length data item";

                }
                else if (itemIndexFRN == "FRN21")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/295 Track Data Ages");
                    listBoxDI.Items.Add("Primary Field: " + dataItems[itemIndex].primary21);
                    string primary21 = dataItems[itemIndex].primary21;
                    int numSubfield = 1;

                    infoBox.Text = "TAG: " + dataItems[itemIndex].primary21.Substring(0, 1) + "Presence of Subfield #1"
                       + Environment.NewLine + "CSN: " + dataItems[itemIndex].primary21.Substring(1, 1) + "Presence of Subfield #2"
                       + Environment.NewLine + "IFI: " + dataItems[itemIndex].primary21.Substring(2, 1) + "Presence of Subfield #3"
                       + Environment.NewLine + "FCT: " + dataItems[itemIndex].primary21.Substring(3, 1) + "Presence of Subfield #4"
                       + Environment.NewLine + "TAC: " + dataItems[itemIndex].primary21.Substring(4, 1) + "Presence of Subfield #5"
                       + Environment.NewLine + "WTC: " + dataItems[itemIndex].primary21.Substring(5, 1) + "Presence of Subfield #6"
                       + Environment.NewLine + "DEP: " + dataItems[itemIndex].primary21.Substring(6, 1) + "Presence of Subfield #7"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary21.Substring(7, 1) + "- Extension Indicator";
                    if (dataItems[itemIndex].primary21.Length > 8)
                    {
                        infoBox.Text += Environment.NewLine + "DST: " + dataItems[itemIndex].primary21.Substring(8, 1) + "Presence of Subfield #8"
                       + Environment.NewLine + "RDS: " + dataItems[itemIndex].primary21.Substring(9, 1) + "Presence of Subfield #9"
                       + Environment.NewLine + "CFL: " + dataItems[itemIndex].primary21.Substring(10, 1) + "Presence of Subfield #10"
                       + Environment.NewLine + "CTL: " + dataItems[itemIndex].primary21.Substring(11, 1) + "Presence of Subfield #11"
                       + Environment.NewLine + "TOD: " + dataItems[itemIndex].primary21.Substring(12, 1) + "Presence of Subfield #12"
                       + Environment.NewLine + "AST: " + dataItems[itemIndex].primary21.Substring(13, 1) + "Presence of Subfield #13"
                       + Environment.NewLine + "STS: " + dataItems[itemIndex].primary21.Substring(14, 1) + "Presence of Subfield #14"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary21.Substring(15, 1) + "- Extension Indicator";
                        if (dataItems[itemIndex].primary21.Length > 16)
                        {
                            infoBox.Text += Environment.NewLine + "STD: " + dataItems[itemIndex].primary21.Substring(16, 1) + "Presence of Subfield #15"
                       + Environment.NewLine + "STA: " + dataItems[itemIndex].primary21.Substring(17, 1) + "Presence of Subfield #16"
                       + Environment.NewLine + "PEM: " + dataItems[itemIndex].primary21.Substring(18, 1) + "Presence of Subfield #17"
                       + Environment.NewLine + "PEC: " + dataItems[itemIndex].primary21.Substring(19, 1) + "Presence of Subfield #18";
                        }
                    }

                    foreach (char Bit in primary21)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1)
                            {
                                listBoxDI.Items.Add("#Subfield 1");
                                listBoxDI.Items.Add("SIC: " + dataItems[itemIndex].FPPSSIC);
                                listBoxDI.Items.Add("SSAC: " + dataItems[itemIndex].FPPSSAC);
                                infoBox.Text += Environment.NewLine + "#Subfield 1: FPPS Identification Tag"
                                    + Environment.NewLine + "FPPSSIC: " + dataItems[itemIndex].FPPSSIC + "System Identity Code"
                                    + Environment.NewLine + "FPPSSAC: " + dataItems[itemIndex].FPPSSAC + "System Area Code";
                            }
                            else if (numSubfield == 2)
                            {
                                listBoxDI.Items.Add("#Subfield 2");
                                listBoxDI.Items.Add("Callsign: " + dataItems[itemIndex].Callsign);
                                infoBox.Text += Environment.NewLine + "#Subfield 2: Callsign"
                                    + Environment.NewLine + "Callsign: " + dataItems[itemIndex].Callsign;
                            }
                            else if (numSubfield == 3)
                            {
                                listBoxDI.Items.Add("#Subfield 3");
                                listBoxDI.Items.Add("TYP: " + dataItems[itemIndex].IFPS_TYP);
                                listBoxDI.Items.Add("NBR: " + dataItems[itemIndex].NBR);
                                infoBox.Text += Environment.NewLine + "#Subfield 3: IFPS_FLIGHT_ID"
                                    + Environment.NewLine + "TYP: " + dataItems[itemIndex].IFPS_TYP
                                    + Environment.NewLine + "NBR: " + dataItems[itemIndex].NBR;
                            }
                            else if (numSubfield == 4)
                            {
                                listBoxDI.Items.Add("#Subfield 4");
                                listBoxDI.Items.Add("GAT/OAT: " + dataItems[itemIndex].GAT_OAT);
                                listBoxDI.Items.Add("FR1/FR2: " + dataItems[itemIndex].FR1FR2);
                                listBoxDI.Items.Add("RVSM: " + dataItems[itemIndex].RVSM);
                                listBoxDI.Items.Add("HPR: " + dataItems[itemIndex].HPR);
                                infoBox.Text += Environment.NewLine + "#Subfield 4: Flight Category"
                                    + Environment.NewLine + "GAT/OAT: " + dataItems[itemIndex].GAT_OAT
                                    + Environment.NewLine + "FR1/FR2: " + dataItems[itemIndex].FR1FR2
                                    + Environment.NewLine + "RVSM: " + dataItems[itemIndex].RVSM
                                    + Environment.NewLine + "HPR: " + dataItems[itemIndex].HPR;
                            }
                            else if (numSubfield == 5)
                            {
                                listBoxDI.Items.Add("#Subfield 5");
                                listBoxDI.Items.Add("Type: " + dataItems[itemIndex].TypeOfAircraft);
                                infoBox.Text += Environment.NewLine + "#Subfield 5: Type of Aircraft"
                                    + Environment.NewLine + "Type: " + dataItems[itemIndex].TypeOfAircraft;
                            }
                            else if (numSubfield == 6)
                            {
                                listBoxDI.Items.Add("#Subfield 6");
                                listBoxDI.Items.Add("Wake Turb. Cat.: " + dataItems[itemIndex].WakeTurbulenceCAT);
                                infoBox.Text += Environment.NewLine + "#Subfield 6: Wake Turbulence Category"
                                    + Environment.NewLine + "Wake. Turb. Cat.: " + dataItems[itemIndex].WakeTurbulenceCAT;
                            }
                            else if (numSubfield == 7)
                            {
                                listBoxDI.Items.Add("#Subfield 7");
                                listBoxDI.Items.Add("Dep. Airport: " + dataItems[itemIndex].DepartureAirport);
                                infoBox.Text += Environment.NewLine + "#Subfield 7: Departure Airport"
                                    + Environment.NewLine + "Departure Airport: " + dataItems[itemIndex].DepartureAirport + " - ICAO";
                            }
                            else if (numSubfield == 9)
                            {
                                listBoxDI.Items.Add("#Subfield 8");
                                listBoxDI.Items.Add("Dest. Airport: " + dataItems[itemIndex].DestinationAirport);
                                infoBox.Text += Environment.NewLine + "#Subfield 8: Destination Airport"
                                    + Environment.NewLine + "Destination Airport: " + dataItems[itemIndex].DestinationAirport + " - ICAO";
                            }
                            else if (numSubfield == 10)
                            {
                                listBoxDI.Items.Add("#Subfield 9");
                                listBoxDI.Items.Add("Runway Designation: " + dataItems[itemIndex].RunwayDesignation);
                                infoBox.Text += Environment.NewLine + "#Subfield 9: Runway Designation"
                                    + Environment.NewLine + "Runway Designation: " + dataItems[itemIndex].RunwayDesignation;
                            }
                            else if (numSubfield == 11)
                            {
                                listBoxDI.Items.Add("#Subfield 10");
                                listBoxDI.Items.Add("CFL: " + dataItems[itemIndex].CFL);
                                infoBox.Text += Environment.NewLine + "#Subfield 10: Current Cleared Flight Level"
                                    + Environment.NewLine + "CFL: " + dataItems[itemIndex].CFL + " - Current Cleared Flight Level (FL)";
                            }
                            else if (numSubfield == 12)
                            {
                                listBoxDI.Items.Add("#Subfield 11");
                                listBoxDI.Items.Add("Centre: " + dataItems[itemIndex].Centre);
                                listBoxDI.Items.Add("Position: " + dataItems[itemIndex].Position);
                                infoBox.Text += Environment.NewLine + "#Subfield 11: Current Control Position"
                                    + Environment.NewLine + "Centre: " + dataItems[itemIndex].Centre + "8-bit group Identification code"
                                    + Environment.NewLine + "Position " + dataItems[itemIndex].Position + "8-bit group Identification code";
                            }
                            else if (numSubfield == 13)
                            {
                                listBoxDI.Items.Add("#Subfield 12");
                                listBoxDI.Items.Add("REP: " + dataItems[itemIndex].REP290);
                                listBoxDI.Items.Add("TYP: " + dataItems[itemIndex].REP290);
                                listBoxDI.Items.Add("DAY: " + dataItems[itemIndex].DAY);
                                listBoxDI.Items.Add("HOR: " + dataItems[itemIndex].HOR);
                                listBoxDI.Items.Add("MIN: " + dataItems[itemIndex].MIN);
                                listBoxDI.Items.Add("AVS: " + dataItems[itemIndex].AVS);
                                listBoxDI.Items.Add("SEC: " + dataItems[itemIndex].SEC);
                                infoBox.Text += Environment.NewLine + "#Subfield 12: Time of Departure / Arrival"
                                    + Environment.NewLine + "REP: " + dataItems[itemIndex].REP290 + " - Repetition Factor"
                                    + Environment.NewLine + "TYP: " + dataItems[itemIndex].TOD_TYP
                                    + Environment.NewLine + "DAY: " + dataItems[itemIndex].DAY
                                    + Environment.NewLine + "HOR: " + dataItems[itemIndex].HOR + " - Hours, from 0 to 23"
                                    + Environment.NewLine + "MIN: " + dataItems[itemIndex].MIN + " - Minutes, from 0 to 59"
                                    + Environment.NewLine + "AVS: " + dataItems[itemIndex].AVS
                                    + Environment.NewLine + "SEC: " + dataItems[itemIndex].SEC + " - Seconds, from 0 to 59"
                                    ;
                            }
                            else if (numSubfield == 14)
                            {
                                listBoxDI.Items.Add("#Subfield 13");
                                listBoxDI.Items.Add("Aircraft Stand: " + dataItems[itemIndex].AircraftStand);
                                infoBox.Text += Environment.NewLine + "#Subfield 13: Aircraft Stand"
                                    + Environment.NewLine + "Aircraft Stand: " + dataItems[itemIndex].AircraftStand;
                            }
                            else if (numSubfield == 15)
                            {
                                listBoxDI.Items.Add("#Subfield 14");
                                listBoxDI.Items.Add("EMP: " + dataItems[itemIndex].EMP);
                                listBoxDI.Items.Add("AVL: " + dataItems[itemIndex].AVL);
                                infoBox.Text += Environment.NewLine + "#Subfield 14: Stand Status"
                                    + Environment.NewLine + "EMP: " + dataItems[itemIndex].EMP
                                    + Environment.NewLine + "AVL: " + dataItems[itemIndex].AVL;
                            }
                            else if (numSubfield == 17)
                            {
                                listBoxDI.Items.Add("#Subfield 15");
                                listBoxDI.Items.Add("Standard Instrument Departure: " + dataItems[itemIndex].StandardInstrumentDeparture);
                                infoBox.Text += Environment.NewLine + "#Subfield 15: Standard Insttrument Departure"
                                    + Environment.NewLine + "Standard Instrument Departure: " + dataItems[itemIndex].StandardInstrumentDeparture;
                            }
                            else if (numSubfield == 18)
                            {
                                listBoxDI.Items.Add("#Subfield 16");
                                listBoxDI.Items.Add("Standard Instrument Arrival: " + dataItems[itemIndex].StandardInstrumentArrival);
                                infoBox.Text += Environment.NewLine + "#Subfield 16: Standard Insttrument Arrival"
                                    + Environment.NewLine + "Standard Instrument Arrival: " + dataItems[itemIndex].StandardInstrumentArrival;
                            }
                            else if (numSubfield == 19)
                            {
                                listBoxDI.Items.Add("#Subfield 17");
                                listBoxDI.Items.Add("Pre-Emergency Mode 3/A: " + dataItems[itemIndex].Mode3ARep);
                                infoBox.Text += Environment.NewLine + "#Subfield 17: Pre-Emergency Mode 3/A"
                                    + Environment.NewLine + "Pre-Emergency Mode 3/A: " + dataItems[itemIndex].Mode3ARep;
                            }
                            else if (numSubfield == 20)
                            {
                                listBoxDI.Items.Add("#Subfield 18");
                                listBoxDI.Items.Add("Pre-Emergency Callsign: " + dataItems[itemIndex].PreEmergencyCallsign);
                                infoBox.Text += Environment.NewLine + "#Subfield 18: Pre-Emergency Callsign"
                                    + Environment.NewLine + "Pre-Emergency Callsign: " + dataItems[itemIndex].PreEmergencyCallsign;
                            }
                        }
                        numSubfield++;
                    }
                }
                else if (itemIndexFRN == "FRN22")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/270 Target Size & Orientation");
                    listBoxDI.Items.Add("Length: " + dataItems[itemIndex].LEN22);
                    infoBox.Text = "No info";
                }
                else if (itemIndexFRN == "FRN23")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/300 Vehicle Fleet Identification");
                    listBoxDI.Items.Add("VFI: " + dataItems[itemIndex].VFI);
                    infoBox.Text = "VFI: " + dataItems[itemIndex].VFI
                                    + Environment.NewLine + "Definition: Vehicle fleet identification number"
                                    + Environment.NewLine + "Format: One-Octet fixed length data item";
                }
                else if (itemIndexFRN == "FRN24")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/110 Mode 5 Data reports & Extended Mode 1 Code");
                    listBoxDI.Items.Add("Length: " + dataItems[itemIndex].LEN24);
                    infoBox.Text = "No info";
                }
                else if (itemIndexFRN == "FRN25")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/120, Track Mode 2 Code");
                    listBoxDI.Items.Add("Mode-2: " + dataItems[itemIndex].TrackMode2Code);
                    infoBox.Text = "Mode-2: " + dataItems[itemIndex].TrackMode2Code + " - Mode-2 code in octal representation"
                                    + Environment.NewLine + "Definition: Mode 2 code associated to the track"
                                    + Environment.NewLine + "Format: Two-Octet fixed length data item";
                }
                else if (itemIndexFRN == "FRN26")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/510 Composed Track Number");
                    listBoxDI.Items.Add("System U. ID: " + dataItems[itemIndex].SystemUnitID);
                    listBoxDI.Items.Add("System Track Number: " + dataItems[itemIndex].SystemTrackNumber);
                    infoBox.Text = "System Unit Identification: " + dataItems[itemIndex].SystemUnitID
                                    + Environment.NewLine + "System Track Number: " + dataItems[itemIndex].SystemTrackNumber
                                    + Environment.NewLine + "Definition: Identification of a system track"
                                    + Environment.NewLine + "Format: Extendible data item, comprising a first part of three octets " +
                                    "(Master Track Number), followed by three - octet extents(Slave Tracks Numbers).";
                }
                else if (itemIndexFRN == "FRN27")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/500 Estimated Accuracies");
                    listBoxDI.Items.Add("Length: " + dataItems[itemIndex].LEN27);
                    infoBox.Text = "No info";
                }
                else if (itemIndexFRN == "FRN28")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("I062/340 Measured Information");
                    listBoxDI.Items.Add("Primary Field: " + dataItems[itemIndex].primary28);
                    string primary28 = dataItems[itemIndex].primary28;
                    int numSubfield = 1;

                    infoBox.Text = "SID: " + dataItems[itemIndex].primary28.Substring(0, 1) + "Presence of Subfield #1"
                       + Environment.NewLine + "POS: " + dataItems[itemIndex].primary28.Substring(1, 1) + "Presence of Subfield #2"
                       + Environment.NewLine + "HEI: " + dataItems[itemIndex].primary28.Substring(2, 1) + "Presence of Subfield #3"
                       + Environment.NewLine + "MDC: " + dataItems[itemIndex].primary28.Substring(3, 1) + "Presence of Subfield #4"
                       + Environment.NewLine + "MDA: " + dataItems[itemIndex].primary28.Substring(4, 1) + "Presence of Subfield #5"
                       + Environment.NewLine + "TYP: " + dataItems[itemIndex].primary28.Substring(5, 1) + "Presence of Subfield #6"
                       + Environment.NewLine + "FX: " + dataItems[itemIndex].primary28.Substring(7, 1) + "- Extension Indicator";
                    foreach (char Bit in primary28)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1)
                            {
                                listBoxDI.Items.Add("#Subfield 1");
                                listBoxDI.Items.Add("SIC: " + dataItems[itemIndex].SICSI);
                                listBoxDI.Items.Add("SAC: " + dataItems[itemIndex].SACSI);
                                infoBox.Text += Environment.NewLine + "#Subfield 1: Sensor Identification"
                                    + Environment.NewLine + "SIC: " + dataItems[itemIndex].FPPSSIC + "System Identity Code"
                                    + Environment.NewLine + "SAC: " + dataItems[itemIndex].FPPSSAC + "System Area Code";
                            }
                            else if (numSubfield == 2)
                            {
                                listBoxDI.Items.Add("#Subfield 2");
                                listBoxDI.Items.Add("Rho: " + dataItems[itemIndex].RHO);
                                listBoxDI.Items.Add("Theta: " + dataItems[itemIndex].THETA);
                                infoBox.Text += Environment.NewLine + "#Subfield 2: Measured Position"
                                    + Environment.NewLine + "Rho: " + dataItems[itemIndex].RHO + "Measured distance. (LSB) = 1/256 NM"
                                    + Environment.NewLine + "Theta: " + dataItems[itemIndex].THETA + "Measured azimuth. (LSB) = 360/2^16 º";
                            }
                            else if (numSubfield == 3)
                            {
                                listBoxDI.Items.Add("#Subfield 3");
                                listBoxDI.Items.Add("Height: " + dataItems[itemIndex].HEI);
                                infoBox.Text += Environment.NewLine + "#Subfield 3: Measured 3D Height"
                                    + Environment.NewLine + "Height: " + dataItems[itemIndex].HEI + "Measured 3D Height. (LSB) = 25 ft";
                            }
                            else if (numSubfield == 4)
                            {
                                listBoxDI.Items.Add("#Subfield 4");
                                listBoxDI.Items.Add("V: " + dataItems[itemIndex].V);
                                listBoxDI.Items.Add("G: " + dataItems[itemIndex].G);
                                listBoxDI.Items.Add("MDC: " + dataItems[itemIndex].MDC);
                                infoBox.Text += Environment.NewLine + "#Subfield 4: Last Measured Mode C Code"
                                    + Environment.NewLine + "V: " + dataItems[itemIndex].V
                                    + Environment.NewLine + "G: " + dataItems[itemIndex].G
                                    + Environment.NewLine + "MDC: " + dataItems[itemIndex].MDC + "Last Measured Mode C Code, in two's complement form. (LSB) = 1/4 FL";
                            }
                            else if (numSubfield == 5)
                            {
                                listBoxDI.Items.Add("#Subfield 5");
                                listBoxDI.Items.Add("V: " + dataItems[itemIndex].V2);
                                listBoxDI.Items.Add("G: " + dataItems[itemIndex].G2);
                                listBoxDI.Items.Add("L: " + dataItems[itemIndex].L);
                                listBoxDI.Items.Add("MDA: " + dataItems[itemIndex].MDA);
                                infoBox.Text += Environment.NewLine + "#Subfield 5: Last Measured Mode 3/A Code"
                                    + Environment.NewLine + "V: " + dataItems[itemIndex].V2
                                    + Environment.NewLine + "G: " + dataItems[itemIndex].G2
                                    + Environment.NewLine + "L: " + dataItems[itemIndex].L
                                    + Environment.NewLine + "MDA: " + dataItems[itemIndex].MDA + "Mode 3/A reply under the form of 4 digits in octal representation";
                            }
                            else if (numSubfield == 6)
                            {
                                listBoxDI.Items.Add("#Subfield 6");
                                listBoxDI.Items.Add("TYP: " + dataItems[itemIndex].TYP);
                                listBoxDI.Items.Add("SIM: " + dataItems[itemIndex].SIMrep);
                                listBoxDI.Items.Add("RAB: " + dataItems[itemIndex].RAB);
                                listBoxDI.Items.Add("TST: " + dataItems[itemIndex].TST);
                                infoBox.Text += Environment.NewLine + "#Subfield 6: Report Type"
                                    + Environment.NewLine + "TYP: " + dataItems[itemIndex].TYP
                                    + Environment.NewLine + "SIM: " + dataItems[itemIndex].SIMrep
                                    + Environment.NewLine + "RAB: " + dataItems[itemIndex].RAB
                                    + Environment.NewLine + "TST: " + dataItems[itemIndex].TST;
                            }
                        }
                        numSubfield++;
                    }
                }
                else if (itemIndexFRN == "FRN34")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("RE: Reserved Expansion Field");
                    listBoxDI.Items.Add("LEN: " + dataItems[itemIndex].LENRE);
                    listBoxDI.Items.Add("CST: " + dataItems[itemIndex].CSTRE);
                    listBoxDI.Items.Add("CSN: " + dataItems[itemIndex].CSN);
                    listBoxDI.Items.Add("TVS: " + dataItems[itemIndex].TVS);
                    listBoxDI.Items.Add("STS: " + dataItems[itemIndex].STS);
                    if (dataItems[itemIndex].CSTRE == "1")
                    {
                        listBoxDI.Items.Add("REP_CST: " + dataItems[itemIndex].REPW);
                        listBoxDI.Items.Add("SAC_CST: " + dataItems[itemIndex].SACW);
                        listBoxDI.Items.Add("SIC_CST: " + dataItems[itemIndex].SICW);
                        listBoxDI.Items.Add("TYP_CST: " + dataItems[itemIndex].TYPW);
                    }
                    if (dataItems[itemIndex].CSN == "1")
                    {
                        listBoxDI.Items.Add("REP_CSN: " + dataItems[itemIndex].REPNO);
                        listBoxDI.Items.Add("SAC_CSN: " + dataItems[itemIndex].SACNO);
                        listBoxDI.Items.Add("SIC_CSN: " + dataItems[itemIndex].SICNO);
                        listBoxDI.Items.Add("TYP_CSN: " + dataItems[itemIndex].TYPNO);
                    }
                    listBoxDI.Items.Add("Vx: " + dataItems[itemIndex].VxRE);
                    listBoxDI.Items.Add("Vy: " + dataItems[itemIndex].VyRE);
                    listBoxDI.Items.Add("FDR: " + dataItems[itemIndex].FDR);
                    infoBox.Text = "LEN: " + dataItems[itemIndex].LENRE + " octets"
                                    + Environment.NewLine + "CST: " + dataItems[itemIndex].CSTRE
                                    + Environment.NewLine + "CSN: " + dataItems[itemIndex].CSN
                                    + Environment.NewLine + "TVS: " + dataItems[itemIndex].TVS
                                    + Environment.NewLine + "STS: " + dataItems[itemIndex].STS;
                    if (dataItems[itemIndex].CSTRE == "1")
                    {
                        infoBox.Text += "REP_CST: " + dataItems[itemIndex].REPW
                        + Environment.NewLine + "SAC_CST: " + dataItems[itemIndex].SACW
                        + Environment.NewLine + "SIC_CST: " + dataItems[itemIndex].SICW
                        + Environment.NewLine + "TYP_CST: " + dataItems[itemIndex].TYPW;
                    }
                    if (dataItems[itemIndex].CSN == "1")
                    {
                        infoBox.Text += "REP_CSN: " + dataItems[itemIndex].REPNO
                        + Environment.NewLine + "SAC_CSN: " + dataItems[itemIndex].SACNO
                        + Environment.NewLine + "SIC_CSN: " + dataItems[itemIndex].SICNO
                        + Environment.NewLine + "TYP_CSN: " + dataItems[itemIndex].TYPNO;
                    }

                    infoBox.Text += Environment.NewLine + "Vx: " + dataItems[itemIndex].VxRE
                                    + Environment.NewLine + "Vy: " + dataItems[itemIndex].VyRE
                                    + Environment.NewLine + "FDR: " + dataItems[itemIndex].FDR;
                }
                else if (itemIndexFRN == "FRN35")
                {
                    titleDI.Text = itemIndexFRN;
                    listBoxDI.Items.Clear();
                    listBoxDI.Items.Add("SP: Reserved For Special Purpose Indicator");
                    listBoxDI.Items.Add("Length: " + dataItems[itemIndex].LEN35);
                    infoBox.Text = "No info";
                }
            }


        }
        private void listBoxDI_Click(object sender, EventArgs e)
        {
            if (listBoxDI.SelectedItem == null)
            {
            }
            else
            {
                infoPic.Visible = true;
                infoBox.Visible = true;
            }
        }
        private void btnSearchBy_Click(object sender, EventArgs e)
        {
            listSearch.Visible = true;
            listSearch.Items.Clear();
            listSearch.Items.Add("Search by...");
            listSearch.Items.Add("Target ID");
            listSearch.Items.Add("Track Number");
            listSearch.Items.Add("Departure Airport");
            listSearch.Items.Add("Destination Airport");
            listSearch.Items.Add("Time");
            btnSearchBy.Visible = false;
            btnTimeConsole.Visible = false;
            //this.gMap.Controls.Add(btnBackMap);
            btnBackMap.Visible = true;
        }
        private void listSearch_Click(object sender, EventArgs e)
        {
            if (listSearch.SelectedItem == null)
            {
            }
            else
            {
                itemSB = listSearch.SelectedItem.ToString();
                if (itemSB == "Search by...")
                {

                }
                else if (itemSB == "Target ID")
                {
                    listBoxID.Visible = true;
                    timeFinal.Visible = false;
                    timeInitial.Visible = false;
                    lblTimeInitial.Visible = false;
                    lblTimeInitialValue.Visible = false;
                    lblFinalTime.Visible = false;
                    lblFinalTimeValue.Visible = false;
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();

                    if ((dataItems[0].ID == null) && (dataItems[0].TargetID == null) && (dataItems[0].Callsign == null))
                    {
                        listBoxID.Items.Add("No Data Provided");
                    }
                    else
                    {
                        listBoxID.Items.Clear();
                        if (flagID != 0)
                        {
                            List<string> distinctID1 = SavedID.Distinct().ToList();
                            distinctID1.Sort();
                            uniqueID = distinctID1;
                            for (int i = 0; i < distinctID1.Count; i++)
                            {
                                listBoxID.Items.Add(distinctID1[i]);
                            }
                            listBoxID.Sorted = true;
                        }
                        else
                        {
                            listBoxID.Items.Add("No Data Provided");
                        }

                    }

                }
                else if (itemSB == "Track Number")
                {
                    listBoxID.Visible = true;
                    timeFinal.Visible = false;
                    timeInitial.Visible = false;
                    lblTimeInitial.Visible = false;
                    lblTimeInitialValue.Visible = false;
                    lblFinalTime.Visible = false;
                    lblFinalTimeValue.Visible = false;
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();
                    if (dataItems[0].TrackNumber == null)
                    {
                        listBoxID.Items.Add("No Data Provided");
                    }
                    else
                    {
                        listBoxID.Items.Clear();
                        if (flagTrackNumber != 0)
                        {
                            List<string> distinctID1 = SavedTrack.Distinct().ToList();
                            distinctID1.Sort();
                            uniqueTrackNumber = distinctID1;
                            for (int i = 0; i < distinctID1.Count; i++)
                            {
                                listBoxID.Items.Add(distinctID1[i]);
                            }
                            listBoxID.Sorted = true;
                        }

                    }
                }
                else if (itemSB == "Departure Airport")
                {
                    listBoxID.Items.Clear();
                    listBoxID.Visible = true;
                    timeFinal.Visible = false;
                    timeInitial.Visible = false;
                    lblTimeInitial.Visible = false;
                    lblTimeInitialValue.Visible = false;
                    lblFinalTime.Visible = false;
                    lblFinalTimeValue.Visible = false;
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();
                    if (flagDAir != 0)
                    {

                        List<string> distinctID1 = SavedOAir.Distinct().ToList();
                        distinctID1.Sort();
                        uniqueDAir = distinctID1;
                        for (int i = 0; i < distinctID1.Count; i++)
                        {
                            listBoxID.Items.Add(distinctID1[i]);
                        }
                    }
                    else
                    {
                        listBoxID.Items.Add("No Data Provided");
                    }

                }
                else if (itemSB == "Destination Airport")
                {
                    listBoxID.Items.Clear();
                    listBoxID.Visible = true;
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();
                    timeFinal.Visible = false;
                    timeInitial.Visible = false;
                    lblTimeInitial.Visible = false;
                    lblTimeInitialValue.Visible = false;
                    lblFinalTime.Visible = false;
                    lblFinalTimeValue.Visible = false;
                    if (flagDAir != 0)
                    {
                        List<string> distinctID1 = SavedDAir.Distinct().ToList();
                        distinctID1.Sort();
                        uniqueDAir = distinctID1;
                        for (int i = 0; i < distinctID1.Count; i++)
                        {
                            listBoxID.Items.Add(distinctID1[i]);
                        }
                    }
                    else
                    {
                        listBoxID.Items.Add("No Data Provided");
                    }
                }
                else if (itemSB == "Time")
                {
                    listBoxID.Visible = false;
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();

                    if (dataItems[0].TimeSeconds != dataItems[tam - 1].TimeSeconds)
                    {
                        listBoxID.Visible = false;
                        timeFinal.Visible = true;
                        timeInitial.Visible = true;
                        lblTimeInitial.Visible = true;
                        lblTimeInitialValue.Visible = true;
                        lblFinalTime.Visible = true;
                        lblFinalTimeValue.Visible = true;
                        lblFinalTime.Text = "Final Time";

                        timeInitial.Minimum = 0;
                        timeInitial.Maximum = 9;
                        timeFinal.Minimum = 0;
                        timeFinal.Maximum = 9;
                        timeInitial.Value = 0;
                        timeFinal.Value = timeInitial.Value + interval;
                        timeInitial.TickFrequency = 1;
                        timeFinal.TickFrequency = 1;

                        chosenTimeI = dataItems[0].TimeSeconds;
                        chosenTimeF = (dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 2 / 9 + dataItems[0].TimeSeconds;

                        System.TimeSpan timeIn = System.TimeSpan.FromSeconds(Convert.ToDouble(dataItems[0].TimeSeconds));
                        System.TimeSpan timeFi = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 2 / 9) + dataItems[0].TimeSeconds));
                        lblFinalTimeValue.Text = timeFi.ToString(@"hh\:mm\:ss\.fff");
                        lblTimeInitialValue.Text = timeIn.ToString(@"hh\:mm\:ss\.fff");

                        int countdataGridS = 0;
                        dataGridS.Rows.Add(tam);
                        for (int j = 0; j < tam * 2 / 9; j++)
                        {
                            if (dataItems[j].TimeSeconds >= chosenTimeI)
                            {
                                if (dataItems[j].TimeSeconds <= chosenTimeF)
                                {
                                    int index2 = j + 1;


                                    dataGridS[0, countdataGridS].Value = index2;
                                    dataGridS[1, countdataGridS].Value = countdataGridS + 1;
                                    dataGridS[2, countdataGridS].Value = dataGrid[1, j].Value;
                                    dataGridS[3, countdataGridS].Value = dataItems[j].TimeOfTrackInfo;
                                    dataGridS[4, countdataGridS].Value = dataItems[j].TrackNumber;
                                    dataGridS[5, countdataGridS].Value = dataItems[j].LatWGS84 + ", " + dataItems[j].LonWGS84;
                                    dataGridS[6, countdataGridS].Value = dataItems[j].X + ", " + dataItems[j].Y;
                                    dataGridS[7, countdataGridS].Value = dataItems[j].Vx;
                                    dataGridS[8, countdataGridS].Value = dataItems[j].Vy;
                                    dataGridS[9, countdataGridS].Value = dataItems[j].DepartureAirport;
                                    dataGridS[10, countdataGridS].Value = dataItems[j].DestinationAirport;

                                    countdataGridS++;
                                }
                            }

                        }

                    }
                    else
                    {
                        lblFinalTime.Visible = true;
                        lblFinalTime.Text = "No Data Provided";
                    }
                }
            }
        }
        private void listBoxID_Click(object sender, EventArgs e)
        {
            btnBackMap.Visible = true;
            if (listBoxID.SelectedItem == null)
            {

            }
            else if (listBoxID.SelectedItem == "")
            {

            }
            else if (listBoxID.SelectedItem == "No Data Provided")
            {

            }
            else if (listBoxID.SelectedItem == "IDs...")
            {

            }
            else if (listBoxID.SelectedItem == "Track Numbers...")
            {

            }
            else if (listBoxID.SelectedItem == "Mode 3/As...")
            {

            }
            else
            {
                if (listSearch.SelectedItem == "Target ID")
                {
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();
                    dataGridS.Rows.Add(tam);
                    string chosenID = listBoxID.SelectedItem.ToString();
                    int countdataGridS = 0;
                    if (lblTitle.Text == "Search by")
                    {
                        for (int i = 0; i < tam; i++)
                        {
                            if ((dataItems[i].ID == chosenID) || (dataItems[i].TargetID == chosenID) || (dataItems[i].Callsign == chosenID))
                            {
                                int index2 = i + 1;

                                dataGridS[1, countdataGridS].Value = countdataGridS + 1;
                                dataGridS[0, countdataGridS].Value = index2;
                                dataGridS[2, countdataGridS].Value = chosenID;
                                dataGridS[4, countdataGridS].Value = dataItems[i].TimeOfTrackInfo;
                                dataGridS[3, countdataGridS].Value = dataItems[i].TrackNumber;
                                dataGridS[5, countdataGridS].Value = dataItems[i].LatWGS84str + ", " + dataItems[i].LonWGS84str;
                                dataGridS[6, countdataGridS].Value = dataItems[i].X + ", " + dataItems[i].Y;
                                dataGridS[7, countdataGridS].Value = dataItems[i].Vx + ", " + dataItems[i].Vy;
                                dataGridS[8, countdataGridS].Value = dataItems[i].ADR;
                                dataGridS[9, countdataGridS].Value = dataItems[i].Mode3AReply;
                                dataGridS[10, countdataGridS].Value = dataItems[i].DepartureAirport;
                                dataGridS[11, countdataGridS].Value = dataItems[i].DestinationAirport;


                                countdataGridS++;
                            }
                        }
                    }
                    else if (pnlMedia.Visible == false)
                    {
                        // Create map overlay
                        this.pnlFormLoader.Controls.Clear();
                        this.pnlFormLoader.Controls.Add(gMap);
                        this.gMap.Controls.Add(btnClearTraces);

                        gMap.Visible = true;
                        btnClearTraces.Visible = true;

                        // map settings
                        gMap.ShowCenter = true;
                        gMap.DragButton = MouseButtons.Left;
                        gMap.MinZoom = 5;
                        gMap.MaxZoom = 100;
                        gMap.Zoom = 8;
                        GMapOverlay routes = new GMapOverlay("routes");
                        List<PointLatLng> points = new List<PointLatLng>();
                        for (int i = 0; i < tam; i++)
                        {
                            if ((dataItems[i].ID == chosenID) || (dataItems[i].TargetID == chosenID) || (dataItems[i].Callsign == chosenID))
                            {
                                points.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                            }
                        }
                        GMapRoute route = new GMapRoute(points, "Routes");
                        Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                        route.Stroke = new Pen(randomColor, 3);
                        routes.Routes.Add(route);
                        gMap.Overlays.Add(routes);
                        gMap.Position = points[points.Count - 1];
                        GMapMarker marker = new GMarkerGoogle(points[points.Count - 1], planeMarker);
                        // Agrega el marker al overlay "markers"
                        markers.Markers.Add(marker);
                        // Agrega el overlay "markers" al mapa "map"
                        gMap.Overlays.Add(markers);
                    }

                }
                else if (listSearch.SelectedItem == "Track Number")
                {
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();
                    dataGridS.Rows.Add(tam);
                    string chosenID = listBoxID.SelectedItem.ToString();
                    int countdataGridS = 0;
                    if (lblTitle.Text == "Search by")
                    {
                        for (int i = 0; i < tam; i++)
                        {
                            if (dataItems[i].TrackNumber == chosenID)
                            {
                                int index2 = i + 1;

                                dataGridS[1, countdataGridS].Value = countdataGridS + 1;
                                dataGridS[0, countdataGridS].Value = index2;
                                dataGridS[2, countdataGridS].Value = chosenID;
                                dataGridS[4, countdataGridS].Value = dataItems[i].TimeOfTrackInfo;
                                dataGridS[3, countdataGridS].Value = dataItems[i].TrackNumber;
                                dataGridS[5, countdataGridS].Value = dataItems[i].LatWGS84str + ", " + dataItems[i].LonWGS84str;
                                dataGridS[6, countdataGridS].Value = dataItems[i].X + ", " + dataItems[i].Y;
                                dataGridS[7, countdataGridS].Value = dataItems[i].Vx + ", " + dataItems[i].Vy;
                                dataGridS[8, countdataGridS].Value = dataItems[i].ADR;
                                dataGridS[9, countdataGridS].Value = dataItems[i].Mode3AReply;
                                dataGridS[10, countdataGridS].Value = dataItems[i].DepartureAirport;
                                dataGridS[11, countdataGridS].Value = dataItems[i].DestinationAirport;

                                countdataGridS++;
                            }
                        }
                    }
                    else if (pnlMedia.Visible == false)
                    {
                        if ((dataItems[0].LatWGS84 != "") && (dataItems[0].LatWGS84 != null))
                        {
                            // Create map overlay
                            this.pnlFormLoader.Controls.Clear();
                            this.pnlFormLoader.Controls.Add(gMap);
                            this.gMap.Controls.Add(btnClearTraces);

                            gMap.Visible = true;
                            btnClearTraces.Visible = true;

                            // map settings
                            gMap.ShowCenter = true;
                            gMap.DragButton = MouseButtons.Left;
                            gMap.MinZoom = 5;
                            gMap.MaxZoom = 100;
                            gMap.Zoom = 8;
                            GMapOverlay routes = new GMapOverlay("routes");
                            List<PointLatLng> points = new List<PointLatLng>();

                            for (int i = 0; i < tam; i++)
                            {
                                if (dataItems[i].TrackNumber == chosenID)
                                {
                                    points.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                }
                            }


                            GMapRoute route = new GMapRoute(points, "Routes");
                            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                            route.Stroke = new Pen(randomColor, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                            gMap.Position = points[points.Count - 1];
                            GMapMarker marker = new GMarkerGoogle(points[points.Count - 1], planeMarker);
                            // Agrega el marker al overlay "markers"
                            markers.Markers.Add(marker);
                            // Agrega el overlay "markers" al mapa "map"
                            gMap.Overlays.Add(markers);

                        }
                    }

                }
                else if (listSearch.SelectedItem == "Destination Airport")
                {
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();
                    dataGridS.Rows.Add(tam);
                    dataGridS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                    string chosenID = listBoxID.SelectedItem.ToString();
                    int countdataGridS = 0;
                    if (lblTitle.Text == "Search by")
                    {
                        for (int i = 0; i < tam; i++)
                        {
                            if (dataItems[i].DestinationAirport == chosenID)
                            {
                                int index2 = i + 1;

                                dataGridS[1, countdataGridS].Value = countdataGridS + 1;
                                dataGridS[0, countdataGridS].Value = index2;
                                dataGridS[2, countdataGridS].Value = SavedID[i];
                                dataGridS[4, countdataGridS].Value = dataItems[i].TimeOfTrackInfo;
                                dataGridS[3, countdataGridS].Value = dataItems[i].TrackNumber;
                                dataGridS[5, countdataGridS].Value = dataItems[i].LatWGS84str + ", " + dataItems[i].LonWGS84str;
                                dataGridS[6, countdataGridS].Value = dataItems[i].X + ", " + dataItems[i].Y;
                                dataGridS[7, countdataGridS].Value = dataItems[i].Vx + ", " + dataItems[i].Vy;
                                dataGridS[8, countdataGridS].Value = dataItems[i].ADR;
                                dataGridS[9, countdataGridS].Value = dataItems[i].Mode3AReply;
                                dataGridS[10, countdataGridS].Value = dataItems[i].DepartureAirport;
                                dataGridS[11, countdataGridS].Value = dataItems[i].DestinationAirport;

                                countdataGridS++;
                            }
                        }
                    }
                    else if (pnlMedia.Visible == false)
                    {
                        List<string> distinctID1 = SavedTrack.Distinct().ToList();
                        distinctID1.Sort();
                        uniqueTrackNumber = distinctID1;
                        // Create map overlay
                        this.pnlFormLoader.Controls.Clear();
                        this.pnlFormLoader.Controls.Add(gMap);
                        this.gMap.Controls.Add(btnClearTraces);

                        gMap.Overlays.Clear();
                        gMap.Visible = true;
                        pnlFormLoader.Visible = true;
                        btnClearTraces.Visible = true;
                        // map settings
                        gMap.ShowCenter = true;
                        gMap.DragButton = MouseButtons.Left;
                        gMap.MinZoom = 5;
                        gMap.MaxZoom = 100;
                        gMap.Zoom = 8;

                        if (flagDAir != 0)
                        {

                            foreach (var (uniqTrack, ind) in uniqueTrackNumber.Select((value, i) => (value, i)))
                            {
                                GMapOverlay routes = new GMapOverlay("routes");
                                List<PointLatLng> points = new List<PointLatLng>();
                                points.Clear();
                                for (int j = 0; j < tam; j++)
                                {
                                    if (dataItems[j].DestinationAirport == chosenID && dataItems[j].TrackNumber == uniqTrack)
                                    {
                                        points.Add(new PointLatLng(Convert.ToDouble(dataItems[j].LatWGS84), Convert.ToDouble(dataItems[j].LonWGS84)));
                                    }
                                }
                                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                                GMapRoute route = new GMapRoute(points, "Routes");
                                route.Stroke = new Pen(randomColor, 3);
                                routes.Routes.Add(route);
                                gMap.Overlays.Add(routes);
                                if (points.Count > 0)
                                {
                                    gMap.Position = points[0];
                                    GMapMarker marker = new GMarkerGoogle(points[points.Count - 1], planeMarker);
                                    // Agrega el marker al overlay "markers"
                                    markers.Markers.Add(marker);
                                    // Agrega el overlay "markers" al mapa "map"
                                    gMap.Overlays.Add(markers);
                                }

                            }
                        }
                    }

                }
                else if (listSearch.SelectedItem == "Departure Airport")
                {
                    dataGridS.Visible = true;
                    dataGridS.Rows.Clear();
                    dataGridS.Rows.Add(tam);
                    string chosenID = listBoxID.SelectedItem.ToString();
                    int countdataGridS = 0;
                    if (lblTitle.Text == "Search by")
                    {
                        for (int i = 0; i < tam; i++)
                        {
                            if (dataItems[i].DepartureAirport == chosenID)
                            {
                                int index2 = i + 1;

                                dataGridS[1, countdataGridS].Value = countdataGridS + 1;
                                dataGridS[0, countdataGridS].Value = index2;
                                dataGridS[2, countdataGridS].Value = SavedID[i];
                                dataGridS[4, countdataGridS].Value = dataItems[i].TimeOfTrackInfo;
                                dataGridS[3, countdataGridS].Value = dataItems[i].TrackNumber;
                                dataGridS[5, countdataGridS].Value = dataItems[i].LatWGS84str + ", " + dataItems[i].LonWGS84str;
                                dataGridS[6, countdataGridS].Value = dataItems[i].X + ", " + dataItems[i].Y;
                                dataGridS[7, countdataGridS].Value = dataItems[i].Vx + ", " + dataItems[i].Vy;
                                dataGridS[8, countdataGridS].Value = dataItems[i].ADR;
                                dataGridS[9, countdataGridS].Value = dataItems[i].Mode3AReply;
                                dataGridS[10, countdataGridS].Value = dataItems[i].DepartureAirport;
                                dataGridS[11, countdataGridS].Value = dataItems[i].DestinationAirport;

                                countdataGridS++;
                            }
                        }
                    }
                    else if (pnlMedia.Visible == false)
                    {

                        List<string> distinctID1 = SavedTrack.Distinct().ToList();
                        distinctID1.Sort();
                        uniqueTrackNumber = distinctID1;
                        // Create map overlay
                        this.pnlFormLoader.Controls.Clear();
                        this.pnlFormLoader.Controls.Add(gMap);
                        this.gMap.Controls.Add(btnClearTraces);

                        gMap.Overlays.Clear();
                        gMap.Visible = true;
                        pnlFormLoader.Visible = true;
                        btnClearTraces.Visible = true;
                        // map settings
                        gMap.ShowCenter = true;
                        gMap.DragButton = MouseButtons.Left;
                        gMap.MinZoom = 5;
                        gMap.MaxZoom = 100;
                        gMap.Zoom = 8;

                        if (flagOAir != 0)
                        {

                            foreach (var (uniqTrack, ind) in uniqueTrackNumber.Select((value, i) => (value, i)))
                            {
                                GMapOverlay routes = new GMapOverlay("routes");
                                List<PointLatLng> points = new List<PointLatLng>();
                                points.Clear();
                                for (int j = 0; j < tam; j++)
                                {
                                    if (dataItems[j].DepartureAirport == chosenID && dataItems[j].TrackNumber == uniqTrack)
                                    {
                                        points.Add(new PointLatLng(Convert.ToDouble(dataItems[j].LatWGS84), Convert.ToDouble(dataItems[j].LonWGS84)));
                                    }
                                }
                                GMapRoute route = new GMapRoute(points, "Routes");
                                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                                route.Stroke = new Pen(randomColor, 3);
                                routes.Routes.Add(route);
                                gMap.Overlays.Add(routes);
                                if (points.Count > 0)
                                {
                                    gMap.Position = points[0];
                                    GMapMarker marker = new GMarkerGoogle(points[points.Count - 1], planeMarker);
                                    // Agrega el marker al overlay "markers"
                                    markers.Markers.Add(marker);
                                    // Agrega el overlay "markers" al mapa "map"
                                    gMap.Overlays.Add(markers);
                                }
                            }

                        }
                    }
                }
                if ((lblTitle.Text == "Map") && (pnlMedia.Visible))
                {

                    if (RoutesIDOn == true)
                    {
                        timer.Stop();
                        selectedRoute = true;
                        markers.Markers.Clear();
                        gMap.Overlays.Clear();

                        string chosenID = listBoxID.SelectedItem.ToString();
                        gMap.MinZoom = 5;
                        gMap.MaxZoom = 100;
                        gMap.Zoom = 8;
                        int j = 0;
                        int p = 0;
                        k = 0;
                        int h = 0;
                        GMapOverlay routes = new GMapOverlay("routes");
                        pointsA.Clear();
                        pointsB.Clear();
                        pointsTotSel.Clear();
                        selectedTimes.Clear();
                        pointsIni.Clear();
                        selectedMSG.Clear();
                        trackMFL.Clear();
                        trackMFLX.Clear();
                        trackMFLY.Clear();
                        

                        for (int i = 0; i < tam; i++)
                        {

                            if ((dataItems[i].ID == chosenID) || (dataItems[i].TargetID == chosenID) || (dataItems[i].Callsign == chosenID))
                            {
                                if (dataItems[i].TimeSeconds <= SavedTimeDouble[newTimeBegin[timeBar.Value] + newTimeNumber[timeBar.Value] - 1])
                                {
                                    pointsA.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    pointsTotSel.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    selectedTimes.Add(itemTimeLap[i]);
                                    if (dataItems[i].MFL != "")
                                    {
                                        trackMFL.Add(Convert.ToDouble(dataItems[i].MFL));
                                        k++;
                                    }
                                    selectedMSG.Add(i);
                                    j++;
                                }
                                else
                                {
                                    pointsB.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    pointsTotSel.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    selectedTimes.Add(itemTimeLap[i]);
                                    if (dataItems[i].MFL != "")
                                    {
                                        trackMFL.Add(Convert.ToDouble(dataItems[i].MFL));
                                        h++;
                                    }
                                    selectedMSG.Add(i);
                                    p++;
                                }
                            }
                        }
                        selectedMSGint = selectedMSG.Count - 1 - p;

                        if (k + h > 0)
                        {
                            Double factor;
                            if (trackMFL.Max() > 1)
                            {
                                factor = trackMFL.Max();
                            }
                            else
                            {
                                factor = 1;
                            }

                            foreach (var (MFL, indexd) in trackMFL.Select((value, i) => (value, i)))
                            {

                                trackMFLY.Add(Convert.ToInt32(100 - (trackMFL[indexd] / factor * 90 + 5)));
                                Double xPOS = (Convert.ToDouble(indexd) / trackMFL.Count) * 250 + 30;
                                trackMFLX.Add(Convert.ToInt32(xPOS));
                            }
                        }
                        //panel2.Visible = true;

                        Live.Visible = true;
                        btnLive.Visible = true;
                        //btnLive2.Visible = true;
                        btnLive.BackColor = Color.Gray;
                        btnLive2.Location = new System.Drawing.Point(268, 235);
                        btnLive2.BackColor = Color.Gray;
                        liveVert = false;

                        planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                        minFL.Text = trackMFL.Min().ToString() + " FL";
                        maxFL.Text = trackMFL.Max().ToString() + " FL";
                        minFL.Visible = true;
                        maxFL.Visible = true;
                        planoZ.Refresh();

                        pnlPlaneInfo.Visible = true;
                        pnlDiv1.Visible = true;
                        pnlDiv2.Visible = true;
                        pnlDiv3.Visible = true;
                        idValue.Text = SavedID[selectedMSG[selectedMSG.Count - 1 - p]];
                        trackValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].TrackNumber;
                        AddressValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].ADR;
                        ModeValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Mode3AReply;
                        lonValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].LonWGS84str + "º";
                        LatValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].LatWGS84str + "º";
                        infoPlaneLat.Visible = true;
                        infoPlaneLon.Visible = true;
                        infoPlaneID.Visible = true;
                        infoPlaneTN.Visible = true;
                        infoPlaneMode3A.Visible = true;
                        infoPlaneTA.Visible = true;
                        LatValue.Visible = true;
                        lonValue.Visible = true;
                        ModeValue.Visible = true;
                        trackValue.Visible = true;
                        idValue.Visible = true;
                        AddressValue.Visible = true;
                        XValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].X + " m";
                        YValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Y + " m";
                        VxValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Vx + " m/s";
                        VyValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Vy + " m/s";
                        AxValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Ax + " m/s^2";
                        AyValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Ay + " m/s^2";
                        infoPlaneX.Visible = true;
                        infoPlaneY.Visible = true;
                        infoPlaneVx.Visible = true;
                        infoPlaneVy.Visible = true;
                        infoPlaneAx.Visible = true;
                        infoPlaneAy.Visible = true;
                        XValue.Visible = true;
                        YValue.Visible = true;
                        VxValue.Visible = true;
                        VyValue.Visible = true;
                        AxValue.Visible = true;
                        AyValue.Visible = true;
                        planoZ.Visible = true;
                        MHGValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].MHG + " º";
                        MFLValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].MFL + " FL";
                        OAValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].DepartureAirport;
                        DAValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].DestinationAirport;
                        TimeValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].TimeOfTrackInfo;
                        MSGValue.Text = selectedMSG[selectedMSG.Count - 1 - p].ToString();
                        infoPlaneMHG.Visible = true;
                        infoPlaneMFL.Visible = true;
                        infoPlaneOA.Visible = true;
                        infoPlaneDA.Visible = true;
                        infoPlaneTime.Visible = true;
                        infoPlaneNM.Visible = true;
                        MHGValue.Visible = true;
                        MFLValue.Visible = true;
                        OAValue.Visible = true;
                        DAValue.Visible = true;
                        TimeValue.Visible = true;
                        MSGValue.Visible = true;




                        selectedRouteInitimeBar = selectedTimes[0];
                        selectedRouteFintimeBar = selectedTimes[selectedTimes.Count - 1];

                        if (j > 1)
                        {
                            GMapRoute route = new GMapRoute(pointsA, "Routes");
                            route.Stroke = new Pen(Color.Orange, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                        }
                        if (p > 1)
                        {

                            GMapRoute route = new GMapRoute(pointsB, "Routes");
                            route.Stroke = new Pen(Color.Gray, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                        }
                        if (j > 0)
                        {
                            gMap.Position = pointsA[j - 1];
                            Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG.Count - 1 - p]);
                            GMapMarker marker = new GMarkerGoogle(pointsA[j - 1], plane);
                            // Agrega el marker al overlay "markers"
                            markers.Markers.Add(marker);
                            // Agrega el overlay "markers" al mapa "map"
                            gMap.Overlays.Add(markers);
                        }
                        if ((j == 0) && (p == 0))
                        {
                            MessageBox.Show("no point");
                        }
                    }
                    else if (RoutesTrackOn == true)
                    {
                        timer.Stop();
                        selectedRoute = true;
                        markers.Markers.Clear();
                        gMap.Overlays.Clear();
                        string chosenID = listBoxID.SelectedItem.ToString();
                        gMap.MinZoom = 5;
                        gMap.MaxZoom = 100;
                        gMap.Zoom = 8;
                        int j = 0;
                        int p = 0;
                        k = 0;
                        int h = 0;
                        GMapOverlay routes = new GMapOverlay("routes");
                        //List<PointLatLng> pointsA = new List<PointLatLng>();
                        //List<PointLatLng> pointsB = new List<PointLatLng>();
                        pointsA.Clear();
                        pointsB.Clear();
                        pointsTotSel.Clear();
                        selectedTimes.Clear();
                        pointsIni.Clear();
                        selectedMSG.Clear();
                        trackMFL.Clear();
                        trackMFLX.Clear();
                        trackMFLY.Clear();

                        for (int i = 0; i < tam; i++)
                        {

                            if (dataItems[i].TrackNumber == chosenID)
                            {
                                if (dataItems[i].TimeSeconds <= SavedTimeDouble[newTimeBegin[timeBar.Value] + newTimeNumber[timeBar.Value] - 1])
                                {
                                    pointsA.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    pointsTotSel.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    selectedTimes.Add(itemTimeLap[i]);
                                    if (dataItems[i].MFL != "")
                                    {
                                        trackMFL.Add(Convert.ToDouble(dataItems[i].MFL));
                                        k++;
                                    }
                                    selectedMSG.Add(i);
                                    j++;
                                }
                                else
                                {
                                    pointsB.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    pointsTotSel.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    selectedTimes.Add(itemTimeLap[i]);
                                    if (dataItems[i].MFL != "")
                                    {
                                        trackMFL.Add(Convert.ToDouble(dataItems[i].MFL));
                                        h++;
                                    }
                                    selectedMSG.Add(i);
                                    p++;
                                }
                            }
                        }

                        if (k + h > 0)
                        {
                            Double factor;
                            if (trackMFL.Max() > 1)
                            {
                                factor = trackMFL.Max();
                            }
                            else
                            {
                                factor = 1;
                            }

                            foreach (var (MFL, indexd) in trackMFL.Select((value, i) => (value, i)))
                            {

                                trackMFLY.Add(Convert.ToInt32(100 - (trackMFL[indexd] / factor * 90 + 5)));
                                Double xPOS = (Convert.ToDouble(indexd) / trackMFL.Count) * 250 + 30;
                                trackMFLX.Add(Convert.ToInt32(xPOS));
                            }
                        }
                        //panel2.Visible = true;
                        planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                        minFL.Text = trackMFL.Min().ToString() + " FL";
                        maxFL.Text = trackMFL.Max().ToString() + " FL";
                        minFL.Visible = true;
                        maxFL.Visible = true;
                        planoZ.Refresh();

                        Live.Visible = true;
                        btnLive.Visible = true;
                        //btnLive2.Visible = true;
                        btnLive.BackColor = Color.Gray;
                        btnLive2.Location = new System.Drawing.Point(268, 235);
                        btnLive2.BackColor = Color.Gray;
                        liveVert = false;



                        selectedMSGint = selectedMSG.Count - 1 - p;

                        pnlPlaneInfo.Visible = true;
                        pnlDiv1.Visible = true;
                        pnlDiv2.Visible = true;
                        pnlDiv3.Visible = true;
                        idValue.Text = SavedID[selectedMSG[selectedMSG.Count - 1 - p]];
                        trackValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].TrackNumber;
                        AddressValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].ADR;
                        ModeValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Mode3AReply;
                        lonValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].LonWGS84str + "º";
                        LatValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].LatWGS84str + "º";
                        infoPlaneLat.Visible = true;
                        infoPlaneLon.Visible = true;
                        infoPlaneID.Visible = true;
                        infoPlaneTN.Visible = true;
                        infoPlaneMode3A.Visible = true;
                        infoPlaneTA.Visible = true;
                        LatValue.Visible = true;
                        lonValue.Visible = true;
                        ModeValue.Visible = true;
                        trackValue.Visible = true;
                        idValue.Visible = true;
                        AddressValue.Visible = true;
                        XValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].X + " m";
                        YValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Y + " m";
                        VxValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Vx + " m/s";
                        VyValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Vy + " m/s";
                        AxValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Ax + " m/s^2";
                        AyValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Ay + " m/s^2";
                        infoPlaneX.Visible = true;
                        infoPlaneY.Visible = true;
                        infoPlaneVx.Visible = true;
                        infoPlaneVy.Visible = true;
                        infoPlaneAx.Visible = true;
                        infoPlaneAy.Visible = true;
                        XValue.Visible = true;
                        YValue.Visible = true;
                        VxValue.Visible = true;
                        VyValue.Visible = true;
                        AxValue.Visible = true;
                        AyValue.Visible = true;
                        planoZ.Visible = true;
                        MHGValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].MHG + " º";
                        MFLValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].MFL + " FL";
                        OAValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].DepartureAirport;
                        DAValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].DestinationAirport;
                        TimeValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].TimeOfTrackInfo;
                        MSGValue.Text = selectedMSG[selectedMSG.Count - 1 - p].ToString();
                        infoPlaneMHG.Visible = true;
                        infoPlaneMFL.Visible = true;
                        infoPlaneOA.Visible = true;
                        infoPlaneDA.Visible = true;
                        infoPlaneTime.Visible = true;
                        infoPlaneNM.Visible = true;
                        MHGValue.Visible = true;
                        MFLValue.Visible = true;
                        OAValue.Visible = true;
                        DAValue.Visible = true;
                        TimeValue.Visible = true;
                        MSGValue.Visible = true;

                        selectedRouteInitimeBar = selectedTimes[0];
                        selectedRouteFintimeBar = selectedTimes[selectedTimes.Count - 1];
                        //lblTitle.Text = selectedRouteFintimeBar.ToString();
                        //lblTitle.Text = selectedRouteFintimeBar.ToString() + selectedRouteInitimeBar.ToString();
                        //pointsB.Insert(0, pointsA[pointsA.Count - 1]);
                        if (j > 1)
                        {

                            GMapRoute route = new GMapRoute(pointsA, "Routes");
                            route.Stroke = new Pen(Color.Orange, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                        }
                        if (p > 1)
                        {

                            GMapRoute route = new GMapRoute(pointsB, "Routes");
                            route.Stroke = new Pen(Color.Gray, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                        }
                        if (j > 0)
                        {
                            gMap.Position = pointsA[j - 1];
                            Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG.Count - 1 - p]);
                            GMapMarker marker = new GMarkerGoogle(pointsA[j - 1], plane);
                            // Agrega el marker al overlay "markers"
                            markers.Markers.Add(marker);
                            // Agrega el overlay "markers" al mapa "map"
                            gMap.Overlays.Add(markers);
                        }
                        if ((j == 0) && (p == 0))
                        {
                            MessageBox.Show("no point");
                        }
                    }
                    else if (RoutesMode3AOn == true)
                    {
                        timer.Stop();
                        selectedRoute = true;
                        markers.Markers.Clear();
                        gMap.Overlays.Clear();
                        string chosenID = listBoxID.SelectedItem.ToString();
                        gMap.MinZoom = 5;
                        gMap.MaxZoom = 100;
                        gMap.Zoom = 8;
                        int j = 0;
                        int p = 0;
                        k = 0;
                        int h = 0;
                        GMapOverlay routes = new GMapOverlay("routes");
                        //List<PointLatLng> pointsA = new List<PointLatLng>();
                        //List<PointLatLng> pointsB = new List<PointLatLng>();
                        pointsA.Clear();
                        pointsB.Clear();
                        pointsTotSel.Clear();
                        pointsIni.Clear();
                        selectedTimes.Clear();
                        selectedMSG.Clear();
                        trackMFL.Clear();
                        trackMFLX.Clear();
                        trackMFLY.Clear();

                        for (int i = 0; i < tam; i++)
                        {

                            if (dataItems[i].Mode3AReply == chosenID)
                            {
                                if (dataItems[i].TimeSeconds <= SavedTimeDouble[newTimeBegin[timeBar.Value] + newTimeNumber[timeBar.Value] - 1])
                                {
                                    pointsA.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    pointsTotSel.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    selectedTimes.Add(itemTimeLap[i]);
                                    if (dataItems[i].MFL != "")
                                    {
                                        trackMFL.Add(Convert.ToDouble(dataItems[i].MFL));
                                        k++;
                                    }
                                    selectedMSG.Add(i);
                                    j++;
                                }
                                else
                                {
                                    pointsB.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    pointsTotSel.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                                    selectedTimes.Add(itemTimeLap[i]);
                                    if (dataItems[i].MFL != "")
                                    {
                                        trackMFL.Add(Convert.ToDouble(dataItems[i].MFL));
                                        h++;
                                    }
                                    selectedMSG.Add(i);
                                    p++;
                                }
                            }
                        }


                        if (k + h > 0)
                        {
                            Double factor;
                            if (trackMFL.Max() > 1)
                            {
                                factor = trackMFL.Max();
                            }
                            else
                            {
                                factor = 1;
                            }

                            foreach (var (MFL, indexd) in trackMFL.Select((value, i) => (value, i)))
                            {

                                trackMFLY.Add(Convert.ToInt32(100 - (trackMFL[indexd] / factor * 90 + 5)));
                                Double xPOS = (Convert.ToDouble(indexd) / trackMFL.Count) * 250 + 30;
                                trackMFLX.Add(Convert.ToInt32(xPOS));
                            }
                        }
                        //panel2.Visible = true;
                        planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                        minFL.Text = trackMFL.Min().ToString() + " FL";
                        maxFL.Text = trackMFL.Max().ToString() + " FL";
                        minFL.Visible = true;
                        maxFL.Visible = true;
                        planoZ.Refresh();

                        Live.Visible = true;
                        btnLive.Visible = true;
                        //btnLive2.Visible = true;
                        btnLive.BackColor = Color.Gray;
                        btnLive2.Location = new System.Drawing.Point(268, 235);
                        btnLive2.BackColor = Color.Gray;
                        liveVert = false;


                        selectedMSGint = selectedMSG.Count - 1 - p;

                        pnlPlaneInfo.Visible = true;
                        pnlDiv1.Visible = true;
                        pnlDiv2.Visible = true;
                        pnlDiv3.Visible = true;
                        idValue.Text = SavedID[selectedMSG[selectedMSG.Count - 1 - p]];
                        trackValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].TrackNumber;
                        AddressValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].ADR;
                        ModeValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Mode3AReply;
                        lonValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].LonWGS84str + "º";
                        LatValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].LatWGS84str + "º";
                        infoPlaneLat.Visible = true;
                        infoPlaneLon.Visible = true;
                        infoPlaneID.Visible = true;
                        infoPlaneTN.Visible = true;
                        infoPlaneMode3A.Visible = true;
                        infoPlaneTA.Visible = true;
                        LatValue.Visible = true;
                        lonValue.Visible = true;
                        ModeValue.Visible = true;
                        trackValue.Visible = true;
                        idValue.Visible = true;
                        AddressValue.Visible = true;
                        XValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].X + " m";
                        YValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Y + " m";
                        VxValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Vx + " m/s";
                        VyValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Vy + " m/s";
                        AxValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Ax + " m/s^2";
                        AyValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].Ay + " m/s^2";
                        infoPlaneX.Visible = true;
                        infoPlaneY.Visible = true;
                        infoPlaneVx.Visible = true;
                        infoPlaneVy.Visible = true;
                        infoPlaneAx.Visible = true;
                        infoPlaneAy.Visible = true;
                        XValue.Visible = true;
                        YValue.Visible = true;
                        VxValue.Visible = true;
                        VyValue.Visible = true;
                        AxValue.Visible = true;
                        AyValue.Visible = true;
                        planoZ.Visible = true;
                        MHGValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].MHG + " º";
                        MFLValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].MFL + " FL";
                        OAValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].DepartureAirport;
                        DAValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].DestinationAirport;
                        TimeValue.Text = dataItems[selectedMSG[selectedMSG.Count - 1 - p]].TimeOfTrackInfo;
                        MSGValue.Text = selectedMSG[selectedMSG.Count - 1 - p].ToString();
                        infoPlaneMHG.Visible = true;
                        infoPlaneMFL.Visible = true;
                        infoPlaneOA.Visible = true;
                        infoPlaneDA.Visible = true;
                        infoPlaneTime.Visible = true;
                        infoPlaneNM.Visible = true;
                        MHGValue.Visible = true;
                        MFLValue.Visible = true;
                        OAValue.Visible = true;
                        DAValue.Visible = true;
                        TimeValue.Visible = true;
                        MSGValue.Visible = true;

                        selectedRouteInitimeBar = selectedTimes[0];
                        selectedRouteFintimeBar = selectedTimes[selectedTimes.Count - 1];
                        //lblTitle.Text = selectedRouteFintimeBar.ToString();
                        //lblTitle.Text = selectedRouteFintimeBar.ToString() + selectedRouteInitimeBar.ToString();
                        //pointsB.Insert(0, pointsA[pointsA.Count - 1]);
                        if (j > 1)
                        {

                            GMapRoute route = new GMapRoute(pointsA, "Routes");
                            route.Stroke = new Pen(Color.Orange, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                        }
                        if (p > 1)
                        {

                            GMapRoute route = new GMapRoute(pointsB, "Routes");
                            route.Stroke = new Pen(Color.Gray, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                        }
                        if (j > 0)
                        {
                            gMap.Position = pointsA[j - 1];
                            Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG.Count - 1 - p]);
                            GMapMarker marker = new GMarkerGoogle(pointsA[j - 1], plane);
                            // Agrega el marker al overlay "markers"
                            markers.Markers.Add(marker);
                            // Agrega el overlay "markers" al mapa "map"
                            gMap.Overlays.Add(markers);
                        }
                        if ((j == 0) && (p == 0))
                        {
                            MessageBox.Show("no point");
                        }
                    }
                }
            }
        }
        private void timeInitial_Scroll(object sender, EventArgs e)
        {
            dataGridS.Rows.Clear();
            dataGridS.Rows.Add(tam);
            if (timeInitial.Value == 0)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = dataItems[0].TimeSeconds;
            }
            else if (timeInitial.Value == 1)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) / 9 + dataItems[0].TimeSeconds);

            }
            else if (timeInitial.Value == 2)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 2 / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 2 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeInitial.Value == 3)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 3 / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 3 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeInitial.Value == 4)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 4 / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 4 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeInitial.Value == 5)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 5 / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 5 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeInitial.Value == 6)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 6 / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 6 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeInitial.Value == 7)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 7 / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 7 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeInitial.Value == 8)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 8 / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 8 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeInitial.Value == 9)
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(dataItems[tam - 1].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeI = dataItems[tam - 1].TimeSeconds;

            }
            int countdataGridS = 0;

            if (lblTitle.Text == "Search by")
            {
                if (timeFinal.Value - timeInitial.Value > interval)
                {
                    infoTable.Visible = true;
                    infoTable.Text = "Select a smaller interval, or change it in Settings";
                }
                else
                {
                    infoTable.Visible = false;
                    for (int j = timeInitial.Value * tam / 9; j < timeFinal.Value * tam / 9; j++)
                    {

                        if ((dataItems[j].TimeSeconds >= chosenTimeI) && ((dataItems[j].TimeSeconds <= chosenTimeF)))
                        {
                            int index2 = j + 1;
                            dataGridS[0, countdataGridS].Value = index2;
                            dataGridS[1, countdataGridS].Value = countdataGridS + 1;
                            dataGridS[2, countdataGridS].Value = dataGrid[1, j].Value;
                            dataGridS[4, countdataGridS].Value = dataItems[j].TimeOfTrackInfo;
                            dataGridS[3, countdataGridS].Value = dataItems[j].TrackNumber;
                            dataGridS[5, countdataGridS].Value = dataItems[j].LatWGS84str + ", " + dataItems[j].LonWGS84str;
                            dataGridS[6, countdataGridS].Value = dataItems[j].X + ", " + dataItems[j].Y;
                            dataGridS[7, countdataGridS].Value = dataItems[j].Vx + ", " + dataItems[j].Vy;
                            dataGridS[8, countdataGridS].Value = dataItems[j].ADR;
                            dataGridS[9, countdataGridS].Value = dataItems[j].Mode3AReply;
                            dataGridS[10, countdataGridS].Value = dataItems[j].DepartureAirport;
                            dataGridS[11, countdataGridS].Value = dataItems[j].DestinationAirport;

                            countdataGridS++;
                        }
                    }
                }
            }
            else
            {
                if (timeFinal.Value - timeInitial.Value > interval)
                {
                    infoTable.Visible = true;
                    infoTable.Text = "Select a smaller interval or change it in Settings";
                }
                else
                {
                    infoTable.Visible = false;
                    List<string> distinctID1 = SavedTrack.Distinct().ToList();
                    //List<string> distinctID1 = SortByLength(distinctIDT);
                    distinctID1.Sort();
                    uniqueTrackNumber = distinctID1;
                    // Create map overlay
                    this.pnlFormLoader.Controls.Clear();
                    this.pnlFormLoader.Controls.Add(gMap);
                    this.gMap.Controls.Add(btnClearTraces);

                    gMap.Overlays.Clear();
                    gMap.Visible = true;
                    pnlFormLoader.Visible = true;
                    btnClearTraces.Visible = true;
                    // map settings
                    gMap.ShowCenter = true;
                    gMap.DragButton = MouseButtons.Left;
                    gMap.MinZoom = 5;
                    gMap.MaxZoom = 100;
                    gMap.Zoom = 8;

                    if (flagTrackNumber != 0)
                    {

                        foreach (var (uniqTrack, ind) in uniqueTrackNumber.Select((value, i) => (value, i)))
                        {
                            GMapOverlay routes = new GMapOverlay("routes");
                            List<PointLatLng> points = new List<PointLatLng>();
                            points.Clear();
                            for (int j = timeInitial.Value * tam / 9; j < timeFinal.Value * tam / 9; j++)
                            {
                                if ((dataItems[j].TimeSeconds >= chosenTimeI) && (dataItems[j].TimeSeconds <= chosenTimeF) && (dataItems[j].TrackNumber == uniqTrack))
                                {
                                    points.Add(new PointLatLng(Convert.ToDouble(dataItems[j].LatWGS84), Convert.ToDouble(dataItems[j].LonWGS84)));
                                }
                            }
                            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            GMapRoute route = new GMapRoute(points, "Routes");
                            route.Stroke = new Pen(randomColor, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                            if (points.Count > 0)
                            {
                                gMap.Position = points[0];
                                GMapMarker marker = new GMarkerGoogle(points[points.Count - 1], planeMarker);
                                GMapMarker marker2 = new GMarkerGoogle(points[0], planeMarker);
                                // Agrega el marker al overlay "markers"
                                markers.Markers.Add(marker);
                                markers.Markers.Add(marker2);
                                // Agrega el overlay "markers" al mapa "map"
                                gMap.Overlays.Add(markers);
                            }
                        }
                    }
                }
            }

        }
        private void timeFinal_Scroll(object sender, EventArgs e)
        {
            dataGridS.Rows.Clear();
            dataGridS.Rows.Add(tam);
            if (timeFinal.Value == 0)
            {
                //time = Convert.ToInt32(dataItems[tam - 1].TimeSeconds).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(dataItems[0].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = dataItems[0].TimeSeconds;
            }
            else if (timeFinal.Value == 1)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) / 9) + dataItems[0].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 1 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeFinal.Value == 2)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) * 2 / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 2 / 9) + dataItems[0].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 2 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeFinal.Value == 3)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) * 3 / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 3 / 9) + dataItems[0].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 3 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeFinal.Value == 4)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) * 3 / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 4 / 9) + dataItems[0].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 4 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeFinal.Value == 5)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) * 3 / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 5 / 9) + dataItems[0].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 5 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeFinal.Value == 6)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) * 3 / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 6 / 9) + dataItems[0].TimeSeconds));
                lblTimeInitialValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 6 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeFinal.Value == 7)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) * 3 / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 7 / 9) + dataItems[0].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 7 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeFinal.Value == 8)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) * 3 / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 8 / 9) + dataItems[0].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = Convert.ToDouble((dataItems[tam - 1].TimeSeconds - dataItems[0].TimeSeconds) * 8 / 9 + dataItems[0].TimeSeconds);
            }
            else if (timeFinal.Value == 9)
            {
                //lblTimeInitialValue.Text = Convert.ToInt32((dataItems[tam - 1].TimeSeconds - dataItems[tam - 1].TimeSeconds) * 3 / 10).ToString();
                System.TimeSpan time = System.TimeSpan.FromSeconds(Convert.ToDouble(dataItems[tam - 1].TimeSeconds));
                lblFinalTimeValue.Text = time.ToString(@"hh\:mm\:ss\.fff");

                chosenTimeF = dataItems[tam - 1].TimeSeconds;
            }
            int countdataGridS = 0;
            if (lblTitle.Text == "Search by")
            {
                if (timeFinal.Value - timeInitial.Value > interval)
                {
                    infoTable.Visible = true;
                    infoTable.Text = "Select a smaller interval, or change it in Settings";
                }
                else
                {
                    for (int j = 0; j < tam; j++)
                    {
                        if ((dataItems[j].TimeSeconds >= chosenTimeI) && ((dataItems[j].TimeSeconds <= chosenTimeF)))
                        {
                            int index2 = j + 1;

                            dataGridS[0, countdataGridS].Value = index2;
                            dataGridS[1, countdataGridS].Value = countdataGridS + 1;
                            dataGridS[2, countdataGridS].Value = dataGrid[1, j].Value;
                            dataGridS[4, countdataGridS].Value = dataItems[j].TimeOfTrackInfo;
                            dataGridS[3, countdataGridS].Value = dataItems[j].TrackNumber;
                            dataGridS[5, countdataGridS].Value = dataItems[j].LatWGS84str + ", " + dataItems[j].LonWGS84str;
                            dataGridS[6, countdataGridS].Value = dataItems[j].X + ", " + dataItems[j].Y;
                            dataGridS[7, countdataGridS].Value = dataItems[j].Vx + ", " + dataItems[j].Vy;
                            dataGridS[8, countdataGridS].Value = dataItems[j].ADR;
                            dataGridS[9, countdataGridS].Value = dataItems[j].Mode3AReply;
                            dataGridS[10, countdataGridS].Value = dataItems[j].DepartureAirport;
                            dataGridS[11, countdataGridS].Value = dataItems[j].DestinationAirport;

                            countdataGridS++;
                        }
                    }
                }
            }
            else
            {
                if (timeFinal.Value - timeInitial.Value > interval)
                {
                    infoTable.Visible = true;
                    infoTable.Text = "Select a smaller interval, or change it in Settings";
                }
                else
                {
                    infoTable.Visible = false;
                    List<string> distinctID1 = SavedTrack.Distinct().ToList();
                    //List<string> distinctID1 = SortByLength(distinctIDT);
                    distinctID1.Sort();
                    uniqueTrackNumber = distinctID1;
                    // Create map overlay
                    this.pnlFormLoader.Controls.Clear();
                    this.pnlFormLoader.Controls.Add(gMap);
                    this.gMap.Controls.Add(btnClearTraces);

                    gMap.Overlays.Clear();
                    gMap.Visible = true;
                    btnClearTraces.Visible = true;
                    // map settings
                    gMap.ShowCenter = true;
                    gMap.DragButton = MouseButtons.Left;
                    gMap.MinZoom = 5;
                    gMap.MaxZoom = 100;
                    gMap.Zoom = 8;

                    if (flagTrackNumber != 0)
                    {
                        foreach (var (uniqTrack, ind) in uniqueTrackNumber.Select((value, i) => (value, i)))
                        {
                            GMapOverlay routes = new GMapOverlay("routes");
                            List<PointLatLng> points = new List<PointLatLng>();
                            points.Clear();
                            for (int j = 0; j < tam; j++)
                            {
                                if ((dataItems[j].TimeSeconds >= chosenTimeI) && (dataItems[j].TimeSeconds <= chosenTimeF) && (dataItems[j].TrackNumber == uniqTrack))
                                {
                                    points.Add(new PointLatLng(Convert.ToDouble(dataItems[j].LatWGS84), Convert.ToDouble(dataItems[j].LonWGS84)));
                                }
                            }
                            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            GMapRoute route = new GMapRoute(points, "Routes");
                            route.Stroke = new Pen(randomColor, 3);
                            routes.Routes.Add(route);
                            gMap.Overlays.Add(routes);
                            if (points.Count > 0)
                            {
                                gMap.Position = points[0];
                                GMapMarker marker = new GMarkerGoogle(points[points.Count - 1], planeMarker);
                                GMapMarker marker2 = new GMarkerGoogle(points[points.Count - 1], planeMarker);
                                // Agrega el marker al overlay "markers"
                                markers.Markers.Add(marker);
                                markers.Markers.Add(marker2);
                                // Agrega el overlay "markers" al mapa "map"
                                gMap.Overlays.Add(markers);
                            }
                        }
                    }
                }
            }
        }
        private void btnClearTraces_Click(object sender, EventArgs e)
        {
            gMap.Overlays.Clear();
            markers.Markers.Clear();
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            Double lat = 38.3025882;
            Double lon = -5.2671378;
            points.Add(new PointLatLng(lat, lon));
            gMap.Position = points[0];
            timer.Stop();
        }
        private void btnBackMap_Click(object sender, EventArgs e)
        {
            btnSearchBy.Visible = true;
            btnTimeConsole.Visible = true;
            btnPlay.Visible = false;
            btnPause.Visible = false;
            btnBack.Visible = false;
            btnFirst.Visible = false;
            btnLast.Visible = false;
            btnForward.Visible = false;
            btnRoutesID.Visible = false;
            btnRoutesMode3A.Visible = false;
            btnRoutesTrack.Visible = false;
            listBoxID.Visible = false;
            listSearch.Visible = false;
            btnBackMap.Visible = false;
            timeBar.Visible = false;
            timeFinal.Visible = false;
            timeInitial.Visible = false;
            lblTimeInitial.Visible = false;
            lblTimeInitialValue.Visible = false;
            lblFinalTime.Visible = false;
            lblFinalTimeValue.Visible = false;
            pnlMedia.Visible = false;
            lblBarFinal.Visible = false;
            lblBarInitial.Visible = false;
            lblcurrentTime.Visible = false;
            listBoxID.Items.Clear();
            selectedRoute = false;
            gMap.Overlays.Clear();
            markers.Markers.Clear();
            RoutesIDOn = false;
            RoutesTrackOn = false;
            RoutesMode3AOn = false;
            btnRoutesID.BackColor = Color.FromArgb(24, 30, 54);
            btnRoutesID.ForeColor = System.Drawing.Color.DarkGray;
            btnRoutesTrack.BackColor = Color.FromArgb(24, 30, 54);
            btnRoutesTrack.ForeColor = System.Drawing.Color.DarkGray;
            btnRoutesMode3A.BackColor = Color.FromArgb(24, 30, 54);
            btnRoutesMode3A.ForeColor = System.Drawing.Color.DarkGray;
            pnlPlaneInfo.Visible = false;
            infoTable.Visible = false;
            pnlPlaneInfo.Visible = false;
        }
        private void btnTimeConsole_Click(object sender, EventArgs e)
        {
            anticlockwise = false;
            shot = false;
            btnSearchBy.Visible = false;
            btnTimeConsole.Visible = false;
            pnlMedia.Visible = true;
            btnPlay.Visible = true;
            btnPause.Visible = true;
            btnBack.Visible = true;
            btnFirst.Visible = true;
            btnLast.Visible = true;
            lblcurrentTime.Visible = true;
            btnForward.Visible = true;
            btnRoutesID.Visible = true;
            btnRoutesMode3A.Visible = true;
            btnRoutesTrack.Visible = true;
            btnBackMap.Visible = true;
            timeBar.Visible = true;
            lblBarInitial.Visible = true;
            lblBarFinal.Visible = true;
            RoutesIDOn = false;
            RoutesTrackOn = false;
            RoutesMode3AOn = false;
            selectedRoute = false;
            infoTable.Visible = true;
            infoTable.Text = "Activate Live View to see the elevation profile" + Environment.NewLine + "Caution: this may slow down the program"; ;
            if (dataItems[0].TimeOfTrackInfo != dataItems[dataItems.Count - 1].TimeOfTrackInfo)
            {
                List<string> distinctID1 = SavedTimestr.Distinct().ToList();
                distinctID1.Sort();
                uniqueTimestr = distinctID1;

                //string timeprev = "0";
                Double timePrev = dataItems[0].TimeSeconds;
                newTimeNumber.Clear();
                newTimeBegin.Clear();
                itemTimeLap.Clear();
                points.Clear();
                uniqueTimeLap.Clear();
                MHGPlane.Clear();

                for (int j = 0; j < tam; j++) //uniqueTimestr.Count
                {
                    newTimeBegin.Add(0);
                    newTimeNumber.Add(0);
                    itemTimeLap.Add(0);
                }

                int counterUniqueTime = 0;
                if (dataItems.Count > 30000) { timeBetweenMsg = 2; }
                else { timeBetweenMsg = 0.5; }

                for (int i = 0; i < tam; i++)
                {
                    //string time = dataItems[i].TimeOfTrackInfo;

                    points.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                    if (dataItems[i].MHG != "")
                    {
                        MHGPlane.Add(float.Parse(dataItems[i].MHG));
                    }
                    else
                    {
                        MHGPlane.Add(0f);
                    }
                    if (i == 0)
                    {
                        newTimeBegin[counterUniqueTime] = 0;
                        newTimeNumber[counterUniqueTime]++;
                        if (dataBlocks.Count < 30000) { uniqueTimeLap.Add(SavedTimestr[0]); }
                        itemTimeLap[i] = counterUniqueTime;
                    }
                    else if (dataItems[i].TimeSeconds - timePrev <= timeBetweenMsg)
                    {
                        newTimeNumber[counterUniqueTime]++;
                        itemTimeLap[i] = counterUniqueTime;
                    }
                    else
                    {
                        counterUniqueTime++;
                        newTimeBegin[counterUniqueTime] = i;
                        newTimeNumber[counterUniqueTime] = 1;
                        if (dataBlocks.Count < 30000) { uniqueTimeLap.Add(SavedTimestr[i]); }
                        else { uniqueTimeLap.Add(SavedTimestr[i - 1]); }
                        itemTimeLap[i] = counterUniqueTime;
                    }
                    timePrev = dataItems[i].TimeSeconds;
                }
                if (dataBlocks.Count >= 30000) { uniqueTimeLap.Add(SavedTimestr[tam - 1]); }
                
                timeBar.Minimum = 0;
                timeBar.Maximum = uniqueTimeLap.Count - 1;
                timeBar.Value = 0;
                timeBar.TickFrequency = 1;
                lblBarFinal.Text = uniqueTimeLap[uniqueTimeLap.Count - 1];
                lblBarInitial.Text = uniqueTimeLap[0];
                lblcurrentTime.Text = uniqueTimeLap[0];
                gMap.Position = points[0];
                gMap.Zoom = 10;
                pointsIni.Clear();
                if (dataItems.Count > 1000)
                {
                    markers.Markers.Clear();
                    for (int i = 0; i < newTimeNumber[timeBar.Value]; i++)
                    {
                        pointsIni.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                        Bitmap plane = RotateImage(planeMarker, MHGPlane[i]);
                        GMapMarker marker = new GMarkerGoogle(pointsIni[i], plane);
                        // Agrega el marker al overlay "markers"
                        markers.Markers.Add(marker);
                        // Agrega el overlay "markers" al mapa "map"
                        gMap.Overlays.Add(markers);
                    }
                }
            }
            //else if (dataItems.Count < 1000)
            //{
            //    points.Clear();
            //    markers.Markers.Clear();
            //    lblcurrentTime.Text = uniqueTimeLap[0];
            //    lblBarFinal.Text = uniqueTimeLap[0];
            //    lblBarInitial.Text = uniqueTimeLap[0];
            //    for (int i = 0; i < tam; i++)
            //    {
            //        if (dataItems[0].Lat)
            //        //string time = dataItems[i].TimeOfTrackInfo;
            //        points.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
            //        GMapMarker marker = new GMarkerGoogle(points[i], planeMarker);
            //        // Agrega el marker al overlay "markers"
            //        markers.Markers.Add(marker);
            //        // Agrega el overlay "markers" al mapa "map"
            //        gMap.Overlays.Add(markers);
            //    }

            //}

        }
        private void planoZ_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;


            System.Drawing.Point[] points = new System.Drawing.Point[trackMFL.Count];
            if (liveVert == true)
            {
                SolidBrush OrangeBrush = new SolidBrush(Color.Orange);
                for (int i = 0; i < trackMFL.Count; i++)
                {
                    points[i] = new System.Drawing.Point(trackMFLX[i], trackMFLY[i]);
                    //g.DrawEllipse(Pens.Gray, new Rectangle(trackMFLX[i], trackMFLY[i], 2, 2));
                    if (i < k)
                    {
                        g.DrawEllipse(Pens.Orange, new Rectangle(trackMFLX[i], trackMFLY[i], 5, 5));
                    }
                    else
                    {
                        g.DrawEllipse(Pens.Gray, new Rectangle(trackMFLX[i], trackMFLY[i], 5, 5));
                    }
                    if (i == k - 1)
                    {
                        g.FillEllipse(OrangeBrush, new Rectangle(trackMFLX[i], trackMFLY[i], 7, 7));
                    }
                }
            }
            else
            {

            }
            //Brush brush = new SolidBrush(Color.DarkGreen);

            //g.FillPolygon(brush, points);
        }
        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new System.Drawing.Point(0, 0));
            }
            return returnBitmap;
        }
        private void btnLive_Click(object sender, EventArgs e)
        {
            if (btnLive.BackColor == Color.Orange)
            {
                btnLive.BackColor = Color.Gray;
                btnLive2.Location = new System.Drawing.Point(268, 235);
                btnLive2.BackColor = Color.Gray;
                liveVert = false;
                planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                planoZ.Refresh();
            }
            else if (btnLive.BackColor == Color.Gray)
            {
                btnLive.BackColor = Color.Orange;
                btnLive2.Location = new System.Drawing.Point(287, 235);
                btnLive2.BackColor = Color.Orange;
                liveVert = true;
                planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                planoZ.Refresh();
            }

        }


        //Console Time
        private void btnRoutesID_Click(object sender, EventArgs e)
        {
            pnlPlaneInfo.Visible = true;
            lblSpeed.Visible = false;
            if (RoutesIDOn == false)
            {
                RoutesIDOn = true;
                RoutesTrackOn = false;
                RoutesMode3AOn = false;
                pnlBackFast.Visible = false;
                pnlForFast.Visible = false;
                btnRoutesID.BackColor = Color.FromArgb(46, 51, 73);
                btnRoutesTrack.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesMode3A.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesID.ForeColor = System.Drawing.Color.Orange;
                btnRoutesTrack.ForeColor = System.Drawing.Color.DarkGray;
                btnRoutesMode3A.ForeColor = System.Drawing.Color.DarkGray;
                //generate routes per ID
                if (flagID != 0)
                {
                    List<string> distinctID1 = SavedID.Distinct().ToList();
                    distinctID1.Sort();
                    uniqueID = distinctID1;

                    listBoxID.Visible = true;

                    lblcurrentTime.Text = uniqueTimeLap[0];


                    if ((dataItems[0].ID == null) && (dataItems[0].TargetID == null) && (dataItems[0].Callsign == null))
                    {
                        listBoxID.Items.Add("No Data Provided");
                    }
                    else
                    {
                        listBoxID.Items.Clear();
                        listBoxID.Items.Add("IDs...");
                        if (flagID != 0)
                        {
                            for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                            {
                                listBoxID.Items.Add(SavedID[newTimeBegin[timeBar.Value] + h]);
                            }
                        }
                        else
                        {
                            listBoxID.Items.Add("No Data Provided");
                        }

                    }
                }

            }
            else
            {
                pnlBackFast.Visible = false;
                pnlForFast.Visible = false;
                RoutesIDOn = false;
                selectedRoute = false;
                btnRoutesID.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesID.ForeColor = System.Drawing.Color.DarkGray;
                listBoxID.Items.Clear();
                listBoxID.Visible = false;
                gMap.Overlays.Clear();
                markers.Markers.Clear();
            }

        }
        private void btnRoutesTrack_Click(object sender, EventArgs e)
        {
            pnlBackFast.Visible = false;
            pnlForFast.Visible = false;
            pnlPlaneInfo.Visible = true;
            lblSpeed.Visible = false;
            if (RoutesTrackOn == false)
            {

                RoutesTrackOn = true;
                RoutesIDOn = false;
                RoutesMode3AOn = false;
                btnRoutesTrack.BackColor = Color.FromArgb(46, 51, 73);
                btnRoutesID.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesMode3A.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesTrack.ForeColor = System.Drawing.Color.Orange;
                btnRoutesID.ForeColor = System.Drawing.Color.DarkGray;
                btnRoutesMode3A.ForeColor = System.Drawing.Color.DarkGray;

                if (flagID != 0)
                {
                    //generate routes per Track
                    List<string> distinctID1 = SavedTrack.Distinct().ToList();
                    distinctID1.Sort();
                    uniqueTrackNumber = distinctID1;

                    listBoxID.Visible = true;

                    lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];


                    listBoxID.Items.Clear();
                    listBoxID.Items.Add("Track Numbers...");
                    if (flagTrackNumber != 0)
                    {
                        for (int h = 0; h < newTimeNumber[0]; h++)
                        {
                            listBoxID.Items.Add(SavedTrack[h]);
                        }
                    }
                    else
                    {
                        listBoxID.Items.Add("No Data Provided");
                    }
                }

            }


            else
            {
                RoutesTrackOn = false;
                btnRoutesTrack.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesTrack.ForeColor = System.Drawing.Color.DarkGray;
                listBox.Items.Clear();
                listBox.Visible = false;
            }
        }
        private void btnRoutesMode3A_Click(object sender, EventArgs e)
        {
            pnlBackFast.Visible = false;
            pnlForFast.Visible = false;
            pnlPlaneInfo.Visible = true;
            lblSpeed.Visible = false;
            if (RoutesMode3AOn == false)
            {
                RoutesMode3AOn = true;
                RoutesIDOn = false;
                RoutesTrackOn = false;
                btnRoutesMode3A.BackColor = Color.FromArgb(46, 51, 73);
                btnRoutesTrack.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesID.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesMode3A.ForeColor = System.Drawing.Color.Orange;
                btnRoutesTrack.ForeColor = System.Drawing.Color.DarkGray;
                btnRoutesID.ForeColor = System.Drawing.Color.DarkGray;

                if (flagID != 0)
                {
                    //generate routes per Track
                    List<string> distinctID1 = SavedMode3A.Distinct().ToList();
                    distinctID1.Sort();
                    uniqueMode3A = distinctID1;

                    listBoxID.Visible = true;

                    lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];


                    listBoxID.Items.Clear();
                    listBoxID.Items.Add("Mode 3/As...");
                    if (flagTrackNumber != 0)
                    {
                        for (int h = 0; h < newTimeNumber[0]; h++)
                        {
                            listBoxID.Items.Add(SavedMode3A[h]);
                        }
                    }
                    else
                    {
                        listBoxID.Items.Add("No Data Provided");
                    }
                }
            }

            else
            {
                RoutesMode3AOn = false;
                btnRoutesMode3A.BackColor = Color.FromArgb(24, 30, 54);
                btnRoutesMode3A.ForeColor = System.Drawing.Color.DarkGray;
                listBox.Items.Clear();
                listBox.Visible = false;
            }
        }
        private void timeBar_Scroll(object sender, EventArgs e)
        {
            if (uniqueTimestr.Count == 1)
            {

            }
            else
            {
                pnlBackFast.Visible = false;
                pnlForFast.Visible = false;
                lblSpeed.Visible = false;
                if (selectedRoute == false)
                {
                    lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];

                    listBoxID.Items.Clear();
                    if (RoutesIDOn == true)
                    {
                        listBoxID.Items.Add("IDs...");
                        if (flagID != 0)
                        {
                            for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                            {
                                listBoxID.Items.Add(SavedID[newTimeBegin[timeBar.Value] + h]);
                            }
                        }
                    }
                    else if (RoutesTrackOn == true)
                    {
                        listBoxID.Items.Add("Track Numbers...");
                        if (flagID != 0)
                        {
                            for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                            {
                                listBoxID.Items.Add(SavedTrack[newTimeBegin[timeBar.Value] + h]);
                            }
                        }
                    }
                    else if (RoutesMode3AOn == true)
                    {
                        listBoxID.Items.Add("Mode 3/As...");
                        if (flagID != 0)
                        {
                            for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                            {
                                listBoxID.Items.Add(SavedMode3A[newTimeBegin[timeBar.Value] + h]);
                            }
                        }
                    }


                    markers.Markers.Clear();
                    timer.Stop();
                    for (int i = 0; i < newTimeNumber[timeBar.Value]; i++)
                    {
                        Bitmap plane = RotateImage(planeMarker, MHGPlane[newTimeBegin[timeBar.Value] + i]);
                        GMapMarker marker = new GMarkerGoogle(points[newTimeBegin[timeBar.Value] + i], plane);
                        // Agrega el marker al overlay "markers"
                        markers.Markers.Add(marker);
                        // Agrega el overlay "markers" al mapa "map"
                        gMap.Overlays.Add(markers);
                    }
                }

                else
                {

                    timer.Stop();
                    pointsA.Clear();
                    pointsB.Clear();
                    lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];
                    listBoxID.Items.Clear();
                    if (RoutesIDOn == true)
                    {
                        listBoxID.Items.Add("IDs...");
                    }
                    else if (RoutesTrackOn == true)
                    {
                        listBoxID.Items.Add("Track Numbers...");
                    }
                    else if (RoutesMode3AOn == true)
                    {
                        listBoxID.Items.Add("Mode 3/As...");
                    }
                    if (pointsTotSel.Count > 3000)
                    {

                    }
                    else
                    {
                        if (flagID != 0)
                        {
                            for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                            {
                                if (RoutesIDOn == true)
                                {
                                    listBoxID.Items.Add(SavedID[newTimeBegin[timeBar.Value] + h]);
                                }
                                else if (RoutesTrackOn == true)
                                {
                                    listBoxID.Items.Add(SavedTrack[newTimeBegin[timeBar.Value] + h]);
                                }
                                else if (RoutesMode3AOn == true)
                                {
                                    listBoxID.Items.Add(SavedMode3A[newTimeBegin[timeBar.Value] + h]);
                                }
                            }
                        }
                        if (timeBar.Value < selectedRouteInitimeBar)
                        {

                        }

                        else if (timeBar.Value <= selectedRouteFintimeBar)
                        {
                            pointsA.Clear();
                            pointsB.Clear();
                            gMap.Overlays.Clear();
                            markers.Markers.Clear();
                            lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];
                            int h = 0;
                            k = 0;
                            trackMFLX.Clear();
                            trackMFLY.Clear();
                            GMapOverlay routes = new GMapOverlay("routes");
                            int p = 0;
                            foreach (var (timeSelected, indexd) in selectedTimes.Select((value, i) => (value, i)))
                            {
                                if (timeSelected == timeBar.Value)
                                {
                                    if (indexd > 0)
                                    {
                                        for (int j = 0; j < indexd + 1; j++)
                                        {
                                            pointsA.Add(pointsTotSel[j]);
                                            k++;
                                        }
                                    }
                                    else
                                    {
                                        pointsA.Add(pointsTotSel[0]);
                                        k++;
                                    }
                                    if (indexd < pointsTotSel.Count - 1)
                                    {
                                        for (int j = indexd + 1; j < pointsTotSel.Count; j++)
                                        {
                                            pointsB.Add(pointsTotSel[j]);
                                            p++;
                                            h++;
                                        }
                                    }

                                }
                            }
                            if (k + h > 0)
                            {
                                Double factor;
                                if (trackMFL.Max() > 1)
                                {
                                    factor = trackMFL.Max();
                                }
                                else
                                {
                                    factor = 1;
                                }

                                foreach (var (MFL, indexd2) in trackMFL.Select((value, i) => (value, i)))
                                {

                                    trackMFLY.Add(Convert.ToInt32(100 - (trackMFL[indexd2] / factor * 90 + 5)));
                                    Double xPOS = (Convert.ToDouble(indexd2) / trackMFL.Count) * 250 + 20;
                                    trackMFLX.Add(Convert.ToInt32(xPOS));
                                }
                            }
                            planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                            planoZ.Refresh();
                            if (pointsA.Count > 1)
                            {

                                GMapRoute route = new GMapRoute(pointsA, "Routes");
                                route.Stroke = new Pen(Color.Orange, 3);
                                routes.Routes.Add(route);
                                gMap.Overlays.Add(routes);
                            }
                            if (pointsB.Count > 1)
                            {

                                GMapRoute route = new GMapRoute(pointsB, "Routes");
                                route.Stroke = new Pen(Color.Gray, 3);
                                routes.Routes.Add(route);
                                gMap.Overlays.Add(routes);
                            }
                            if (pointsA.Count > 0)
                            {
                                gMap.Position = pointsA[pointsA.Count - 1];
                                Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG[k - 1]]);
                                GMapMarker marker = new GMarkerGoogle(pointsA[pointsA.Count - 1], plane);
                                // Agrega el marker al overlay "markers"
                                markers.Markers.Add(marker);
                                // Agrega el overlay "markers" al mapa "map"
                                gMap.Overlays.Add(markers);
                            }
                            else if (pointsA.Count == 1)
                            {
                                gMap.Position = pointsA[0];
                                Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG[k - 1]]);
                                GMapMarker marker = new GMarkerGoogle(pointsA[0], planeMarker);
                                // Agrega el marker al overlay "markers"
                                markers.Markers.Add(marker);
                                // Agrega el overlay "markers" al mapa "map"
                                gMap.Overlays.Add(markers);
                            }
                            selectedMSGint = selectedMSG.Count - p - 1;
                            lonValue.Text = dataItems[selectedMSG[selectedMSGint]].LonWGS84str + "º";
                            LatValue.Text = dataItems[selectedMSG[selectedMSGint]].LatWGS84str + "º";
                            XValue.Text = dataItems[selectedMSG[selectedMSGint]].X + " m";
                            YValue.Text = dataItems[selectedMSG[selectedMSGint]].Y + " m";
                            VxValue.Text = dataItems[selectedMSG[selectedMSGint]].Vx + " m/s";
                            VyValue.Text = dataItems[selectedMSG[selectedMSGint]].Vy + " m/s";
                            AxValue.Text = dataItems[selectedMSG[selectedMSGint]].Ax + " m/s^2";
                            AyValue.Text = dataItems[selectedMSG[selectedMSGint]].Ay + " m/s^2";
                            MHGValue.Text = dataItems[selectedMSG[selectedMSGint]].MHG + " º";
                            MFLValue.Text = dataItems[selectedMSG[selectedMSGint]].MFL + " FL";
                            TimeValue.Text = dataItems[selectedMSG[selectedMSGint]].TimeOfTrackInfo;
                            MSGValue.Text = selectedMSG[selectedMSGint].ToString();
                        }
                        else if (timeBar.Value > selectedRouteFintimeBar)
                        {
                        }
                    }

                }
            }

        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            timer.Interval = 2000;
            timer.Start();
            shot = true;
            anticlockwise = false;
            pnlBackFast.Visible = false;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x1";
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (anticlockwise == false) //forward
            {
                if (selectedRoute == false)
                {
                    if (timeBar.Value < uniqueTimeLap.Count - 1)
                    {
                        timeBar.Value++;
                        lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];
                        listBoxID.Items.Clear();
                        if (RoutesIDOn == true)
                        {
                            listBoxID.Items.Add("IDs...");
                            if (flagID != 0)
                            {
                                for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                                {
                                    listBoxID.Items.Add(SavedID[newTimeBegin[timeBar.Value] + h]);
                                }
                            }
                        }
                        else if (RoutesTrackOn == true)
                        {
                            listBoxID.Items.Add("Track Numbers...");
                            if (flagID != 0)
                            {
                                for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                                {
                                    listBoxID.Items.Add(SavedTrack[newTimeBegin[timeBar.Value] + h]);
                                }
                            }
                        }
                        else if (RoutesMode3AOn == true)
                        {
                            listBoxID.Items.Add("Mode 3/As...");
                            if (flagID != 0)
                            {
                                for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                                {
                                    listBoxID.Items.Add(SavedMode3A[newTimeBegin[timeBar.Value] + h]);
                                }
                            }
                        }

                        markers.Markers.Clear();
                        for (int i = 0; i < newTimeNumber[timeBar.Value]; i++)
                        {
                            Bitmap plane = RotateImage(planeMarker, MHGPlane[newTimeBegin[timeBar.Value] + i]);
                            GMapMarker marker = new GMarkerGoogle(points[newTimeBegin[timeBar.Value] + i], plane);
                            // Agrega el marker al overlay "markers"
                            markers.Markers.Add(marker);
                            // Agrega el overlay "markers" al mapa "map"
                            gMap.Overlays.Add(markers);

                        }
                    }
                    else
                    {
                        timer.Stop();
                    }
                }
                else
                {

                    if ((timeBar.Value < selectedRouteFintimeBar) && (timeBar.Value >= selectedRouteInitimeBar))
                    {
                        selectedMSGint++;
                        lonValue.Text = dataItems[selectedMSG[selectedMSGint]].LonWGS84str + "º";
                        LatValue.Text = dataItems[selectedMSG[selectedMSGint]].LatWGS84str + "º";
                        XValue.Text = dataItems[selectedMSG[selectedMSGint]].X + " m";
                        YValue.Text = dataItems[selectedMSG[selectedMSGint]].Y + " m";
                        VxValue.Text = dataItems[selectedMSG[selectedMSGint]].Vx + " m/s";
                        VyValue.Text = dataItems[selectedMSG[selectedMSGint]].Vy + " m/s";
                        AxValue.Text = dataItems[selectedMSG[selectedMSGint]].Ax + " m/s^2";
                        AyValue.Text = dataItems[selectedMSG[selectedMSGint]].Ay + " m/s^2";
                        MHGValue.Text = dataItems[selectedMSG[selectedMSGint]].MHG + " º";
                        MFLValue.Text = dataItems[selectedMSG[selectedMSGint]].MFL + " FL";
                        TimeValue.Text = dataItems[selectedMSG[selectedMSGint]].TimeOfTrackInfo;
                        MSGValue.Text = selectedMSG[selectedMSGint].ToString();



                        timeBar.Value++;
                        lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];

                        listBoxID.Items.Clear();
                        if (RoutesIDOn == true)
                        {
                            listBoxID.Items.Add("IDs...");
                            if (flagID != 0)
                            {
                                for (int q = 0; q < newTimeNumber[timeBar.Value]; q++)
                                {
                                    listBoxID.Items.Add(SavedID[newTimeBegin[timeBar.Value] + q]);
                                }
                            }
                        }
                        else if (RoutesTrackOn == true)
                        {
                            listBoxID.Items.Add("Track Numbers...");
                            if (flagID != 0)
                            {
                                for (int q = 0; q < newTimeNumber[timeBar.Value]; q++)
                                {
                                    listBoxID.Items.Add(SavedTrack[newTimeBegin[timeBar.Value] + q]);
                                }
                            }
                        }
                        else if (RoutesMode3AOn == true)
                        {
                            listBoxID.Items.Add("Mode 3/As...");
                            if (flagID != 0)
                            {
                                for (int q = 0; q < newTimeNumber[timeBar.Value]; q++)
                                {
                                    listBoxID.Items.Add(SavedMode3A[newTimeBegin[timeBar.Value] + q]);
                                }
                            }
                        }


                        k = 0;
                        int h = 0;
                        trackMFLX.Clear();
                        trackMFLY.Clear();
                        foreach (var (timeSelected, indexd) in selectedTimes.Select((value, i) => (value, i)))
                        {
                            if (timeSelected == timeBar.Value)
                            {
                                gMap.Overlays.Clear();
                                markers.Markers.Clear();
                                GMapOverlay routes = new GMapOverlay("routes");
                                pointsA.Clear();
                                pointsB.Clear();
                                for (int j = 0; j < indexd + 1; j++)
                                {
                                    pointsA.Add(pointsTotSel[j]);
                                    k++;
                                }
                                for (int j = indexd + 1; j < pointsTotSel.Count; j++)
                                {
                                    pointsB.Add(pointsTotSel[j]);
                                    h++;
                                }

                                if (k + h > 0)
                                {
                                    Double factor;
                                    if (trackMFL.Max() > 1)
                                    {
                                        factor = trackMFL.Max();
                                    }
                                    else
                                    {
                                        factor = 1;
                                    }

                                    foreach (var (MFL, indexd2) in trackMFL.Select((value, i) => (value, i)))
                                    {

                                        trackMFLY.Add(Convert.ToInt32(100 - (trackMFL[indexd2] / factor * 90 + 5)));
                                        Double xPOS = (Convert.ToDouble(indexd2) / trackMFL.Count) * 250 + 20;
                                        trackMFLX.Add(Convert.ToInt32(xPOS));
                                    }
                                }
                                planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                                planoZ.Refresh();
                                if (pointsA.Count > 1)
                                {

                                    GMapRoute route = new GMapRoute(pointsA, "Routes");
                                    route.Stroke = new Pen(Color.Orange, 3);
                                    routes.Routes.Add(route);
                                    gMap.Overlays.Add(routes);
                                }
                                if (pointsB.Count > 1)
                                {

                                    GMapRoute route = new GMapRoute(pointsB, "Routes");
                                    route.Stroke = new Pen(Color.Gray, 3);
                                    routes.Routes.Add(route);
                                    gMap.Overlays.Add(routes);
                                }
                                if (pointsA.Count > 0)
                                {
                                    gMap.Position = pointsA[pointsA.Count - 1];
                                    Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG[selectedMSGint]]);
                                    GMapMarker marker = new GMarkerGoogle(pointsA[pointsA.Count - 1], plane);
                                    // Agrega el marker al overlay "markers"
                                    markers.Markers.Add(marker);
                                    // Agrega el overlay "markers" al mapa "map"
                                    gMap.Overlays.Add(markers);
                                }
                                else if (pointsA.Count == 0)
                                {
                                    gMap.Position = pointsA[0];
                                    Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG[selectedMSGint]]);
                                    GMapMarker marker = new GMarkerGoogle(pointsA[0], plane);
                                    // Agrega el marker al overlay "markers"
                                    markers.Markers.Add(marker);
                                    // Agrega el overlay "markers" al mapa "map"
                                    gMap.Overlays.Add(markers);
                                }
                            }
                        }
                    }
                    else
                    {
                        timer.Stop();
                    }
                }
            }
            else //backwards
            {
                if (selectedRoute == false)
                {
                    if (timeBar.Value > 0)
                    {
                        timeBar.Value--;
                        lblcurrentTime.Text = uniqueTimestr[timeBar.Value];

                        listBoxID.Items.Clear();
                        if (RoutesIDOn == true)
                        {
                            listBoxID.Items.Add("IDs...");
                            if (flagID != 0)
                            {
                                for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                                {
                                    listBoxID.Items.Add(SavedID[newTimeBegin[timeBar.Value] + h]);
                                }
                            }
                        }
                        else if (RoutesTrackOn == true)
                        {
                            listBoxID.Items.Add("Track Numbers...");
                            if (flagTrackNumber != 0)
                            {
                                for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                                {
                                    listBoxID.Items.Add(SavedTrack[newTimeBegin[timeBar.Value] + h]);
                                }
                            }
                        }
                        else if (RoutesMode3AOn == true)
                        {
                            listBoxID.Items.Add("Mode 3/As...");
                            if (flagID != 0)
                            {
                                for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
                                {
                                    listBoxID.Items.Add(SavedMode3A[newTimeBegin[timeBar.Value] + h]);
                                }
                            }
                        }
                        listBoxID.Items.Add("IDs...");


                        markers.Markers.Clear();
                        for (int i = 0; i < newTimeNumber[timeBar.Value]; i++)
                        {
                            //if (timeBar.Value > 100)
                            //{
                            //    markers.Markers.RemoveAt(0);
                            //}
                            //
                            Bitmap plane = RotateImage(planeMarker, MHGPlane[newTimeBegin[timeBar.Value] + i]);
                            GMapMarker marker = new GMarkerGoogle(points[newTimeBegin[timeBar.Value] + i], plane);
                            // Agrega el marker al overlay "markers"
                            markers.Markers.Add(marker);
                            // Agrega el overlay "markers" al mapa "map"
                            gMap.Overlays.Add(markers);

                        }
                    }
                    else
                    {
                        timer.Stop();
                    }
                }
                else
                {
                    if ((timeBar.Value > selectedRouteInitimeBar) && (timeBar.Value > 0) && (timeBar.Value <= selectedRouteFintimeBar))
                    {
                        selectedMSGint--;
                        lonValue.Text = dataItems[selectedMSG[selectedMSGint]].LonWGS84str + "º";
                        LatValue.Text = dataItems[selectedMSG[selectedMSGint]].LatWGS84str + "º";
                        XValue.Text = dataItems[selectedMSG[selectedMSGint]].X + " m";
                        YValue.Text = dataItems[selectedMSG[selectedMSGint]].Y + " m";
                        VxValue.Text = dataItems[selectedMSG[selectedMSGint]].Vx + " m/s";
                        VyValue.Text = dataItems[selectedMSG[selectedMSGint]].Vy + " m/s";
                        AxValue.Text = dataItems[selectedMSG[selectedMSGint]].Ax + " m/s^2";
                        AyValue.Text = dataItems[selectedMSG[selectedMSGint]].Ay + " m/s^2";
                        MHGValue.Text = dataItems[selectedMSG[selectedMSGint]].MHG + " º";
                        MFLValue.Text = dataItems[selectedMSG[selectedMSGint]].MFL + " FL";
                        TimeValue.Text = dataItems[selectedMSG[selectedMSGint]].TimeOfTrackInfo;
                        MSGValue.Text = selectedMSG[selectedMSGint].ToString();
                        timeBar.Value--;
                        lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];

                        listBoxID.Items.Clear();
                        if (RoutesIDOn == true)
                        {
                            listBoxID.Items.Add("IDs...");
                            if (flagID != 0)
                            {
                                for (int q = 0; q < newTimeNumber[timeBar.Value]; q++)
                                {
                                    listBoxID.Items.Add(SavedID[newTimeBegin[timeBar.Value] + q]);
                                }
                            }
                        }
                        else if (RoutesTrackOn == true)
                        {
                            listBoxID.Items.Add("Track Numbers...");
                            if (flagID != 0)
                            {
                                for (int q = 0; q < newTimeNumber[timeBar.Value]; q++)
                                {
                                    listBoxID.Items.Add(SavedTrack[newTimeBegin[timeBar.Value] + q]);
                                }
                            }
                        }
                        else if (RoutesMode3AOn == true)
                        {
                            listBoxID.Items.Add("Mode 3/As...");
                            if (flagID != 0)
                            {
                                for (int q = 0; q < newTimeNumber[timeBar.Value]; q++)
                                {
                                    listBoxID.Items.Add(SavedMode3A[newTimeBegin[timeBar.Value] + q]);
                                }
                            }
                        }


                        k = 0;
                        int h = 0;
                        trackMFLX.Clear();
                        trackMFLY.Clear();
                        foreach (var (timeSelected, indexd) in selectedTimes.Select((value, i) => (value, i)))
                        {
                            if (timeSelected == timeBar.Value)
                            {
                                gMap.Overlays.Clear();
                                markers.Markers.Clear();
                                GMapOverlay routes = new GMapOverlay("routes");
                                pointsA.Clear();
                                pointsB.Clear();
                                for (int j = 0; j < indexd + 1; j++)
                                {
                                    pointsA.Add(pointsTotSel[j]);
                                    k++;
                                }
                                for (int j = indexd + 1; j < pointsTotSel.Count; j++)
                                {
                                    pointsB.Add(pointsTotSel[j]);
                                    h++;
                                }
                                if (k + h > 0)
                                {
                                    Double factor;
                                    if (trackMFL.Max() > 1)
                                    {
                                        factor = trackMFL.Max();
                                    }
                                    else
                                    {
                                        factor = 1;
                                    }

                                    foreach (var (MFL, indexd2) in trackMFL.Select((value, i) => (value, i)))
                                    {

                                        trackMFLY.Add(Convert.ToInt32(100 - (trackMFL[indexd2] / factor * 90 + 5)));
                                        Double xPOS = (Convert.ToDouble(indexd2) / trackMFL.Count) * 250 + 20;
                                        trackMFLX.Add(Convert.ToInt32(xPOS));
                                    }
                                }
                                planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                                planoZ.Refresh();
                                if (pointsA.Count > 1)
                                {

                                    GMapRoute route = new GMapRoute(pointsA, "Routes");
                                    route.Stroke = new Pen(Color.Orange, 3);
                                    routes.Routes.Add(route);
                                    gMap.Overlays.Add(routes);
                                }
                                if (pointsB.Count > 1)
                                {

                                    GMapRoute route = new GMapRoute(pointsB, "Routes");
                                    route.Stroke = new Pen(Color.Gray, 3);
                                    routes.Routes.Add(route);
                                    gMap.Overlays.Add(routes);
                                }
                                if (pointsA.Count > 0)
                                {
                                    gMap.Position = pointsA[pointsA.Count - 1];
                                    Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG[selectedMSGint]]);
                                    GMapMarker marker = new GMarkerGoogle(pointsA[pointsA.Count - 1], plane);
                                    // Agrega el marker al overlay "markers"
                                    markers.Markers.Add(marker);
                                    // Agrega el overlay "markers" al mapa "map"
                                    gMap.Overlays.Add(markers);
                                }
                                else if (pointsA.Count == 0)
                                {
                                    gMap.Position = pointsA[0];
                                    Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG[selectedMSGint]]);
                                    GMapMarker marker = new GMarkerGoogle(pointsA[0], plane);
                                    // Agrega el marker al overlay "markers"
                                    markers.Markers.Add(marker);
                                    // Agrega el overlay "markers" al mapa "map"
                                    gMap.Overlays.Add(markers);
                                }
                            }
                        }
                    }
                    else
                    {
                        timer.Stop();
                    }
                }
            }
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            timer.Interval = 5000;
            timer.Stop();
            pnlBackFast.Visible = false;
            pnlForFast.Visible = false;
            lblSpeed.Visible = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            anticlockwise = true;
            timer.Start();
            timer.Interval = 1000;
            pnlBackFast.Visible = true;
            btnBackx4.Visible = true;
            btnBackx8.Visible = true;
            btnBackx16.Visible = true;
            pnlForFast.Visible = false;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x2";
            //if (timer.Interval > 400)
            //{
            //    if (timer.Interval > 2000)
            //    {
            //        ToolTip tt = new ToolTip();
            //        tt.SetToolTip(this.btnBack, "Speed: x2");
            //    }
            //    else if (timer.Interval > 1000)
            //    {
            //        ToolTip tt = new ToolTip();
            //        tt.SetToolTip(this.btnBack, "Speed: x4");
            //    }
            //    else if (timer.Interval > 500)
            //    {
            //        ToolTip tt = new ToolTip();
            //        tt.SetToolTip(this.btnBack, "Speed: x8");
            //    }
            //}
            //else
            //{
            //    ToolTip tt = new ToolTip();
            //    tt.SetToolTip(this.btnBack, "Speed: x16");
            //}

        }
        private void btnForward_Click(object sender, EventArgs e)
        {
            anticlockwise = false;
            timer.Start();
            timer.Interval = 1000;
            pnlForFast.Visible = true;
            btnForx4.Visible = true;
            btnForx8.Visible = true;
            btnForx16.Visible = true;
            pnlBackFast.Visible = false;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x2";
            //timer.Interval = timer.Interval / 2;
            //if (timer.Interval > 400)
            //{
            //    if (timer.Interval > 2000)
            //    {
            //        ToolTip tt = new ToolTip();
            //        tt.SetToolTip(this.btnForward, "Speed: x2");
            //    }
            //    else if (timer.Interval > 1000)
            //    {
            //        ToolTip tt = new ToolTip();
            //        tt.SetToolTip(this.btnForward, "Speed: x4");
            //    }
            //    else if (timer.Interval > 500)
            //    {
            //        ToolTip tt = new ToolTip();
            //        tt.SetToolTip(this.btnForward, "Speed: x8");
            //    }
            //}
            //else
            //{
            //    ToolTip tt = new ToolTip();
            //    tt.SetToolTip(this.btnForward, "Speed: x16");
            //}
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            pnlBackFast.Visible = false;
            pnlForFast.Visible = false;
            lblSpeed.Visible = false;
            if (dataItems[0].TimeOfTrackInfo != dataItems[dataItems.Count - 1].TimeOfTrackInfo)
            {
                if (selectedRoute == false)
                {
                    anticlockwise = false;
                    timeBar.Value = 0;
                    timer.Stop();
                    lblcurrentTime.Text = dataItems[0].TimeOfTrackInfo;
                    gMap.Overlays.Clear();
                    markers.Markers.Clear();
                    GMapMarker marker = new GMarkerGoogle(points[0], planeMarker);
                    // Agrega el marker al overlay "markers"
                    markers.Markers.Add(marker);
                    // Agrega el overlay "markers" al mapa "map"
                    gMap.Overlays.Add(markers);
                }
                else
                {
                    selectedMSGint = 0;
                    lonValue.Text = dataItems[selectedMSG[selectedMSGint]].LonWGS84str + "º";
                    LatValue.Text = dataItems[selectedMSG[selectedMSGint]].LatWGS84str + "º";
                    XValue.Text = dataItems[selectedMSG[selectedMSGint]].X + " m";
                    YValue.Text = dataItems[selectedMSG[selectedMSGint]].Y + " m";
                    VxValue.Text = dataItems[selectedMSG[selectedMSGint]].Vx + " m/s";
                    VyValue.Text = dataItems[selectedMSG[selectedMSGint]].Vy + " m/s";
                    AxValue.Text = dataItems[selectedMSG[selectedMSGint]].Ax + " m/s^2";
                    AyValue.Text = dataItems[selectedMSG[selectedMSGint]].Ay + " m/s^2";
                    MHGValue.Text = dataItems[selectedMSG[selectedMSGint]].MHG + " º";
                    MFLValue.Text = dataItems[selectedMSG[selectedMSGint]].MFL + " FL";
                    TimeValue.Text = dataItems[selectedMSG[selectedMSGint]].TimeOfTrackInfo;
                    MSGValue.Text = selectedMSG[selectedMSGint].ToString();
                    timer.Stop();
                    timeBar.Value = selectedRouteInitimeBar;
                    lblcurrentTime.Text = uniqueTimeLap[selectedRouteInitimeBar];
                    gMap.Overlays.Clear();
                    markers.Markers.Clear();
                    k = 0;
                    int h = 0;
                    trackMFLX.Clear();
                    trackMFLY.Clear();
                    pointsA.Clear();
                    pointsB.Clear();
                    for (int i = 0; i < pointsTotSel.Count; i++)
                    {
                        pointsB.Add(pointsTotSel[i]);
                        h++;
                    }
                    if (k + h > 0)
                    {
                        Double factor;
                        if (trackMFL.Max() > 1)
                        {
                            factor = trackMFL.Max();
                        }
                        else
                        {
                            factor = 1;
                        }

                        foreach (var (MFL, indexd2) in trackMFL.Select((value, i) => (value, i)))
                        {

                            trackMFLY.Add(Convert.ToInt32(100 - (trackMFL[indexd2] / factor * 90 + 5)));
                            Double xPOS = (Convert.ToDouble(indexd2) / trackMFL.Count) * 250 + 20;
                            trackMFLX.Add(Convert.ToInt32(xPOS));
                        }
                    }
                    planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                    planoZ.Refresh();
                    //btnMenu.Text = pointsTotSel.Count.ToString() + pointsB.Count.ToString();
                    Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG[selectedMSGint]]);
                    GMapMarker marker = new GMarkerGoogle(pointsTotSel[0], plane);
                    // Agrega el marker al overlay "markers"
                    markers.Markers.Add(marker);
                    // Agrega el overlay "markers" al mapa "map"
                    gMap.Overlays.Add(markers);
                    GMapOverlay routes = new GMapOverlay("routes");
                    if (pointsB.Count > 1)
                    {
                        GMapRoute route = new GMapRoute(pointsB, "Routes");
                        route.Stroke = new Pen(Color.Gray, 3);
                        routes.Routes.Add(route);
                        gMap.Overlays.Add(routes);
                    }
                    gMap.Zoom--;
                    gMap.Position = pointsTotSel[0];
                }
            }
            else if (dataItems[0].LatWGS84 != "")
            {
                for (int i = 0; i < tam; i++)
                {
                    //string time = dataItems[i].TimeOfTrackInfo;
                    points.Add(new PointLatLng(Convert.ToDouble(dataItems[i].LatWGS84), Convert.ToDouble(dataItems[i].LonWGS84)));
                    GMapMarker marker = new GMarkerGoogle(points[i], planeMarker);
                    // Agrega el marker al overlay "markers"
                    markers.Markers.Add(marker);
                    // Agrega el overlay "markers" al mapa "map"
                    gMap.Overlays.Add(markers);
                }

            }
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            pnlBackFast.Visible = false;
            pnlForFast.Visible = false;
            lblSpeed.Visible = false;
            if (dataItems[0].TimeOfTrackInfo != dataItems[dataItems.Count - 1].TimeOfTrackInfo)
            {
                if (selectedRoute == false)
                {
                    anticlockwise = false;
                    timer.Stop();
                    timeBar.Value = uniqueTimeLap.Count - 1;
                    lblcurrentTime.Text = dataItems[tam - 1].TimeOfTrackInfo;
                    markers.Markers.Clear();
                    for (int i = 0; i < newTimeNumber[timeBar.Value]; i++)
                    {
                        GMapMarker marker = new GMarkerGoogle(points[newTimeBegin[timeBar.Value] + i], planeMarker);
                        // Agrega el marker al overlay "markers"
                        markers.Markers.Add(marker);
                        // Agrega el overlay "markers" al mapa "map"
                        gMap.Overlays.Add(markers);
                    }
                }

                else
                {
                    selectedMSGint = selectedMSG.Count - 1;
                    lonValue.Text = dataItems[selectedMSG[selectedMSGint]].LonWGS84str + "º";
                    LatValue.Text = dataItems[selectedMSG[selectedMSGint]].LatWGS84str + "º";
                    XValue.Text = dataItems[selectedMSG[selectedMSGint]].X + " m";
                    YValue.Text = dataItems[selectedMSG[selectedMSGint]].Y + " m";
                    VxValue.Text = dataItems[selectedMSG[selectedMSGint]].Vx + " m/s";
                    VyValue.Text = dataItems[selectedMSG[selectedMSGint]].Vy + " m/s";
                    AxValue.Text = dataItems[selectedMSG[selectedMSGint]].Ax + " m/s^2";
                    AyValue.Text = dataItems[selectedMSG[selectedMSGint]].Ay + " m/s^2";
                    MHGValue.Text = dataItems[selectedMSG[selectedMSGint]].MHG + " º";
                    MFLValue.Text = dataItems[selectedMSG[selectedMSGint]].MFL + " FL";
                    TimeValue.Text = dataItems[selectedMSG[selectedMSGint]].TimeOfTrackInfo;
                    MSGValue.Text = selectedMSG[selectedMSGint].ToString();

                    anticlockwise = false;
                    timeBar.Value = selectedRouteFintimeBar;
                    timer.Stop();
                    lblcurrentTime.Text = uniqueTimeLap[selectedRouteFintimeBar];
                    gMap.Overlays.Clear();
                    markers.Markers.Clear();
                    GMapOverlay routes = new GMapOverlay("routes");
                    pointsA.Clear();
                    pointsB.Clear();
                    k = 0;
                    int h = 0;
                    trackMFLX.Clear();
                    trackMFLY.Clear();
                    for (int i = 0; i < pointsTotSel.Count; i++)
                    {
                        pointsA.Add(pointsTotSel[i]);
                        k++;
                    }
                    if (k + h > 0)
                    {
                        Double factor;
                        if (trackMFL.Max() > 1)
                        {
                            factor = trackMFL.Max();
                        }
                        else
                        {
                            factor = 1;
                        }

                        foreach (var (MFL, indexd2) in trackMFL.Select((value, i) => (value, i)))
                        {

                            trackMFLY.Add(Convert.ToInt32(100 - (trackMFL[indexd2] / factor * 90 + 5)));
                            Double xPOS = (Convert.ToDouble(indexd2) / trackMFL.Count) * 250 + 20;
                            trackMFLX.Add(Convert.ToInt32(xPOS));
                        }
                    }
                    planoZ.Paint += new PaintEventHandler(planoZ_Paint);
                    planoZ.Refresh();
                    Bitmap plane = RotateImage(planeMarker, MHGPlane[selectedMSG[selectedMSGint]]);
                    GMapMarker marker = new GMarkerGoogle(pointsTotSel[pointsTotSel.Count - 1], plane);
                    // Agrega el marker al overlay "markers"
                    markers.Markers.Add(marker);
                    // Agrega el overlay "markers" al mapa "map"
                    gMap.Overlays.Add(markers);
                    if (pointsA.Count > 1)
                    {
                        GMapRoute route = new GMapRoute(pointsA, "Routes");
                        route.Stroke = new Pen(Color.Orange, 3);
                        routes.Routes.Add(route);
                        gMap.Overlays.Add(routes);
                    }
                    gMap.Zoom++;
                    gMap.Position = pointsTotSel[pointsTotSel.Count - 1];
                }
            }

        }
        private void btnForx4_Click(object sender, EventArgs e)
        {
            timer.Interval = 500;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x4";
        }
        private void btnForx8_Click(object sender, EventArgs e)
        {
            timer.Interval = 250;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x8";
        }
        private void btnForx16_Click(object sender, EventArgs e)
        {
            timer.Interval = 125;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x16";
        }
        private void btnBackx4_Click(object sender, EventArgs e)
        {
            timer.Interval = 500;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x4";
        }
        private void btnBackx8_Click(object sender, EventArgs e)
        {
            timer.Interval = 250;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x8";
        }
        private void btnBackx16_Click(object sender, EventArgs e)
        {
            timer.Interval = 125;
            lblSpeed.Visible = true;
            lblSpeed.Text = "Speed" + Environment.NewLine + "x16";
        }
        //settings
        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            fileRun = false;
            lblFile.Text = "";
            btnRemoveFile.BackColor = Color.Orange;
            MessageBox.Show("Go back to Menu and select a File");
        }
        private void btnVisibleTop_Click(object sender, EventArgs e)
        {
            if (btnVisibleTop.BackColor == Color.Orange)
            {
                btnVisibleTop.BackColor = Color.Gray;
                visibleTop = false;
                lblFile.Visible = false;
            }
            else if (btnVisibleTop.BackColor == Color.Gray)
            {
                btnVisibleTop.BackColor = Color.Orange;
                visibleTop = true;
                lblFile.Text = file;
                lblFile.Visible = true;
            }
        }
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (btnExportCSV.BackColor == Color.Orange)
            {

            }
            else
            {
                var csv = new StringBuilder();

                foreach (var (DataBlock, indexd) in dataItems.Select((value, i) => (value, i)))
                {
                    var first = dataItems[indexd].LatWGS84;
                    var second = dataItems[indexd].LonWGS84;
                    //Suggestion made by KyleMit
                    var newLine = string.Format("{0},{1}", first, second);
                    csv.AppendLine(newLine);
                }
                File.WriteAllText("MyFile.csv", csv.ToString());
                btnExportCSV.BackColor = Color.Orange;
                MessageBox.Show("File correctly saved in path as 'MyFile.csv'");
            }
        }
        private void btnExportKML_Click(object sender, EventArgs e)
        {
            if (btnExportKML.BackColor == Color.Orange)
            {

            }
            else
            {
                LineString linestring = new LineString();
                CoordinateCollection coordinates = new CoordinateCollection();

                foreach (var (DataBlock, indexd) in dataItems.Select((value, i) => (value, i)))
                {
                    coordinates.Add(new Vector(Convert.ToDouble(dataItems[indexd].LatWGS84), Convert.ToDouble(dataItems[indexd].LonWGS84)));
                }

                linestring.Coordinates = coordinates;
                var kml = new Kml();
                KmlFile kmlFile = KmlFile.Create(kml, true);
                using (var stream = System.IO.File.OpenWrite("Myfile.kml"))
                {
                    kmlFile.Save(stream);
                }
                btnExportKML.BackColor = Color.Orange;
                MessageBox.Show("File correctly saved in path as 'MyFile.kml'");

            }
        }
        private void btnExportDBText_Click(object sender, EventArgs e)
        {
            if (btnExportDBText.BackColor == Color.Orange)
            {

            }
            else
            {
                using (var sw = new StreamWriter("AllDataBlocks.txt"))
                {
                    foreach (var datablock in dataBlocks)
                    {
                        var dump = ObjectDumper.Dump(datablock);
                        string createText = dump;
                        sw.WriteLine(createText);
                    }
                }
                btnExportDBText.BackColor = Color.Orange;
                MessageBox.Show("File correctly saved in path as 'AllDataBlocks.txt'");
            }

        }
        private void btnExportDIText_Click(object sender, EventArgs e)
        {
            if (btnExportDIText.BackColor == Color.Orange)
            {

            }
            else
            {
                using (var sw = new StreamWriter("AllDataItems.txt"))
                {
                    foreach (var dataitem in dataItems)
                    {
                        var dump = ObjectDumper.Dump(dataitem);
                        string createText = dump;
                        sw.WriteLine(createText);
                    }
                }
                btnExportDIText.BackColor = Color.Orange;
                MessageBox.Show("File correctly saved in path as 'AllDataItemss.txt'");

            }

        }
        private void listMapProviders_Click(object sender, EventArgs e)
        {
            if (clickedMap == false)
            {
                listMapProviders.Items.Clear();
                listMapProviders.Items.Add("Bing");
                listMapProviders.Items.Add("Google Maps");
                listMapProviders.Items.Add("Google Satellite Map");
                listMapProviders.Items.Add("Google Terrain Map");
                clickedMap = true;
            }
            else
            {
                selectedMapProvider = listMapProviders.SelectedItem.ToString();
                listMapProviders.Items.Clear();
                listMapProviders.Items.Add(selectedMapProvider);
                clickedMap = false;
            }


        }
        private void btn1Step_Click(object sender, EventArgs e)
        {
            btn1Step.BackColor = Color.Orange;
            btn2Steps.BackColor = Color.Gray;
            interval = 1;
        }
        private void btn2Steps_Click(object sender, EventArgs e)
        {
            btn2Steps.BackColor = Color.Orange;
            btn1Step.BackColor = Color.Gray;
            interval = 2;
        }
        private void btnInfoProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was created as a project of PGTA, Aerospace Engineering Degree in UPC." + Environment.NewLine + "By: Jonatan Palacios & José Triviño" + Environment.NewLine + "May 2022");
        }
        //window
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


    }
}


//gMap.Overlays.Clear();
//markers.Markers.Clear();
//GMapOverlay routes = new GMapOverlay("routes");

//bool pointPerTime = false;
//for (int h = 0; h < newTimeNumber[timeBar.Value]; h++)
//{
//    if (SavedID[newTimeBegin[timeBar.Value] + h] == listBoxID.SelectedItem.ToString())
//    {
//        pointPerTime = true;
//    }
//}

//if (pointPerTime == true)
//{

//    if (pointsB.Count > 0)
//    {
//        pointsA.Add(pointsB[0]);
//        pointsB.RemoveAt(0);
//    }
//    else { timer.Stop(); }
//    if (pointsA.Count > 1)
//    {

//        GMapRoute route = new GMapRoute(pointsA, "Routes");
//        route.Stroke = new Pen(Color.Red, 3);
//        routes.Routes.Add(route);
//        gMap.Overlays.Add(routes);
//    }
//    if (pointsB.Count > 1)
//    {

//        GMapRoute route = new GMapRoute(pointsB, "Routes");
//        route.Stroke = new Pen(Color.Gray, 3);
//        routes.Routes.Add(route);
//        gMap.Overlays.Add(routes);
//    }
//    if (pointsA.Count > 0)
//    {
//        gMap.Position = pointsA[pointsA.Count - 1];
//        GMapMarker marker = new GMarkerGoogle(pointsA[pointsA.Count - 1], planeMarker);
//        // Agrega el marker al overlay "markers"
//        markers.Markers.Add(marker);
//        // Agrega el overlay "markers" al mapa "map"
//        gMap.Overlays.Add(markers);
//    }
//    else
//    {
//        gMap.Position = pointsA[0];
//        GMapMarker marker = new GMarkerGoogle(pointsA[0], planeMarker);
//        // Agrega el marker al overlay "markers"
//        markers.Markers.Add(marker);
//        // Agrega el overlay "markers" al mapa "map"
//        gMap.Overlays.Add(markers);
//    }
//}
//else
//{
//    changedTimeFin = true;
//    lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];
//    plusTime++;
//    selectedRouteFintimeBar += plusTime;
//}




///////forwardselectedItem::::
/////if ((timeBar.Value < selectedRouteFintimeBar) && (timeBar.Value < uniqueTimeLap.Count-1))
//{
//    gMap.Overlays.Clear();
//    markers.Markers.Clear();
//    GMapOverlay routes = new GMapOverlay("routes");
//    timeBar.Value++;
//    lblcurrentTime.Text = uniqueTimeLap[timeBar.Value];
//    if (pointsB.Count > 0)
//    {
//        pointsA.Add(pointsB[0]);
//        pointsB.RemoveAt(0);
//    }
//    else { timer.Stop(); }
//    if (pointsA.Count > 1)
//    {

//        GMapRoute route = new GMapRoute(pointsA, "Routes");
//        route.Stroke = new Pen(Color.Red, 3);
//        routes.Routes.Add(route);
//        gMap.Overlays.Add(routes);
//    }
//    if (pointsB.Count > 1)
//    {

//        GMapRoute route = new GMapRoute(pointsB, "Routes");
//        route.Stroke = new Pen(Color.Gray, 3);
//        routes.Routes.Add(route);
//        gMap.Overlays.Add(routes);
//    }
//    if (pointsA.Count > 0)
//    {
//        gMap.Position = pointsA[pointsA.Count - 1];
//        GMapMarker marker = new GMarkerGoogle(pointsA[pointsA.Count - 1], planeMarker);
//        // Agrega el marker al overlay "markers"
//        markers.Markers.Add(marker);
//        // Agrega el overlay "markers" al mapa "map"
//        gMap.Overlays.Add(markers);
//    }
//    else
//    {
//        gMap.Position = pointsA[0];
//        GMapMarker marker = new GMarkerGoogle(pointsA[0], planeMarker);
//        // Agrega el marker al overlay "markers"
//        markers.Markers.Add(marker);
//        // Agrega el overlay "markers" al mapa "map"
//        gMap.Overlays.Add(markers);
//    }
//}