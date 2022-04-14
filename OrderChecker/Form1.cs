namespace OrderChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BrezePreisLabel.Text = "3.90 €";
            BaguettePreisLabel.Text = "2.90 €";
            AmperlaiberlPreisLabel.Text = "9.00 €";
            pdaPreisLabel.Text = "7.50 €";

            comboBox1.SelectedItem = "1";
            comboBox2.SelectedItem = "1";
            comboBox3.SelectedItem = "1";
            comboBox4.SelectedItem = "1";
        }

        int brezenAnzahlBestellung = 0;
        int baguetteAnzahlBestellung = 0;
        int amperlaiberlAnzahlBestellung = 0;
        int pdaAnzahlBestellung = 0;

        DateTime abholDatum = new DateTime();

        float brezenPreis = 3.90f;
        float baguettePreis = 2.90f;
        float amperlaiberlPreis = 9.00f;
        float pdaPreis = 7.50f;

        float gesamtPreis = 0.00f;
        Boolean valide = false;

        private void button1_Click(object sender, EventArgs e)
        {
            int brezenAnzahl = int.Parse(comboBox1.SelectedItem.ToString());

            
            brezenAnzahlBestellung = brezenAnzahlBestellung + brezenAnzahl;
            renewBestellText();
            calcTotalPrice();
            textBox5.Text = MyOwnRound(gesamtPreis);
            textBox5.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int baguetteAnzahl = int.Parse(comboBox2.SelectedItem.ToString());
            baguetteAnzahlBestellung = baguetteAnzahl + baguetteAnzahlBestellung;
            
            renewBestellText();
            
            calcTotalPrice();
            textBox5.Text = MyOwnRound(gesamtPreis);
            textBox5.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int amperlaiberlAnzahl = int.Parse(comboBox3.SelectedItem.ToString());
            amperlaiberlAnzahlBestellung = amperlaiberlAnzahl + amperlaiberlAnzahlBestellung;
            renewBestellText();
            calcTotalPrice();
            textBox5.Text = MyOwnRound(gesamtPreis);
            textBox5.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void allesweg_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            brezenAnzahlBestellung = 0;
            baguetteAnzahlBestellung = 0;
            amperlaiberlAnzahlBestellung = 0;
            pdaAnzahlBestellung = 0;

            calcTotalPrice();
            textBox5.Text = gesamtPreis.ToString();
            textBox5.Refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int pdaAnzahl = int.Parse(comboBox4.SelectedItem.ToString());
            richTextBox1.Text = richTextBox1.Text + pdaAnzahl + " Pain des Ami     ";
            pdaAnzahlBestellung = pdaAnzahlBestellung + pdaAnzahl;
            calcTotalPrice();
            textBox5.Text = MyOwnRound(gesamtPreis);
            textBox5.Refresh();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            textBox5.Text = MyOwnRound(gesamtPreis);
        }

        private void calcTotalPrice() 
        {
            gesamtPreis = brezenAnzahlBestellung * brezenPreis + baguetteAnzahlBestellung * baguettePreis + amperlaiberlAnzahlBestellung * amperlaiberlPreis + pdaAnzahlBestellung * pdaPreis;
            Math.Round(gesamtPreis, 2);
            bestellStatusChecken();

            updateDate();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void bestellStatusChecken()
        {
            if (baguetteAnzahlBestellung==8) valide = true;
            else valide = false;
            valideDate();


            if (valide) textBox6.Text = "gültig";
            else textBox6.Text  = "nicht gültig";

            if (valide) textBox6.BackColor = Color.Green;
            else textBox6.BackColor = Color.Red;    
            textBox6.Refresh();
        }

        public void renewBestellText() {
            String x = "";
            if (brezenAnzahlBestellung != 0) x = x + brezenAnzahlBestellung.ToString() + " Brezen" + System.Environment.NewLine;
            if (baguetteAnzahlBestellung != 0) x = x + baguetteAnzahlBestellung.ToString() + " Baguette" + System.Environment.NewLine;
            if (amperlaiberlAnzahlBestellung != 0) x = x + amperlaiberlAnzahlBestellung.ToString() + " Amperlaiberl" + System.Environment.NewLine;
            if (pdaAnzahlBestellung != 0) x = x+ pdaAnzahlBestellung.ToString() + " Pain des Amis";
            

            richTextBox1.Text = x;
            richTextBox1.Refresh();


        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            updateDate();
;        }

        private void updateDate() {
            String s = (abholDatumKalender.SelectionStart.ToShortDateString());
            abholDatum = abholDatumKalender.SelectionStart;
            bestellStatusChecken();
            abholDatumTextBox.Text = "Abholdatum: "+ s;
            abholDatumTextBox.Refresh();

        }

        private void valideDate() {
            if (abholDatum < (DateTime.Now).AddDays(2)) valide = false;
        }

        private void BrezePreisLabel_Click(object sender, EventArgs e)
        {

        }

        private void BaguettePreisLabel_Click(object sender, EventArgs e)
        {

        }

        private void abholDatumKalender_DateChanged(object sender, DateRangeEventArgs e)
        {
            updateDate();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private String MyOwnRound(float a) {
        String s = a.ToString();
            int lenght = s.Length;
            if (lenght == 4 && a >= 10) s = s + "0";
            else if (lenght == 1) s = s + ",00";
            else if (lenght == 2) s = s + ",00";
            else if (lenght == 3 && a<100) s = s + "0";
            else if (lenght >= 5 && a < 100) s = s.Substring(0, 5);
            else if (lenght == 5 && a > 100) s = s + "0";
            else if (lenght >= 6 && a < 1000 && a >= 100) s = s.Substring(0, 6);

            s = s + "€";

            return s;
        }
    }
}