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
            if (game.CheckPlayerInventory("Topur Obosieczny"))
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
            }
        }

        private void eqBox6_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Czerwona mikstura"))
            {
                
            }
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
    }
}
