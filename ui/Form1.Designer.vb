Option Explicit On
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.chkHatAuftakt = New System.Windows.Forms.CheckBox()
        Me.chkHatSchlussakkord = New System.Windows.Forms.CheckBox()
        Me.pnlSequenzer = New System.Windows.Forms.Panel()
        Me.TaktEingabe1 = New easy_Harmony.TaktEingabe()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTonartDur = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernBetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LadenBetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MIDIExportBetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstrumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KlavierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GitarreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomatischeUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AufUpdatePrüfenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HilfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NachrichtAnDenSupportSendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MIDIExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÜberwachungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MIDIInstrumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DummyMidiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MIDIGeneratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RaiseFehlerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BehandelterFehlerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.scrlTempo = New System.Windows.Forms.TrackBar()
        Me.lblTempo = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.stlStatus = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboSpiele_bisTakt = New System.Windows.Forms.ComboBox()
        Me.cboSpiele_vonTakt = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.kpfStop = New easy_Harmony.Knopf()
        Me.lblTitel = New System.Windows.Forms.Label()
        Me.kpfPlay = New easy_Harmony.Knopf()
        Me.chkAlleTakteSpielen = New System.Windows.Forms.CheckBox()
        Me.Steuerleiste1 = New easy_Harmony.Steuerleiste()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbMoll = New System.Windows.Forms.RadioButton()
        Me.rbDur = New System.Windows.Forms.RadioButton()
        Me.kpf4Takt = New easy_Harmony.Knopf()
        Me.kpfTonartRunter = New easy_Harmony.Knopf()
        Me.kpfTonartHoch = New easy_Harmony.Knopf()
        Me.Steuerleiste2 = New easy_Harmony.Steuerleiste()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lbl_Akkordhead = New System.Windows.Forms.Label()
        Me.lbl_MelodieHead = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape10 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape9 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape8 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape7 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.pnlSequenzer.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.scrlTempo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkHatAuftakt
        '
        Me.chkHatAuftakt.AutoSize = True
        Me.chkHatAuftakt.BackColor = System.Drawing.Color.Gainsboro
        Me.chkHatAuftakt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHatAuftakt.Location = New System.Drawing.Point(483, 26)
        Me.chkHatAuftakt.Name = "chkHatAuftakt"
        Me.chkHatAuftakt.Size = New System.Drawing.Size(133, 15)
        Me.chkHatAuftakt.TabIndex = 2
        Me.chkHatAuftakt.Text = "Auftakt anzeigen"
        Me.chkHatAuftakt.UseVisualStyleBackColor = False
        '
        'chkHatSchlussakkord
        '
        Me.chkHatSchlussakkord.AutoSize = True
        Me.chkHatSchlussakkord.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.chkHatSchlussakkord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHatSchlussakkord.Location = New System.Drawing.Point(483, 44)
        Me.chkHatSchlussakkord.Name = "chkHatSchlussakkord"
        Me.chkHatSchlussakkord.Size = New System.Drawing.Size(161, 15)
        Me.chkHatSchlussakkord.TabIndex = 3
        Me.chkHatSchlussakkord.Text = "Schlusstakt anzeigen"
        Me.chkHatSchlussakkord.UseVisualStyleBackColor = False
        '
        'pnlSequenzer
        '
        Me.pnlSequenzer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSequenzer.AutoScroll = True
        Me.pnlSequenzer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlSequenzer.Controls.Add(Me.TaktEingabe1)
        Me.pnlSequenzer.Location = New System.Drawing.Point(3, 3)
        Me.pnlSequenzer.Name = "pnlSequenzer"
        Me.pnlSequenzer.Size = New System.Drawing.Size(760, 391)
        Me.pnlSequenzer.TabIndex = 5
        '
        'TaktEingabe1
        '
        Me.TaktEingabe1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TaktEingabe1.Location = New System.Drawing.Point(167, 32)
        Me.TaktEingabe1.Name = "TaktEingabe1"
        Me.TaktEingabe1.Size = New System.Drawing.Size(455, 104)
        Me.TaktEingabe1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Lucida Console", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(171, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Tonart:"
        '
        'lblTonartDur
        '
        Me.lblTonartDur.BackColor = System.Drawing.Color.DimGray
        Me.lblTonartDur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTonartDur.Font = New System.Drawing.Font("Lucida Console", 9.0!)
        Me.lblTonartDur.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblTonartDur.Location = New System.Drawing.Point(157, 31)
        Me.lblTonartDur.Name = "lblTonartDur"
        Me.lblTonartDur.Size = New System.Drawing.Size(112, 23)
        Me.lblTonartDur.TabIndex = 9
        Me.lblTonartDur.Text = " "
        Me.lblTonartDur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.AudioToolStripMenuItem, Me.VersionToolStripMenuItem, Me.HilfeToolStripMenuItem, Me.ToolStripMenuItem1, Me.SystemToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(789, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetToolStripMenuItem, Me.SpeichernBetaToolStripMenuItem, Me.LadenBetaToolStripMenuItem, Me.MIDIExportBetaToolStripMenuItem, Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.New_icon
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ResetToolStripMenuItem.Text = "Neu"
        '
        'SpeichernBetaToolStripMenuItem
        '
        Me.SpeichernBetaToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.Save_icon
        Me.SpeichernBetaToolStripMenuItem.Name = "SpeichernBetaToolStripMenuItem"
        Me.SpeichernBetaToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.SpeichernBetaToolStripMenuItem.Text = "Speichern..."
        '
        'LadenBetaToolStripMenuItem
        '
        Me.LadenBetaToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.folder_open_icon
        Me.LadenBetaToolStripMenuItem.Name = "LadenBetaToolStripMenuItem"
        Me.LadenBetaToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.LadenBetaToolStripMenuItem.Text = "Laden..."
        '
        'MIDIExportBetaToolStripMenuItem
        '
        Me.MIDIExportBetaToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.file_music_icon
        Me.MIDIExportBetaToolStripMenuItem.Name = "MIDIExportBetaToolStripMenuItem"
        Me.MIDIExportBetaToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.MIDIExportBetaToolStripMenuItem.Text = "MIDI Export..."
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'AudioToolStripMenuItem
        '
        Me.AudioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstrumentToolStripMenuItem})
        Me.AudioToolStripMenuItem.Name = "AudioToolStripMenuItem"
        Me.AudioToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.AudioToolStripMenuItem.Text = "Audio"
        '
        'InstrumentToolStripMenuItem
        '
        Me.InstrumentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KlavierToolStripMenuItem, Me.GitarreToolStripMenuItem})
        Me.InstrumentToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.piano_keyboard_icon
        Me.InstrumentToolStripMenuItem.Name = "InstrumentToolStripMenuItem"
        Me.InstrumentToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.InstrumentToolStripMenuItem.Text = "Instrument"
        '
        'KlavierToolStripMenuItem
        '
        Me.KlavierToolStripMenuItem.Name = "KlavierToolStripMenuItem"
        Me.KlavierToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.KlavierToolStripMenuItem.Text = "Piano"
        '
        'GitarreToolStripMenuItem
        '
        Me.GitarreToolStripMenuItem.Name = "GitarreToolStripMenuItem"
        Me.GitarreToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.GitarreToolStripMenuItem.Text = "Gitarre"
        Me.GitarreToolStripMenuItem.Visible = False
        '
        'VersionToolStripMenuItem
        '
        Me.VersionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutomatischeUpdatesToolStripMenuItem, Me.AufUpdatePrüfenToolStripMenuItem})
        Me.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem"
        Me.VersionToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.VersionToolStripMenuItem.Text = "Update"
        '
        'AutomatischeUpdatesToolStripMenuItem
        '
        Me.AutomatischeUpdatesToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.Apps_system_software_update_icon
        Me.AutomatischeUpdatesToolStripMenuItem.Name = "AutomatischeUpdatesToolStripMenuItem"
        Me.AutomatischeUpdatesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.AutomatischeUpdatesToolStripMenuItem.Text = "automatische Updates"
        '
        'AufUpdatePrüfenToolStripMenuItem
        '
        Me.AufUpdatePrüfenToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.Actions_edit_redo_icon
        Me.AufUpdatePrüfenToolStripMenuItem.Name = "AufUpdatePrüfenToolStripMenuItem"
        Me.AufUpdatePrüfenToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.AufUpdatePrüfenToolStripMenuItem.Text = "jetzt auf Update prüfen"
        '
        'HilfeToolStripMenuItem
        '
        Me.HilfeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NachrichtAnDenSupportSendenToolStripMenuItem})
        Me.HilfeToolStripMenuItem.Name = "HilfeToolStripMenuItem"
        Me.HilfeToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HilfeToolStripMenuItem.Text = "Hilfe"
        '
        'NachrichtAnDenSupportSendenToolStripMenuItem
        '
        Me.NachrichtAnDenSupportSendenToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.Status_mail_unread_new_icon
        Me.NachrichtAnDenSupportSendenToolStripMenuItem.Name = "NachrichtAnDenSupportSendenToolStripMenuItem"
        Me.NachrichtAnDenSupportSendenToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.NachrichtAnDenSupportSendenToolStripMenuItem.Text = "Nachricht an den Support senden..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuItem1.Text = "?"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Image = Global.easy_Harmony.My.Resources.Resources.Info_icon
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DebugToolStripMenuItem, Me.MIDIExportToolStripMenuItem, Me.ÜberwachungToolStripMenuItem, Me.MIDIInstrumentToolStripMenuItem, Me.DummyMidiToolStripMenuItem, Me.MIDIGeneratorToolStripMenuItem, Me.RaiseFehlerToolStripMenuItem, Me.BehandelterFehlerToolStripMenuItem})
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.SystemToolStripMenuItem.Text = "System"
        '
        'DebugToolStripMenuItem
        '
        Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
        Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.DebugToolStripMenuItem.Text = "Debug"
        '
        'MIDIExportToolStripMenuItem
        '
        Me.MIDIExportToolStripMenuItem.Name = "MIDIExportToolStripMenuItem"
        Me.MIDIExportToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.MIDIExportToolStripMenuItem.Text = "MIDI Export"
        '
        'ÜberwachungToolStripMenuItem
        '
        Me.ÜberwachungToolStripMenuItem.Name = "ÜberwachungToolStripMenuItem"
        Me.ÜberwachungToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ÜberwachungToolStripMenuItem.Text = "Überwachung"
        '
        'MIDIInstrumentToolStripMenuItem
        '
        Me.MIDIInstrumentToolStripMenuItem.Name = "MIDIInstrumentToolStripMenuItem"
        Me.MIDIInstrumentToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.MIDIInstrumentToolStripMenuItem.Text = "MIDI Instrument"
        '
        'DummyMidiToolStripMenuItem
        '
        Me.DummyMidiToolStripMenuItem.Name = "DummyMidiToolStripMenuItem"
        Me.DummyMidiToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.DummyMidiToolStripMenuItem.Text = "Dummy Midi"
        Me.DummyMidiToolStripMenuItem.Visible = False
        '
        'MIDIGeneratorToolStripMenuItem
        '
        Me.MIDIGeneratorToolStripMenuItem.Name = "MIDIGeneratorToolStripMenuItem"
        Me.MIDIGeneratorToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.MIDIGeneratorToolStripMenuItem.Text = "MIDI Generator"
        '
        'RaiseFehlerToolStripMenuItem
        '
        Me.RaiseFehlerToolStripMenuItem.Name = "RaiseFehlerToolStripMenuItem"
        Me.RaiseFehlerToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.RaiseFehlerToolStripMenuItem.Text = "Raise Fehler"
        '
        'BehandelterFehlerToolStripMenuItem
        '
        Me.BehandelterFehlerToolStripMenuItem.Name = "BehandelterFehlerToolStripMenuItem"
        Me.BehandelterFehlerToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.BehandelterFehlerToolStripMenuItem.Text = "Behandelter Fehler"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 675)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(789, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'scrlTempo
        '
        Me.scrlTempo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.scrlTempo.AutoSize = False
        Me.scrlTempo.BackColor = System.Drawing.Color.DimGray
        Me.scrlTempo.Location = New System.Drawing.Point(298, 29)
        Me.scrlTempo.Maximum = 160
        Me.scrlTempo.Minimum = 70
        Me.scrlTempo.Name = "scrlTempo"
        Me.scrlTempo.Size = New System.Drawing.Size(137, 21)
        Me.scrlTempo.TabIndex = 17
        Me.scrlTempo.Value = 90
        '
        'lblTempo
        '
        Me.lblTempo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTempo.BackColor = System.Drawing.Color.DimGray
        Me.lblTempo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTempo.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblTempo.Location = New System.Drawing.Point(196, 28)
        Me.lblTempo.Name = "lblTempo"
        Me.lblTempo.Size = New System.Drawing.Size(96, 22)
        Me.lblTempo.TabIndex = 18
        Me.lblTempo.Text = "Tempo 120"
        Me.lblTempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.pnlSequenzer)
        Me.Panel2.Location = New System.Drawing.Point(7, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(770, 401)
        Me.Panel2.TabIndex = 24
        '
        'stlStatus
        '
        Me.stlStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stlStatus.Location = New System.Drawing.Point(6, 732)
        Me.stlStatus.Name = "stlStatus"
        Me.stlStatus.Size = New System.Drawing.Size(769, 13)
        Me.stlStatus.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lblTempo)
        Me.Panel1.Controls.Add(Me.scrlTempo)
        Me.Panel1.Controls.Add(Me.cboSpiele_bisTakt)
        Me.Panel1.Controls.Add(Me.cboSpiele_vonTakt)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.kpfStop)
        Me.Panel1.Controls.Add(Me.lblTitel)
        Me.Panel1.Controls.Add(Me.kpfPlay)
        Me.Panel1.Controls.Add(Me.chkAlleTakteSpielen)
        Me.Panel1.Controls.Add(Me.Steuerleiste1)
        Me.Panel1.Location = New System.Drawing.Point(6, 595)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(770, 75)
        Me.Panel1.TabIndex = 2
        '
        'cboSpiele_bisTakt
        '
        Me.cboSpiele_bisTakt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboSpiele_bisTakt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSpiele_bisTakt.FormattingEnabled = True
        Me.cboSpiele_bisTakt.Location = New System.Drawing.Point(483, 41)
        Me.cboSpiele_bisTakt.Name = "cboSpiele_bisTakt"
        Me.cboSpiele_bisTakt.Size = New System.Drawing.Size(101, 19)
        Me.cboSpiele_bisTakt.TabIndex = 32
        '
        'cboSpiele_vonTakt
        '
        Me.cboSpiele_vonTakt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboSpiele_vonTakt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSpiele_vonTakt.FormattingEnabled = True
        Me.cboSpiele_vonTakt.Location = New System.Drawing.Point(483, 17)
        Me.cboSpiele_vonTakt.Name = "cboSpiele_vonTakt"
        Me.cboSpiele_vonTakt.Size = New System.Drawing.Size(101, 19)
        Me.cboSpiele_vonTakt.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(441, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 15)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Ende"
        '
        'kpfStop
        '
        Me.kpfStop.BackColor = System.Drawing.Color.Transparent
        Me.kpfStop.Location = New System.Drawing.Point(129, 6)
        Me.kpfStop.Name = "kpfStop"
        Me.kpfStop.Size = New System.Drawing.Size(59, 64)
        Me.kpfStop.TabIndex = 27
        '
        'lblTitel
        '
        Me.lblTitel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTitel.AutoSize = True
        Me.lblTitel.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTitel.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitel.ForeColor = System.Drawing.Color.Gray
        Me.lblTitel.Location = New System.Drawing.Point(441, 18)
        Me.lblTitel.Name = "lblTitel"
        Me.lblTitel.Size = New System.Drawing.Size(35, 15)
        Me.lblTitel.TabIndex = 29
        Me.lblTitel.Text = "Start"
        '
        'kpfPlay
        '
        Me.kpfPlay.BackColor = System.Drawing.Color.Transparent
        Me.kpfPlay.Location = New System.Drawing.Point(71, 6)
        Me.kpfPlay.Name = "kpfPlay"
        Me.kpfPlay.Size = New System.Drawing.Size(59, 64)
        Me.kpfPlay.TabIndex = 26
        '
        'chkAlleTakteSpielen
        '
        Me.chkAlleTakteSpielen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAlleTakteSpielen.AutoSize = True
        Me.chkAlleTakteSpielen.BackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.chkAlleTakteSpielen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAlleTakteSpielen.Location = New System.Drawing.Point(596, 32)
        Me.chkAlleTakteSpielen.Name = "chkAlleTakteSpielen"
        Me.chkAlleTakteSpielen.Size = New System.Drawing.Size(140, 15)
        Me.chkAlleTakteSpielen.TabIndex = 28
        Me.chkAlleTakteSpielen.Text = "Spiele alle Takte"
        Me.chkAlleTakteSpielen.UseVisualStyleBackColor = False
        Me.chkAlleTakteSpielen.Visible = False
        '
        'Steuerleiste1
        '
        Me.Steuerleiste1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Steuerleiste1.Location = New System.Drawing.Point(3, 3)
        Me.Steuerleiste1.Name = "Steuerleiste1"
        Me.Steuerleiste1.Size = New System.Drawing.Size(763, 70)
        Me.Steuerleiste1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.chkHatAuftakt)
        Me.Panel3.Controls.Add(Me.chkHatSchlussakkord)
        Me.Panel3.Controls.Add(Me.rbMoll)
        Me.Panel3.Controls.Add(Me.rbDur)
        Me.Panel3.Controls.Add(Me.kpf4Takt)
        Me.Panel3.Controls.Add(Me.kpfTonartRunter)
        Me.Panel3.Controls.Add(Me.kpfTonartHoch)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lblTonartDur)
        Me.Panel3.Controls.Add(Me.Steuerleiste2)
        Me.Panel3.Location = New System.Drawing.Point(6, 27)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(769, 80)
        Me.Panel3.TabIndex = 2
        '
        'rbMoll
        '
        Me.rbMoll.AutoSize = True
        Me.rbMoll.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rbMoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbMoll.Location = New System.Drawing.Point(215, 56)
        Me.rbMoll.Name = "rbMoll"
        Me.rbMoll.Size = New System.Drawing.Size(50, 15)
        Me.rbMoll.TabIndex = 14
        Me.rbMoll.TabStop = True
        Me.rbMoll.Text = "Moll"
        Me.rbMoll.UseVisualStyleBackColor = False
        '
        'rbDur
        '
        Me.rbDur.AutoSize = True
        Me.rbDur.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rbDur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbDur.Location = New System.Drawing.Point(167, 56)
        Me.rbDur.Name = "rbDur"
        Me.rbDur.Size = New System.Drawing.Size(43, 15)
        Me.rbDur.TabIndex = 13
        Me.rbDur.TabStop = True
        Me.rbDur.Text = "Dur"
        Me.rbDur.UseVisualStyleBackColor = False
        '
        'kpf4Takt
        '
        Me.kpf4Takt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.kpf4Takt.BackColor = System.Drawing.Color.Transparent
        Me.kpf4Takt.Location = New System.Drawing.Point(333, 8)
        Me.kpf4Takt.Name = "kpf4Takt"
        Me.kpf4Takt.Size = New System.Drawing.Size(135, 64)
        Me.kpf4Takt.TabIndex = 12
        '
        'kpfTonartRunter
        '
        Me.kpfTonartRunter.BackColor = System.Drawing.Color.Transparent
        Me.kpfTonartRunter.Location = New System.Drawing.Point(115, 7)
        Me.kpfTonartRunter.Name = "kpfTonartRunter"
        Me.kpfTonartRunter.Size = New System.Drawing.Size(38, 64)
        Me.kpfTonartRunter.TabIndex = 11
        '
        'kpfTonartHoch
        '
        Me.kpfTonartHoch.BackColor = System.Drawing.Color.Transparent
        Me.kpfTonartHoch.Location = New System.Drawing.Point(271, 8)
        Me.kpfTonartHoch.Name = "kpfTonartHoch"
        Me.kpfTonartHoch.Size = New System.Drawing.Size(37, 64)
        Me.kpfTonartHoch.TabIndex = 10
        '
        'Steuerleiste2
        '
        Me.Steuerleiste2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Steuerleiste2.Location = New System.Drawing.Point(3, 4)
        Me.Steuerleiste2.Name = "Steuerleiste2"
        Me.Steuerleiste2.Size = New System.Drawing.Size(765, 73)
        Me.Steuerleiste2.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(7, 116)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbl_Akkordhead)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbl_MelodieHead)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(769, 59)
        Me.SplitContainer1.SplitterDistance = 133
        Me.SplitContainer1.TabIndex = 25
        '
        'lbl_Akkordhead
        '
        Me.lbl_Akkordhead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Akkordhead.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Akkordhead.Location = New System.Drawing.Point(0, 4)
        Me.lbl_Akkordhead.Name = "lbl_Akkordhead"
        Me.lbl_Akkordhead.Size = New System.Drawing.Size(122, 22)
        Me.lbl_Akkordhead.TabIndex = 0
        Me.lbl_Akkordhead.Text = "Akkord"
        Me.lbl_Akkordhead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_MelodieHead
        '
        Me.lbl_MelodieHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MelodieHead.Location = New System.Drawing.Point(56, 6)
        Me.lbl_MelodieHead.Name = "lbl_MelodieHead"
        Me.lbl_MelodieHead.Size = New System.Drawing.Size(348, 22)
        Me.lbl_MelodieHead.TabIndex = 0
        Me.lbl_MelodieHead.Text = "Melodie"
        Me.lbl_MelodieHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape10, Me.LineShape9, Me.LineShape8, Me.LineShape7, Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(628, 55)
        Me.ShapeContainer1.TabIndex = 6
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape10
        '
        Me.LineShape10.BorderColor = System.Drawing.Color.DarkGray
        Me.LineShape10.Name = "LineShape10"
        Me.LineShape10.X1 = 90
        Me.LineShape10.X2 = 90
        Me.LineShape10.Y1 = 26
        Me.LineShape10.Y2 = 54
        '
        'LineShape9
        '
        Me.LineShape9.BorderColor = System.Drawing.Color.DarkGray
        Me.LineShape9.Name = "LineShape9"
        Me.LineShape9.X1 = 181
        Me.LineShape9.X2 = 181
        Me.LineShape9.Y1 = 27
        Me.LineShape9.Y2 = 55
        '
        'LineShape8
        '
        Me.LineShape8.BorderColor = System.Drawing.Color.DarkGray
        Me.LineShape8.Name = "LineShape8"
        Me.LineShape8.X1 = 272
        Me.LineShape8.X2 = 272
        Me.LineShape8.Y1 = 27
        Me.LineShape8.Y2 = 55
        '
        'LineShape7
        '
        Me.LineShape7.BorderColor = System.Drawing.Color.DarkGray
        Me.LineShape7.Name = "LineShape7"
        Me.LineShape7.X1 = 363
        Me.LineShape7.X2 = 363
        Me.LineShape7.Y1 = 28
        Me.LineShape7.Y2 = 56
        '
        'LineShape4
        '
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 273
        Me.LineShape4.X2 = 273
        Me.LineShape4.Y1 = 27
        Me.LineShape4.Y2 = 55
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 364
        Me.LineShape3.X2 = 364
        Me.LineShape3.Y1 = 28
        Me.LineShape3.Y2 = 56
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.Black
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 182
        Me.LineShape2.X2 = 182
        Me.LineShape2.Y1 = 27
        Me.LineShape2.Y2 = 55
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 91
        Me.LineShape1.X2 = 91
        Me.LineShape1.Y1 = 26
        Me.LineShape1.Y2 = 54
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 11.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(789, 697)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.stlStatus)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(711, 34)
        Me.Name = "Form1"
        Me.Text = "easy Harmony"
        Me.pnlSequenzer.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.scrlTempo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkHatAuftakt As System.Windows.Forms.CheckBox
    Friend WithEvents chkHatSchlussakkord As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSequenzer As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTonartDur As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents scrlTempo As System.Windows.Forms.TrackBar
    Friend WithEvents lblTempo As System.Windows.Forms.Label
    Friend WithEvents DebugToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TaktEingabe1 As easy_Harmony.TaktEingabe
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents stlStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents Steuerleiste1 As easy_Harmony.Steuerleiste
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents kpfPlay As easy_Harmony.Knopf
    Friend WithEvents kpfStop As easy_Harmony.Knopf
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Steuerleiste2 As easy_Harmony.Steuerleiste
    Friend WithEvents kpfTonartRunter As easy_Harmony.Knopf
    Friend WithEvents kpfTonartHoch As easy_Harmony.Knopf
    Friend WithEvents kpf4Takt As easy_Harmony.Knopf
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbl_Akkordhead As System.Windows.Forms.Label
    Friend WithEvents lbl_MelodieHead As System.Windows.Forms.Label
    Friend WithEvents VersionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AufUpdatePrüfenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutomatischeUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HilfeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NachrichtAnDenSupportSendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AudioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstrumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KlavierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GitarreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernBetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LadenBetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIDIExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÜberwachungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkAlleTakteSpielen As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTitel As System.Windows.Forms.Label
    Friend WithEvents cboSpiele_bisTakt As System.Windows.Forms.ComboBox
    Friend WithEvents cboSpiele_vonTakt As System.Windows.Forms.ComboBox
    Friend WithEvents rbMoll As System.Windows.Forms.RadioButton
    Friend WithEvents rbDur As System.Windows.Forms.RadioButton
    Friend WithEvents MIDIExportBetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIDIInstrumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DummyMidiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIDIGeneratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape10 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape9 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape8 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape7 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents RaiseFehlerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BehandelterFehlerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
