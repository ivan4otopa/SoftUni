using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Customer.Enumerations;

namespace Customer.Classes
{
    class Customer : ICloneable, IComparable<Customer>
    {
        public Customer(string firstName, string middleName, string lastName, int iD, string permanentAddress, string mobilePhone,
            string email, IList<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = iD;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public string PermanentAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public IList<Payment> Payments { get; set; }
        public CustomerType CustomerType { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Customer c = (Customer)obj;
            bool isEqual = FirstName == c.FirstName && MiddleName == c.MiddleName && LastName == c.LastName && ID == c.ID &&
                PermanentAddress == c.PermanentAddress && MobilePhone == c.MobilePhone && Email == c.Email && Payments == c.Payments &&
                CustomerType == c.CustomerType;

            return isEqual;
        }

        public override string ToString()
        {
            return String.Format("First Name: {0}; Middle Name: {1}; Last Name: {2}; ID: {3}; Permanent Address: {4}; Mobile Phone: {5}; " +
                "Email: {6}; Payments:\n{7}\nCustomer Type: {8};", this.FirstName, this.MiddleName, this.LastName, this.ID,
                this.PermanentAddress, this.MobilePhone, this.Email, string.Join("\n", this.Payments.Select(p => p.ToString()).ToArray()),
                this.CustomerType);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ MiddleName.GetHashCode() ^ LastName.GetHashCode() ^ ID.GetHashCode() ^
                PermanentAddress.GetHashCode() ^ MobilePhone.GetHashCode() ^ Email.GetHashCode() ^ Payments.GetHashCode() ^
                CustomerType.GetHashCode();
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            bool isEqual = Equals(c1, c2);

            return isEqual;
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            bool isNotEqual = !Equals(c1, c2);

            return isNotEqual;
        }

        public object Clone()
        {
            Customer clone = new Customer(this.FirstName, this.MiddleName, this.LastName, this.ID, this.PermanentAddress,
                this.MobilePhone, this.Email, this.Payments, this.CustomerType);

            return clone;
        }

        public int CompareTo(Customer c)
        {
            string thisFullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string comparatorFullName = c.FirstName + " " + c.MiddleName + " " + c.LastName;

            if (thisFullName.CompareTo(comparatorFullName) == 0)
            {
                return this.ID.CompareTo(c.ID);
            }

            return thisFullName.CompareTo(comparatorFullName);
        }
    }
}
