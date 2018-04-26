using System;
using System.Windows.Forms;

namespace Aurora.Viewer
{
    public sealed class AuroraToolStripComboBox : ToolStripComboBox
    {
        public AuroraToolStripComboBox()
        {
            SetObjectProperty();
        }

        public AuroraToolStripComboBox(Array items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
            SelectedIndex = 0;
            SetObjectProperty();
        }

        private void SetObjectProperty()
        {
            Font = new System.Drawing.Font("Consolas", 9);
            Alignment = ToolStripItemAlignment.Right;
            DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle = FlatStyle.Flat;
        }
    }
}
