using System;
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
            UpdadeCharackters();
        }

        private void UpdadeCharackters()
        {
            throw new NotImplementedException();
        }

        private void eqBox1_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Miecz"))
            {
                game.Equip("Miecz");
                RemoveInventorySpriteBorders();
            }
            eqBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void eqBox2_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Łuk"))
            {
                game.Equip("Łuk");
                RemoveInventorySpriteBorders();
            }
            eqBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void eqBox3_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Buława"))
            {
                game.Equip("Buława");
                RemoveInventorySpriteBorders();
            }
            eqBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void eqBox4_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Topór Obosieczny"))
            {
                game.Equip("Topur Obosieczny");
                RemoveInventorySpriteBorders();
            }
            eqBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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

        private void RemoveInventorySpriteBorders()
        {
            eqBox1.BorderStyle = BorderStyle.None;
            eqBox2.BorderStyle = BorderStyle.None;
            eqBox3.BorderStyle = BorderStyle.None;
            eqBox4.BorderStyle = BorderStyle.None;
            eqBox5.BorderStyle = BorderStyle.None;
            eqBox6.BorderStyle = BorderStyle.None;
        }

        public void UpdateCharacters()
        {
            playerBox.Location = game.playerLocation;
            playerHitPoints.Text = game.playerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            if (batBox.Visible == true)
            {
                showBat = true;
            }
            if (ghostBox.Visible)
            {
                showGhost = true;
            }
            if (ghoulBox.Visible == true)
            {
                showGhoul = true;
            }

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
                    ghostBox.Location = enemy.Location;
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
            }

            if (showBat == false)
            {
                batBox.Visible = false;
                label1.Text = "";
            }
            if (showGhost == false)
            {
                ghostBox.Visible = false;
                label3.Text = "";
            }
            if (showGhoul == false)
            {
                ghoulBox.Visible = false;
                label2.Text = "";
            }

            swordBox.Visible = false;
            axeBox.Visible = false;
            redPotionBox.Visible = false;
            bluePotionBox.Visible = false;
            maceBox.Visible = false;
            bowBox.Visible = false;

            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Miecz":
                    weaponControl = swordBox;
                    break;

                case "Buława":
                    weaponControl = maceBox;
                    break;

                case "Topór Obosieczny":
                    weaponControl = axeBox;
                    break;

                case "Łuk":
                    weaponControl = bowBox;
                    break;

                default:
                    break;
            }
            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
            {
                weaponControl.Visible = false;
            }
            else
            {
                weaponControl.Visible = true;
            }

            eqBox1.Visible = false;
            eqBox2.Visible = false;
            eqBox3.Visible = false;
            eqBox4.Visible = false;
            eqBox5.Visible = false;
            eqBox6.Visible = false;

            if (game.CheckPlayerInventory("Miecz"))
            {
                eqBox1.Visible = true;
            }
            if (game.CheckPlayerInventory("Topór obosieczny"))
            {
                eqBox3.Visible = true;
            }
            if (game.CheckPlayerInventory("Łuk"))
            {
                eqBox2.Visible = true;
            }
            if (game.CheckPlayerInventory("Buława"))
            {
                eqBox4.Visible = true;
            }
            if (game.CheckPlayerInventory("Czerwona mikstura"))
            {
                if (!game.Potion("Czerwona mikstura"))
                {
                    eqBox6.Visible = true;
                }
            }
            if (game.CheckPlayerInventory("Niebieska mikstura"))
            {
                if (game.Potion("Niebieska mikstura"))
                {
                    eqBox5.Visible = true;
                }
            }

            if (game.playerHitPoints <= 0)
            {
                dieBox.Visible = true;
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                victoryBox.Visible = true;
                game.NewLevel(random);
                UpdadeCharackters();
            }
        }
    }
}
