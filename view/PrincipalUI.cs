using controle_contas_a_pagar_receber.view;
using System.Drawing;
using System.Windows.Forms;

namespace controle_contas_a_pagar_receber
{

  public partial class PrincipalUI : Form
  {
    private ClienteUI clienteUI;

    public PrincipalUI()
    {
      this.InitializeComponent();
    }

    private void menuItemContasReceberClientes_Click(object sender, System.EventArgs e)
    {

      if (this.clienteUI == null || this.clienteUI.IsDisposed) 
      {
        this.clienteUI = new ClienteUI();
        this.clienteUI.MdiParent = this;
      }

      this.clienteUI.Location = new Point(0, 0);
      this.clienteUI.BringToFront();
      this.clienteUI.Show();


    }

  }

}
