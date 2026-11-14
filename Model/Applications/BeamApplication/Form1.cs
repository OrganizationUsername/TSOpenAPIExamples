using System;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace BeamApplication;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var myModel = new Model();

        var myBeam = new Beam(new Point(1000, 1000, 1000), new Point(6000, 6000, 10000));
        myBeam.Material.MaterialString = "S235JR";
        myBeam.Profile.ProfileString = "W24X62";
        var inserted = myBeam.Insert();
        myModel.CommitChanges();
    }
}