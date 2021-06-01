using System;
using System.IO;
using System.Windows.Forms;

namespace FlightSim
{
    public partial class View_Simulation : Form
    {
        //Data members
        private Controller_Simulation _controllerSimulation; //The controller of the simulation
        
        //Constructor
        /*
         * Creates the view of the simulator
         */
        public View_Simulation(Controller_Simulation controllerSimulation)
        {
            _controllerSimulation = controllerSimulation;
            InitializeComponent();
        }

        //Functions
        /*
         * Calls the method to decrement the speed of the simulator
         */
        private void btnDecrementSpeed_Click(object sender, EventArgs e)
        {
            _controllerSimulation.DecrementSecondsPerTick();
        }

        /*
         * Calls the method to increment the speed of the simulator
         */
        private void btnIncrementSpeed_Click(object sender, EventArgs e)
        {
            _controllerSimulation.IncrementSecondsPerTick();
        }

        /*
         * Calls the method to load the XML file specified in the textBox
         */
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbxXmlFile.Text))
            {
                _controllerSimulation.LoadXml(tbxXmlFile.Text);
                btnIncrementSpeed.Enabled = true;
                btnDecrementSpeed.Enabled = true;
            }
            else
                MessageBox.Show("Ce fichier xml n'existe pas :(", "Fichier non trouvé", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}