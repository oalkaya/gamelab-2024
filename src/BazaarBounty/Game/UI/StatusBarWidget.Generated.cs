/* Generated by MyraPad at 2024/4/14 16:49:36 */

using System.Collections.Generic;
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI.Properties;
using FontStashSharp.RichText;
using AssetManagementBase;
using FontStashSharp;

#if STRIDE
using Stride.Core.Mathematics;
#elif PLATFORM_AGNOSTIC
using System.Drawing;
using System.Numerics;
using Color = FontStashSharp.FSColor;
#else
// MonoGame/FNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endif

namespace BazaarBounty
{
	partial class StatusBarWidget: Panel
	{
		private void BuildUI()
		{
			// preload buff icons and fonts
			foreach (var buff in BuffFactory.buffNames)
			{
				buffIconMap[buff] = MyraEnvironment.DefaultAssetManager.LoadTextureRegion($"images/fruits/{buff}2.png");
			}
			for (int i = 0; i < 4; ++i)
			{
				bulletImage[i] = MyraEnvironment.DefaultAssetManager.LoadTextureRegion($"images/ammo-rifle{i+1}.png");
			}
			labelFont24 = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft24.fnt");
			heartImage = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/heart.png");
			heartEmptyImage = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/heart_empty.png");
			dashImage = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/dash.png");


			var hpLabel = new Label();
			hpLabel.Text = "HP";
			hpLabel.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft48.fnt");
			hpLabel.Margin = new Thickness(20, 10, 10, 10);

			healthGrid = new Grid();
			healthGrid.ColumnSpacing = 8;
			healthGrid.RowSpacing = 8;
			healthGrid.DefaultColumnProportion = new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			};
			healthGrid.DefaultRowProportion = new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			};
			healthGrid.Margin = new Thickness(20, 0, 0, 0);

			for (int i = 0; i < 4; i++)
			{
				var image = new Image();
				image.Renderable = heartImage;
				image.Width = 64;
				image.Height = 64;
				Grid.SetRow(image, i);
				Grid.SetColumn(image, 0);
			}

			// Dash Panel
			dashPanel = new HorizontalStackPanel();
			dashPanel.Margin = new Thickness(20, 10, 10, 10);
			for (int i = 0; i < 3; i++)
			{
				var image = new Image();
				image.Renderable = dashImage;
				image.Width = 48;
				image.Height = 48;
				dashPanel.Widgets.Add(image);
			}
			
			// Attack panel
			var attackIcon = new Image();
			attackIcon.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/attack.png");
			attackIcon.Width = 48;
			attackIcon.Height = 48;
			attackLabel = new Label();
			attackLabel.Text = "10";
			attackLabel.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft48.fnt");
			attackLabel.Margin = new Thickness(10, 0, 0, 0);
			attackLabel.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;
			var attackPanel = new HorizontalStackPanel();
			attackPanel.Margin = new Thickness(20, 10, 0, 5);
			attackPanel.Widgets.Add(attackIcon);
			attackPanel.Widgets.Add(attackLabel);

			var rangedIcon = new Image();
			rangedIcon.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/ranged.png");
			rangedIcon.Width = 48;
			rangedIcon.Height = 48;
			rangedLabel = new Label();
			rangedLabel.Text = "10";
			rangedLabel.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft48.fnt");
			rangedLabel.Margin = new Thickness(10, 0, 0, 0);
			rangedLabel.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;
			var rangedPanel = new HorizontalStackPanel();
			rangedPanel.Margin = new Thickness(20, 10, 0, 5);
			rangedPanel.Widgets.Add(rangedIcon);
			rangedPanel.Widgets.Add(rangedLabel);

            // Melee defense panel
			var meleeDefIcon = new Image();
			meleeDefIcon.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/shield_with_sword_red.png");
			meleeDefIcon.Width = 48;
			meleeDefIcon.Height = 48;
			meleeDefLabel = new Label();
			meleeDefLabel.Text = "10";
			meleeDefLabel.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft48.fnt");
			meleeDefLabel.Margin = new Thickness(10, 0, 0, 0);
			meleeDefLabel.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;
			var meleeDefPanel = new HorizontalStackPanel();
			meleeDefPanel.Margin = new Thickness(20, 10, 0, 5);
			meleeDefPanel.Widgets.Add(meleeDefIcon);
			meleeDefPanel.Widgets.Add(meleeDefLabel);

            // Melee defense panel
			var rangedDefIcon = new Image();
			rangedDefIcon.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/shield_red.png");
			rangedDefIcon.Width = 48;
			rangedDefIcon.Height = 48;
			rangedDefLabel = new Label();
			rangedDefLabel.Text = "10";
			rangedDefLabel.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft48.fnt");
			rangedDefLabel.Margin = new Thickness(10, 0, 0, 0);
			rangedDefLabel.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;
			var rangedeDefPanel = new HorizontalStackPanel();
			rangedeDefPanel.Margin = new Thickness(20, 10, 0, 5);
			rangedeDefPanel.Widgets.Add(rangedDefIcon);
			rangedeDefPanel.Widgets.Add(rangedDefLabel);

			// Buff Panel
			buffGrid = new Grid();
			buffGrid.ColumnSpacing = 8;
			buffGrid.RowSpacing = 8;
			buffGrid.DefaultColumnProportion = new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			};
			buffGrid.DefaultRowProportion = new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			};
			buffGrid.Margin = new Thickness(20, 10, 0, 0);

			var leftVerticalPanel = new VerticalStackPanel();
			leftVerticalPanel.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Left;
			leftVerticalPanel.Widgets.Add(hpLabel);
			leftVerticalPanel.Widgets.Add(healthGrid);
			leftVerticalPanel.Widgets.Add(dashPanel);
			leftVerticalPanel.Widgets.Add(attackPanel);
			leftVerticalPanel.Widgets.Add(rangedPanel);
            leftVerticalPanel.Widgets.Add(meleeDefPanel);
            leftVerticalPanel.Widgets.Add(rangedeDefPanel);
			leftVerticalPanel.Widgets.Add(buffGrid);

			bulletsLabel = new Label();
			bulletsLabel.Text = "Bullets";
			bulletsLabel.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft48.fnt");
			bulletsLabel.Margin = new Thickness(10, 10, 20, 0);

			bulletsPanel = new VerticalStackPanel();
			bulletsPanel.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Right;
			bulletsPanel.Widgets.Add(bulletsLabel);
			for (int i = 0; i < 5; ++i)
			{
				var image = new Image();
				image.Renderable = bulletImage[3];
				image.Width = 84;
				image.Height = 64;
				image.Margin = new Thickness(0, 0, 20, 0);
				image.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Right;
				bulletsPanel.Widgets.Add(image);
			}

			// Input Panel
			var image9 = new Image();
			image9.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/rightbumper.png");
			image9.Width = 48;
			image9.Height = 48;
			image9.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;

			var label5 = new Label();
			label5.Text = "Melee Attack";
			label5.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft24.fnt");
			label5.TextAlign = FontStashSharp.RichText.TextHorizontalAlignment.Center;
			label5.Height = 16;
			label5.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			label5.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetColumn(label5, 1);

			var image10 = new Image();
			image10.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/leftbumper.png");
			image10.Width = 48;
			image10.Height = 48;
			image10.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetRow(image10, 1);

			var label6 = new Label();
			label6.Text = "Ranged Attack";
			label6.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft24.fnt");
			label6.TextAlign = FontStashSharp.RichText.TextHorizontalAlignment.Center;
			label6.Height = 16;
			label6.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			label6.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetColumn(label6, 1);
			Grid.SetRow(label6, 1);

			var image11 = new Image();
			image11.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/leftstick.png");
			image11.Width = 48;
			image11.Height = 48;
			image11.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetRow(image11, 2);

			var label7 = new Label();
			label7.Text = "Move";
			label7.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft24.fnt");
			label7.TextAlign = FontStashSharp.RichText.TextHorizontalAlignment.Center;
			label7.Height = 16;
			label7.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			label7.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetColumn(label7, 1);
			Grid.SetRow(label7, 2);

			var image12 = new Image();
			image12.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/rightstick.png");
			image12.Width = 48;
			image12.Height = 48;
			image12.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetRow(image12, 3);

			var label8 = new Label();
			label8.Text = "Aim";
			label8.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft24.fnt");
			label8.TextAlign = FontStashSharp.RichText.TextHorizontalAlignment.Center;
			label8.Height = 16;
			label8.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			label8.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetColumn(label8, 1);
			Grid.SetRow(label8, 3);

			var image13 = new Image();
			image13.Renderable = MyraEnvironment.DefaultAssetManager.LoadTextureRegion("images/icons/righttrigger.png");
			image13.Width = 48;
			image13.Height = 48;
			image13.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetRow(image13, 4);

			var label9 = new Label();
			label9.Text = "Dash";
			label9.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft24.fnt");
			label9.TextAlign = FontStashSharp.RichText.TextHorizontalAlignment.Center;
			label9.Height = 16;
			label9.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			label9.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Center;
			Grid.SetColumn(label9, 1);
			Grid.SetRow(label9, 4);

			var grid2 = new Grid();
			grid2.ColumnSpacing = 8;
			grid2.DefaultColumnProportion = new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			};
			grid2.DefaultRowProportion = new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			};
			grid2.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Right;
			grid2.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;
			grid2.Margin = new Thickness(0, 0, 20, 10);
			grid2.Widgets.Add(image9);
			grid2.Widgets.Add(label5);
			grid2.Widgets.Add(image10);
			grid2.Widgets.Add(label6);
			grid2.Widgets.Add(image11);
			grid2.Widgets.Add(label7);
			grid2.Widgets.Add(image12);
			grid2.Widgets.Add(label8);
			grid2.Widgets.Add(image13);
			grid2.Widgets.Add(label9);

			levelLabel = new Label();
			levelLabel.Text = "Level 1";
			levelLabel.Font = MyraEnvironment.DefaultAssetManager.LoadFont("fonts/Minecraft32.fnt");
			levelLabel.Margin = new Thickness(20, 10, 10, 10);
			levelLabel.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;

			Widgets.Add(leftVerticalPanel);
			Widgets.Add(bulletsPanel);
			Widgets.Add(levelLabel);
			Widgets.Add(grid2);
		}
		// assets related
		private IImage heartImage;
		private IImage heartEmptyImage;
		private IImage dashImage;
		private SpriteFontBase labelFont24; 
		private IImage[] bulletImage = new IImage[4];

		private Grid buffGrid;
		private Grid healthGrid;
		private VerticalStackPanel bulletsPanel;
		private HorizontalStackPanel dashPanel;
		private Label bulletsLabel;
		private Label levelLabel;
		private Label attackLabel;
		private Label rangedLabel;
        private Label meleeDefLabel;
		private Label rangedDefLabel;
		private static Dictionary<string, IImage> buffIconMap = new();
	}
}
