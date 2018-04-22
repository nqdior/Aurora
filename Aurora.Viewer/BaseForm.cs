using System.Windows.Forms;

namespace Aurora.Viewer
{
    public partial class BaseForm : Form
    {

        public BaseForm() 
        {
            ControlBox = false;            
        }

        public void MoveForm(MouseEventArgs e) => FormManager.ConvertMessageMove(e, Handle);

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
