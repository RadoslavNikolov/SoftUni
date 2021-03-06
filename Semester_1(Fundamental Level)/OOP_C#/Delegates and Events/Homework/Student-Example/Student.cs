﻿namespace Student_Example
{
    using System;

    public delegate void ChangePropertyEventHandler(object sender, PropertyChangedEventArgs e);

    public class Student
    {
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.PropertyChanged += this.GetMessage;
        }

        public event ChangePropertyEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name should not to be null or empty string.");
                }

                var ev = new PropertyChangedEventArgs { OldName = this.name, Name = value, ChangedProperty = "Name" };
                this.name = value;
                this.OnChanged(this, ev);
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age should be positive.");
                }

                var ev = new PropertyChangedEventArgs {OldAge = this.age, Age = value, ChangedProperty = "Age"};
                this.age = value;
                this.OnChanged(this, ev);
            }
        }

        private void OnChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(sender, e);
            }
        }

        private void GetMessage(object sender, PropertyChangedEventArgs e)
        {
            switch (e.ChangedProperty)
            {
                case "Name":
                    Console.WriteLine("Property changed: Name (from {1} to {0}).", e.Name, e.OldName);
                    break;
                case "Age":
                    Console.WriteLine("Property changed: Age (from {1} to {0}).", e.Age, e.OldAge);
                    break;
            }
        }

    }
}