using OrderDetailsMaintenance.Models.DataLayer;
using System.Linq;

namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        // Dylan Bausch
        private void btnFind_Click(object sender, EventArgs e)
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                string customerId = txtCustomerId.Text.Trim();
                Customer? customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);

                if (customer != null)
                {
                    txtContact.Text = customer.ContactName;
                    txtAddress.Text = customer.Address;
                    txtCity.Text = customer.City;
                    txtCountry.Text = customer.Country;
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
        }

        // Dylan Bausch
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Dylan Bausch
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                string customerId = txtCustomerId.Text.Trim();
                Customer? customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);

                if (customer != null)
                {
                    customer.ContactName = txtContact.Text.Trim();
                    customer.Address = txtAddress.Text.Trim();
                    customer.City = txtCity.Text.Trim();
                    customer.Country = txtCountry.Text.Trim();

                    db.SaveChanges();
                    MessageBox.Show("Customer information updated successfully.");
                }
                else
                {
                    MessageBox.Show("Customer not found. Cannot save changes.");
                }
            }
        }
    }
}