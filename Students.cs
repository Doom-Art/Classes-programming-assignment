﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_programming_assignment
{
    internal class Students
    {
        private static Random rand = new Random();
        private string _firstName;
        private string _lastName;
        private int _studentNumber;
        private string _email;
        public Students(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._studentNumber = (rand.Next(0, 1000))+555000;
            GenerateEmail();
        }
        private void GenerateEmail(){
            this._email = "";
            if (_firstName.Length < 3)
                this._email += _firstName;
            else
                this._email += _firstName.Substring(0, 3);
            this._email +=  _lastName.Substring(0, 3) + Convert.ToString(_studentNumber).Substring(3, 3) + "@ICS4U.com";
        }
        public void ResetStudentNumber()
        {
            this._studentNumber = (rand.Next(0, 1000)) + 555000;
            GenerateEmail();
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                this._firstName = value;
                GenerateEmail();
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                this._lastName = value;
                GenerateEmail() ;
            }
        }
        public int StudentNumber
        {
            get
            {
                return _studentNumber;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
        }
        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
    }
    
}