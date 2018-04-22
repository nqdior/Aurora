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
    }
}
