namespace DirtyTracker
{
    using System;
    using System.Windows.Forms;

    public class DirtyTracker
    {
        private Form frmTracker;
        private bool isDirty;

        public DirtyTracker(Form frm)
        {
            this.frmTracker = frm;
            this.AssignHandlesForControlCollection(frm.Controls);
        }

        public bool IsDirty
        {
            get { return this.isDirty; }
            private set { this.isDirty = value; }
        }

        public void SetAsDirty()
        {
            this.isDirty = true;
        }

        public void SetAsCllean()
        {
            this.isDirty = false;
        }

        private void DirtyTracker_TextChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        private void DirtyTracker_CheckedChanged(object sender, EventArgs e)
        {
            this.isDirty = true;
        }

        private void AssignHandlesForControlCollection(Control.ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                if (c is TextBox)
                {
                    (c as TextBox).TextChanged += new EventHandler(this.DirtyTracker_TextChanged);
                }

                if (c is CheckBox)
                {
                    (c as CheckBox).CheckedChanged += new EventHandler(this.DirtyTracker_CheckedChanged);
                }


                // ... apply for other desired input types similarly ...

                // recurively apply to inner collections
                if (c.HasChildren)
                {
                    this.AssignHandlesForControlCollection(c.Controls);
                }
            }
        }
    }
}