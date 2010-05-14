using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GradersAssistant
{
    public partial class CreateAssignmentForm : Form
    {
        public CreateAssignmentForm()
        {
            InitializeComponent();
        }

        public string d_date
        {
            get { return d_date_box.ToString(); }
        }
        
        public string a_name
        {
            get { return a_name_textbox.Text; }
        }
    }
}
