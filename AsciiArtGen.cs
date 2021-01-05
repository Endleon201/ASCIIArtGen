// ASCII Art Generator
// .NET Windows GUI desktop application version (v0.80)
// Ported from the original ASP.NET web application from
// Code Project article "ASCII Art Generator"
// http://www.codeproject.com/aspnet/AsciiArt.asp
// Ported by David Luu
// http://www.parsingprose.com

// Credits to the original work:
/*                           ASCII Art Generator Web Page
 *                           ============================
 *                     Created by Sau Fan Lee (wraith10@yahoo.com)
 *                        Copyleft (c) 2005 Sau Fan Lee (GPL)
 *                                All rights granted.
 *
 * (But please include this Credits section if you want to use it for your own apps.)
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;	//for launching scripts & help files
using System.IO;			//for saving ASCII text output to a file & browsing for images
using AsciiArt;				//Image to ASCII art conversion library

namespace Ascii
{
	/// <summary>
	/// ASCII Art Generator GUI
	/// </summary>
	public class AsciiArtGen : System.Windows.Forms.Form
	{
		//non-GUI program components
		private ImageToText AsciiArtist = null; //used to generate ASCII art from image
		private System.Windows.Forms.OpenFileDialog ofd;
		private string currDir; //specifies the current directory of this GUI program

		//GUI components
		private System.Windows.Forms.TextBox txtImageFile;
		private System.Windows.Forms.Label lblImageFile;
		private System.Windows.Forms.Button btnImageFile;
		private System.Windows.Forms.GroupBox AsciiOptGrp;
		private System.Windows.Forms.CheckBox chkUseAlpha;
		private System.Windows.Forms.CheckBox chkUseNum;
		private System.Windows.Forms.CheckBox chkUseBasic;
		private System.Windows.Forms.CheckBox chkUseExtended;
		private System.Windows.Forms.CheckBox chkUseBlock;
		private System.Windows.Forms.GroupBox CharSetGrp;
		private System.Windows.Forms.CheckBox chkUseFixed;
		private System.Windows.Forms.Label lblFixedChars;
		private System.Windows.Forms.TextBox txtFixedChars;
		private System.Windows.Forms.Button btnResetFixedChars;
		private System.Windows.Forms.ComboBox txtFontSize;
		private System.Windows.Forms.GroupBox ColorsGrp;
		private System.Windows.Forms.RadioButton radSingleColor;
		private System.Windows.Forms.RadioButton radMultiColor;
		private System.Windows.Forms.RadioButton chkGrayScale;
		private System.Windows.Forms.Label lblBackColor;
		private System.Windows.Forms.GroupBox OutOptGrp;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.RadioButton chkTextOnly;
		private System.Windows.Forms.RadioButton chkHTML;
		private System.Windows.Forms.Button btnAsciiFy;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.ComboBox radScale;
		private System.Windows.Forms.ComboBox txtBackColor;
		private System.Windows.Forms.ComboBox txtForeColor;
		private System.Windows.Forms.CheckBox savOver;
		private System.Windows.Forms.RadioButton sav2src;
		private System.Windows.Forms.GroupBox fileIOptGrp;
		private System.Windows.Forms.RadioButton sav2app;
		private System.Windows.Forms.Label srcOpts;
		private System.Windows.Forms.Label destOpts;
		private System.Windows.Forms.Button viewImgBtn;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AsciiArtGen()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.ofd = new OpenFileDialog();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsciiArtGen));
            this.txtImageFile = new System.Windows.Forms.TextBox();
            this.lblImageFile = new System.Windows.Forms.Label();
            this.btnImageFile = new System.Windows.Forms.Button();
            this.AsciiOptGrp = new System.Windows.Forms.GroupBox();
            this.chkUseBlock = new System.Windows.Forms.CheckBox();
            this.chkUseExtended = new System.Windows.Forms.CheckBox();
            this.chkUseBasic = new System.Windows.Forms.CheckBox();
            this.chkUseNum = new System.Windows.Forms.CheckBox();
            this.chkUseAlpha = new System.Windows.Forms.CheckBox();
            this.CharSetGrp = new System.Windows.Forms.GroupBox();
            this.txtFontSize = new System.Windows.Forms.ComboBox();
            this.btnResetFixedChars = new System.Windows.Forms.Button();
            this.txtFixedChars = new System.Windows.Forms.TextBox();
            this.lblFixedChars = new System.Windows.Forms.Label();
            this.chkUseFixed = new System.Windows.Forms.CheckBox();
            this.ColorsGrp = new System.Windows.Forms.GroupBox();
            this.txtForeColor = new System.Windows.Forms.ComboBox();
            this.txtBackColor = new System.Windows.Forms.ComboBox();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.chkGrayScale = new System.Windows.Forms.RadioButton();
            this.radMultiColor = new System.Windows.Forms.RadioButton();
            this.radSingleColor = new System.Windows.Forms.RadioButton();
            this.OutOptGrp = new System.Windows.Forms.GroupBox();
            this.chkHTML = new System.Windows.Forms.RadioButton();
            this.chkTextOnly = new System.Windows.Forms.RadioButton();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.radScale = new System.Windows.Forms.ComboBox();
            this.btnAsciiFy = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.savOver = new System.Windows.Forms.CheckBox();
            this.sav2src = new System.Windows.Forms.RadioButton();
            this.fileIOptGrp = new System.Windows.Forms.GroupBox();
            this.viewImgBtn = new System.Windows.Forms.Button();
            this.destOpts = new System.Windows.Forms.Label();
            this.srcOpts = new System.Windows.Forms.Label();
            this.sav2app = new System.Windows.Forms.RadioButton();
            this.AsciiOptGrp.SuspendLayout();
            this.CharSetGrp.SuspendLayout();
            this.ColorsGrp.SuspendLayout();
            this.OutOptGrp.SuspendLayout();
            this.fileIOptGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtImageFile
            // 
            this.txtImageFile.Location = new System.Drawing.Point(80, 56);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.Size = new System.Drawing.Size(440, 20);
            this.txtImageFile.TabIndex = 0;
            // 
            // lblImageFile
            // 
            this.lblImageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageFile.Location = new System.Drawing.Point(8, 56);
            this.lblImageFile.Name = "lblImageFile";
            this.lblImageFile.Size = new System.Drawing.Size(64, 16);
            this.lblImageFile.TabIndex = 1;
            this.lblImageFile.Text = "Image Path";
            // 
            // btnImageFile
            // 
            this.btnImageFile.Location = new System.Drawing.Point(528, 56);
            this.btnImageFile.Name = "btnImageFile";
            this.btnImageFile.Size = new System.Drawing.Size(75, 23);
            this.btnImageFile.TabIndex = 2;
            this.btnImageFile.Text = "Browse";
            this.btnImageFile.Click += new System.EventHandler(this.btnImageFile_Click);
            // 
            // AsciiOptGrp
            // 
            this.AsciiOptGrp.Controls.Add(this.chkUseBlock);
            this.AsciiOptGrp.Controls.Add(this.chkUseExtended);
            this.AsciiOptGrp.Controls.Add(this.chkUseBasic);
            this.AsciiOptGrp.Controls.Add(this.chkUseNum);
            this.AsciiOptGrp.Controls.Add(this.chkUseAlpha);
            this.AsciiOptGrp.Location = new System.Drawing.Point(8, 192);
            this.AsciiOptGrp.Name = "AsciiOptGrp";
            this.AsciiOptGrp.Size = new System.Drawing.Size(616, 120);
            this.AsciiOptGrp.TabIndex = 3;
            this.AsciiOptGrp.TabStop = false;
            this.AsciiOptGrp.Text = "Ascii Options";
            // 
            // chkUseBlock
            // 
            this.chkUseBlock.Location = new System.Drawing.Point(168, 88);
            this.chkUseBlock.Name = "chkUseBlock";
            this.chkUseBlock.Size = new System.Drawing.Size(408, 24);
            this.chkUseBlock.TabIndex = 9;
            this.chkUseBlock.Text = "Use Block Symbols (Unicode symbols: Blocks, pipes, etc.)";
            // 
            // chkUseExtended
            // 
            this.chkUseExtended.Location = new System.Drawing.Point(168, 56);
            this.chkUseExtended.Name = "chkUseExtended";
            this.chkUseExtended.Size = new System.Drawing.Size(408, 24);
            this.chkUseExtended.TabIndex = 8;
            this.chkUseExtended.Text = "Use Extended Symbols (Non-Unicode symbols, Font-dependent brightness)";
            // 
            // chkUseBasic
            // 
            this.chkUseBasic.Location = new System.Drawing.Point(168, 24);
            this.chkUseBasic.Name = "chkUseBasic";
            this.chkUseBasic.Size = new System.Drawing.Size(392, 24);
            this.chkUseBasic.TabIndex = 7;
            this.chkUseBasic.Text = "Use Basic Symbols (Non-Unicode symbols, Font-independent brightness)";
            // 
            // chkUseNum
            // 
            this.chkUseNum.Checked = true;
            this.chkUseNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseNum.Location = new System.Drawing.Point(16, 56);
            this.chkUseNum.Name = "chkUseNum";
            this.chkUseNum.Size = new System.Drawing.Size(120, 24);
            this.chkUseNum.TabIndex = 6;
            this.chkUseNum.Text = "Use Numbers (0-9)";
            // 
            // chkUseAlpha
            // 
            this.chkUseAlpha.Checked = true;
            this.chkUseAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseAlpha.Location = new System.Drawing.Point(16, 24);
            this.chkUseAlpha.Name = "chkUseAlpha";
            this.chkUseAlpha.Size = new System.Drawing.Size(152, 24);
            this.chkUseAlpha.TabIndex = 5;
            this.chkUseAlpha.Text = "Use Alphabets (A-Z, a-z)";
            // 
            // CharSetGrp
            // 
            this.CharSetGrp.Controls.Add(this.txtFontSize);
            this.CharSetGrp.Controls.Add(this.btnResetFixedChars);
            this.CharSetGrp.Controls.Add(this.txtFixedChars);
            this.CharSetGrp.Controls.Add(this.lblFixedChars);
            this.CharSetGrp.Controls.Add(this.chkUseFixed);
            this.CharSetGrp.Location = new System.Drawing.Point(8, 320);
            this.CharSetGrp.Name = "CharSetGrp";
            this.CharSetGrp.Size = new System.Drawing.Size(616, 104);
            this.CharSetGrp.TabIndex = 6;
            this.CharSetGrp.TabStop = false;
            this.CharSetGrp.Text = "Ascii Character Set Options";
            // 
            // txtFontSize
            // 
            this.txtFontSize.Items.AddRange(new object[] {
            "6",
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16"});
            this.txtFontSize.Location = new System.Drawing.Point(448, 24);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(121, 21);
            this.txtFontSize.TabIndex = 4;
            this.txtFontSize.Text = "Select Font Size";
            // 
            // btnResetFixedChars
            // 
            this.btnResetFixedChars.Location = new System.Drawing.Point(528, 64);
            this.btnResetFixedChars.Name = "btnResetFixedChars";
            this.btnResetFixedChars.Size = new System.Drawing.Size(75, 23);
            this.btnResetFixedChars.TabIndex = 3;
            this.btnResetFixedChars.Text = "Reset";
            this.btnResetFixedChars.Click += new System.EventHandler(this.btnResetFixedChars_Click);
            // 
            // txtFixedChars
            // 
            this.txtFixedChars.Enabled = false;
            this.txtFixedChars.Location = new System.Drawing.Point(128, 64);
            this.txtFixedChars.Name = "txtFixedChars";
            this.txtFixedChars.Size = new System.Drawing.Size(384, 20);
            this.txtFixedChars.TabIndex = 2;
            // 
            // lblFixedChars
            // 
            this.lblFixedChars.Location = new System.Drawing.Point(16, 64);
            this.lblFixedChars.Name = "lblFixedChars";
            this.lblFixedChars.Size = new System.Drawing.Size(112, 16);
            this.lblFixedChars.TabIndex = 1;
            this.lblFixedChars.Text = "Fixed Character Set";
            // 
            // chkUseFixed
            // 
            this.chkUseFixed.Location = new System.Drawing.Point(16, 24);
            this.chkUseFixed.Name = "chkUseFixed";
            this.chkUseFixed.Size = new System.Drawing.Size(392, 24);
            this.chkUseFixed.TabIndex = 0;
            this.chkUseFixed.Text = "Used Fixed Character Set (Use the following characters instead of above)";
            this.chkUseFixed.CheckedChanged += new System.EventHandler(this.chkUseFixed_CheckedChanged);
            // 
            // ColorsGrp
            // 
            this.ColorsGrp.Controls.Add(this.txtForeColor);
            this.ColorsGrp.Controls.Add(this.txtBackColor);
            this.ColorsGrp.Controls.Add(this.lblBackColor);
            this.ColorsGrp.Controls.Add(this.chkGrayScale);
            this.ColorsGrp.Controls.Add(this.radMultiColor);
            this.ColorsGrp.Controls.Add(this.radSingleColor);
            this.ColorsGrp.Location = new System.Drawing.Point(8, 432);
            this.ColorsGrp.Name = "ColorsGrp";
            this.ColorsGrp.Size = new System.Drawing.Size(616, 88);
            this.ColorsGrp.TabIndex = 7;
            this.ColorsGrp.TabStop = false;
            this.ColorsGrp.Text = "Colors & Aliasing";
            // 
            // txtForeColor
            // 
            this.txtForeColor.Enabled = false;
            this.txtForeColor.Items.AddRange(new object[] {
            "Black",
            "Brown",
            "Gray",
            "Orange",
            "Red",
            "Blue",
            "Green",
            "White"});
            this.txtForeColor.Location = new System.Drawing.Point(152, 48);
            this.txtForeColor.Name = "txtForeColor";
            this.txtForeColor.Size = new System.Drawing.Size(121, 21);
            this.txtForeColor.TabIndex = 5;
            this.txtForeColor.Text = "Select Fore Color";
            // 
            // txtBackColor
            // 
            this.txtBackColor.Items.AddRange(new object[] {
            "Black",
            "Brown",
            "Gray",
            "Orange",
            "Red",
            "Blue",
            "Green",
            "White"});
            this.txtBackColor.Location = new System.Drawing.Point(152, 16);
            this.txtBackColor.Name = "txtBackColor";
            this.txtBackColor.Size = new System.Drawing.Size(121, 21);
            this.txtBackColor.TabIndex = 4;
            this.txtBackColor.Text = "Select Color";
            // 
            // lblBackColor
            // 
            this.lblBackColor.Location = new System.Drawing.Point(16, 24);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(100, 16);
            this.lblBackColor.TabIndex = 3;
            this.lblBackColor.Text = "Background Color";
            // 
            // chkGrayScale
            // 
            this.chkGrayScale.Location = new System.Drawing.Point(312, 56);
            this.chkGrayScale.Name = "chkGrayScale";
            this.chkGrayScale.Size = new System.Drawing.Size(208, 16);
            this.chkGrayScale.TabIndex = 2;
            this.chkGrayScale.Text = "Use Multiple Font Colors - grayscale";
            this.chkGrayScale.CheckedChanged += new System.EventHandler(this.chkGrayScale_CheckedChanged);
            // 
            // radMultiColor
            // 
            this.radMultiColor.Checked = true;
            this.radMultiColor.Location = new System.Drawing.Point(312, 24);
            this.radMultiColor.Name = "radMultiColor";
            this.radMultiColor.Size = new System.Drawing.Size(208, 16);
            this.radMultiColor.TabIndex = 1;
            this.radMultiColor.TabStop = true;
            this.radMultiColor.Text = "Use Multiple Font Colors - Full color";
            this.radMultiColor.CheckedChanged += new System.EventHandler(this.radMultiColor_CheckedChanged);
            // 
            // radSingleColor
            // 
            this.radSingleColor.Location = new System.Drawing.Point(16, 56);
            this.radSingleColor.Name = "radSingleColor";
            this.radSingleColor.Size = new System.Drawing.Size(136, 16);
            this.radSingleColor.TabIndex = 0;
            this.radSingleColor.Text = "Use Single Font Color";
            this.radSingleColor.CheckedChanged += new System.EventHandler(this.radSingleColor_CheckedChanged);
            // 
            // OutOptGrp
            // 
            this.OutOptGrp.Controls.Add(this.chkHTML);
            this.OutOptGrp.Controls.Add(this.chkTextOnly);
            this.OutOptGrp.Controls.Add(this.txtHeight);
            this.OutOptGrp.Controls.Add(this.txtWidth);
            this.OutOptGrp.Controls.Add(this.lblHeight);
            this.OutOptGrp.Controls.Add(this.lblWidth);
            this.OutOptGrp.Controls.Add(this.radScale);
            this.OutOptGrp.Location = new System.Drawing.Point(8, 528);
            this.OutOptGrp.Name = "OutOptGrp";
            this.OutOptGrp.Size = new System.Drawing.Size(616, 96);
            this.OutOptGrp.TabIndex = 8;
            this.OutOptGrp.TabStop = false;
            this.OutOptGrp.Text = "Output Options";
            // 
            // chkHTML
            // 
            this.chkHTML.Checked = true;
            this.chkHTML.Location = new System.Drawing.Point(392, 24);
            this.chkHTML.Name = "chkHTML";
            this.chkHTML.Size = new System.Drawing.Size(80, 24);
            this.chkHTML.TabIndex = 10;
            this.chkHTML.TabStop = true;
            this.chkHTML.Text = "HTML text";
            this.chkHTML.CheckedChanged += new System.EventHandler(this.chkHTML_CheckedChanged);
            // 
            // chkTextOnly
            // 
            this.chkTextOnly.Location = new System.Drawing.Point(272, 24);
            this.chkTextOnly.Name = "chkTextOnly";
            this.chkTextOnly.Size = new System.Drawing.Size(104, 24);
            this.chkTextOnly.TabIndex = 9;
            this.chkTextOnly.Text = "Plain Text Only";
            this.chkTextOnly.CheckedChanged += new System.EventHandler(this.chkTextOnly_CheckedChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(184, 24);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(56, 20);
            this.txtHeight.TabIndex = 8;
            this.txtHeight.Text = "100";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(56, 24);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(56, 20);
            this.txtWidth.TabIndex = 7;
            this.txtWidth.Text = "100";
            // 
            // lblHeight
            // 
            this.lblHeight.Location = new System.Drawing.Point(136, 24);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(40, 16);
            this.lblHeight.TabIndex = 6;
            this.lblHeight.Text = "Height";
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(16, 24);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(40, 16);
            this.lblWidth.TabIndex = 5;
            this.lblWidth.Text = "Width";
            // 
            // radScale
            // 
            this.radScale.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.radScale.Location = new System.Drawing.Point(16, 56);
            this.radScale.Name = "radScale";
            this.radScale.Size = new System.Drawing.Size(216, 21);
            this.radScale.TabIndex = 4;
            this.radScale.Text = "Select Anti-Alias Down-Scaling Factor";
            // 
            // btnAsciiFy
            // 
            this.btnAsciiFy.Location = new System.Drawing.Point(40, 640);
            this.btnAsciiFy.Name = "btnAsciiFy";
            this.btnAsciiFy.Size = new System.Drawing.Size(120, 23);
            this.btnAsciiFy.TabIndex = 9;
            this.btnAsciiFy.Text = "ASCII-fy Image";
            this.btnAsciiFy.Click += new System.EventHandler(this.btnAsciiFy_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(408, 640);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(120, 23);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "About this Program";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(256, 640);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // savOver
            // 
            this.savOver.Location = new System.Drawing.Point(240, 112);
            this.savOver.Name = "savOver";
            this.savOver.Size = new System.Drawing.Size(240, 24);
            this.savOver.TabIndex = 12;
            this.savOver.Text = "Don\'t prompt when overwriting output files";
            // 
            // sav2src
            // 
            this.sav2src.Checked = true;
            this.sav2src.Location = new System.Drawing.Point(16, 112);
            this.sav2src.Name = "sav2src";
            this.sav2src.Size = new System.Drawing.Size(168, 24);
            this.sav2src.TabIndex = 13;
            this.sav2src.TabStop = true;
            this.sav2src.Text = "Save to image source folder";
            this.sav2src.CheckedChanged += new System.EventHandler(this.sav2src_CheckedChanged);
            // 
            // fileIOptGrp
            // 
            this.fileIOptGrp.Controls.Add(this.viewImgBtn);
            this.fileIOptGrp.Controls.Add(this.destOpts);
            this.fileIOptGrp.Controls.Add(this.srcOpts);
            this.fileIOptGrp.Controls.Add(this.sav2app);
            this.fileIOptGrp.Controls.Add(this.lblImageFile);
            this.fileIOptGrp.Controls.Add(this.txtImageFile);
            this.fileIOptGrp.Controls.Add(this.btnImageFile);
            this.fileIOptGrp.Controls.Add(this.sav2src);
            this.fileIOptGrp.Controls.Add(this.savOver);
            this.fileIOptGrp.Location = new System.Drawing.Point(8, 8);
            this.fileIOptGrp.Name = "fileIOptGrp";
            this.fileIOptGrp.Size = new System.Drawing.Size(616, 176);
            this.fileIOptGrp.TabIndex = 14;
            this.fileIOptGrp.TabStop = false;
            this.fileIOptGrp.Text = "Ascii Art Input/Output Options";
            // 
            // viewImgBtn
            // 
            this.viewImgBtn.Location = new System.Drawing.Point(496, 16);
            this.viewImgBtn.Name = "viewImgBtn";
            this.viewImgBtn.Size = new System.Drawing.Size(104, 23);
            this.viewImgBtn.TabIndex = 17;
            this.viewImgBtn.Text = "View Input Image";
            this.viewImgBtn.Click += new System.EventHandler(this.viewImgBtn_Click);
            // 
            // destOpts
            // 
            this.destOpts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destOpts.Location = new System.Drawing.Point(8, 88);
            this.destOpts.Name = "destOpts";
            this.destOpts.Size = new System.Drawing.Size(100, 16);
            this.destOpts.TabIndex = 16;
            this.destOpts.Text = "Output Options";
            // 
            // srcOpts
            // 
            this.srcOpts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcOpts.Location = new System.Drawing.Point(8, 24);
            this.srcOpts.Name = "srcOpts";
            this.srcOpts.Size = new System.Drawing.Size(144, 16);
            this.srcOpts.TabIndex = 15;
            this.srcOpts.Text = "Art or Image Input Options";
            // 
            // sav2app
            // 
            this.sav2app.Location = new System.Drawing.Point(16, 144);
            this.sav2app.Name = "sav2app";
            this.sav2app.Size = new System.Drawing.Size(216, 24);
            this.sav2app.TabIndex = 14;
            this.sav2app.Text = "Save to this application\'s output folder";
            this.sav2app.CheckedChanged += new System.EventHandler(this.sav2app_CheckedChanged);
            // 
            // AsciiArtGen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 686);
            this.Controls.Add(this.fileIOptGrp);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnAsciiFy);
            this.Controls.Add(this.OutOptGrp);
            this.Controls.Add(this.ColorsGrp);
            this.Controls.Add(this.CharSetGrp);
            this.Controls.Add(this.AsciiOptGrp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AsciiArtGen";
            this.Text = "ASCII Art Generator";
            this.Load += new System.EventHandler(this.AsciiArtGen_Load);
            this.AsciiOptGrp.ResumeLayout(false);
            this.CharSetGrp.ResumeLayout(false);
            this.CharSetGrp.PerformLayout();
            this.ColorsGrp.ResumeLayout(false);
            this.OutOptGrp.ResumeLayout(false);
            this.OutOptGrp.PerformLayout();
            this.fileIOptGrp.ResumeLayout(false);
            this.fileIOptGrp.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new AsciiArtGen());
		}

		#region Methods for Creating/Destroying Image To ASCII Converter

		private bool CreateImageConverter (string imagePath, bool useCurrentSettings) 
		{
			// Create/Get ASCII Art Converter.
			try 
			{
				AsciiArtist = new ImageToText (imagePath);
			} 
			catch (FileNotFoundException) 
			{
				MessageBox.Show("Cannot find image file at: " + txtImageFile.Text,"Error");
				return (false);
			} 
			catch (Exception exc) 
			{
				MessageBox.Show(exc.Message,"Error");
				return (false);
			}

			// Configuration settings of ASCII Art Converter.
			if (useCurrentSettings) 
			{
				// Set ASCII characters to use for ASCII art
				AsciiArtist.UseAlpabets = chkUseAlpha.Checked;
				AsciiArtist.UseNumbers = chkUseNum.Checked;
				AsciiArtist.UseBasicSymbols = chkUseBasic.Checked;
				AsciiArtist.UseExtendedSymbols = chkUseExtended.Checked;
				AsciiArtist.UseBlockSymbols = chkUseBlock.Checked;
				AsciiArtist.UseFixedChars = chkUseFixed.Checked;
				AsciiArtist.FixedChars = txtFixedChars.Text.ToCharArray();

				// Set ASCII text font size
				try 
				{
					if(txtFontSize.SelectedItem != null)
					{
						AsciiArtist.FontSize = (int) UInt16.Parse (txtFontSize.SelectedItem.ToString());
					}
					else
					{
						//default font size = 6 pt
						AsciiArtist.FontSize = (int) UInt16.Parse ("6");
					}
				} 
				catch 
				{
					MessageBox.Show("Invalid font size! Reset to default value.","Error");
				}

				// Set Background color (HTML ASCII art only)
				if(txtBackColor.SelectedItem != null)
				{
					AsciiArtist.BackColor = txtBackColor.SelectedItem.ToString();
				}
				else
				{
					//default background color
					AsciiArtist.BackColor = "White";
				}

				// Set Foreground or text color (HTML ASCII art only)
				if(txtForeColor.SelectedItem != null)
				{
					AsciiArtist.FontColor = txtForeColor.SelectedItem.ToString();
				}
				else
				{
					//default foreground or text color
					AsciiArtist.FontColor = "Black";
				}

				// Set color gradient
				AsciiArtist.UseColors = radMultiColor.Checked;
				AsciiArtist.IsGrayScale = chkGrayScale.Checked;
				if(chkGrayScale.Checked)
				{
					//Grayscale = use more than 1 color or use gradient
					AsciiArtist.UseColors = true;
				}

				// Set ASCII text output as HTML or text
				AsciiArtist.IsHtmlOutput = !chkTextOnly.Checked;
			}
			return (true);
		}

		// Dispose ImageToText object.
		private void DestroyImageConverter() 
		{
			if (AsciiArtist != null) 
			{
				AsciiArtist.Dispose();
				AsciiArtist = null;
			}
		}

		#endregion

		#region Methods for Image To ASCII Conversions

		// Convert image to ascii text-image using ImageToText object.
		private string GetAsciiImage (bool useBlock) 
		{
			if (AsciiArtist == null) return (null);;
			int width = -1;
			int height = -1;
			int scale = 1;

			// Retrieve image width.
			if (txtWidth.Text != "") 
			{
				string val = txtWidth.Text;
				bool isPercent = false;

				if (val.EndsWith ("%")) 
				{
					isPercent = true;
					val = val.Substring (0, val.Length - 1);
				}

				try 
				{
					width = (int) UInt16.Parse (val);

					if (isPercent) 
					{
						width = AsciiArtist.ImageWidth * width / 100;
						txtWidth.Text = width.ToString();
					}
				} 
				catch 
				{
					width = AsciiArtist.ImageWidth;
					txtWidth.Text = width.ToString();
					MessageBox.Show("Invalid image width! Reset to default value.","Error");
				}
			}

			// Retrieve image height.
			if (txtHeight.Text != "") 
			{
				string val = txtHeight.Text;
				bool isPercent = false;

				if (val.EndsWith ("%")) 
				{
					isPercent = true;
					val = val.Substring (0, val.Length - 1);
				}

				try 
				{
					height = (int) UInt16.Parse (val);

					if (isPercent) 
					{
						height = AsciiArtist.ImageHeight * height / 100;
						txtHeight.Text = height.ToString();
					}
				} 
				catch 
				{
					height = AsciiArtist.ImageHeight;
					txtHeight.Text = height.ToString();
					MessageBox.Show("Invalid image height! Reset to default value.","Error");
				}
			}

			// Validate image width & height.
			if ((txtWidth.Text == "") && (txtHeight.Text == "")) 
			{
				width = AsciiArtist.ImageWidth;
				height = AsciiArtist.ImageHeight;
				txtWidth.Text = width.ToString();
				txtHeight.Text = height.ToString();
			} 
			else if (txtWidth.Text == "") 
			{
				width = height * AsciiArtist.ImageWidth / AsciiArtist.ImageHeight;
				txtWidth.Text = width.ToString();
			} 
			else if (txtHeight.Text == "") 
			{
				height = width * AsciiArtist.ImageHeight / AsciiArtist.ImageWidth;
				txtHeight.Text = height.ToString();
			}

			// Retrieve scaling factor.
			if(radScale.SelectedItem != null)
			{
				scale = Int32.Parse (radScale.SelectedItem.ToString());
			}
			else
			{
				scale = 1;
			}
			/*
			foreach (Control comp in Form1.Controls) 
			{
				RadioButton radScale = comp as RadioButton;
				if (radScale == null) continue;
				if (!radScale.Checked) continue;
				if (radScale.ID.Length < 9) continue;
				if (!radScale.ID.StartsWith ("radScale")) continue;

				try 
				{
					scale = Int32.Parse (radScale.ID.Substring (8));
					break;
				} 
				catch {}
			}
			*/

			// Ascii-fy image.
			try 
			{
				if (radScale.SelectedItem != null) 
				{
					return (AsciiArtist.GetAsciiImage (scale, useBlock));
				} 
				else 
				{
					return (AsciiArtist.GetAsciiImage (width, height, useBlock));
				}
			} 
			catch (Exception exc) 
			{
				MessageBox.Show(exc.Message,"Error");
				return (null);
			}
		}

		#endregion

		#region Miscellaneous Methods

		// Retrieve a filename from a path or URL.
		private static string GetFileName (string filePath) 
		{
			if (filePath == null) return (null);
			int index = filePath.LastIndexOf ('?');
			if (index >= 0) filePath = filePath.Substring (0, index);
			index = filePath.LastIndexOfAny (new char[] {'/', '\\'});
			filePath = filePath.Substring (index + 1);
			return (filePath == "" ? null : filePath);
		}

		// Open ASCII output for viewing as a separate process
		// HTML = open in browser, text = open in Notepad or text editor
		private static void ViewOutput(string fileName)
		{
			Process p = null;
			try
			{
				p = new Process();
				p = Process.Start(fileName);
				//p.WaitForExit();
			}
			catch
			{				
				//do nothing
			}
		}

		#endregion

		#region Ascii Art Generator Event Handlers
		
		private void AsciiArtGen_Load(object sender, System.EventArgs e)
		{
			//Get local current working directory upon application startup
			this.currDir = Directory.GetCurrentDirectory();		
		}

		private void radMultiColor_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radMultiColor.Checked)
			{
				//disable single color selection
				radSingleColor.Checked = false;
				txtForeColor.Enabled = false;
				chkGrayScale.Checked = false;
			}
		}

		private void chkGrayScale_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkGrayScale.Checked)
			{
				//disable single color selection
				radSingleColor.Checked = false;
				txtForeColor.Enabled = false;
				radMultiColor.Checked = false;
			}		
		}

		private void radSingleColor_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radSingleColor.Checked)
			{
				//disable multi-color selection
				radMultiColor.Checked = false;
				chkGrayScale.Checked = false;
				//enable single color selection
				txtForeColor.Enabled = true;
			}
		}

		private void chkUseFixed_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkUseFixed.Checked)
			{
				txtFixedChars.Enabled = true;
			}
			else
			{
				txtFixedChars.Enabled = false;
			}
		}

		private void btnResetFixedChars_Click(object sender, System.EventArgs e)
		{
			txtFixedChars.Text = "";
		}

		private void chkTextOnly_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkTextOnly.Checked)
			{
				//diable HTML output
				chkHTML.Checked = false;
			}		
		}

		private void chkHTML_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkHTML.Checked)
			{
				//disable text output
				chkTextOnly.Checked = false;
			}
		}

		private void sav2src_CheckedChanged(object sender, System.EventArgs e)
		{
			if(sav2src.Checked)
			{
				//unselect save to application output folder
				sav2app.Checked = false;
			}
		}

		private void sav2app_CheckedChanged(object sender, System.EventArgs e)
		{
			if(sav2app.Checked)
			{
				//unselect save to source image folder
				sav2src.Checked = false;
			}		
		}

		private void btnImageFile_Click(object sender, System.EventArgs e)
		{
			//set file format filter for image selection
			this.ofd.Filter = "All formats (*.*)|*.*"
				+ "|Bitmap Image (*.bmp)|*.bmp"
				+ "|GIF Image (*.gif)|*.gif"
				+ "|JPEG Image (*.jpg)|*.jpg"				
				+ "|PNG Image (*.png)|*.png"
				+ "|TIFF Image (*.tif)|*.tif";
			this.ofd.FilterIndex = 1;

			//show file open dialog
			if(this.ofd.ShowDialog() == DialogResult.OK)
				txtImageFile.Text = this.ofd.FileName;
			else
				txtImageFile.Text = "";
		}

		private void btnAsciiFy_Click(object sender, System.EventArgs e)
		{
			//Begin ASCII-fy process
			try
			{
				//Generate ASCII image
				CreateImageConverter (txtImageFile.Text, true);
				
				bool isHtml = !chkTextOnly.Checked;
				//string ascii = GetAsciiImage (isHtml || isView);
				string ascii = GetAsciiImage (true);
				string newLine = (isHtml ? AsciiArtist.HtmlNewLine : AsciiArtist.TextNewLine);
				int size = AsciiArtist.FontSize;
				DestroyImageConverter();
				if (ascii == null) return;
	
				//Get input image file name
				string srcDir = Directory.GetParent(txtImageFile.Text).ToString();
				string fileName = txtImageFile.Text.Substring(srcDir.Length+1);
				//Debug code
				//MessageBox.Show(fileName,"fileName");
				//return;

				//Set up HTML tags to encapsulate HTML ASCII output
				string foreColor, backColor;
				// Set Background color
				if(txtBackColor.SelectedItem != null)
				{
					backColor = txtBackColor.SelectedItem.ToString();
				}
				else
				{
					//default background color
					backColor = "White";
				}

				// Set Foreground or text color
				if(txtForeColor.SelectedItem != null)
				{
					foreColor = txtForeColor.SelectedItem.ToString();
				}
				else
				{
					//default foreground or text color
					foreColor = "Black";
				}
				string startHtml = "<html>" + newLine + "<head>" + newLine 
					+ "<title>ASCII Image</title>" 
					+ newLine + "</head>" + newLine 
					+ "<body bgcolor='" + backColor 
					+ "' text='" + foreColor + "'>"
					+ newLine + "<div align='center'><br>";
				string endHtml = "</div>" + newLine + "</body>" + newLine + "</html>";

				//Determine output filename from input filename
				int extIndex = fileName.LastIndexOf(".");
				int fileNameLen = fileName.Length;
				int extLen = fileNameLen - extIndex;
				fileName = fileName.Substring(0,fileNameLen-extLen);
				fileName += (isHtml ? ".htm" : ".txt");

				//Determine output file path
				string savPath = "";
				if(sav2src.Checked)
				{
					//Set save to source folder where original image resides
					int dirNameLen = txtImageFile.Text.Length;
					savPath = txtImageFile.Text.Substring(0,dirNameLen-fileNameLen);
				}
				else
				{
					//Set save to this applications output subfolder
					savPath = this.currDir + @"\Output\";
				}
				string outFile = savPath + fileName;

				//Debug code
				//MessageBox.Show(fileName,"file is");
				//MessageBox.Show(outFile,"save to");

				//Save output to file
				DialogResult result;
				if (File.Exists(outFile)) 
				{
					//if file exists, prompt user if wish to overwrite
					//UNLESS overwrite flag checked in GUI
					if(savOver.Checked)
					{
						result = DialogResult.OK;
					}
					else
					{
						result = MessageBox.Show(outFile+" already exists, overwrite? Click OK to overwrite or Cancel to abort.","Warning",MessageBoxButtons.OKCancel);
					}
					if(result == DialogResult.OK)
					{
						using (StreamWriter sw = new StreamWriter(outFile)) 
						{
							if (isHtml) 
							{
								sw.WriteLine(startHtml);
								sw.WriteLine(ascii);
								sw.WriteLine(endHtml);
							}
							else
							{
								sw.WriteLine(ascii);
							}
						}
						//View output after ASCII-fy
						ViewOutput(outFile);
					}
				}
				else
				{ 
					//file not exist, save to a new file
					StreamWriter sr = File.CreateText(outFile);
					if (isHtml) 
					{
						sr.WriteLine(startHtml);
						sr.WriteLine(ascii);
						sr.WriteLine(endHtml);
					}
					else
					{
						sr.WriteLine(ascii);
					}
					sr.Close();
					//View output after ASCII-fy
					ViewOutput(outFile);
				}
				//Debug code
				//MessageBox.Show(ascii,"Debug Output");
			}
			catch
			{
				MessageBox.Show("Could not ASCII-fy","Error");
			}		
		}

		private void btnHelp_Click(object sender, System.EventArgs e)
		{
			//Launch help file in browser as a new process
			Process p = null;
			try
			{
				p = new Process();
				p = Process.Start(this.currDir+"\\asciiArtGenHelp.htm");
				//p.WaitForExit();
			}
			catch
			{				
				MessageBox.Show("Could not launch the help file","Error");
			}
		}

		private void btnAbout_Click(object sender, System.EventArgs e)
		{
			//Specify & display "About" information
			string aboutInfo = "ASCII Art Generator\n" + 
				".NET Windows GUI desktop application version (v0.8)\n" +
				"Ported by David Luu\n" +
				"http://www.parsingprose.com\n\n" +
				"Original version information: \n\n" +
				"ASCII Art Generator  v1.3 Beta\n" +
                " ===================\n" +
                "Copyleft (c) Sau Fan Lee '2005\n\n" +
                "Email: wraith10@yahoo.com\n" +
                "License: GNU Public License (GPL)\n" +
				"CodeProject article \"ASCII Art Generator\"\n" +
				"http://www.codeproject.com/aspnet/AsciiArt.asp\n";

			MessageBox.Show(aboutInfo,"About ASCII Art Generator");
		}

		#endregion

		private void viewImgBtn_Click(object sender, System.EventArgs e)
		{
			ViewOutput(txtImageFile.Text);
		}
	}
}
