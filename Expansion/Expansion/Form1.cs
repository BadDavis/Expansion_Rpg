﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expansion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game;
        private Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155)); //dostosować
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void eqBox1_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Długi miecz"))
            {
                game.Equip("Długi miecz");
                
            }
            eqBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void eqBox2_Click(object sender, EventArgs e)
        {
              if (game.CheckPlayerInventory("Łuk"))
               {
                   game.Equip("Łuk");
                   
               }
               eqBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           /* SelectInventoryItem(bowBox, "Łuk", "weapon");*/
        }

        private void eqBox3_Click(object sender, EventArgs e)
        {
             if (game.CheckPlayerInventory("Buława"))
             {
                 game.Equip("Buława");
                 
             }
             eqBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            /* SelectInventoryItem(swordBox, "Długi miecz", "weapon");
         
            SelectInventoryItem(bowBox, "Łuk", "weapon");*/
        }

        private void eqBox4_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Topór Obosieczny"))
             {
                 game.Equip("Topur Obosieczny");
                 /*RemoveInventorySpriteBorders();*/
             }
             eqBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           /* SelectInventoryItem(axeBox, "Topór Obosieczny", "weapon");*/
        }

        private void eqBox5_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Niebieska mikstura"))
            {
                game.Equip("Niebieska mikstura");
            }
            eqBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        }

        private void eqBox6_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Czerwona mikstura"))
            {
                game.Equip("Czerwona mikstura");
            }
            eqBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        public void UpdateCharacters()
        {
            //dieBox.Visible = false;
           // victoryBox.Visible = false;
            playerBox.Visible = true;
            playerBox.Location = game.playerLocation;
            playerHitPoints.Text = game.playerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            bool showWizard = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    batBox.Location = enemy.Location;
                    label1.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghost)
                {
                    batBox.Location = enemy.Location;
                    label2.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghoul)
                {
                    ghoulBox.Location = enemy.Location;
                    label3.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }

                if (showBat)
                {
                    batBox.Visible = true;
                }
                else batBox.Visible = false;

                if (showGhost)
                {
                    ghostBox.Visible = true;
                }
                else ghostBox.Visible = false;

                if (showGhoul)
                {
                    ghoulBox.Visible = true;
                }
                else ghoulBox.Visible = false;



                swordBox.Visible = false;
                maceBox.Visible = false;
                axeBox.Visible = false;
                bowBox.Visible = false;
                redPotionBox.Visible = false;
                bluePotionBox.Visible = false;

                

                if (game.WeaponInRoom.Name != null)
                {
                    Control weaponControl = null;
                    switch (game.WeaponInRoom.Name)
                    {
                        case "Długi miecz":
                            weaponControl = swordBox;
                            break;

                        case "Buława":
                            weaponControl = maceBox;
                            break;

                        case "Łuk":
                            weaponControl = bowBox;
                            break;

                        case "Topór Obosieczny":
                            weaponControl = axeBox;
                            break;

                        case "Czerwona mikstura":
                            weaponControl = redPotionBox;
                            break;

                        case "Niebieska mikstura":
                            weaponControl = bluePotionBox;
                            break;

                        default:
                            break;
                    }

                    if (game.WeaponInRoom.PickedUp)
                    {
                        weaponControl.Visible = false;
                    }
                    else
                    {
                        weaponControl.Visible = true;
                        weaponControl.Location = game.WeaponInRoom.Location;
                    }
                }

                eqBox1.Visible = false;
                eqBox2.Visible = false;
                eqBox3.Visible = false;
                eqBox4.Visible = false;
                eqBox5.Visible = false;
                eqBox6.Visible = false;

                if (game.CheckPlayerInventory("Długi miecz"))
                {
                    eqBox1.Visible = true;
                }
                if (game.CheckPlayerInventory("Łuk"))
                {
                    eqBox2.Visible = true;
                }
                if (game.CheckPlayerInventory("Buława"))
                {
                    eqBox3.Visible = true;
                }
                if (game.CheckPlayerInventory("Topór Obosieczny"))
                {
                    eqBox4.Visible = true;
                }
                if (game.CheckPlayerInventory("Czerwona mikstura"))
                {
                    eqBox6.Visible = true;
                }
                if (game.CheckPlayerInventory("Niebieska mikstura"))
                {
                    eqBox5.Visible = true;
                }

                /*weaponControl.Location = game.WeaponInRoom.Location;
                if (game.WeaponInRoom.PickedUp)
                {
                    weaponControl.Visible = true;
                }
                else
                {
                    weaponControl.Visible = false;
                }*/

                if (game.playerHitPoints <= 0)
                {
                    dieBox.Visible = true;
                    Application.Exit();
                }

                if (enemiesShown < 1)
                {
                    victoryBox.Visible = true;
                    game.NewLevel(random);
                    UpdateCharacters();
                }
            }
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void moveLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void moveRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void attackUp_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void attackDown_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void attackLeft_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void attackRight_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }
      }

}

