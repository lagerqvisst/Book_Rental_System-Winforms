using Models;
using ServiceLayer;

namespace WinFormGUI
{
    public partial class Form1 : Form
    {
        Servicelayer servicelayer = new Servicelayer();
        public Form1()
        {
            InitializeComponent();
            servicelayer.Seed();
            FyllT�gstation();


        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FyllT�gstation()
        {
            foreach (var station in servicelayer.database.t�gstationer)
            {
                t�gstationList.Items.Add(station.stad);
            }
        }

        private void t�gstationList_SelectedIndexChanged(object sender, EventArgs e)
        {
   
            T�gstation station = servicelayer.GetT�gstation(t�gstationList.SelectedItem as string); 
           
            bokmaskinerList.Items.Clear();
    
            foreach (Bokmaskin bokmaskin in station.Bokmaskiner)
            {
                        
                bokmaskinerList.Items.Add(bokmaskin.maskinID);
            }
                 
        }

        private void bokmaskinerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maskinID = bokmaskinerList.SelectedIndex;

            Bokmaskin maskin = servicelayer.GetBokmaskin(maskinID);

            boksaldoLabel.Text = $"Antal b�cker: {servicelayer.VisaBokSaldo(maskin)}";
            
        }
    }
}
