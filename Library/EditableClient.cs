using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Annotations;

namespace Library
{
    public class EditableClient : INotifyPropertyChanged
    {
        public int ClientId { get; set; }

        private string _firstName;
        [Required]
        [StringLength(25)]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    if (this != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                    }
                }
            }
        }

        private string _lastName;
        [Required]
        [StringLength(25)]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
                }
            }
        }

        private string _pesel;
        [Required]
        [StringLength(11)]
        public string Pesel
        {
            get { return _pesel; }
            set
            {
                if (_pesel != value)
                {
                    _pesel = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Pesel"));
                }
            }
        }

        private string _sex;
        [Required]
        [StringLength(1)]
        public string Sex
        {
            get { return _sex; }
            set
            {
                if (_sex != value)
                {
                    _sex = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Sex"));
                }
            }
        }

        private string _city;

        [Required]
        [StringLength(30)]
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("City"));
                }
            }
        }

        private string _phoneNumber;
        [Required]
        [StringLength(12)]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PhoneNumber"));
                }
            }
        }

        private string _email;
        [Required]
        [StringLength(30)]
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
