using System;
using System.Runtime.Serialization;

namespace covid_takip
{
    internal class Patient
    {
        private string name;
        private string tc;
        private string phone;
        private string age;
        private string gender;
        private string date;
        private string symptoms;

        public Patient(string name, string tc, string phone, string age, string gender, string date, string symptoms)
        {
            this.name = name;
            this.tc = tc;
            this.phone = phone;
            this.age = age;
            this.gender = gender;
            this.date = date;
            this.symptoms = symptoms;
        }

        internal SerializationInfo GetDisplayData()
        {
            throw new NotImplementedException();
        }
    }
}